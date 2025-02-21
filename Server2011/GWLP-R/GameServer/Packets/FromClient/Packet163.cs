using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 163)]
        public class Packet163 : IPacket
        {
                public class PacketSt163 : IPacketTemplate
                {
                        public UInt16 Header { get { return 163; } }
                        public byte Data1;
                        [PacketFieldType(ConstSize = false, MaxSize = 32)]
                        public string Data2;
                        public UInt16 Data3;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt163>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt163> pParser;
        }
}
