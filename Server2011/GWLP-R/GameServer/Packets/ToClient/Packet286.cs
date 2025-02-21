using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 286)]
        public class Packet286 : IPacket
        {
                public class PacketSt286 : IPacketTemplate
                {
                        public UInt16 Header { get { return 286; } }
                        [PacketFieldType(ConstSize = false, MaxSize = 20)]
                        public string Data1;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt286>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt286)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt286> pParser;

        }
}
