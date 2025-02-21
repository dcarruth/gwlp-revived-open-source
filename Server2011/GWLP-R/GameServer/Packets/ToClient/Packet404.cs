using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 404)]
        public class Packet404 : IPacket
        {
                public class PacketSt404 : IPacketTemplate
                {
                        public UInt16 Header { get { return 404; } }
                        public byte Data1;
                        [PacketFieldType(ConstSize = false, MaxSize = 122)]
                        public string Data2;
                        [PacketFieldType(ConstSize = false, MaxSize = 122)]
                        public string Data3;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt404>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt404)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt404> pParser;

        }
}
