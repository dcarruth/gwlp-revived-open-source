using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 99)]
        public class Packet99 : IPacket
        {
                public class PacketSt99 : IPacketTemplate
                {
                        public UInt16 Header { get { return 99; } }
                        public UInt32 Data1;
                        public UInt16 ArraySize1;
                        [PacketFieldType(ConstSize = false, MaxSize = 16)]
                        public UInt32[] Data2;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt99>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt99> pParser;
        }
}
