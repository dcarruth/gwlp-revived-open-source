using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 223)]
        public class P223_UpdateMaxLuxonFaction : IPacket
        {
                public class PacketSt223 : IPacketTemplate
                {
                        public UInt16 Header { get { return 223; } }
                        public UInt32 MaxLuxonFaction;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt223>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt223)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt223> pParser;

        }
}
