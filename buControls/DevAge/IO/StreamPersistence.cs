// Decompiled with JetBrains decompiler
// Type: DevAge.IO.StreamPersistence
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.IO;
using System.Text;

#nullable disable
namespace DevAge.IO;

public static class StreamPersistence
{
  public static void Write(Stream p_Stream, string p_Value, Encoding encoding)
  {
    byte[] bytes = encoding.GetBytes(p_Value);
    StreamPersistence.Write(p_Stream, bytes);
  }

  public static void Write(Stream p_Stream, byte p_Value) => p_Stream.WriteByte(p_Value);

  public static void Write(Stream p_Stream, Guid p_Value)
  {
    byte[] byteArray = p_Value.ToByteArray();
    StreamPersistence.Write(p_Stream, byteArray);
  }

  public static void Write(Stream p_Stream, Decimal p_Value)
  {
    int[] bits = Decimal.GetBits(p_Value);
    StreamPersistence.Write(p_Stream, bits[0]);
    StreamPersistence.Write(p_Stream, bits[1]);
    StreamPersistence.Write(p_Stream, bits[2]);
    StreamPersistence.Write(p_Stream, bits[3]);
  }

  public static void Write(Stream p_Stream, DateTime p_Value)
  {
    StreamPersistence.Write(p_Stream, p_Value.ToOADate());
  }

  public static void Write(Stream p_Stream, short p_Value)
  {
    StreamPersistence.WriteBytes(p_Stream, BitConverter.GetBytes(p_Value));
  }

  public static void Write(Stream p_Stream, int p_Value)
  {
    StreamPersistence.WriteBytes(p_Stream, BitConverter.GetBytes(p_Value));
  }

  public static void Write(Stream p_Stream, long p_Value)
  {
    StreamPersistence.WriteBytes(p_Stream, BitConverter.GetBytes(p_Value));
  }

  public static void Write(Stream p_Stream, float p_Value)
  {
    StreamPersistence.WriteBytes(p_Stream, BitConverter.GetBytes(p_Value));
  }

  public static void Write(Stream p_Stream, double p_Value)
  {
    StreamPersistence.WriteBytes(p_Stream, BitConverter.GetBytes(p_Value));
  }

  public static void Write(Stream p_Stream, char p_Value)
  {
    StreamPersistence.WriteBytes(p_Stream, BitConverter.GetBytes(p_Value));
  }

  public static void Write(Stream p_Stream, bool p_Value)
  {
    StreamPersistence.WriteBytes(p_Stream, BitConverter.GetBytes(p_Value));
  }

  public static void Write(Stream p_Stream, ushort p_Value)
  {
    StreamPersistence.WriteBytes(p_Stream, BitConverter.GetBytes(p_Value));
  }

  public static void Write(Stream p_Stream, uint p_Value)
  {
    StreamPersistence.WriteBytes(p_Stream, BitConverter.GetBytes(p_Value));
  }

  public static void Write(Stream p_Stream, ulong p_Value)
  {
    StreamPersistence.WriteBytes(p_Stream, BitConverter.GetBytes(p_Value));
  }

  public static void Write(Stream p_Stream, byte[] p_Bytes)
  {
    StreamPersistence.Write(p_Stream, p_Bytes.Length);
    StreamPersistence.WriteBytes(p_Stream, p_Bytes);
  }

  public static void Write(Stream stream, Type valueType, object val)
  {
    if (valueType == typeof (string))
      StreamPersistence.Write(stream, (string) val, Encoding.UTF8);
    else if (valueType == typeof (short))
      StreamPersistence.Write(stream, (short) val);
    else if (valueType == typeof (int))
      StreamPersistence.Write(stream, (int) val);
    else if (valueType == typeof (long))
      StreamPersistence.Write(stream, (long) val);
    else if (valueType == typeof (float))
      StreamPersistence.Write(stream, (float) val);
    else if (valueType == typeof (double))
      StreamPersistence.Write(stream, (double) val);
    else if (valueType == typeof (bool))
      StreamPersistence.Write(stream, (bool) val);
    else if (valueType == typeof (Decimal))
      StreamPersistence.Write(stream, (Decimal) val);
    else if (valueType == typeof (char))
      StreamPersistence.Write(stream, (char) val);
    else if (valueType == typeof (byte))
      StreamPersistence.Write(stream, (byte) val);
    else if (valueType == typeof (byte[]))
      StreamPersistence.Write(stream, (byte[]) val);
    else if (valueType == typeof (DateTime))
    {
      StreamPersistence.Write(stream, (DateTime) val);
    }
    else
    {
      if (!(valueType == typeof (Guid)))
        throw new TypeNotSupportedException(valueType);
      StreamPersistence.Write(stream, (Guid) val);
    }
  }

  public static void WriteBytes(Stream p_Stream, byte[] p_Bytes)
  {
    p_Stream.Write(p_Bytes, 0, p_Bytes.Length);
  }

  public static Guid ReadGuid(Stream stream) => new Guid(StreamPersistence.ReadByteArray(stream));

  public static Decimal ReadDecimal(Stream stream)
  {
    return new Decimal(new int[4]
    {
      StreamPersistence.ReadInt32(stream),
      StreamPersistence.ReadInt32(stream),
      StreamPersistence.ReadInt32(stream),
      StreamPersistence.ReadInt32(stream)
    });
  }

