using System;
using System.IO;
using GameServer.Actions;
using GameServer.Enums;
using GameServer.Packets.ToClient;
using GameServer.ServerData;
using ServerEngine.ProcessorQueues;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 137)]
        public class P137_InstanceLoadRequestPlayerData : IPacket
        {
                public class PacketSt137 : IPacketTemplate
                {
                        public UInt16 Header { get { return 137; } }
                        [PacketFieldType(ConstSize = true, MaxSize = 16)]
                        public byte[] Data1;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt137>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        // parse the message
                        message.PacketTemplate = new PacketSt137();
                        pParser((PacketSt137)message.PacketTemplate, message.PacketData);

                        //// Note: ZONE DATA HEADER
                        //var zdHead = new NetworkMessage(message.NetID);
                        //zdHead.PacketTemplate = new P018_InstanceLoadZoneDataHeader.PacketSt18()
                        //                                {
                        //                                        ArraySize1 = 70,
                        //                                        Data1 = new byte[] {0x66, 0xE4, 0xA6, 0xFE, 0xE7, 0x5D, 0x0C, 0x66,
                        //                                                    0x3A, 0x3F, 0xFB, 0x11, 0x50, 0xE3, 0xFC, 0x0D, 0xA0, 0xEE, 0x06, 0x7B,
                        //                                                    0x74, 0xB3, 0xDB, 0xFD, 0xFF, 0x0D, 0xC8, 0xDF, 0x22, 0x58, 0xBE, 0xD7,
                        //                                                    0xBF, 0x9C, 0xB3, 0x8E, 0xF7, 0xFB, 0xFE, 0x63, 0x4C, 0x7C, 0xDB, 0xB4,
                        //                                                    0x8D, 0x4C, 0x09, 0x55, 0x43, 0xDD, 0x00, 0x18, 0x00, 0x07, 0x1B, 0x46,
                        //                                                    0xEC, 0x6F, 0x5A, 0x3D, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                        //                                                    0x00, 0x00, 0x00, 0x1C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                        //                                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                        //                                                    0x00, 0x00, 0x00, 0x00, 0x94, 0x97, 0xDF, 0x03, 0x71, 0x60, 0x8B, 0x57,
                        //                                                    0x01, 0x01, 0x20, 0x0C, 0x82, 0x50, 0xD3, 0x00, 0x04, 0xC0, 0x8C, 0x2A,
                        //                                                    0x56, 0x81, 0x40, 0x41, 0x10, 0x20, 0xE8, 0xA4, 0x00, 0x00, 0x00, 0x5C,
                        //                                                    0x9D, 0x21, 0x38, 0x42, 0x40, 0x00, 0x60, 0x10, 0x68, 0x01, 0x00, 0x2C,
                        //                                                    0x4A, 0x29, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x90, 0x00, 0x28,
                        //                                                    0xCC, 0xE2, 0x76, 0xC0, 0x3A, 0x2E, 0x3A, 0x00, 0x00, 0x00, 0x00, 0x00,
                        //                                                    0x00, 0x00, 0x80, 0x10, 0x05, 0x11, 0x39, 0xCC, 0x78, 0x00, 0x9A, 0x93,
                        //                                                    0x58, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0xDF, 0xB2, 0x25, 0xD0,
                        //                                                    0x2F, 0xFD, 0xE7, 0x85, 0xB8, 0xBD, 0xF8, 0x30, 0x20, 0x16, 0xA3, 0x48,
                        //                                                    0x2B, 0x00, 0x00, 0x00, 0x60, 0xC6, 0xCE, 0x44, 0x00, 0x00, 0xC0, 0x0E,
                        //                                                    0x22, 0x00, 0x00, 0x85, 0x71, 0xD7, 0x71, 0xA1, 0xDC, 0x6B, 0x7B, 0x01,
                        //                                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                        //                                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                        //                                                    0x58, 0x09, 0x5C, 0x18, 0x03, 0x00, 0x00, 0x00, 0x00, 0xE5, 0xB3, 0x06,
                        //                                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x59, 0x50, 0x00, 0x00, 0x00,
                        //                                                    0x00, 0xA0, 0x4C, 0x65, 0x01, 0x00, 0x00, 0x40, 0x0D, 0x00, 0x01, 0x00,
                        //                                                    0xFA, 0x4E, 0xAD, 0x0F
                        //                                              }
                        //                                };
                        //QueuingService.PostProcessingQueue.Enqueue(zdHead);

                        // Note: Char specific packets
                        Character chara;
                        lock (chara = World.GetCharacter(Chars.NetID, message.NetID))
                        {
                                // Note: ZONE DATA BEGIN CHAR INFO
                                var charInfo = new NetworkMessage(message.NetID);
                                charInfo.PacketTemplate = new P230_ZoneDataBeginCharInfo.PacketSt230()
                                                                  {
                                                                          Data1 = 1886151033 //"yalp"
                                                                  };
                                QueuingService.PostProcessingQueue.Enqueue(charInfo);

                                // Note: UPDATE FREE ATTRIB PTS
                                var attPts = new NetworkMessage(message.NetID);
                                attPts.PacketTemplate = new P044_UpdateAttribPts.PacketSt44()
                                                                {
                                                                        ID1 = (uint)(int)chara[Chars.AgentID],
                                                                        FreePts = (byte)chara.AttPtsFree,
                                                                        MaxPts = (byte)chara.AttPtsTotal
                                                                };
                                QueuingService.PostProcessingQueue.Enqueue(attPts);

                                // Note: UPDATE PRIV PROF
                                var professions = new NetworkMessage(message.NetID);
                                professions.PacketTemplate = new P171_UpdatePrivProfessions.PacketSt171()
                                                                     {
                                                                             ID1 = (uint)(int)chara[Chars.AgentID],
                                                                             Prof1 = chara.CharStats.ProfessionPrimary,
                                                                             Prof2 = chara.CharStats.ProfessionSecondary,
                                                                             Data3 = 0
                                                                     };
                                QueuingService.PostProcessingQueue.Enqueue(professions);

                                // Note: UPDATE SKILL BAR
                                var skillbar = new NetworkMessage(message.NetID);
                                skillbar.PacketTemplate = new P206_UpdateSkillBar.PacketSt206()
                                                                  {
                                                                          ID1 = (uint)(int)chara[Chars.AgentID],
                                                                          ArraySize1 = 8,
                                                                          SkillBar = new uint[8],
                                                                          ArraySize2 = 8,
                                                                          SkillBarPvPMask = new uint[8],
                                                                          Data3 = 1
                                                                  };
                                QueuingService.PostProcessingQueue.Enqueue(skillbar);

                                // Note: UPDATE GENERICVALUE ENERGY
                                var genEne = new NetworkMessage(message.NetID);
                                genEne.PacketTemplate = new P147_UpdateGenericValueInt.PacketSt147()
                                                                {
                                                                        ID1 =
                                                                                (uint)
                                                                                (int)
                                                                                chara[Chars.AgentID],
                                                                        ValueID = (int)GenericValues.Energy,
                                                                        Value = (ushort)chara.CharStats.Energy
                                                                };
                                QueuingService.PostProcessingQueue.Enqueue(genEne);

                                // Note: UPDATE GENERICVALUE ENERGYREGEN
                                var genEneReg = new NetworkMessage(message.NetID);
                                genEneReg.PacketTemplate = new P150_UpdateGenericValueFloat.PacketSt150()
                                                                   {
                                                                           ID1 =
                                                                                   (uint)
                                                                                   (int)
                                                                                   chara[Chars.AgentID],
                                                                           ValueID = (int)GenericValues.EnergyRegen,
                                                                           Value = chara.CharStats.EnergyRegen
                                                                   };
                                QueuingService.PostProcessingQueue.Enqueue(genEneReg);

                                // Note: UPDATE GENERICVALUE HEALTH
                                var genHea = new NetworkMessage(message.NetID);
                                genHea.PacketTemplate = new P147_UpdateGenericValueInt.PacketSt147()
                                                                {
                                                                        ID1 =
                                                                                (uint)
                                                                                (int)
                                                                                chara[Chars.AgentID],
                                                                        ValueID = (int)GenericValues.Health,
                                                                        Value = (ushort)chara.CharStats.Health
                                                                };
                                QueuingService.PostProcessingQueue.Enqueue(genHea);

                                // Note: UPDATE GENERICVALUE HEALTH REGEN
                                var genHeaReg = new NetworkMessage(message.NetID);
                                genHeaReg.PacketTemplate = new P150_UpdateGenericValueFloat.PacketSt150()
                                                                   {
                                                                           ID1 = (uint)(int)chara[Chars.AgentID],
                                                                           ValueID = (int)GenericValues.HealthRegen,
                                                                           Value = chara.CharStats.HealthRegen
                                                                   };
                                QueuingService.PostProcessingQueue.Enqueue(genHeaReg);

                                // Note: PREPARE MAP DATA
                                var prepMap = new NetworkMessage(message.NetID);
                                prepMap.PacketTemplate = new P127_ZoneDataPrepMapData.PacketSt127()
                                                                 {
                                                                         Data1 = 64,
                                                                         Data2 = 128,
                                                                         Data3 = 27
                                                                 };
                                QueuingService.PostProcessingQueue.Enqueue(prepMap);

                                // Note: MAP DATA (exploration! this is empty)
                                var mapData = new NetworkMessage(message.NetID);
                                mapData.PacketTemplate = new P126_ZoneDataMapData.PacketSt126()
                                                                 {
                                                                         ArraySize1 = 7,
                                                                         Data1 = new byte[] 
                                                                         {	
                                                                                0x00, 0x00, 0x0B, 0x00, 0xFF, 0xFF, 0x54, 0x03, 
                                                                                0x3B, 0x04, 0x3A, 0x04, 0x3A, 0x04, 0xE8, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                                                                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x17,
                                                                         }
                                                                 };
                                QueuingService.PostProcessingQueue.Enqueue(mapData);

                                // Note: UPDATE FACTION PTS
                                var faction = new NetworkMessage(message.NetID);
                                faction.PacketTemplate = new P221_UpdateFactionPts.PacketSt221()
                                                                 {
                                                                         KurzFree = 0,
                                                                         KurzTotal = 0,
                                                                         LuxFree = 0,
                                                                         LuxTotal = 0,
                                                                         ImpFree = 0,
                                                                         ImpTotal = 0,
                                                                         BalthFree = 0,
                                                                         BalthTotal = 0,
                                                                         Level = (ushort)chara.CharStats.Level,
                                                                         Morale = 100,
                                                                         Data1 = 0,
                                                                         Data2 = 0
                                                                 };
                                QueuingService.PostProcessingQueue.Enqueue(faction);

                                // Note: UPDATE AVAILABLE SKILLS
                                var ulockSkills = new NetworkMessage(message.NetID);
                                ulockSkills.PacketTemplate = new P207_UpdateAvailableSkills.PacketSt207()
                                                                     {
                                                                             // ar size is actually for an UInt32[], so this has to be /4
                                                                             ArraySize1 = (ushort)Math.Round((double)chara.CharStats.UnlockedSkills.Length / 4),
                                                                             SkillsBitfield = chara.CharStats.UnlockedSkills
                                                                     };
                                QueuingService.PostProcessingQueue.Enqueue(ulockSkills);

                                var action = new SpawnPlayer((int)chara[Chars.CharID]);
                                World.GetMap(Maps.MapID, chara.MapID).ActionQueue.Enqueue(action.Execute);

                                
                        }

                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt137> pParser;
        }
}

