using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 349)]
        public class Packet349 : IPacket
        {
                public class PacketSt349 : IPacketTemplate
                {
                        public UInt16 Header { get { return 349; } }
                        public byte Data1;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt349>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt349)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt349> pParser;

        }
}