  public static DateTime ReadDateTime(Stream p_Stream)
  {
    return DateTime.FromOADate(StreamPersistence.ReadDouble(p_Stream));
  }

  public static float ReadSingle(Stream p_Stream)
  {
    byte[] bytes = BitConverter.GetBytes(0.0f);
    StreamPersistence.ReadBytes(p_Stream, bytes);
    return BitConverter.ToSingle(bytes, 0);
  }

  public static double ReadDouble(Stream p_Stream)
  {
    byte[] bytes = BitConverter.GetBytes(0.0);
    StreamPersistence.ReadBytes(p_Stream, bytes);
    return BitConverter.ToDouble(bytes, 0);
  }

  public static short ReadInt16(Stream p_Stream)
  {
    byte[] bytes = BitConverter.GetBytes((short) 0);
    StreamPersistence.ReadBytes(p_Stream, bytes);
    return BitConverter.ToInt16(bytes, 0);
  }

  public static int ReadInt32(Stream p_Stream)
  {
    byte[] bytes = BitConverter.GetBytes(0);
    StreamPersistence.ReadBytes(p_Stream, bytes);
    return BitConverter.ToInt32(bytes, 0);
  }

  public static long ReadInt64(Stream p_Stream)
  {
    byte[] bytes = BitConverter.GetBytes(0L);
    StreamPersistence.ReadBytes(p_Stream, bytes);
    return BitConverter.ToInt64(bytes, 0);
  }

  public static ushort ReadUInt16(Stream p_Stream)
  {
    byte[] bytes = BitConverter.GetBytes((ushort) 0);
    StreamPersistence.ReadBytes(p_Stream, bytes);
    return BitConverter.ToUInt16(bytes, 0);
  }

  public static uint ReadUInt32(Stream p_Stream)
  {
    byte[] bytes = BitConverter.GetBytes(0U);
    StreamPersistence.ReadBytes(p_Stream, bytes);
    return BitConverter.ToUInt32(bytes, 0);
  }

  public static ulong ReadUInt64(Stream p_Stream)
  {
    byte[] bytes = BitConverter.GetBytes(0UL);
    StreamPersistence.ReadBytes(p_Stream, bytes);
    return BitConverter.ToUInt64(bytes, 0);
  }

  public static byte ReadByte(Stream p_Stream)
  {
    int num = p_Stream.ReadByte();
    return num != -1 ? (byte) num : throw new InvalidDataException();
  }

  public static char ReadChar(Stream p_Stream)
  {
    byte[] bytes = BitConverter.GetBytes(char.MinValue);
    StreamPersistence.ReadBytes(p_Stream, bytes);
    return BitConverter.ToChar(bytes, 0);
  }

  public static bool ReadBoolean(Stream p_Stream)
  {
    byte[] bytes = BitConverter.GetBytes(false);
    StreamPersistence.ReadBytes(p_Stream, bytes);
    return BitConverter.ToBoolean(bytes, 0);
  }

  public static string ReadString(Stream p_Stream, Encoding encoding)
  {
    byte[] bytes = StreamPersistence.ReadByteArray(p_Stream);
    return encoding.GetString(bytes);
  }

  public static byte[] ReadByteArray(Stream p_Stream)
  {
    byte[] p_Value = new byte[StreamPersistence.ReadInt32(p_Stream)];
    StreamPersistence.ReadBytes(p_Stream, p_Value);
    return p_Value;
  }

  public static object Read(Stream stream, Type valueType)
  {
    if (valueType == typeof (string))
      return (object) StreamPersistence.ReadString(stream, Encoding.UTF8);
    if (valueType == typeof (char))
      return (object) StreamPersistence.ReadChar(stream);
    if (valueType == typeof (bool))
      return (object) StreamPersistence.ReadBoolean(stream);
    if (valueType == typeof (Decimal))
      return (object) StreamPersistence.ReadDecimal(stream);
    if (valueType == typeof (short))
      return (object) StreamPersistence.ReadInt16(stream);
    if (valueType == typeof (int))
      return (object) StreamPersistence.ReadInt32(stream);
    if (valueType == typeof (long))
      return (object) StreamPersistence.ReadInt64(stream);
    if (valueType == typeof (float))
      return (object) StreamPersistence.ReadSingle(stream);
    if (valueType == typeof (double))
      return (object) StreamPersistence.ReadDouble(stream);
    if (valueType == typeof (byte))
      return (object) StreamPersistence.ReadByte(stream);
    if (valueType == typeof (byte[]))
      return (object) StreamPersistence.ReadByteArray(stream);
    if (valueType == typeof (DateTime))
      return (object) StreamPersistence.ReadDateTime(stream);
    if (valueType == typeof (Guid))
      return (object) StreamPersistence.ReadGuid(stream);
    throw new TypeNotSupportedException(valueType);
  }

  public static void ReadBytes(Stream p_Stream, byte[] p_Value)
  {
    if (p_Stream.Read(p_Value, 0, p_Value.Length) != p_Value.Length)
      throw new InvalidDataException();
  }
}
