// Decompiled with JetBrains decompiler
// Type: System.HashCode
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable enable
namespace System;

[ComVisible(true)]
public struct HashCode
{
  private static readonly uint s_seed = HashCode.GenerateGlobalSeed();
  private const uint Prime1 = 2654435761;
  private const uint Prime2 = 2246822519;
  private const uint Prime3 = 3266489917;
  private const uint Prime4 = 668265263;
  private const uint Prime5 = 374761393;
  private uint _v1;
  private uint _v2;
  private uint _v3;
  private uint _v4;
  private uint _queue1;
  private uint _queue2;
  private uint _queue3;
  private uint _length;

  private static unsafe uint GenerateGlobalSeed()
  {
    uint globalSeed;
    Interop.GetRandomBytes((byte*) &globalSeed, 4);
    return globalSeed;
  }

  public static int Combine<T1>(T1 value1)
  {
    uint hashCode = (object) value1 != null ? (uint) value1.GetHashCode() : 0U;
    return (int) HashCode.MixFinal(HashCode.QueueRound(HashCode.MixEmptyState() + 4U, hashCode));
  }

  public static int Combine<T1, T2>(T1 value1, T2 value2)
  {
    uint hashCode1 = (object) value1 != null ? (uint) value1.GetHashCode() : 0U;
    uint hashCode2 = (object) value2 != null ? (uint) value2.GetHashCode() : 0U;
    return (int) HashCode.MixFinal(HashCode.QueueRound(HashCode.QueueRound(HashCode.MixEmptyState() + 8U, hashCode1), hashCode2));
  }

  public static int Combine<T1, T2, T3>(T1 value1, T2 value2, T3 value3)
  {
    uint hashCode1 = (object) value1 != null ? (uint) value1.GetHashCode() : 0U;
    uint hashCode2 = (object) value2 != null ? (uint) value2.GetHashCode() : 0U;
    uint hashCode3 = (object) value3 != null ? (uint) value3.GetHashCode() : 0U;
    return (int) HashCode.MixFinal(HashCode.QueueRound(HashCode.QueueRound(HashCode.QueueRound(HashCode.MixEmptyState() + 12U, hashCode1), hashCode2), hashCode3));
  }

