using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 371)]
        public class P371_InstanceLoadCharName : IPacket
        {
                public class PacketSt371 : IPacketTemplate
                {
                        public UInt16 Header { get { return 371; } }
                        [PacketFieldType(ConstSize = false, MaxSize = 20)]
                        public string CharName;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt371>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt371)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt371> pParser;

        }
}
