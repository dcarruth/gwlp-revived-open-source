using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 26)]
        public class P026_MovementDirection : IPacket
        {
                public class PacketSt26 : IPacketTemplate
                {
                        public UInt16 Header { get { return 26; } }
                        public UInt32 AgentID;
                        public Single DirX;
                        public Single DirY;
                        public byte MoveType;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt26>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt26)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt26> pParser;

        }
}
