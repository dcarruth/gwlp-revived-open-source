using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 180)]
        public class Packet180 : IPacket
        {
                public class PacketSt180 : IPacketTemplate
                {
                        public UInt16 Header { get { return 180; } }
                        public UInt32 Data1;
                        public UInt32 Data2;
                        public UInt32 Data3;
                        [PacketFieldType(ConstSize = false, MaxSize = 128)]
                        public string Data4;
                        [PacketFieldType(ConstSize = false, MaxSize = 128)]
                        public string Data5;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt180>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt180)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt180> pParser;

        }
}
