using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace LoginServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 51)]
        public class Packet51 : IPacket
        {
                public class PacketSt51 : IPacketTemplate
                {
                        public UInt16 Header { get { return 51; } }
                        public UInt32 Data1;
                        public UInt32 Data2;
                        public UInt32 Data3;
                        public UInt32 Data4;
                        [PacketFieldType(ConstSize = false, MaxSize = 18)]
                        public string Data5;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt51>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt51> pParser;
        }
}
