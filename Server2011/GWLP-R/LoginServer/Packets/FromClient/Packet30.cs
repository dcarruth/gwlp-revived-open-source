using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace LoginServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 30)]
        public class Packet30 : IPacket
        {
                public class PacketSt30 : IPacketTemplate
                {
                        public UInt16 Header { get { return 30; } }
                        public UInt32 Data1;
                        public UInt32 Data2;
                        [PacketFieldType(ConstSize = false, MaxSize = 26)]
                        public string Data3;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt30>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt30> pParser;
        }
}
