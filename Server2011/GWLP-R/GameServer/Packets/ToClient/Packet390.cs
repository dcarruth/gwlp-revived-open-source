using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 390)]
        public class Packet390 : IPacket
        {
                public class PacketSt390 : IPacketTemplate
                {
                        public UInt16 Header { get { return 390; } }
                        public byte Data1;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt390>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt390)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt390> pParser;

        }
}
