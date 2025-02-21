using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 75)]
        public class P075_NpcModel : IPacket
        {
                public class PacketSt75 : IPacketTemplate
                {
                        public UInt16 Header { get { return 75; } }
                        public UInt32 NpcID;
                        public UInt16 ArraySize1;
                        //[PacketFieldType(ConstSize = false, MaxSize = 32)]
                        //public UInt32[] ModelHash;
                        [PacketFieldType(ConstSize = false, MaxSize = 32)]
                        public byte[] ModelHash;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt75>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt75)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt75> pParser;

        }
}
