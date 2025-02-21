using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 81)]
        public class P081_GeneralChatMessage : IPacket
        {
                public class PacketSt81 : IPacketTemplate
                {
                        public UInt16 Header { get { return 81; } }
                        [PacketFieldType(ConstSize = false, MaxSize = 122)]
                        public string Message; // that is a GWString
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt81>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt81)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt81> pParser;

        }
}
