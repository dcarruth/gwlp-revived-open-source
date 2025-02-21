using System;
using ServerEngine.NetworkManagement;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace GameServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 52)]
        public class P052_PressDialogButton : IPacket
        {
                public class PacketSt52 : IPacketTemplate
                {
                        public UInt16 Header { get { return 52; } }
                        public UInt32 ButtonID;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt52>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        throw new NotImplementedException();
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt52> pParser;
        }
}
