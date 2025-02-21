using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace LoginServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 15)]
        public class P15_ComputerHardware : IPacket
        {
                public class PacketSt15 : IPacketTemplate
                {
                        public UInt16 Header { get { return 15; } }
                        public UInt16 ArraySize1;
                        [PacketFieldType(ConstSize = false, MaxSize = 92)]
                        public byte[] Data1;
                        [PacketFieldType(ConstSize = true, MaxSize = 16)]
                        public byte[] Data2;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt15>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        // parse the message
                        var pack = new PacketSt15();
                        pParser(pack, message.PacketData);

                        // do nothing here

                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt15> pParser;
        }
}
