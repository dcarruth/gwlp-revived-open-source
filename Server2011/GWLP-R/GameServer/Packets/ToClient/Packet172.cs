using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 172)]
        public class Packet172 : IPacket
        {
                public class PacketSt172 : IPacketTemplate
                {
                        public UInt16 Header { get { return 172; } }
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt172>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt172)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt172> pParser;

        }
}
