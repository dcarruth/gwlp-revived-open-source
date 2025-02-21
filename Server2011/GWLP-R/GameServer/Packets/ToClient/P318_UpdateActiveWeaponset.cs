using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 318)]
        public class P318_UpdateActiveWeaponset : IPacket
        {
                public class PacketSt318 : IPacketTemplate
                {
                        public UInt16 Header { get { return 318; } }
                        public UInt16 ItemStreamID;
                        public byte ActiveWeaponSlot;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt318>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt318)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt318> pParser;

        }
}
