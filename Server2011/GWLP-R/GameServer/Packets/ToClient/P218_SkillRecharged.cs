using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 218)]
        public class P218_SkillRecharged : IPacket
        {
                public class PacketSt218 : IPacketTemplate
                {
                        public UInt16 Header { get { return 218; } }
                        public UInt32 AgentID;
                        public UInt16 SkillID;
                        public UInt32 Data2; // 0?
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt218>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt218)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt218> pParser;

        }
}
