using System;
using ServerEngine.ProcessorQueues;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 194)]
        public class Packet194 : IPacket
        {
                public class PacketSt194 : IPacketTemplate
                {
                        public UInt16 Header { get { return 194; } }
                        public UInt32 Data1;
                        public UInt32 Data2;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt194>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt194)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt194> pParser;

        }
}
