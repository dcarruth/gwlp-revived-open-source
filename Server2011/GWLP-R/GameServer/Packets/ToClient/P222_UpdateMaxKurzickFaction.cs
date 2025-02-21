using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 222)]
        public class P222_UpdateMaxKurzickFaction : IPacket
        {
                public class PacketSt222 : IPacketTemplate
                {
                        public UInt16 Header { get { return 222; } }
                        public UInt32 MaxKurzickFaction;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt222>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt222)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt222> pParser;

        }
}
