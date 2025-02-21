using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 207)]
        public class P207_UpdateAvailableSkills : IPacket
        {
                public class PacketSt207 : IPacketTemplate
                {
                        public UInt16 Header { get { return 207; } }
                        public UInt16 ArraySize1; // counts in UInt32
                        [PacketFieldType(ConstSize = false, MaxSize = 512)]
                        public byte[] SkillsBitfield; // was UInt32
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt207>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt207)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt207> pParser;

        }
}
