using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 101)]
        public class P101_IdentifyItem : IPacket
        {
                public class PacketSt101 : IPacketTemplate
                {
                        public UInt16 Header { get { return 101; } }
                        public UInt32 KitID;
                        public UInt32 ItemID;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt101>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt101> pParser;
        }
}
