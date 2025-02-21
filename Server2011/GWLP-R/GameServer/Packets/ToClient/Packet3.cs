using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 3)]
        public class Packet3 : IPacket
        {
                public class PacketSt3 : IPacketTemplate
                {
                        public UInt16 Header { get { return 3; } }
                        public UInt32 Data1;
                        public UInt32 Data2;
                        [PacketFieldType(ConstSize = false, MaxSize = 256)]
                        public string Data3;
                        [PacketFieldType(ConstSize = false, MaxSize = 256)]
                        public string Data4;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt3>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt3)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt3> pParser;

        }
}
