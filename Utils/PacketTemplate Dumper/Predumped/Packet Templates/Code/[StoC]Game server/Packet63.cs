using System;
using ServerEngine.ProcessorQueues;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 63)]
        public class Packet63 : IPacket
        {
                public class PacketSt63 : IPacketTemplate
                {
                        public UInt16 Header { get { return 63; } }
                        public UInt16 ArraySize1;
                        [PacketFieldType(ConstSize = false, MaxSize = 256)]
                        public UInt32[] Data1;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt63>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt63)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt63> pParser;

        }
}
