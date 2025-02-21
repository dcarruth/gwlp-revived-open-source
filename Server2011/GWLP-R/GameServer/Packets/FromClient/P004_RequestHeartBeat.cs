using System;
using GameServer.Enums;
using GameServer.ServerData;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 4)]
        public class P004_RequestHeartBeat : IPacket
        {
                public class PacketSt4 : IPacketTemplate
                {
                        public UInt16 Header { get { return 4; } }
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt4>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        // nothing to do here, just ensure the status is 'playing'
                        var chara = GameServerWorld.Instance.Get<DataClient>(message.NetID).Character;
                        chara.Data.Player = PlayStatus.ReadyToPlay;

                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt4> pParser;
        }
}