  public static int Combine<T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3, T4 value4)
  {
    uint hashCode1 = (object) value1 != null ? (uint) value1.GetHashCode() : 0U;
    uint hashCode2 = (object) value2 != null ? (uint) value2.GetHashCode() : 0U;
    uint hashCode3 = (object) value3 != null ? (uint) value3.GetHashCode() : 0U;
    uint hashCode4 = (object) value4 != null ? (uint) value4.GetHashCode() : 0U;
    uint v1_1;
    uint v2;
    uint v3;
    uint v4;
    HashCode.Initialize(out v1_1, out v2, out v3, out v4);
    uint v1_2 = HashCode.Round(v1_1, hashCode1);
    v2 = HashCode.Round(v2, hashCode2);
    v3 = HashCode.Round(v3, hashCode3);
    v4 = HashCode.Round(v4, hashCode4);
    return (int) HashCode.MixFinal(HashCode.MixState(v1_2, v2, v3, v4) + 16U /*0x10*/);
  }

  public static int Combine<T1, T2, T3, T4, T5>(
    T1 value1,
    T2 value2,
    T3 value3,
    T4 value4,
    T5 value5)
  {
    uint hashCode1 = (object) value1 != null ? (uint) value1.GetHashCode() : 0U;
    uint hashCode2 = (object) value2 != null ? (uint) value2.GetHashCode() : 0U;
    uint hashCode3 = (object) value3 != null ? (uint) value3.GetHashCode() : 0U;
    uint hashCode4 = (object) value4 != null ? (uint) value4.GetHashCode() : 0U;
    uint hashCode5 = (object) value5 != null ? (uint) value5.GetHashCode() : 0U;
    uint v1_1;
    uint v2;
    uint v3;
    uint v4;
    HashCode.Initialize(out v1_1, out v2, out v3, out v4);
    uint v1_2 = HashCode.Round(v1_1, hashCode1);
    v2 = HashCode.Round(v2, hashCode2);
    v3 = HashCode.Round(v3, hashCode3);
    v4 = HashCode.Round(v4, hashCode4);
    return (int) HashCode.MixFinal(HashCode.QueueRound(HashCode.MixState(v1_2, v2, v3, v4) + 20U, hashCode5));
  }

  public static int Combine<T1, T2, T3, T4, T5, T6>(
    T1 value1,
    T2 value2,
    T3 value3,
    T4 value4,
    T5 value5,
    T6 value6)
  {
    uint hashCode1 = (object) value1 != null ? (uint) value1.GetHashCode() : 0U;
    uint hashCode2 = (object) value2 != null ? (uint) value2.GetHashCode() : 0U;
    uint hashCode3 = (object) value3 != null ? (uint) value3.GetHashCode() : 0U;
    uint hashCode4 = (object) value4 != null ? (uint) value4.GetHashCode() : 0U;
    uint hashCode5 = (object) value5 != null ? (uint) value5.GetHashCode() : 0U;
    uint hashCode6 = (object) value6 != null ? (uint) value6.GetHashCode() : 0U;
    uint v1_1;
    uint v2;
    uint v3;
    uint v4;
    HashCode.Initialize(out v1_1, out v2, out v3, out v4);
    uint v1_2 = HashCode.Round(v1_1, hashCode1);
    v2 = HashCode.Round(v2, hashCode2);
    v3 = HashCode.Round(v3, hashCode3);
    v4 = HashCode.Round(v4, hashCode4);
    return (int) HashCode.MixFinal(HashCode.QueueRound(HashCode.QueueRound(HashCode.MixState(v1_2, v2, v3, v4) + 24U, hashCode5), hashCode6));
  }

  public static int Combine<T1, T2, T3, T4, T5, T6, T7>(
    T1 value1,
    T2 value2,
    T3 value3,
    T4 value4,
    T5 value5,
    T6 value6,
    T7 value7)
  {
    uint hashCode1 = (object) value1 != null ? (uint) value1.GetHashCode() : 0U;
    uint hashCode2 = (object) value2 != null ? (uint) value2.GetHashCode() : 0U;
    uint hashCode3 = (object) value3 != null ? (uint) value3.GetHashCode() : 0U;
    uint hashCode4 = (object) value4 != null ? (uint) value4.GetHashCode() : 0U;
    uint hashCode5 = (object) value5 != null ? (uint) value5.GetHashCode() : 0U;
    uint hashCode6 = (object) value6 != null ? (uint) value6.GetHashCode() : 0U;
    uint hashCode7 = (object) value7 != null ? (uint) value7.GetHashCode() : 0U;
    uint v1_1;
    uint v2;
    uint v3;
    uint v4;
    HashCode.Initialize(out v1_1, out v2, out v3, out v4);
    uint v1_2 = HashCode.Round(v1_1, hashCode1);
    v2 = HashCode.Round(v2, hashCode2);
    v3 = HashCode.Round(v3, hashCode3);
    v4 = HashCode.Round(v4, hashCode4);
    return (int) HashCode.MixFinal(HashCode.QueueRound(HashCode.QueueRound(HashCode.QueueRound(HashCode.MixState(v1_2, v2, v3, v4) + 28U, hashCode5), hashCode6), hashCode7));
  }

  public static int Combine<T1, T2, T3, T4, T5, T6, T7, T8>(
    T1 value1,
    T2 value2,
    T3 value3,
    T4 value4,
    T5 value5,
    T6 value6,
    T7 value7,
    T8 value8)
  {
    uint hashCode1 = (object) value1 != null ? (uint) value1.GetHashCode() : 0U;
    uint hashCode2 = (object) value2 != null ? (uint) value2.GetHashCode() : 0U;
    uint hashCode3 = (object) value3 != null ? (uint) value3.GetHashCode() : 0U;
    uint hashCode4 = (object) value4 != null ? (uint) value4.GetHashCode() : 0U;
    uint hashCode5 = (object) value5 != null ? (uint) value5.GetHashCode() : 0U;
    uint hashCode6 = (object) value6 != null ? (uint) value6.GetHashCode() : 0U;
    uint hashCode7 = (object) value7 != null ? (uint) value7.GetHashCode() : 0U;
    uint hashCode8 = (object) value8 != null ? (uint) value8.GetHashCode() : 0U;
    uint v1_1;
    uint v2;
    uint v3;
    uint v4;
    HashCode.Initialize(out v1_1, out v2, out v3, out v4);
    uint hash = HashCode.Round(v1_1, hashCode1);
    v2 = HashCode.Round(v2, hashCode2);
    v3 = HashCode.Round(v3, hashCode3);
    v4 = HashCode.Round(v4, hashCode4);
    uint v1_2 = HashCode.Round(hash, hashCode5);
    v2 = HashCode.Round(v2, hashCode6);
    v3 = HashCode.Round(v3, hashCode7);
    v4 = HashCode.Round(v4, hashCode8);
    return (int) HashCode.MixFinal(HashCode.MixState(v1_2, v2, v3, v4) + 32U /*0x20*/);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static void Initialize(out uint v1, out uint v2, out uint v3, out uint v4)
  {
    v1 = (uint) ((int) HashCode.s_seed - 1640531535 - 2048144777);
    v2 = HashCode.s_seed + 2246822519U;
    v3 = HashCode.s_seed;
    v4 = HashCode.s_seed - 2654435761U;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint Round(uint hash, uint input)
  {
    return BitOperations.RotateLeft(hash + input * 2246822519U, 13) * 2654435761U;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint QueueRound(uint hash, uint queuedValue)
  {
    return BitOperations.RotateLeft(hash + queuedValue * 3266489917U, 17) * 668265263U;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint MixState(uint v1, uint v2, uint v3, uint v4)
  {
    return BitOperations.RotateLeft(v1, 1) + BitOperations.RotateLeft(v2, 7) + BitOperations.RotateLeft(v3, 12) + BitOperations.RotateLeft(v4, 18);
  }

  private static uint MixEmptyState() => HashCode.s_seed + 374761393U;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint MixFinal(uint hash)
  {
    hash ^= hash >> 15;
    hash *= 2246822519U;
    hash ^= hash >> 13;
    hash *= 3266489917U;
    hash ^= hash >> 16 /*0x10*/;
    return hash;
  }

  public void Add<T>(T value) => this.Add((object) value != null ? value.GetHashCode() : 0);

  public void Add<T>(T value, IEqualityComparer<T>? comparer)
  {
    this.Add(comparer != null ? comparer.GetHashCode(value) : ((object) value != null ? value.GetHashCode() : 0));
  }

  private void Add(int value)
  {
    uint input = (uint) value;
    uint num = this._length++;
    switch (num % 4U)
    {
      case 0:
        this._queue1 = input;
        break;
      case 1:
        this._queue2 = input;
        break;
      case 2:
        this._queue3 = input;
        break;
      default:
        if (num == 3U)
          HashCode.Initialize(out this._v1, out this._v2, out this._v3, out this._v4);
        this._v1 = HashCode.Round(this._v1, this._queue1);
        this._v2 = HashCode.Round(this._v2, this._queue2);
        this._v3 = HashCode.Round(this._v3, this._queue3);
        this._v4 = HashCode.Round(this._v4, input);
        break;
    }
  }

  public int ToHashCode()
  {
    uint length = this._length;
    uint num = length % 4U;
    uint hash = (length < 4U ? HashCode.MixEmptyState() : HashCode.MixState(this._v1, this._v2, this._v3, this._v4)) + length * 4U;
    if (num > 0U)
    {
      hash = HashCode.QueueRound(hash, this._queue1);
      if (num > 1U)
      {
        hash = HashCode.QueueRound(hash, this._queue2);
        if (num > 2U)
          hash = HashCode.QueueRound(hash, this._queue3);
      }
    }
    return (int) HashCode.MixFinal(hash);
  }

  [Obsolete("HashCode is a mutable struct and should not be compared with other HashCodes. Use ToHashCode to retrieve the computed hash code.", true)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public override int GetHashCode()
  {
    throw new NotSupportedException(SR.HashCode_HashCodeNotSupported);
  }

  [Obsolete("HashCode is a mutable struct and should not be compared with other HashCodes.", true)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public override bool Equals(object? obj)
  {
    throw new NotSupportedException(SR.HashCode_EqualityNotSupported);
  }
}
