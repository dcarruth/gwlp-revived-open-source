using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 47)]
        public class Packet47 : IPacket
        {
                public class PacketSt47 : IPacketTemplate
                {
                        public UInt16 Header { get { return 47; } }
                        public UInt32 ID1;
                        public UInt16 ArraySize1;
                        [PacketFieldType(ConstSize = false, MaxSize = 192)]
                        public UInt32[] Data1;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt47>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt47)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt47> pParser;

        }
}
