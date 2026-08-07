// Decompiled with JetBrains decompiler
// Type: System.Numerics.BitOperations
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices;

#nullable disable
namespace System.Numerics;

internal static class BitOperations
{
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static uint RotateLeft(uint value, int offset)
  {
    return value << offset | value >> 32 /*0x20*/ - offset;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ulong RotateLeft(ulong value, int offset)
  {
    return value << offset | value >> 64 /*0x40*/ - offset;
  }
}
