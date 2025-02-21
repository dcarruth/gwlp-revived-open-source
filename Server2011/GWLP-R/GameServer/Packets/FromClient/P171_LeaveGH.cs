using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 171)]
        public class P171_LeaveGH : IPacket
        {
                public class PacketSt171 : IPacketTemplate
                {
                        public UInt16 Header { get { return 171; } }
                        public byte Flag;//1
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt171>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt171> pParser;
        }
}
