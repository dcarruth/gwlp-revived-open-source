using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 119)]
        public class P119_UseItem : IPacket
        {
                public class PacketSt119 : IPacketTemplate
                {
                        public UInt16 Header { get { return 119; } }
                        public UInt32 ItemID;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt119>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt119> pParser;
        }
}
