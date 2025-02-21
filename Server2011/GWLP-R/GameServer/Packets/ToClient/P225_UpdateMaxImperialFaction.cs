using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 225)]
        public class P225_UpdateMaxImperialFaction : IPacket
        {
                public class PacketSt225 : IPacketTemplate
                {
                        public UInt16 Header { get { return 225; } }
                        public UInt32 MaxImperialFaction;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt225>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt225)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt225> pParser;

        }
}
