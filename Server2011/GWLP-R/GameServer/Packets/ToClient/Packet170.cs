using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 170)]
        public class Packet170 : IPacket
        {
                public class PacketSt170 : IPacketTemplate
                {
                        public UInt16 Header { get { return 170; } }
                        public UInt32 ID1;
                        public UInt32 Data1;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt170>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt170)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt170> pParser;

        }
}
