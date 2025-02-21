using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 89)]
        public class Packet89 : IPacket
        {
                public class PacketSt89 : IPacketTemplate
                {
                        public UInt16 Header { get { return 89; } }
                        [PacketFieldType(ConstSize = false, MaxSize = 32)]
                        public string Data1;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt89>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt89> pParser;
        }
}
