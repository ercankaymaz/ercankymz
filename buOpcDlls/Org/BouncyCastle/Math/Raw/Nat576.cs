// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.Raw.Nat576
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;

#nullable disable
namespace Org.BouncyCastle.Math.Raw;

internal static class Nat576
{
  public static void Copy64(ulong[] x, ulong[] z)
  {
    z[0] = x[0];
    z[1] = x[1];
    z[2] = x[2];
    z[3] = x[3];
    z[4] = x[4];
    z[5] = x[5];
    z[6] = x[6];
    z[7] = x[7];
    z[8] = x[8];
  }

  public static void Copy64(ulong[] x, int xOff, ulong[] z, int zOff)
  {
    z[zOff] = x[xOff];
    z[zOff + 1] = x[xOff + 1];
    z[zOff + 2] = x[xOff + 2];
    z[zOff + 3] = x[xOff + 3];
    z[zOff + 4] = x[xOff + 4];
    z[zOff + 5] = x[xOff + 5];
    z[zOff + 6] = x[xOff + 6];
    z[zOff + 7] = x[xOff + 7];
    z[zOff + 8] = x[xOff + 8];
  }

  public static ulong[] Create64() => new ulong[9];

  public static ulong[] CreateExt64() => new ulong[18];

  public static bool Eq64(ulong[] x, ulong[] y)
  {
    for (int index = 8; index >= 0; --index)
    {
      if ((long) x[index] != (long) y[index])
        return false;
    }
    return true;
  }

  public static bool IsOne64(ulong[] x)
  {
    if (x[0] != 1UL)
      return false;
    for (int index = 1; index < 9; ++index)
    {
      if (x[index] != 0UL)
        return false;
    }
    return true;
  }

  public static bool IsZero64(ulong[] x)
  {
    for (int index = 0; index < 9; ++index)
    {
      if (x[index] != 0UL)
        return false;
    }
    return true;
  }

  public static BigInteger ToBigInteger64(ulong[] x)
  {
    byte[] numArray = new byte[72];
    for (int index = 0; index < 9; ++index)
    {
      ulong n = x[index];
      if (n != 0UL)
        Pack.UInt64_To_BE(n, numArray, 8 - index << 3);
    }
    return new BigInteger(1, numArray);
  }
}
