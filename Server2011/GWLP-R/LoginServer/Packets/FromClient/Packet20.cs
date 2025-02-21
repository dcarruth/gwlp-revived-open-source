using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace LoginServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 20)]
        public class Packet20 : IPacket
        {
                public class PacketSt20 : IPacketTemplate
                {
                        public UInt16 Header { get { return 20; } }
                        public UInt32 Data1;
                        public UInt32 Data2;
                        [PacketFieldType(ConstSize = false, MaxSize = 64)]
                        public string Data3;
                        [PacketFieldType(ConstSize = false, MaxSize = 64)]
                        public string Data4;
                        [PacketFieldType(ConstSize = false, MaxSize = 256)]
                        public string Data5;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt20>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt20> pParser;
        }
}
