// Decompiled with JetBrains decompiler
// Type: System.Numerics.ConstantHelper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices;

#nullable disable
namespace System.Numerics;

internal class ConstantHelper
{
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static byte GetByteWithAllBitsSet()
  {
    byte byteWithAllBitsSet = 0;
    byteWithAllBitsSet = byte.MaxValue;
    return byteWithAllBitsSet;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static sbyte GetSByteWithAllBitsSet()
  {
    sbyte sbyteWithAllBitsSet = 0;
    sbyteWithAllBitsSet = (sbyte) -1;
    return sbyteWithAllBitsSet;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ushort GetUInt16WithAllBitsSet()
  {
    ushort uint16WithAllBitsSet = 0;
    uint16WithAllBitsSet = ushort.MaxValue;
    return uint16WithAllBitsSet;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static short GetInt16WithAllBitsSet()
  {
    short int16WithAllBitsSet = 0;
    int16WithAllBitsSet = (short) -1;
    return int16WithAllBitsSet;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static uint GetUInt32WithAllBitsSet()
  {
    uint uint32WithAllBitsSet = 0;
    uint32WithAllBitsSet = uint.MaxValue;
    return uint32WithAllBitsSet;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int GetInt32WithAllBitsSet()
  {
    int int32WithAllBitsSet = 0;
    int32WithAllBitsSet = -1;
    return int32WithAllBitsSet;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ulong GetUInt64WithAllBitsSet()
  {
    ulong uint64WithAllBitsSet = 0;
    uint64WithAllBitsSet = ulong.MaxValue;
    return uint64WithAllBitsSet;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static long GetInt64WithAllBitsSet()
  {
    long int64WithAllBitsSet = 0;
    int64WithAllBitsSet = -1L;
    return int64WithAllBitsSet;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe float GetSingleWithAllBitsSet()
  {
    float singleWithAllBitsSet = 0.0f;
    *(int*) &singleWithAllBitsSet = -1;
    return singleWithAllBitsSet;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe double GetDoubleWithAllBitsSet()
  {
    double doubleWithAllBitsSet = 0.0;
    *(long*) &doubleWithAllBitsSet = -1L;
    return doubleWithAllBitsSet;
  }
}
