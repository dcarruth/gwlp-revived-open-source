using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 71)]
        public class Packet71 : IPacket
        {
                public class PacketSt71 : IPacketTemplate
                {
                        public UInt16 Header { get { return 71; } }
                        public byte Data1;
                        [PacketFieldType(ConstSize = false, MaxSize = 122)]
                        public string Data2;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt71>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt71> pParser;
        }
}
