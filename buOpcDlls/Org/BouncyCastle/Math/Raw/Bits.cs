// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.Raw.Bits
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Math.Raw;

internal static class Bits
{
  internal static uint BitPermuteStep(uint x, uint m, int s)
  {
    int num = ((int) x ^ (int) (x >> s)) & (int) m;
    return (uint) (num ^ num << s) ^ x;
  }

  internal static ulong BitPermuteStep(ulong x, ulong m, int s)
  {
    long num = ((long) x ^ (long) (x >> s)) & (long) m;
    return (ulong) (num ^ num << s) ^ x;
  }

  internal static void BitPermuteStep2(ref uint hi, ref uint lo, uint m, int s)
  {
    uint num = (lo >> s ^ hi) & m;
    lo ^= num << s;
    hi ^= num;
  }

  internal static void BitPermuteStep2(ref ulong hi, ref ulong lo, ulong m, int s)
  {
    ulong num = (lo >> s ^ hi) & m;
    lo ^= num << s;
    hi ^= num;
  }

  internal static uint BitPermuteStepSimple(uint x, uint m, int s)
  {
    return (uint) (((int) x & (int) m) << s | (int) (x >> s) & (int) m);
  }

  internal static ulong BitPermuteStepSimple(ulong x, ulong m, int s)
  {
    return (ulong) (((long) x & (long) m) << s | (long) (x >> s) & (long) m);
  }
}
