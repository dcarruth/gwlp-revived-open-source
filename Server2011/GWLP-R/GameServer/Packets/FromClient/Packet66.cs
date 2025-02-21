using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 66)]
        public class Packet66 : IPacket
        {
                public class PacketSt66 : IPacketTemplate
                {
                        public UInt16 Header { get { return 66; } }
                        public UInt32 ID1;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt66>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt66> pParser;
        }
}
