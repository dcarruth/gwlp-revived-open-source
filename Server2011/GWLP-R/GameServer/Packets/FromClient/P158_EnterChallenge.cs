using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 158)]
        public class P158_EnterChallenge : IPacket
        {
                public class PacketSt158 : IPacketTemplate
                {
                        public UInt16 Header { get { return 158; } }
                        public byte Flag;//0 = Foreign // 1 = same Campaign
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt158>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt158> pParser;
        }
}
