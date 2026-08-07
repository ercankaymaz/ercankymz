// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP192R1Field
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP192R1Field
{
  internal static readonly uint[] P = new uint[6]
  {
    uint.MaxValue,
    uint.MaxValue,
    4294967294U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue
  };
  private static readonly uint[] PExt = new uint[12]
  {
    1U,
    0U,
    2U,
    0U,
    1U,
    0U,
    4294967294U,
    uint.MaxValue,
    4294967293U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue
  };
  private static readonly uint[] PExtInv = new uint[9]
  {
    uint.MaxValue,
    uint.MaxValue,
    4294967293U,
    uint.MaxValue,
    4294967294U,
    uint.MaxValue,
    1U,
    0U,
    2U
  };
  private const uint P5 = 4294967295 /*0xFFFFFFFF*/;
  private const uint PExt11 = 4294967295 /*0xFFFFFFFF*/;

  public static void Add(uint[] x, uint[] y, uint[] z)
  {
    if (Nat192.Add(x, y, z) == 0U && (z[5] != uint.MaxValue || !Nat192.Gte(z, SecP192R1Field.P)))
      return;
    SecP192R1Field.AddPInvTo(z);
  }

  public static void AddExt(uint[] xx, uint[] yy, uint[] zz)
  {
    if (Nat.Add(12, xx, yy, zz) == 0U && (zz[11] != uint.MaxValue || !Nat.Gte(12, zz, SecP192R1Field.PExt)) || Nat.AddTo(SecP192R1Field.PExtInv.Length, SecP192R1Field.PExtInv, zz) == 0U)
      return;
    int num = (int) Nat.IncAt(12, zz, SecP192R1Field.PExtInv.Length);
  }

  public static void AddOne(uint[] x, uint[] z)
  {
    if (Nat.Inc(6, x, z) == 0U && (z[5] != uint.MaxValue || !Nat192.Gte(z, SecP192R1Field.P)))
      return;
    SecP192R1Field.AddPInvTo(z);
  }

  public static uint[] FromBigInteger(BigInteger x)
  {
    uint[] numArray = Nat.FromBigInteger(192 /*0xC0*/, x);
    if (numArray[5] == uint.MaxValue && Nat192.Gte(numArray, SecP192R1Field.P))
      Nat192.SubFrom(SecP192R1Field.P, numArray);
    return numArray;
  }

  public static void Half(uint[] x, uint[] z)
  {
    if (((int) x[0] & 1) == 0)
    {
      int num1 = (int) Nat.ShiftDownBit(6, x, 0U, z);
    }
    else
    {
      uint c = Nat192.Add(x, SecP192R1Field.P, z);
      int num2 = (int) Nat.ShiftDownBit(6, z, c);
    }
  }

  public static void Inv(uint[] x, uint[] z) => Mod.CheckedModOddInverse(SecP192R1Field.P, x, z);

  public static int IsZero(uint[] x)
  {
    uint num = 0;
    for (int index = 0; index < 6; ++index)
      num |= x[index];
    return (int) (num >> 1 | num & 1U) - 1 >> 31 /*0x1F*/;
  }

  public static void Multiply(uint[] x, uint[] y, uint[] z)
  {
    uint[] ext = Nat192.CreateExt();
    Nat192.Mul(x, y, ext);
    SecP192R1Field.Reduce(ext, z);
  }

  public static void MultiplyAddToExt(uint[] x, uint[] y, uint[] zz)
  {
    if (Nat192.MulAddTo(x, y, zz) == 0U && (zz[11] != uint.MaxValue || !Nat.Gte(12, zz, SecP192R1Field.PExt)) || Nat.AddTo(SecP192R1Field.PExtInv.Length, SecP192R1Field.PExtInv, zz) == 0U)
      return;
    int num = (int) Nat.IncAt(12, zz, SecP192R1Field.PExtInv.Length);
  }

  public static void Negate(uint[] x, uint[] z)
  {
    if (SecP192R1Field.IsZero(x) != 0)
      Nat192.Sub(SecP192R1Field.P, SecP192R1Field.P, z);
    else
      Nat192.Sub(SecP192R1Field.P, x, z);
  }

  public static void Random(SecureRandom r, uint[] z)
  {
    byte[] numArray = new byte[24];
    do
    {
      r.NextBytes(numArray);
      Pack.LE_To_UInt32(numArray, 0, z, 0, 6);
    }
    while (Nat.LessThan(6, z, SecP192R1Field.P) == 0);
  }

  public static void RandomMult(SecureRandom r, uint[] z)
  {
    do
    {
      SecP192R1Field.Random(r, z);
    }
    while (SecP192R1Field.IsZero(z) != 0);
  }

  public static void Reduce(uint[] xx, uint[] z)
  {
    ulong num1 = (ulong) xx[6];
    ulong num2 = (ulong) xx[7];
    ulong num3 = (ulong) xx[8];
    ulong num4 = (ulong) xx[9];
    ulong num5 = (ulong) xx[10];
    ulong num6 = (ulong) xx[11];
    ulong num7 = num1 + num5;
    ulong num8 = num2 + num6;
    ulong num9 = (ulong) (0L + ((long) xx[0] + (long) num7));
    uint num10 = (uint) num9;
    ulong num11 = (num9 >> 32 /*0x20*/) + ((ulong) xx[1] + num8);
    z[1] = (uint) num11;
    ulong num12 = num11 >> 32 /*0x20*/;
    ulong num13 = num7 + num3;
    ulong num14 = num8 + num4;
    ulong num15 = num12 + ((ulong) xx[2] + num13);
    ulong num16 = (ulong) (uint) num15;
    ulong num17 = (num15 >> 32 /*0x20*/) + ((ulong) xx[3] + num14);
    z[3] = (uint) num17;
    ulong num18 = num17 >> 32 /*0x20*/;
    ulong num19 = num13 - num1;
    ulong num20 = num14 - num2;
    ulong num21 = num18 + ((ulong) xx[4] + num19);
    z[4] = (uint) num21;
    ulong num22 = (num21 >> 32 /*0x20*/) + ((ulong) xx[5] + num20);
    z[5] = (uint) num22;
    ulong num23 = num22 >> 32 /*0x20*/;
    ulong num24 = num16 + num23;
    ulong num25 = num23 + (ulong) num10;
    z[0] = (uint) num25;
    ulong num26 = num25 >> 32 /*0x20*/;
    if (num26 != 0UL)
    {
      ulong num27 = num26 + (ulong) z[1];
      z[1] = (uint) num27;
      num24 += num27 >> 32 /*0x20*/;
    }
    z[2] = (uint) num24;
    if ((num24 >> 32 /*0x20*/ == 0UL || Nat.IncAt(6, z, 3) == 0U) && (z[5] != uint.MaxValue || !Nat192.Gte(z, SecP192R1Field.P)))
      return;
    SecP192R1Field.AddPInvTo(z);
  }

  public static void Reduce32(uint x, uint[] z)
  {
    ulong num1 = 0;
    if (x != 0U)
    {
      ulong num2 = num1 + ((ulong) z[0] + (ulong) x);
      z[0] = (uint) num2;
      ulong num3 = num2 >> 32 /*0x20*/;
      if (num3 != 0UL)
      {
        ulong num4 = num3 + (ulong) z[1];
        z[1] = (uint) num4;
        num3 = num4 >> 32 /*0x20*/;
      }
      ulong num5 = num3 + ((ulong) z[2] + (ulong) x);
      z[2] = (uint) num5;
      num1 = num5 >> 32 /*0x20*/;
    }
    if ((num1 == 0UL || Nat.IncAt(6, z, 3) == 0U) && (z[5] != uint.MaxValue || !Nat192.Gte(z, SecP192R1Field.P)))
      return;
    SecP192R1Field.AddPInvTo(z);
  }

  public static void Square(uint[] x, uint[] z)
  {
    uint[] ext = Nat192.CreateExt();
    Nat192.Square(x, ext);
    SecP192R1Field.Reduce(ext, z);
  }

  public static void SquareN(uint[] x, int n, uint[] z)
  {
    uint[] ext = Nat192.CreateExt();
    Nat192.Square(x, ext);
    SecP192R1Field.Reduce(ext, z);
    while (--n > 0)
    {
      Nat192.Square(z, ext);
      SecP192R1Field.Reduce(ext, z);
    }
  }

  public static void Subtract(uint[] x, uint[] y, uint[] z)
  {
    if (Nat192.Sub(x, y, z) == 0)
      return;
    SecP192R1Field.SubPInvFrom(z);
  }

  public static void SubtractExt(uint[] xx, uint[] yy, uint[] zz)
  {
    if (Nat.Sub(12, xx, yy, zz) == 0 || Nat.SubFrom(SecP192R1Field.PExtInv.Length, SecP192R1Field.PExtInv, zz) == 0)
      return;
    Nat.DecAt(12, zz, SecP192R1Field.PExtInv.Length);
  }

  public static void Twice(uint[] x, uint[] z)
  {
    if (Nat.ShiftUpBit(6, x, 0U, z) == 0U && (z[5] != uint.MaxValue || !Nat192.Gte(z, SecP192R1Field.P)))
      return;
    SecP192R1Field.AddPInvTo(z);
  }

  private static void AddPInvTo(uint[] z)
  {
    long num1 = (long) z[0] + 1L;
    z[0] = (uint) num1;
    long num2 = num1 >> 32 /*0x20*/;
    if (num2 != 0L)
    {
      long num3 = num2 + (long) z[1];
      z[1] = (uint) num3;
      num2 = num3 >> 32 /*0x20*/;
    }
    long num4 = num2 + ((long) z[2] + 1L);
    z[2] = (uint) num4;
    if (num4 >> 32 /*0x20*/ == 0L)
      return;
    int num5 = (int) Nat.IncAt(6, z, 3);
  }

  private static void SubPInvFrom(uint[] z)
  {
    long num1 = (long) z[0] - 1L;
    z[0] = (uint) num1;
    long num2 = num1 >> 32 /*0x20*/;
    if (num2 != 0L)
    {
      long num3 = num2 + (long) z[1];
      z[1] = (uint) num3;
      num2 = num3 >> 32 /*0x20*/;
    }
    long num4 = num2 + ((long) z[2] - 1L);
    z[2] = (uint) num4;
    if (num4 >> 32 /*0x20*/ == 0L)
      return;
    Nat.DecAt(6, z, 3);
  }
}
