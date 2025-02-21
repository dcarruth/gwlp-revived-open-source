using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 234)]
        public class Packet234 : IPacket
        {
                public class PacketSt234 : IPacketTemplate
                {
                        public UInt16 Header { get { return 234; } }
                        public UInt32 Data1;
                        public UInt32 Data2;
                        public UInt32 Data3;
                        public UInt32 Data4;
                        public UInt32 Data5;
                        public UInt32 Data6;
                        public UInt32 Data7;
                        public UInt32 Data8;
                        public UInt32 Data9;
                        [PacketFieldType(ConstSize = false, MaxSize = 8)]
                        public string Data10;
                        [PacketFieldType(ConstSize = false, MaxSize = 8)]
                        public string Data11;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt234>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt234)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt234> pParser;

        }
}
