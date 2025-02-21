using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 129)]
        public class Packet129 : IPacket
        {
                public class PacketSt129 : IPacketTemplate
                {
                        public UInt16 Header { get { return 129; } }
                        public UInt32 Data1;
                        public Single Data2;
                        public Single Data3;
                        public UInt16 Data4;
                        public byte Data5;
                        public UInt32 Data6;
                        public UInt32 Data7;
                        [PacketFieldType(ConstSize = false, MaxSize = 8)]
                        public string Data8;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt129>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt129)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt129> pParser;

        }
}
