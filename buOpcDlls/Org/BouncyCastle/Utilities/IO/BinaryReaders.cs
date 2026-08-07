// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.IO.BinaryReaders
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.IO;

public static class BinaryReaders
{
  public static byte[] ReadBytesFully(BinaryReader binaryReader, int count)
  {
    byte[] numArray = binaryReader.ReadBytes(count);
    if (numArray == null || numArray.Length != count)
      throw new EndOfStreamException();
    return numArray;
  }

  public static short ReadInt16BigEndian(BinaryReader binaryReader)
  {
    short i = binaryReader.ReadInt16();
    return !BitConverter.IsLittleEndian ? i : Shorts.ReverseBytes(i);
  }

  public static short ReadInt16LittleEndian(BinaryReader binaryReader)
  {
    short i = binaryReader.ReadInt16();
    return !BitConverter.IsLittleEndian ? Shorts.ReverseBytes(i) : i;
  }

  public static int ReadInt32BigEndian(BinaryReader binaryReader)
  {
    int i = binaryReader.ReadInt32();
    return !BitConverter.IsLittleEndian ? i : Integers.ReverseBytes(i);
  }

  public static int ReadInt32LittleEndian(BinaryReader binaryReader)
  {
    int i = binaryReader.ReadInt32();
    return !BitConverter.IsLittleEndian ? Integers.ReverseBytes(i) : i;
  }

  public static long ReadInt64BigEndian(BinaryReader binaryReader)
  {
    long i = binaryReader.ReadInt64();
    return !BitConverter.IsLittleEndian ? i : Longs.ReverseBytes(i);
  }

  public static long ReadInt64LittleEndian(BinaryReader binaryReader)
  {
    long i = binaryReader.ReadInt64();
    return !BitConverter.IsLittleEndian ? Longs.ReverseBytes(i) : i;
  }

  [CLSCompliant(false)]
  public static ushort ReadUInt16BigEndian(BinaryReader binaryReader)
  {
    ushort i = binaryReader.ReadUInt16();
    return !BitConverter.IsLittleEndian ? i : Shorts.ReverseBytes(i);
  }

  [CLSCompliant(false)]
  public static ushort ReadUInt16LittleEndian(BinaryReader binaryReader)
  {
    ushort i = binaryReader.ReadUInt16();
    return !BitConverter.IsLittleEndian ? Shorts.ReverseBytes(i) : i;
  }

  [CLSCompliant(false)]
  public static uint ReadUInt32BigEndian(BinaryReader binaryReader)
  {
    uint i = binaryReader.ReadUInt32();
    return !BitConverter.IsLittleEndian ? i : Integers.ReverseBytes(i);
  }

  [CLSCompliant(false)]
  public static uint ReadUInt32LittleEndian(BinaryReader binaryReader)
  {
    uint i = binaryReader.ReadUInt32();
    return !BitConverter.IsLittleEndian ? Integers.ReverseBytes(i) : i;
  }

  [CLSCompliant(false)]
  public static ulong ReadUInt64BigEndian(BinaryReader binaryReader)
  {
    ulong i = binaryReader.ReadUInt64();
    return !BitConverter.IsLittleEndian ? i : Longs.ReverseBytes(i);
  }

  [CLSCompliant(false)]
  public static ulong ReadUInt64LittleEndian(BinaryReader binaryReader)
  {
    ulong i = binaryReader.ReadUInt64();
    return !BitConverter.IsLittleEndian ? Longs.ReverseBytes(i) : i;
  }
}
