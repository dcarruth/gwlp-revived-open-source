using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace LoginServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 20)]
        public class P20_FriendsListEnd : IPacket
        {
                public class PacketSt20 : IPacketTemplate
                {
                        public UInt16 Header { get { return 20; } }
                        public UInt32 LoginCount;
                        public UInt32 StaticData1;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt20>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt20)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt20> pParser;

        }
}
