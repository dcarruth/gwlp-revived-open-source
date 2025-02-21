using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 117)]
        public class P117_ChangeGold : IPacket
        {
                public class PacketSt117 : IPacketTemplate
                {
                        public UInt16 Header { get { return 117; } }
                        public UInt32 Self;
                        public UInt32 Storage;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt117>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt117> pParser;
        }
}
