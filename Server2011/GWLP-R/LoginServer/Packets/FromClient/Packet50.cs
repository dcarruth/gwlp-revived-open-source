using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace LoginServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 50)]
        public class Packet50 : IPacket
        {
                public class PacketSt50 : IPacketTemplate
                {
                        public UInt16 Header { get { return 50; } }
                        public UInt32 Data1;
                        [PacketFieldType(ConstSize = false, MaxSize = 10)]
                        public string Data2;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt50>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt50> pParser;
        }
}
