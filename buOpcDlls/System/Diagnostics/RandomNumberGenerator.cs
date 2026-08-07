// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.RandomNumberGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Security;

#nullable disable
namespace System.Diagnostics;

internal sealed class RandomNumberGenerator
{
  [ThreadStatic]
  private static RandomNumberGenerator t_random;
  private ulong _s0;
  private ulong _s1;
  private ulong _s2;
  private ulong _s3;

  public static RandomNumberGenerator Current
  {
    get
    {
      if (RandomNumberGenerator.t_random == null)
        RandomNumberGenerator.t_random = new RandomNumberGenerator();
      return RandomNumberGenerator.t_random;
    }
  }

  [SecuritySafeCritical]
  public unsafe RandomNumberGenerator()
  {
    do
    {
      Guid guid1 = Guid.NewGuid();
      Guid guid2 = Guid.NewGuid();
      ulong* numPtr1 = (ulong*) &guid1;
      ulong* numPtr2 = (ulong*) &guid2;
      this._s0 = *numPtr1;
      this._s1 = numPtr1[1];
      this._s2 = *numPtr2;
      this._s3 = numPtr2[1];
      this._s0 = (ulong) ((long) this._s0 & 1152921504606846975L /*0x0FFFFFFFFFFFFFFF*/ | (long) this._s1 & -1152921504606846976L /*0xF000000000000000*/);
      this._s2 = (ulong) ((long) this._s2 & 1152921504606846975L /*0x0FFFFFFFFFFFFFFF*/ | (long) this._s3 & -1152921504606846976L /*0xF000000000000000*/);
      this._s1 = (ulong) ((long) this._s1 & -193L | (long) this._s0 & 192L /*0xC0*/);
      this._s3 = (ulong) ((long) this._s3 & -193L | (long) this._s2 & 192L /*0xC0*/);
    }
    while (((long) this._s0 | (long) this._s1 | (long) this._s2 | (long) this._s3) == 0L);
  }

  private ulong Rol64(ulong x, int k) => x << k | x >> 64 /*0x40*/ - k;

  public long Next()
  {
    ulong num1 = this.Rol64(this._s1 * 5UL, 7) * 9UL;
    ulong num2 = this._s1 << 17;
    this._s2 ^= this._s0;
    this._s3 ^= this._s1;
    this._s1 ^= this._s2;
    this._s0 ^= this._s3;
    this._s2 ^= num2;
    this._s3 = this.Rol64(this._s3, 45);
    return (long) num1;
  }
}
