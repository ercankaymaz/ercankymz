// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Shorts
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Utilities;

public static class Shorts
{
  public const int NumBits = 16 /*0x10*/;
  public const int NumBytes = 2;

  public static short ReverseBytes(short i) => Shorts.RotateLeft(i, 8);

  [CLSCompliant(false)]
  public static ushort ReverseBytes(ushort i) => Shorts.RotateLeft(i, 8);

  public static short RotateLeft(short i, int distance)
  {
    return (short) Shorts.RotateLeft((ushort) i, distance);
  }

  [CLSCompliant(false)]
  public static ushort RotateLeft(ushort i, int distance)
  {
    return (ushort) ((int) i << distance | (int) i >> 16 /*0x10*/ - distance);
  }

  public static short RotateRight(short i, int distance)
  {
    return (short) Shorts.RotateRight((ushort) i, distance);
  }

  [CLSCompliant(false)]
  public static ushort RotateRight(ushort i, int distance)
  {
    return (ushort) ((int) i >> distance | (int) i << 16 /*0x10*/ - distance);
  }
}
