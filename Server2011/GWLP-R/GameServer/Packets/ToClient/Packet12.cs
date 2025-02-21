using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 12)]
        public class Packet12 : IPacket
        {
                public class PacketSt12 : IPacketTemplate
                {
                        public UInt16 Header { get { return 12; } }
                        public byte Data1;
                        public byte Data2;
                        public UInt32 Data3;
                        public UInt32 Data4;
                        public byte Data5;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt12>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt12)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt12> pParser;

        }
}
