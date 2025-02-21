using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 143)]
        public class P143_NpcName : IPacket
        {
                public class PacketSt143 : IPacketTemplate
                {
                        public UInt16 Header { get { return 143; } }
                        public UInt32 AgentID;
                        [PacketFieldType(ConstSize = false, MaxSize = 32)]
                        public string Name;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt143>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt143)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt143> pParser;

        }
}
