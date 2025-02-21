using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 101)]
        public class P101_NpcStatsTerminator : IPacket
        {
                public class PacketSt101 : IPacketTemplate
                {
                        public UInt16 Header { get { return 101; } }
                        public UInt32 AgentID;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt101>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt101)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt101> pParser;

        }
}
