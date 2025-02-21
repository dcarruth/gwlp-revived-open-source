﻿using System;
using System.Linq;
using GameServer.Enums;
using GameServer.Interfaces;
using GameServer.Packets.ToClient;
using GameServer.ServerData;
using ServerEngine;
using ServerEngine.GuildWars.DataWrappers.Clients;
using ServerEngine.NetworkManagement;

namespace GameServer.Actions
{
        public class SpawnPlayer : IAction
        {
                private readonly CharID newCharID;

                public SpawnPlayer(CharID charID)
                {
                        newCharID = charID;
                }

                public void Execute(DataMap map)
                {
                        // spawn this player for himself
                        CreateSpawnPacketsFor(newCharID, newCharID);

                        var chara = map.Get<DataCharacter>(newCharID);

                        // Note: FADE INTO MAP
                        var fadeIntoMap = new NetworkMessage(chara.Data.NetID)
                        {
                                PacketTemplate = new P023_InstanceLoadFadeIntoMap.PacketSt23
                                {
                                        AgentID = (ushort)chara.Data.AgentID.Value,
                                        Data2 = 3
                                }
                        };
                        QueuingService.PostProcessingQueue.Enqueue(fadeIntoMap);
                        

                        // spawn him for others & spawn others for him
                        // the following linq expression returns an IEnumerable<CharID> of all characters on that map
                        foreach (var charID in map.GetAll<DataCharacter>()
                                .Where(x => (x.Data.CharID != chara.Data.CharID))
                                .Select(x => x.Data.CharID))
                        {
                                CreateSpawnPacketsFor(newCharID, charID);
                                CreateSpawnPacketsFor(charID, newCharID);
                        }

                        // update his status to playing
                        chara.Data.Player = PlayStatus.ReadyToPlay;

                        // spawn NPC's
                        // the following linq expression returns an IEnumerable<CharID> of all characters on that map
                        foreach (var npc in map.GetAll<DataNpc>())
                        {
                                // Note: NPC GENERAL STATS
                                var npcStats = new NetworkMessage(chara.Data.NetID)
                                {
                                        PacketTemplate = new P074_NpcGeneralStats.PacketSt74
                                        {
                                                NpcID = npc.Data.LocalID.Value,
                                                FileID = (uint)npc.Data.NpcFileID,
                                                Data1 = 0,
                                                Scale = (uint)(npc.Data.Scale << 24),
                                                Data2 = 0,
                                                ProfessionFlags = (uint)npc.Data.NpcFlags, //| (0x00 << 8),
                                                Profession = npc.Data.ProfessionPrimary,
                                                Level = (byte)npc.Data.Level,
                                                ArraySize1 = (ushort)(npc.Data.Appearance.Length / 2),
                                                Appearance = npc.Data.Appearance
                                        }
                                };
                                QueuingService.PostProcessingQueue.Enqueue(npcStats);

                                // Note: NPC MODEL
                                var npcModel = new NetworkMessage(chara.Data.NetID)
                                {
                                        PacketTemplate = new P075_NpcModel.PacketSt75
                                        {
                                                NpcID = npc.Data.LocalID.Value,
                                                ArraySize1 = (ushort)(npc.Data.ModelHash.Length / 4),
                                                ModelHash = npc.Data.ModelHash
                                        }
                                };
                                QueuingService.PostProcessingQueue.Enqueue(npcModel);

                                // Change the name if necessary
                                if (npc.Data.Name.Value != "")
                                {
                                        // Note: NPC NAME
                                        var npcName = new NetworkMessage(chara.Data.NetID)
                                        {
                                                PacketTemplate = new P143_NpcName.PacketSt143
                                                {
                                                        AgentID = npc.Data.AgentID.Value,
                                                        Name = npc.Data.Name.Value
                                                }
                                        };
                                        QueuingService.PostProcessingQueue.Enqueue(npcName);
                                }

                                // Note: UPDATE AGENT MAIN STATS
                                var charMain = new NetworkMessage(chara.Data.NetID)
                                {
                                        PacketTemplate = new P021_SpawnObject.PacketSt21
                                        {
                                                AgentID = npc.Data.AgentID.Value,
                                                Data1 = (0x20 << 24) | npc.Data.LocalID.Value, // was assumed to be LocalID
                                                Data2 = 1,
                                                Data3 = 9,
                                                PosX = npc.Data.Position.X,
                                                PosY = npc.Data.Position.Y,
                                                Plane = (ushort)npc.Data.Position.PlaneZ,
                                                Data4 = float.PositiveInfinity,
                                                Rotation = npc.Data.Rotation,
                                                Data5 = 1,
                                                Speed = npc.Data.Speed,
                                                Data12 = 1F,
                                                Data13 = 0x41400000,
                                                //Data14 = 1886151033,
                                                Data14 = 1852796515,
                                                Data15 = 0,
                                                Data16 = 0,
                                                Data17 = 0,
                                                Data18 = 0,
                                                Data19 = 0,
                                                Data20 = 0,
                                                Data21 = 0,
                                                Data22 = float.PositiveInfinity,
                                                Data23 = float.PositiveInfinity,
                                                Data24 = 0,
                                                Data25 = 0,
                                                Data26 = float.PositiveInfinity,
                                                Data27 = float.PositiveInfinity,
                                                Data28 = 0
                                        }
                                };
                                QueuingService.PostProcessingQueue.Enqueue(charMain);
                        }

                        // show equipment
                        chara.Data.Items.SendEquipment(chara.Data.NetID, chara.Data.AgentID);

                        // partywindow test
                        var teamWindow1 = new NetworkMessage(chara.Data.NetID)
                        {
                            PacketTemplate = new Packet165.PacketSt165
                            {
                                Data1 = (ushort)chara.Data.LocalID.Value,
                                Data2 = (ushort)chara.Data.LocalID.Value
                            }
                        };
                        QueuingService.PostProcessingQueue.Enqueue(teamWindow1);

                        var teamWindow2 = new NetworkMessage(chara.Data.NetID)
                        {
                            PacketTemplate = new Packet451.PacketSt451
                            {
                                Data1 = (ushort)chara.Data.LocalID.Value
                            }
                        };
                        QueuingService.PostProcessingQueue.Enqueue(teamWindow2);

                        var teamWindow3 = new NetworkMessage(chara.Data.NetID)
                        {
                            PacketTemplate = new Packet444.PacketSt444
                            {
                                Data1 = (ushort)chara.Data.LocalID.Value,
                                Data2 = (ushort)chara.Data.LocalID.Value,
                                Data3 = 1
                            }
                        };
                        QueuingService.PostProcessingQueue.Enqueue(teamWindow3);

                        var teamWindow4 = new NetworkMessage(chara.Data.NetID)
                        {
                            PacketTemplate = new Packet452.PacketSt452
                            {
                                Data1 = (ushort)chara.Data.LocalID.Value
                            }
                        };
                        QueuingService.PostProcessingQueue.Enqueue(teamWindow4);

                        var teamWindow5 = new NetworkMessage(chara.Data.NetID)
                        {
                            PacketTemplate = new Packet419.PacketSt419
                            {
                                Data1 = (ushort)chara.Data.LocalID.Value,
                                Data2 = 1
                            }
                        };
                        QueuingService.PostProcessingQueue.Enqueue(teamWindow5);

                        var teamWindow6 = new NetworkMessage(chara.Data.NetID)
                        {
                            PacketTemplate = new Packet463.PacketSt463
                            {
                                Data1 = 0
                            }
                        };
                        QueuingService.PostProcessingQueue.Enqueue(teamWindow6);

                        // send the message of the day ;)
                        // get some info to display (srvInfo is of type string[] btw)
                        var srvInfo = GameServerWorld.Instance.MessageOfTheDay;

                        // iterate trough the lines, show each line as one chat message (with orange color)
                        foreach (var info in srvInfo)
                        {
                                // Note: CHAT MESSAGE
                                var chatMsg = new NetworkMessage(chara.Data.NetID)
                                {
                                        PacketTemplate = new P081_GeneralChatMessage.PacketSt81
                                        {
                                                Message = "Ĉć" +
                                                        info +
                                                        BitConverter.ToChar(new byte[] { 0x01, 0x00 }, 0)
                                        }
                                };
                                QueuingService.PostProcessingQueue.Enqueue(chatMsg);

                                // Note: CHAT MESSAGE NO OWNER
                                var chatOwner = new NetworkMessage(chara.Data.NetID)
                                {
                                        PacketTemplate = new P082_GeneralChatNoOwner.PacketSt82
                                        {
                                                Data1 = 0,
                                                Data2 = (byte)ChatColors.DarkOrange_DarkOrange
                                        }
                                };
                                QueuingService.PostProcessingQueue.Enqueue(chatOwner);
                        }

                        // update client status
                        GameServerWorld.Instance.Get<DataClient>(newCharID).Data.Status = SyncStatus.Playing;
                }

