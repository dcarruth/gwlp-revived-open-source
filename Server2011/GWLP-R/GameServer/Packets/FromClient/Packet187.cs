using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 187)]
        public class Packet187 : IPacket
        {
                public class PacketSt187 : IPacketTemplate
                {
                        public UInt16 Header { get { return 187; } }
                        public UInt32 Data1;
                        [PacketFieldType(ConstSize = false, MaxSize = 20)]
                        public string Data2;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt187>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt187> pParser;
        }
}
