using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 116)]
        public class P116_DialogBody : IPacket
        {
                public class PacketSt116 : IPacketTemplate
                {
                        public UInt16 Header { get { return 116; } }
                        [PacketFieldType(ConstSize = false, MaxSize = 122)]
                        public string DialogData; //text (buttons scriptlike implementation)
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt116>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt116)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt116> pParser;

        }
}
