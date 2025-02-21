using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 364)]
        public class Packet364 : IPacket
        {
                public class PacketSt364 : IPacketTemplate
                {
                        public UInt16 Header { get { return 364; } }
                        public UInt32 Data1;
                        public UInt16 Data2;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt364>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt364)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt364> pParser;

        }
}
