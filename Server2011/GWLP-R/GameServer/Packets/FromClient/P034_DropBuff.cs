using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 34)]
        public class P034_DropBuff : IPacket
        {
                public class PacketSt34 : IPacketTemplate
                {
                        public UInt16 Header { get { return 34; } }
                        public UInt32 BuffID;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt34>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt34> pParser;
        }
}
