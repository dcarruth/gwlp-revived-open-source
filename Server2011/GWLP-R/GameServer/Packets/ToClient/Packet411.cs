using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 411)]
        public class Packet411 : IPacket
        {
                public class PacketSt411 : IPacketTemplate
                {
                        public UInt16 Header { get { return 411; } }
                        public byte Data1;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt411>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt411)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt411> pParser;

        }
}
