using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace LoginServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 12)]
        public class Packet12 : IPacket
        {
                public class PacketSt12 : IPacketTemplate
                {
                        public UInt16 Header { get { return 12; } }
                        public UInt32 Data1;
                        public UInt32 Data2;
                        [PacketFieldType(ConstSize = false, MaxSize = 20)]
                        public string Data3;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt12>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt12> pParser;
        }
}