                private static void CreateSpawnPacketsFor(CharID senderCharID, CharID recipientCharID)
                {
                        var chara = GameServerWorld.Instance.Get<DataClient>(senderCharID).Character;

                        // get the recipient of all those packets
                        var reNetID = recipientCharID.Value != senderCharID.Value ?
                                GameServerWorld.Instance.Get<DataClient>(recipientCharID).Data.NetID :
                                chara.Data.NetID;

                        // Note: UPDATE AGENT APPEARANCE
                        var charAppear = new NetworkMessage(reNetID)
                        {
                                PacketTemplate = new P077_UpdateAgentAppearance.PacketSt77
                                {
                                        Data1 = chara.Data.LocalID.Value,
                                        ID1 = chara.Data.AgentID.Value,
                                        Appearance = chara.Data.Appearance,
                                        Data2 = 0,
                                        Data3 = 0,
                                        Data4 = 0x3CBFA094,
                                        Name = chara.Data.Name.Value
                                }
                        };
                        QueuingService.PostProcessingQueue.Enqueue(charAppear);

                        // Note: UPDATE AGENT MAIN STATS
                        var charMain = new NetworkMessage(reNetID)
                        {
                                PacketTemplate = new P021_SpawnObject.PacketSt21
                                {
                                        AgentID = chara.Data.AgentID.Value,
                                        Data1 = (0x30 << 24) |  chara.Data.LocalID.Value, // was assumed to be LocalID
                                        Data2 = 1,
                                        Data3 = 5,
                                        PosX = chara.Data.Position.X,
                                        PosY = chara.Data.Position.Y,
                                        Plane = (ushort)chara.Data.Position.PlaneZ,
                                        Data4 = float.PositiveInfinity,
                                        Rotation = chara.Data.Rotation,
                                        Data5 = 1,
                                        Speed = chara.Data.Speed,
                                        Data12 = float.PositiveInfinity,
                                        Data13 = 0x41400000,
                                        Data14 = 1886151033,
                                        Data15 = 0,
                                        Data16 = 0,
                                        Data17 = 0,
                                        Data18 = 0,
                                        Data19 = 0,
                                        Data20 = 0,
                                        Data21 = 0,
                                        Data22 = float.PositiveInfinity,
                                        Data23 = float.PositiveInfinity,
                                        Data24 = 0,
                                        Data25 = 0,
                                        Data26 = float.PositiveInfinity,
                                        Data27 = float.PositiveInfinity,
                                        Data28 = 0
                                }
                        };
                        QueuingService.PostProcessingQueue.Enqueue(charMain);

                        // Note: Bugfix. Without it the display of armor may bug.
                        var map = GameServerWorld.Instance.Get<DataMap>(chara.Data.MapID);
                        for (var equipmentSlot = AgentEquipment.Leadhand; equipmentSlot <= AgentEquipment.CostumeHead; equipmentSlot++)
                        {
                                if (!chara.Data.Items.Equipment.ContainsKey(equipmentSlot)) continue;

                                map.Data.ActionQueue.Enqueue(
                                new SendToAllClients(
                                        new P099_UpdateAgentEquipment.PacketSt99
                                        {
                                                AgentID = chara.Data.AgentID.Value,
                                                EquipmentSlot = (uint)equipmentSlot,
                                                ItemLocalID = (uint)chara.Data.Items.Equipment[equipmentSlot].Data.ItemLocalID
                                        }
                                ).Execute);
                        }

                        // Note: UPDATE AGENT MORALE
                        var charMorale = new NetworkMessage(reNetID)
                        {
                                PacketTemplate = new P144_UpdateMorale.PacketSt144
                                {
                                        ID1 = chara.Data.AgentID.Value,
                                        Morale = chara.Data.Morale
                                }
                        };
                        QueuingService.PostProcessingQueue.Enqueue(charMorale);

                        // Note: UPDATE PUBLIC PROFESSIONS
                        var charProf = new NetworkMessage(reNetID)
                        {
                                PacketTemplate = new P154_UpdatePublicProfessions.PacketSt154
                                {
                                        ID1 = chara.Data.AgentID.Value,
                                        Prof1 = chara.Data.ProfessionPrimary,
                                        Prof2 = chara.Data.ProfessionSecondary
                                }
                        };
                        QueuingService.PostProcessingQueue.Enqueue(charProf);

                        //// Note: UPDATE GENERICVALUE PUBLIC LEVEL
                        //var charLvl = new NetworkMessage(reNetID)
                        //{
                        //        PacketTemplate = new P147_UpdateGenericValueInt.PacketSt147
                        //        {
                        //                ID1 = chara.Data.AgentID.Value,
                        //                ValueID = (int)GenericValues.PublicLvl,
                        //                Value = (ushort)chara.Data.Level
                        //        }
                        //};
                        //QueuingService.PostProcessingQueue.Enqueue(charLvl);

                        // Note: UPDATE VITAL STATS
                        var charVital = new NetworkMessage(reNetID)
                        {
                                PacketTemplate = new P228_UpdateVitalStats.PacketSt228
                                {
                                        ID1 = chara.Data.AgentID.Value,
                                        VitalFlagsBitfield = (uint)chara.Data.VitalStatus
                                }
                        };
                        QueuingService.PostProcessingQueue.Enqueue(charVital);
                        
                }
        }
}
