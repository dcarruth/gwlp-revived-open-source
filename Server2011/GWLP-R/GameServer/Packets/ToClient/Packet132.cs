using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 132)]
        public class Packet132 : IPacket
        {
                public class PacketSt132 : IPacketTemplate
                {
                        public UInt16 Header { get { return 132; } }
                        public UInt32 Data1;
                        public UInt32 Data2;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt132>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt132)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt132> pParser;

        }
}
