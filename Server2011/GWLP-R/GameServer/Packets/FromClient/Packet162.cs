using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 162)]
        public class Packet162 : IPacket
        {
                public class PacketSt162 : IPacketTemplate
                {
                        public UInt16 Header { get { return 162; } }
                        public UInt16 Data1;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt162>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt162> pParser;
        }
}
