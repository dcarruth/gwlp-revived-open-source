using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 167)]
        public class Packet167 : IPacket
        {
                public class PacketSt167 : IPacketTemplate
                {
                        public UInt16 Header { get { return 167; } }
                        public UInt32 ID1;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt167>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt167)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt167> pParser;

        }
}
