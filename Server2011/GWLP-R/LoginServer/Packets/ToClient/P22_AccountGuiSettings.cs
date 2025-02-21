using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace LoginServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 22)]
        public class P22_AccountGuiSettings : IPacket
        {
                public class PacketSt22 : IPacketTemplate
                {
                        public UInt16 Header { get { return 22; } }
                        public UInt32 LoginCount;
                        public UInt16 ArraySize1;
                        [PacketFieldType(ConstSize = false, MaxSize = 1024)]
                        public byte[] RawData;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt22>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt22)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt22> pParser;

        }
}
