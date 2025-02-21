using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace LoginServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 3)]
        public class P03_StreamTerminator : IPacket
        {
                public class PacketSt3 : IPacketTemplate
                {
                        public UInt16 Header { get { return 3; } }
                        public UInt32 LoginCount;
                        public UInt32 ErrorCode;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt3>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt3)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt3> pParser;

        }
}
