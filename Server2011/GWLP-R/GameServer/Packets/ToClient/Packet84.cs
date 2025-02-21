using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 84)]
        public class Packet84 : IPacket
        {
                public class PacketSt84 : IPacketTemplate
                {
                        public UInt16 Header { get { return 84; } }
                        public byte Data1;
                        [PacketFieldType(ConstSize = false, MaxSize = 32)]
                        public string Data2;
                        [PacketFieldType(ConstSize = false, MaxSize = 6)]
                        public string Data3;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt84>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt84)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt84> pParser;

        }
}
