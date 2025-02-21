using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 76)]
        public class P076_OpenChest : IPacket
        {
                public class PacketSt76 : IPacketTemplate
                {
                        public UInt16 Header { get { return 76; } }
                        public UInt32 Flag;//2
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt76>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt76> pParser;
        }
}
