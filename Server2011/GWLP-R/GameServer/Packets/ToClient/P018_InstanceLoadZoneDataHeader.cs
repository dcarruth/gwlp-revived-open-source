using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 18)]
        public class P018_InstanceLoadZoneDataHeader : IPacket
        {
                public class PacketSt18 : IPacketTemplate
                {
                        public UInt16 Header { get { return 18; } }
                        public UInt16 ArraySize1;
                        [PacketFieldType(ConstSize = false, MaxSize = 512)]
                        public byte[] Data1; // was UInt32
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt18>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt18)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt18> pParser;

        }
}
