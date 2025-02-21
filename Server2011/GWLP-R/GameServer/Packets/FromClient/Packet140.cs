using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 140)]
        public class Packet140 : IPacket
        {
                public class PacketSt140 : IPacketTemplate
                {
                        public UInt16 Header { get { return 140; } }
                        public UInt16 Data1;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt140>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt140> pParser;
        }
}
