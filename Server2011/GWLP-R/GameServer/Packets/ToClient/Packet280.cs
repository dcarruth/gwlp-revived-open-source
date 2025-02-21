using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 280)]
        public class Packet280 : IPacket
        {
                public class PacketSt280 : IPacketTemplate
                {
                        public UInt16 Header { get { return 280; } }
                        public UInt16 Data1;
                        public byte Data2;
                        public UInt32 Data3;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt280>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt280)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt280> pParser;

        }
}
