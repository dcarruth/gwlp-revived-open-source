using System;
using System.Linq;
using GameServer.Packets.ToLoginServer;
using GameServer.ServerData;
using ServerEngine;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromLoginServer
{
        [PacketAttributes(IsIncoming = true, Header = 65282)]
        public class P65282_ServerStatsRequest : IPacket
        {
                public class PacketSt65282 : IPacketTemplate
                {
                        public UInt16 Header { get { return 65282; } }
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt65282>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        // nothing to parse here ;)

                        // get availabe maps: (as ushort array of mapID's)
                        var ids = GameServerWorld.Instance.GetMapIDs().Select(x => (ushort)x.Value).ToArray();

                        // create reply
                        // Note: SERVER STATS
                        var reply = new NetworkMessage(message.NetID)
                        {
                                PacketTemplate = new P65282_ServerStatsReply.PacketSt65282
                                {
                                        ArraySize1 = (ushort)ids.Length,
                                        MapIDs = ids,
                                        Utilization = (byte)NetworkManager.Instance.GetUtilization(),
                                }
                        };
                        QueuingService.PostProcessingQueue.Enqueue(reply);

                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt65282> pParser;
        }
}
