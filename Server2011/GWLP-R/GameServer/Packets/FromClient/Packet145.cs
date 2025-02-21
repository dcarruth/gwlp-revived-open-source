using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 145)]
        public class Packet145 : IPacket
        {
                public class PacketSt145 : IPacketTemplate
                {
                        public UInt16 Header { get { return 145; } }
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt145>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt145> pParser;
        }
}
