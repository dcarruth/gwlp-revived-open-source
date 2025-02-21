using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 125)]
        public class Packet125 : IPacket
        {
                public class PacketSt125 : IPacketTemplate
                {
                        public UInt16 Header { get { return 125; } }
                        public byte Data1;
                        public Single Data2;
                        public Single Data3;
                        public Single Data4;
                        public Single Data5;
                        public Single Data6;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt125>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt125)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt125> pParser;

        }
}
