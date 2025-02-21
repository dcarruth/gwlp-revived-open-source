using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 91)]
        public class Packet91 : IPacket
        {
                public class PacketSt91 : IPacketTemplate
                {
                        public UInt16 Header { get { return 91; } }
                        public Single Data1;
                        public Single Data2;
                        public UInt16 Data3;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt91>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt91)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt91> pParser;

        }
}
