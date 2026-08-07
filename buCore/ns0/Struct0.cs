// Decompiled with JetBrains decompiler
// Type: ns0.Struct0
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace ns0;

internal struct Struct0(long long_1, ulong ulong_1)
{
  private long long_0 = long_1;
  private ulong ulong_0 = ulong_1;

  [SpecialName]
  public static bool smethod_0(Struct0 struct0_0, Struct0 struct0_1)
  {
    return (ValueType) struct0_0 == (ValueType) struct0_1 || ((ValueType) struct0_0 == null ? 1 : ((ValueType) struct0_1 == null ? 1 : 0)) == 0 && struct0_0.long_0 == struct0_1.long_0 && (long) struct0_0.ulong_0 == (long) struct0_1.ulong_0;
  }

  virtual bool ValueType.Equals(object obj)
  {
    bool flag;
    if ((obj == null ? 1 : (!(obj is Struct0) ? 1 : 0)) != 0)
    {
      flag = false;
    }
    else
    {
      Struct0 struct0 = (Struct0) obj;
      flag = struct0.long_0 == this.long_0 && (long) struct0.ulong_0 == (long) this.ulong_0;
    }
    return flag;
  }

  virtual int ValueType.GetHashCode() => this.long_0.GetHashCode() ^ this.ulong_0.GetHashCode();

  [SpecialName]
  public static Struct0 smethod_1(Struct0 struct0_0)
  {
    return struct0_0.ulong_0 != 0UL ? new Struct0(~struct0_0.long_0, (ulong) (~(long) struct0_0.ulong_0 + 1L)) : new Struct0(-struct0_0.long_0, 0UL);
  }

  public static Struct0 smethod_2(long long_1, long long_2)
  {
    bool flag = long_1 < 0L != long_2 < 0L;
    if (long_1 < 0L)
      long_1 = -long_1;
    if (long_2 < 0L)
      long_2 = -long_2;
    ulong num1 = (ulong) (long_1 >>> 32 /*0x20*/);
    ulong num2 = (ulong) (long_1 & (long) uint.MaxValue);
    ulong num3 = (ulong) (long_2 >>> 32 /*0x20*/);
    ulong num4 = (ulong) (long_2 & (long) uint.MaxValue);
    ulong num5 = num1 * num3;
    ulong num6 = num2 * num4;
    ulong num7 = (ulong) ((long) num1 * (long) num4 + (long) num2 * (long) num3);
    long long_1_1 = (long) num5 + (long) (num7 >> 32 /*0x20*/);
    ulong ulong_1 = (num7 << 32 /*0x20*/) + num6;
    if (ulong_1 < num6)
      ++long_1_1;
    Struct0 struct0_0 = new Struct0(long_1_1, ulong_1);
    return flag ? Struct0.smethod_1(struct0_0) : struct0_0;
  }
}
