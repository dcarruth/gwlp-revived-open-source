using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 110)]
        public class Packet110 : IPacket
        {
                public class PacketSt110 : IPacketTemplate
                {
                        public UInt16 Header { get { return 110; } }
                        public UInt32 Data1;
                        public UInt32 Data2;
                        public UInt16 Data3;
                        public byte Data4;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt110>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt110> pParser;
        }
}
