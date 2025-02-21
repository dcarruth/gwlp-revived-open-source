using System;
using System.IO;
using GameServer.Enums;
using ServerEngine.PacketManagement.StaticConvert;

namespace GameServer.ServerData.Items
{
        public class ItemStat
        {
                private readonly ItemStatEnums stat;
                private readonly byte value1;
                private readonly byte value2;

                /// <summary>
                ///   Create a new instance of the class
                /// </summary>
                /// <param name="stat">
                ///   The item-stat found wihtin the enums
                /// </param>
                /// <param name="value1">
                ///   This is the first byte of the itemstat, read in littleendian
                /// </param>
                /// <param name="value2">
                ///   This is the second byte of the itemstat, read in littleendian
                /// </param>
                public ItemStat(ItemStatEnums stat, byte value1, byte value2)
                {
                        this.stat = stat;
                        this.value1 = value1;
                        this.value2 = value2;
                }

                /// <summary>
                ///   Creates a new instance of the class
                /// </summary>
                /// <param name="rawData">
                ///   The raw data of the stat in littleendian byteorder
                /// </param>
                public ItemStat(byte[] rawData)
                {
                        using (var ms = new MemoryStream(rawData))
                        {
                                byte buf1 = 0;
                                ushort buf2 = 0;

                                RawConverter.ReadByte(ref buf1, ms);
                                value1 = buf1;
                                RawConverter.ReadByte(ref buf1, ms);
                                value2 = buf1;
                                RawConverter.ReadUInt16(ref buf2, ms);
                                stat = (ItemStatEnums) Enum.ToObject(typeof (ItemStatEnums), buf2);
                        }
                }

                /// <summary>
                ///   This property is the second byte (littleendian) of the ItemStat
                ///   It may be some sort of value or ID...
                /// </summary>
                public byte Value2
                {
                        get { return value2; }
                }

                /// <summary>
                ///   This property is the first byte (littleendian) of the ItemStat
                ///   It may be some sort of value or ID...
                /// </summary>
                public byte Value1
                {
                        get { return value1; }
                }

                /// <summary>
                ///   This represents the item stat.
                /// </summary>
                public ItemStatEnums Stat
                {
                        get { return stat; }
                }

                /// <summary>
                ///   Generates the GW-Item-Stat code out of this object's data
                /// </summary>
                public UInt32 Compile()
                {
                        return (UInt32)(
                               ((ushort) stat << 16) |
                               (value2 << 8) |
                               value1);

                }
        }
}