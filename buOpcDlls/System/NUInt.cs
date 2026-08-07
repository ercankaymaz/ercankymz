// Decompiled with JetBrains decompiler
// Type: System.NUInt
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices;

#nullable disable
namespace System;

internal struct NUInt
{
  private readonly unsafe void* _value;

  private unsafe NUInt(uint value) => this._value = (void*) value;

  private unsafe NUInt(ulong value) => this._value = (void*) value;

  public static implicit operator NUInt(uint value) => new NUInt(value);

  public static unsafe implicit operator IntPtr(NUInt value) => (IntPtr) value._value;

  public static explicit operator NUInt(int value) => new NUInt((uint) value);

  public static unsafe explicit operator void*(NUInt value) => value._value;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static unsafe NUInt operator *(NUInt left, NUInt right)
  {
    return sizeof (IntPtr) != 4 ? new NUInt((ulong) left._value * (ulong) right._value) : new NUInt((uint) left._value * (uint) right._value);
  }
}
