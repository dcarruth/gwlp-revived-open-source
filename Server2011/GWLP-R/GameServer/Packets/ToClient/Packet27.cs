using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 27)]
        public class Packet27 : IPacket
        {
                public class PacketSt27 : IPacketTemplate
                {
                        public UInt16 Header { get { return 27; } }
                        public UInt32 Data1;
                        public byte Data2;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt27>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt27)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt27> pParser;

        }
}
