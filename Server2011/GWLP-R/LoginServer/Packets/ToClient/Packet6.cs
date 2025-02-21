using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace LoginServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 6)]
        public class Packet6 : IPacket
        {
                public class PacketSt6 : IPacketTemplate
                {
                        public UInt16 Header { get { return 6; } }
                        public UInt32 Data1;
                        [PacketFieldType(ConstSize = true, MaxSize = 8)]
                        public byte[] Data2;
                        [PacketFieldType(ConstSize = true, MaxSize = 8)]
                        public byte[] Data3;
                        [PacketFieldType(ConstSize = true, MaxSize = 8)]
                        public byte[] Data4;
                        [PacketFieldType(ConstSize = true, MaxSize = 8)]
                        public byte[] Data5;
                        public UInt32 Data6;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt6>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt6)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt6> pParser;

        }
}
