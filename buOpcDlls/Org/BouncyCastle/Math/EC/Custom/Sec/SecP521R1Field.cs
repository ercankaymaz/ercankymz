// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP521R1Field
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP521R1Field
{
  internal static readonly uint[] P = new uint[17]
  {
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    511U /*0x01FF*/
  };
  private const uint P16 = 511 /*0x01FF*/;

  public static void Add(uint[] x, uint[] y, uint[] z)
  {
    uint num = Nat.Add(16 /*0x10*/, x, y, z) + x[16 /*0x10*/] + y[16 /*0x10*/];
    if (num > 511U /*0x01FF*/ || num == 511U /*0x01FF*/ && Nat.Eq(16 /*0x10*/, z, SecP521R1Field.P))
      num = num + Nat.Inc(16 /*0x10*/, z) & 511U /*0x01FF*/;
    z[16 /*0x10*/] = num;
  }

  public static void AddOne(uint[] x, uint[] z)
  {
    uint num = Nat.Inc(16 /*0x10*/, x, z) + x[16 /*0x10*/];
    if (num > 511U /*0x01FF*/ || num == 511U /*0x01FF*/ && Nat.Eq(16 /*0x10*/, z, SecP521R1Field.P))
      num = num + Nat.Inc(16 /*0x10*/, z) & 511U /*0x01FF*/;
    z[16 /*0x10*/] = num;
  }

  public static uint[] FromBigInteger(BigInteger x)
  {
    uint[] numArray = Nat.FromBigInteger(521, x);
    if (Nat.Eq(17, numArray, SecP521R1Field.P))
      Nat.Zero(17, numArray);
    return numArray;
  }

  public static void Half(uint[] x, uint[] z)
  {
    uint c = x[16 /*0x10*/];
    uint num = Nat.ShiftDownBit(16 /*0x10*/, x, c, z);
    z[16 /*0x10*/] = c >> 1 | num >> 23;
  }

  public static void Inv(uint[] x, uint[] z) => Mod.CheckedModOddInverse(SecP521R1Field.P, x, z);

  public static int IsZero(uint[] x)
  {
    uint num = 0;
    for (int index = 0; index < 17; ++index)
      num |= x[index];
    return (int) (num >> 1 | num & 1U) - 1 >> 31 /*0x1F*/;
  }

  public static void Multiply(uint[] x, uint[] y, uint[] z)
  {
    uint[] numArray = Nat.Create(33);
    SecP521R1Field.ImplMultiply(x, y, numArray);
    SecP521R1Field.Reduce(numArray, z);
  }

  public static void Multiply(uint[] x, uint[] y, uint[] z, uint[] tt)
  {
    SecP521R1Field.ImplMultiply(x, y, tt);
    SecP521R1Field.Reduce(tt, z);
  }

  public static void Negate(uint[] x, uint[] z)
  {
    if (SecP521R1Field.IsZero(x) != 0)
      Nat.Sub(17, SecP521R1Field.P, SecP521R1Field.P, z);
    else
      Nat.Sub(17, SecP521R1Field.P, x, z);
  }

  public static void Random(SecureRandom r, uint[] z)
  {
    byte[] numArray = new byte[68];
    do
    {
      r.NextBytes(numArray);
      Pack.LE_To_UInt32(numArray, 0, z, 0, 17);
      z[16 /*0x10*/] &= 511U /*0x01FF*/;
    }
    while (Nat.LessThan(17, z, SecP521R1Field.P) == 0);
  }

  public static void RandomMult(SecureRandom r, uint[] z)
  {
    do
    {
      SecP521R1Field.Random(r, z);
    }
    while (SecP521R1Field.IsZero(z) != 0);
  }

  public static void Reduce(uint[] xx, uint[] z)
  {
    uint c = xx[32 /*0x20*/];
    uint num = (Nat.ShiftDownBits(16 /*0x10*/, xx, 16 /*0x10*/, 9, c, z, 0) >> 23) + (c >> 9) + Nat.AddTo(16 /*0x10*/, xx, z);
    if (num > 511U /*0x01FF*/ || num == 511U /*0x01FF*/ && Nat.Eq(16 /*0x10*/, z, SecP521R1Field.P))
      num = num + Nat.Inc(16 /*0x10*/, z) & 511U /*0x01FF*/;
    z[16 /*0x10*/] = num;
  }

  public static void Reduce23(uint[] z)
  {
    uint num1 = z[16 /*0x10*/];
    uint num2 = Nat.AddWordTo(16 /*0x10*/, num1 >> 9, z) + (num1 & 511U /*0x01FF*/);
    if (num2 > 511U /*0x01FF*/ || num2 == 511U /*0x01FF*/ && Nat.Eq(16 /*0x10*/, z, SecP521R1Field.P))
      num2 = num2 + Nat.Inc(16 /*0x10*/, z) & 511U /*0x01FF*/;
    z[16 /*0x10*/] = num2;
  }

  public static void Square(uint[] x, uint[] z)
  {
    uint[] numArray = Nat.Create(33);
    SecP521R1Field.ImplSquare(x, numArray);
    SecP521R1Field.Reduce(numArray, z);
  }

  public static void Square(uint[] x, uint[] z, uint[] tt)
  {
    SecP521R1Field.ImplSquare(x, tt);
    SecP521R1Field.Reduce(tt, z);
  }

  public static void SquareN(uint[] x, int n, uint[] z)
  {
    uint[] numArray = Nat.Create(33);
    SecP521R1Field.ImplSquare(x, numArray);
    SecP521R1Field.Reduce(numArray, z);
    while (--n > 0)
    {
      SecP521R1Field.ImplSquare(z, numArray);
      SecP521R1Field.Reduce(numArray, z);
    }
  }

  public static void SquareN(uint[] x, int n, uint[] z, uint[] tt)
  {
    SecP521R1Field.ImplSquare(x, tt);
    SecP521R1Field.Reduce(tt, z);
    while (--n > 0)
    {
      SecP521R1Field.ImplSquare(z, tt);
      SecP521R1Field.Reduce(tt, z);
    }
  }

  public static void Subtract(uint[] x, uint[] y, uint[] z)
  {
    int num = Nat.Sub(16 /*0x10*/, x, y, z) + ((int) x[16 /*0x10*/] - (int) y[16 /*0x10*/]);
    if (num < 0)
      num = num + Nat.Dec(16 /*0x10*/, z) & 511 /*0x01FF*/;
    z[16 /*0x10*/] = (uint) num;
  }

  public static void Twice(uint[] x, uint[] z)
  {
    uint num1 = x[16 /*0x10*/];
    uint num2 = Nat.ShiftUpBit(16 /*0x10*/, x, num1 << 23, z) | num1 << 1;
    z[16 /*0x10*/] = num2 & 511U /*0x01FF*/;
  }

  protected static void ImplMultiply(uint[] x, uint[] y, uint[] zz)
  {
    Nat512.Mul(x, y, zz);
    uint a = x[16 /*0x10*/];
    uint b = y[16 /*0x10*/];
    zz[32 /*0x20*/] = Nat.Mul31BothAdd(16 /*0x10*/, a, y, b, x, zz, 16 /*0x10*/) + a * b;
  }

  protected static void ImplSquare(uint[] x, uint[] zz)
  {
    Nat512.Square(x, zz);
    uint num = x[16 /*0x10*/];
    zz[32 /*0x20*/] = Nat.MulWordAddTo(16 /*0x10*/, num << 1, x, 0, zz, 16 /*0x10*/) + num * num;
  }
}
