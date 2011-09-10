using System;
using LoginServer.Packets.ToClient;
using LoginServer.ServerData;
using ServerEngine.ProcessorQueues;
using ServerEngine.PacketManagement.CustomAttributes;
using ServerEngine.PacketManagement.Definitions;

namespace LoginServer.Packets.FromClient
{
        [PacketAttributes(IsIncoming = true, Header = 9)]
        public class P09_LastCharInfo : IPacket
        {
                public class PacketSt9 : IPacketTemplate
                {
                        public UInt16 Header { get { return 9; } }
                        public UInt32 LoginCount;
                        [PacketFieldType(ConstSize = false, MaxSize = 20)]
                        public string Data2;
                        public UInt16 ArraySize1;
                        [PacketFieldType(ConstSize = false, MaxSize = 64)]
                        public byte[] Data3;
                }

                public void InitPacket(object parser)
                {
                        pParser = (PacketParser<PacketSt9>)parser;
                        IsInitialized = true;
                        IsInUse = false;
                }

                public bool Handler(ref NetworkMessage message)
                {
                        // parse the message
                        message.PacketTemplate = new PacketSt9();
                        pParser((PacketSt9)message.PacketTemplate, message.PacketData);

                        Client client;
                        lock (client = World.GetClient(Idents.Clients.NetID, message.NetID))
                        {
                                client.LoginCount = (int)((PacketSt9)message.PacketTemplate).LoginCount;

                                // send a stream terminator:
                                var msg = new NetworkMessage(message.NetID)
                                {
                                        PacketTemplate = new P03_StreamTerminator.PacketSt3()
                                };
                                // set the message data
                                ((P03_StreamTerminator.PacketSt3)msg.PacketTemplate).LoginCount = (uint)client.LoginCount;
                                ((P03_StreamTerminator.PacketSt3)msg.PacketTemplate).ErrorCode = 0;
                                // send it
                                QueuingService.PostProcessingQueue.Enqueue(msg);
                        }

                        return true;
                }

                public bool IsInitialized { get; set; }

                public bool IsInUse { get; set; }

                private PacketParser<PacketSt9> pParser;
        }
}
