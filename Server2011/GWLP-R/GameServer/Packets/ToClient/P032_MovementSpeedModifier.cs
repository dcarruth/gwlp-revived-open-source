using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 32)]
        public class P032_MovementSpeedModifier : IPacket
        {
                public class PacketSt32 : IPacketTemplate
                {
                        public UInt16 Header { get { return 32; } }
                        public UInt32 AgentID;
                        public Single Speed;
                        public byte MoveType;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt32>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt32)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt32> pParser;

        }
}
