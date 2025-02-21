using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 193)]
        public class Packet193 : IPacket
        {
                public class PacketSt193 : IPacketTemplate
                {
                        public UInt16 Header { get { return 193; } }
                        public byte Data1;
                        public UInt32 Data2;
                        public byte Data3;
                        public byte Data4;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt193>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt193)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt193> pParser;

        }
}
