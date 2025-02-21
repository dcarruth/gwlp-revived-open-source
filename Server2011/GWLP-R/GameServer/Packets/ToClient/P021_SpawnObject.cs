using System;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.ToClient
{
        [PacketAttributes(IsIncoming = false, Header = 21)]
        public class P021_SpawnObject : IPacket
        {
                public class PacketSt21 : IPacketTemplate
                {
                        public UInt16 Header { get { return 21; } }
                        public UInt32 AgentID;
                        public UInt32 Data1;
                        public byte Data2;
                        public byte Data3;
                        public Single PosX;
                        public Single PosY;
                        public UInt16 Plane;
                        public Single Data4;
                        public Single Rotation;
                        public byte Data5;
                        public Single Speed;
                        public Single Data12;
                        public UInt32 Data13;
                        public UInt32 Data14;
                        public UInt32 Data15;
                        public UInt32 Data16;
                        public UInt32 Data17;
                        public UInt32 Data18;
                        public UInt32 Data19;
                        public Single Data20;
                        public Single Data21;
                        public Single Data22;
                        public Single Data23;
                        public UInt16 Data24;
                        public UInt32 Data25;
                        public Single Data26;
                        public Single Data27;
                        public UInt16 Data28;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt21>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        pParser((PacketSt21)message.PacketTemplate, message.PacketData);
                        QueuingService.NetOutQueue.Enqueue(message);
                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt21> pParser;

        }
}
