using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 147)]
        public class Packet147 : IPacket
        {
                public class PacketSt147 : IPacketTemplate
                {
                        public UInt16 Header { get { return 147; } }
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt147>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt147> pParser;
        }
}
