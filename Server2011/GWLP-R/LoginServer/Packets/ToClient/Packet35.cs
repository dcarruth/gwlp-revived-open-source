using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace LoginServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 35)]
        public class Packet35 : IPacket
        {
                public class PacketSt35 : IPacketTemplate
                {
                        public UInt16 Header { get { return 35; } }
                        public UInt32 Data1;
                        public UInt32 Data2;
                        [PacketFieldType(ConstSize = true, MaxSize = 16)]
                        public byte[] Data3;
                        [PacketFieldType(ConstSize = true, MaxSize = 16)]
                        public byte[] Data4;
                        [PacketFieldType(ConstSize = true, MaxSize = 16)]
                        public byte[] Data5;
                        [PacketFieldType(ConstSize = false, MaxSize = 16)]
                        public string Data6;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt35>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt35)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt35> pParser;

        }
}
