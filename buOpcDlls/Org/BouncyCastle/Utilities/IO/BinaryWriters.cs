// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.IO.BinaryWriters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.IO;

public static class BinaryWriters
{
  public static void WriteInt16BigEndian(BinaryWriter binaryWriter, short n)
  {
    short num = BitConverter.IsLittleEndian ? Shorts.ReverseBytes(n) : n;
    binaryWriter.Write(num);
  }

  public static void WriteInt16LittleEndian(BinaryWriter binaryWriter, short n)
  {
    short num = BitConverter.IsLittleEndian ? n : Shorts.ReverseBytes(n);
    binaryWriter.Write(num);
  }

  public static void WriteInt32BigEndian(BinaryWriter binaryWriter, int n)
  {
    int num = BitConverter.IsLittleEndian ? Integers.ReverseBytes(n) : n;
    binaryWriter.Write(num);
  }

  public static void WriteInt32LittleEndian(BinaryWriter binaryWriter, int n)
  {
    int num = BitConverter.IsLittleEndian ? n : Integers.ReverseBytes(n);
    binaryWriter.Write(num);
  }

  public static void WriteInt64BigEndian(BinaryWriter binaryWriter, long n)
  {
    long num = BitConverter.IsLittleEndian ? Longs.ReverseBytes(n) : n;
    binaryWriter.Write(num);
  }

  public static void WriteInt64LittleEndian(BinaryWriter binaryWriter, long n)
  {
    long num = BitConverter.IsLittleEndian ? n : Longs.ReverseBytes(n);
    binaryWriter.Write(num);
  }

  [CLSCompliant(false)]
  public static void WriteUInt16BigEndian(BinaryWriter binaryWriter, ushort n)
  {
    ushort num = BitConverter.IsLittleEndian ? Shorts.ReverseBytes(n) : n;
    binaryWriter.Write(num);
  }

  [CLSCompliant(false)]
  public static void WriteUInt16LittleEndian(BinaryWriter binaryWriter, ushort n)
  {
    ushort num = BitConverter.IsLittleEndian ? n : Shorts.ReverseBytes(n);
    binaryWriter.Write(num);
  }

  [CLSCompliant(false)]
  public static void WriteUInt32BigEndian(BinaryWriter binaryWriter, uint n)
  {
    uint num = BitConverter.IsLittleEndian ? Integers.ReverseBytes(n) : n;
    binaryWriter.Write(num);
  }

  [CLSCompliant(false)]
  public static void WriteUInt32LittleEndian(BinaryWriter binaryWriter, uint n)
  {
    uint num = BitConverter.IsLittleEndian ? n : Integers.ReverseBytes(n);
    binaryWriter.Write(num);
  }

  [CLSCompliant(false)]
  public static void WriteUInt64BigEndian(BinaryWriter binaryWriter, ulong n)
  {
    ulong num = BitConverter.IsLittleEndian ? Longs.ReverseBytes(n) : n;
    binaryWriter.Write(num);
  }

  [CLSCompliant(false)]
  public static void WriteUInt64LittleEndian(BinaryWriter binaryWriter, ulong n)
  {
    ulong num = BitConverter.IsLittleEndian ? n : Longs.ReverseBytes(n);
    binaryWriter.Write(num);
  }
}
