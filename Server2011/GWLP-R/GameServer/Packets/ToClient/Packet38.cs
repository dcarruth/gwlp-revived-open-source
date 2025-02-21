using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 38)]
        public class Packet38 : IPacket
        {
                public class PacketSt38 : IPacketTemplate
                {
                        public UInt16 Header { get { return 38; } }
                        [PacketFieldType(ConstSize = false, MaxSize = 32)]
                        public string Data1;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt38>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt38)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt38> pParser;

        }
}
