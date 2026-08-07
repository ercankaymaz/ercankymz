// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.Raw.Nat448
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;

#nullable disable
namespace Org.BouncyCastle.Math.Raw;

internal static class Nat448
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
  }

  public static ulong[] Create64() => new ulong[7];

  public static ulong[] CreateExt64() => new ulong[14];

  public static bool Eq64(ulong[] x, ulong[] y)
  {
    for (int index = 6; index >= 0; --index)
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
    for (int index = 1; index < 7; ++index)
    {
      if (x[index] != 0UL)
        return false;
    }
    return true;
  }

  public static bool IsZero64(ulong[] x)
  {
    for (int index = 0; index < 7; ++index)
    {
      if (x[index] != 0UL)
        return false;
    }
    return true;
  }

  public static void Mul(uint[] x, uint[] y, uint[] zz)
  {
    Nat224.Mul(x, y, zz);
    Nat224.Mul(x, 7, y, 7, zz, 14);
    uint eachOther = Nat224.AddToEachOther(zz, 7, zz, 14);
    uint cIn = eachOther + Nat224.AddTo(zz, 0, zz, 7, 0U);
    uint num1 = eachOther + Nat224.AddTo(zz, 21, zz, 14, cIn);
    uint[] numArray1 = Nat224.Create();
    uint[] numArray2 = Nat224.Create();
    bool flag = Nat224.Diff(x, 7, x, 0, numArray1, 0) != Nat224.Diff(y, 7, y, 0, numArray2, 0);
    uint[] ext = Nat224.CreateExt();
    Nat224.Mul(numArray1, numArray2, ext);
    int num2 = (int) Nat.AddWordAt(28, num1 + (flag ? Nat.AddTo(14, ext, 0, zz, 7) : (uint) Nat.SubFrom(14, ext, 0, zz, 7)), zz, 21);
  }

  public static void Square(uint[] x, uint[] zz)
  {
    Nat224.Square(x, zz);
    Nat224.Square(x, 7, zz, 14);
    uint eachOther = Nat224.AddToEachOther(zz, 7, zz, 14);
    uint cIn = eachOther + Nat224.AddTo(zz, 0, zz, 7, 0U);
    uint num1 = eachOther + Nat224.AddTo(zz, 21, zz, 14, cIn);
    uint[] numArray = Nat224.Create();
    Nat224.Diff(x, 7, x, 0, numArray, 0);
    uint[] ext = Nat224.CreateExt();
    Nat224.Square(numArray, ext);
    int num2 = (int) Nat.AddWordAt(28, num1 + (uint) Nat.SubFrom(14, ext, 0, zz, 7), zz, 21);
  }

  public static BigInteger ToBigInteger64(ulong[] x)
  {
    byte[] numArray = new byte[56];
    for (int index = 0; index < 7; ++index)
    {
      ulong n = x[index];
      if (n != 0UL)
        Pack.UInt64_To_BE(n, numArray, 6 - index << 3);
    }
    return new BigInteger(1, numArray);
  }
}
