using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 110)]
        public class Packet110 : IPacket
        {
                public class PacketSt110 : IPacketTemplate
                {
                        public UInt16 Header { get { return 110; } }
                        public UInt32 Data1;
                        [PacketFieldType(ConstSize = false, MaxSize = 8)]
                        public string Data2;
                        public UInt32 Data3;
                        public UInt32 Data4;
                        public UInt32 Data5;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt110>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt110)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt110> pParser;

        }
}
