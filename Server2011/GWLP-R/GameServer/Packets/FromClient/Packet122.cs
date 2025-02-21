using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 122)]
        public class Packet122 : IPacket
        {
                public class PacketSt122 : IPacketTemplate
                {
                        public UInt16 Header { get { return 122; } }
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt122>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt122> pParser;
        }
}
