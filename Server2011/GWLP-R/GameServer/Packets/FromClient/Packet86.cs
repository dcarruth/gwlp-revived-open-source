using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 86)]
        public class Packet86 : IPacket
        {
                public class PacketSt86 : IPacketTemplate
                {
                        public UInt16 Header { get { return 86; } }
                        public UInt32 ID1;
                        public UInt32 Data1;
                        public UInt32 Data2;
                        public UInt32 Data3;
                        public UInt32 Data4;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt86>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt86> pParser;
        }
}
