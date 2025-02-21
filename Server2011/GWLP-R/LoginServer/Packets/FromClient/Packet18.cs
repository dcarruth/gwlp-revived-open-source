using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace LoginServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 18)]
        public class Packet18 : IPacket
        {
                public class PacketSt18 : IPacketTemplate
                {
                        public UInt16 Header { get { return 18; } }
                        public UInt32 Data1;
                        public UInt32 Data2;
                        [PacketFieldType(ConstSize = true, MaxSize = 20)]
                        public byte[] Data3;
                        [PacketFieldType(ConstSize = false, MaxSize = 64)]
                        public string Data4;
                        [PacketFieldType(ConstSize = false, MaxSize = 16)]
                        public string Data5;
                        [PacketFieldType(ConstSize = false, MaxSize = 20)]
                        public string Data6;
                        [PacketFieldType(ConstSize = false, MaxSize = 20)]
                        public string Data7;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt18>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt18> pParser;
        }
}
