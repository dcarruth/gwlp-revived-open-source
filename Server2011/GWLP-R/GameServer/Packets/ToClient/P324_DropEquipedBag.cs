using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 324)]
        public class P324_DropEquipedBag : IPacket
        {
                public class PacketSt324 : IPacketTemplate
                {
                        public UInt16 Header { get { return 324; } }
                        public UInt16 ItemStreamID;
                        public UInt16 PageID;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt324>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt324)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt324> pParser;

        }
}
