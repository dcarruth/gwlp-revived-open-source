using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 303)]
        public class P303_UpdateItemQuantity : IPacket
        {
                public class PacketSt303 : IPacketTemplate
                {
                        public UInt16 Header { get { return 303; } }
                        public UInt32 ItemLocalID;
                        public UInt32 NewQuantity;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt303>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt303)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt303> pParser;

        }
}
