// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP224R1Field
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP224R1Field
{
  internal static readonly uint[] P = new uint[7]
  {
    1U,
    0U,
    0U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue
  };
  private static readonly uint[] PExt = new uint[14]
  {
    1U,
    0U,
    0U,
    4294967294U,
    uint.MaxValue,
    uint.MaxValue,
    0U,
    2U,
    0U,
    0U,
    4294967294U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue
  };
  private static readonly uint[] PExtInv = new uint[11]
  {
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    1U,
    0U,
    0U,
    uint.MaxValue,
    4294967293U,
    uint.MaxValue,
    uint.MaxValue,
    1U
  };
  private const uint P6 = 4294967295 /*0xFFFFFFFF*/;
  private const uint PExt13 = 4294967295 /*0xFFFFFFFF*/;

  public static void Add(uint[] x, uint[] y, uint[] z)
  {
    if (Nat224.Add(x, y, z) == 0U && (z[6] != uint.MaxValue || !Nat224.Gte(z, SecP224R1Field.P)))
      return;
    SecP224R1Field.AddPInvTo(z);
  }

  public static void AddExt(uint[] xx, uint[] yy, uint[] zz)
  {
    if (Nat.Add(14, xx, yy, zz) == 0U && (zz[13] != uint.MaxValue || !Nat.Gte(14, zz, SecP224R1Field.PExt)) || Nat.AddTo(SecP224R1Field.PExtInv.Length, SecP224R1Field.PExtInv, zz) == 0U)
      return;
    int num = (int) Nat.IncAt(14, zz, SecP224R1Field.PExtInv.Length);
  }

  public static void AddOne(uint[] x, uint[] z)
  {
    if (Nat.Inc(7, x, z) == 0U && (z[6] != uint.MaxValue || !Nat224.Gte(z, SecP224R1Field.P)))
      return;
    SecP224R1Field.AddPInvTo(z);
  }

  public static uint[] FromBigInteger(BigInteger x)
  {
    uint[] numArray = Nat.FromBigInteger(224 /*0xE0*/, x);
    if (numArray[6] == uint.MaxValue && Nat224.Gte(numArray, SecP224R1Field.P))
      Nat224.SubFrom(SecP224R1Field.P, numArray);
    return numArray;
  }

  public static void Half(uint[] x, uint[] z)
  {
    if (((int) x[0] & 1) == 0)
    {
      int num1 = (int) Nat.ShiftDownBit(7, x, 0U, z);
    }
    else
    {
      uint c = Nat224.Add(x, SecP224R1Field.P, z);
      int num2 = (int) Nat.ShiftDownBit(7, z, c);
    }
  }

  public static void Inv(uint[] x, uint[] z) => Mod.CheckedModOddInverse(SecP224R1Field.P, x, z);

  public static int IsZero(uint[] x)
  {
    uint num = 0;
    for (int index = 0; index < 7; ++index)
      num |= x[index];
    return (int) (num >> 1 | num & 1U) - 1 >> 31 /*0x1F*/;
  }

  public static void Multiply(uint[] x, uint[] y, uint[] z)
  {
    uint[] ext = Nat224.CreateExt();
    Nat224.Mul(x, y, ext);
    SecP224R1Field.Reduce(ext, z);
  }

  public static void MultiplyAddToExt(uint[] x, uint[] y, uint[] zz)
  {
    if (Nat224.MulAddTo(x, y, zz) == 0U && (zz[13] != uint.MaxValue || !Nat.Gte(14, zz, SecP224R1Field.PExt)) || Nat.AddTo(SecP224R1Field.PExtInv.Length, SecP224R1Field.PExtInv, zz) == 0U)
      return;
    int num = (int) Nat.IncAt(14, zz, SecP224R1Field.PExtInv.Length);
  }

  public static void Negate(uint[] x, uint[] z)
  {
    if (SecP224R1Field.IsZero(x) != 0)
      Nat224.Sub(SecP224R1Field.P, SecP224R1Field.P, z);
    else
      Nat224.Sub(SecP224R1Field.P, x, z);
  }

  public static void Random(SecureRandom r, uint[] z)
  {
    byte[] numArray = new byte[28];
    do
    {
      r.NextBytes(numArray);
      Pack.LE_To_UInt32(numArray, 0, z, 0, 7);
    }
    while (Nat.LessThan(7, z, SecP224R1Field.P) == 0);
  }

  public static void RandomMult(SecureRandom r, uint[] z)
  {
    do
    {
      SecP224R1Field.Random(r, z);
    }
    while (SecP224R1Field.IsZero(z) != 0);
  }

  public static void Reduce(uint[] xx, uint[] z)
  {
    long num1 = (long) xx[10];
    long num2 = (long) xx[11];
    long num3 = (long) xx[12];
    long num4 = (long) xx[13];
    long num5 = (long) xx[7] + num2 - 1L;
    long num6 = (long) xx[8] + num3;
    long num7 = (long) xx[9] + num4;
    long num8 = 0L + ((long) xx[0] - num5);
    long num9 = (long) (uint) num8;
    long num10 = (num8 >> 32 /*0x20*/) + ((long) xx[1] - num6);
    z[1] = (uint) num10;
    long num11 = (num10 >> 32 /*0x20*/) + ((long) xx[2] - num7);
    z[2] = (uint) num11;
    long num12 = (num11 >> 32 /*0x20*/) + ((long) xx[3] + num5 - num1);
    long num13 = (long) (uint) num12;
    long num14 = (num12 >> 32 /*0x20*/) + ((long) xx[4] + num6 - num2);
    z[4] = (uint) num14;
    long num15 = (num14 >> 32 /*0x20*/) + ((long) xx[5] + num7 - num3);
    z[5] = (uint) num15;
    long num16 = (num15 >> 32 /*0x20*/) + ((long) xx[6] + num1 - num4);
    z[6] = (uint) num16;
    long num17 = (num16 >> 32 /*0x20*/) + 1L;
    long num18 = num13 + num17;
    long num19 = num9 - num17;
    z[0] = (uint) num19;
    long num20 = num19 >> 32 /*0x20*/;
    if (num20 != 0L)
    {
      long num21 = num20 + (long) z[1];
      z[1] = (uint) num21;
      long num22 = (num21 >> 32 /*0x20*/) + (long) z[2];
      z[2] = (uint) num22;
      num18 += num22 >> 32 /*0x20*/;
    }
    z[3] = (uint) num18;
    if ((num18 >> 32 /*0x20*/ == 0L || Nat.IncAt(7, z, 4) == 0U) && (z[6] != uint.MaxValue || !Nat224.Gte(z, SecP224R1Field.P)))
      return;
    SecP224R1Field.AddPInvTo(z);
  }

  public static void Reduce32(uint x, uint[] z)
  {
    long num1 = 0;
    if (x != 0U)
    {
      long num2 = (long) x;
      long num3 = num1 + ((long) z[0] - num2);
      z[0] = (uint) num3;
      long num4 = num3 >> 32 /*0x20*/;
      if (num4 != 0L)
      {
        long num5 = num4 + (long) z[1];
        z[1] = (uint) num5;
        long num6 = (num5 >> 32 /*0x20*/) + (long) z[2];
        z[2] = (uint) num6;
        num4 = num6 >> 32 /*0x20*/;
      }
      long num7 = num4 + ((long) z[3] + num2);
      z[3] = (uint) num7;
      num1 = num7 >> 32 /*0x20*/;
    }
    if ((num1 == 0L || Nat.IncAt(7, z, 4) == 0U) && (z[6] != uint.MaxValue || !Nat224.Gte(z, SecP224R1Field.P)))
      return;
    SecP224R1Field.AddPInvTo(z);
  }

  public static void Square(uint[] x, uint[] z)
  {
    uint[] ext = Nat224.CreateExt();
    Nat224.Square(x, ext);
    SecP224R1Field.Reduce(ext, z);
  }

  public static void SquareN(uint[] x, int n, uint[] z)
  {
    uint[] ext = Nat224.CreateExt();
    Nat224.Square(x, ext);
    SecP224R1Field.Reduce(ext, z);
    while (--n > 0)
    {
      Nat224.Square(z, ext);
      SecP224R1Field.Reduce(ext, z);
    }
  }

  public static void Subtract(uint[] x, uint[] y, uint[] z)
  {
    if (Nat224.Sub(x, y, z) == 0)
      return;
    SecP224R1Field.SubPInvFrom(z);
  }

  public static void SubtractExt(uint[] xx, uint[] yy, uint[] zz)
  {
    if (Nat.Sub(14, xx, yy, zz) == 0 || Nat.SubFrom(SecP224R1Field.PExtInv.Length, SecP224R1Field.PExtInv, zz) == 0)
      return;
    Nat.DecAt(14, zz, SecP224R1Field.PExtInv.Length);
  }

  public static void Twice(uint[] x, uint[] z)
  {
    if (Nat.ShiftUpBit(7, x, 0U, z) == 0U && (z[6] != uint.MaxValue || !Nat224.Gte(z, SecP224R1Field.P)))
      return;
    SecP224R1Field.AddPInvTo(z);
  }

  private static void AddPInvTo(uint[] z)
  {
    long num1 = (long) z[0] - 1L;
    z[0] = (uint) num1;
    long num2 = num1 >> 32 /*0x20*/;
    if (num2 != 0L)
    {
      long num3 = num2 + (long) z[1];
      z[1] = (uint) num3;
      long num4 = (num3 >> 32 /*0x20*/) + (long) z[2];
      z[2] = (uint) num4;
      num2 = num4 >> 32 /*0x20*/;
    }
    long num5 = num2 + ((long) z[3] + 1L);
    z[3] = (uint) num5;
    if (num5 >> 32 /*0x20*/ == 0L)
      return;
    int num6 = (int) Nat.IncAt(7, z, 4);
  }

  private static void SubPInvFrom(uint[] z)
  {
    long num1 = (long) z[0] + 1L;
    z[0] = (uint) num1;
    long num2 = num1 >> 32 /*0x20*/;
    if (num2 != 0L)
    {
      long num3 = num2 + (long) z[1];
      z[1] = (uint) num3;
      long num4 = (num3 >> 32 /*0x20*/) + (long) z[2];
      z[2] = (uint) num4;
      num2 = num4 >> 32 /*0x20*/;
    }
    long num5 = num2 + ((long) z[3] - 1L);
    z[3] = (uint) num5;
    if (num5 >> 32 /*0x20*/ == 0L)
      return;
    Nat.DecAt(7, z, 4);
  }
}
