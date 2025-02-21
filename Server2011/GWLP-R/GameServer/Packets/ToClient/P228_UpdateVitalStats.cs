using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 228)]
        public class P228_UpdateVitalStats : IPacket
        {
                public class PacketSt228 : IPacketTemplate
                {
                        public UInt16 Header { get { return 228; } }
                        public UInt32 ID1;
                        public UInt32 VitalFlagsBitfield;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt228>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt228)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt228> pParser;

        }
}
