using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 144)]
        public class P144_UpdateMorale : IPacket
        {
                public class PacketSt144 : IPacketTemplate
                {
                        public UInt16 Header { get { return 144; } }
                        public UInt32 ID1;
                        public UInt32 Morale;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt144>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt144)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt144> pParser;

        }
}
