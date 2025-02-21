using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 61)]
        public class Packet61 : IPacket
        {
                public class PacketSt61 : IPacketTemplate
                {
                        public UInt16 Header { get { return 61; } }
                        public UInt32 Data1;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt61>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt61> pParser;
        }
}
