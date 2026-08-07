// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP384R1Field
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP384R1Field
{
  internal static readonly uint[] P = new uint[12]
  {
    uint.MaxValue,
    0U,
    0U,
    uint.MaxValue,
    4294967294U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue
  };
  private static readonly uint[] PExt = new uint[24]
  {
    1U,
    4294967294U,
    0U,
    2U,
    0U,
    4294967294U,
    0U,
    2U,
    1U,
    0U,
    0U,
    0U,
    4294967294U,
    1U,
    0U,
    4294967294U,
    4294967293U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue
  };
  private static readonly uint[] PExtInv = new uint[17]
  {
    uint.MaxValue,
    1U,
    uint.MaxValue,
    4294967293U,
    uint.MaxValue,
    1U,
    uint.MaxValue,
    4294967293U,
    4294967294U,
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    1U,
    4294967294U,
    uint.MaxValue,
    1U,
    2U
  };
  private const uint P11 = 4294967295 /*0xFFFFFFFF*/;
  private const uint PExt23 = 4294967295 /*0xFFFFFFFF*/;

  public static void Add(uint[] x, uint[] y, uint[] z)
  {
    if (Nat.Add(12, x, y, z) == 0U && (z[11] != uint.MaxValue || !Nat.Gte(12, z, SecP384R1Field.P)))
      return;
    SecP384R1Field.AddPInvTo(z);
  }

  public static void AddExt(uint[] xx, uint[] yy, uint[] zz)
  {
    if (Nat.Add(24, xx, yy, zz) == 0U && (zz[23] != uint.MaxValue || !Nat.Gte(24, zz, SecP384R1Field.PExt)) || Nat.AddTo(SecP384R1Field.PExtInv.Length, SecP384R1Field.PExtInv, zz) == 0U)
      return;
    int num = (int) Nat.IncAt(24, zz, SecP384R1Field.PExtInv.Length);
  }

  public static void AddOne(uint[] x, uint[] z)
  {
    if (Nat.Inc(12, x, z) == 0U && (z[11] != uint.MaxValue || !Nat.Gte(12, z, SecP384R1Field.P)))
      return;
    SecP384R1Field.AddPInvTo(z);
  }

  public static uint[] FromBigInteger(BigInteger x)
  {
    uint[] numArray = Nat.FromBigInteger(384, x);
    if (numArray[11] == uint.MaxValue && Nat.Gte(12, numArray, SecP384R1Field.P))
      Nat.SubFrom(12, SecP384R1Field.P, numArray);
    return numArray;
  }

  public static void Half(uint[] x, uint[] z)
  {
    if (((int) x[0] & 1) == 0)
    {
      int num1 = (int) Nat.ShiftDownBit(12, x, 0U, z);
    }
    else
    {
      uint c = Nat.Add(12, x, SecP384R1Field.P, z);
      int num2 = (int) Nat.ShiftDownBit(12, z, c);
    }
  }

  public static void Inv(uint[] x, uint[] z) => Mod.CheckedModOddInverse(SecP384R1Field.P, x, z);

  public static int IsZero(uint[] x)
  {
    uint num = 0;
    for (int index = 0; index < 12; ++index)
      num |= x[index];
    return (int) (num >> 1 | num & 1U) - 1 >> 31 /*0x1F*/;
  }

  public static void Multiply(uint[] x, uint[] y, uint[] z)
  {
    uint[] numArray = Nat.Create(24);
    Nat384.Mul(x, y, numArray);
    SecP384R1Field.Reduce(numArray, z);
  }

  public static void Multiply(uint[] x, uint[] y, uint[] z, uint[] tt)
  {
    Nat384.Mul(x, y, tt);
    SecP384R1Field.Reduce(tt, z);
  }

  public static void Negate(uint[] x, uint[] z)
  {
    if (SecP384R1Field.IsZero(x) != 0)
      Nat.Sub(12, SecP384R1Field.P, SecP384R1Field.P, z);
    else
      Nat.Sub(12, SecP384R1Field.P, x, z);
  }

  public static void Random(SecureRandom r, uint[] z)
  {
    byte[] numArray = new byte[48 /*0x30*/];
    do
    {
      r.NextBytes(numArray);
      Pack.LE_To_UInt32(numArray, 0, z, 0, 12);
    }
    while (Nat.LessThan(12, z, SecP384R1Field.P) == 0);
  }

  public static void RandomMult(SecureRandom r, uint[] z)
  {
    do
    {
      SecP384R1Field.Random(r, z);
    }
    while (SecP384R1Field.IsZero(z) != 0);
  }

  public static void Reduce(uint[] xx, uint[] z)
  {
    long num1 = (long) xx[16 /*0x10*/];
    long num2 = (long) xx[17];
    long num3 = (long) xx[18];
    long num4 = (long) xx[19];
    long num5 = (long) xx[20];
    long num6 = (long) xx[21];
    long num7 = (long) xx[22];
    long num8 = (long) xx[23];
    long num9 = (long) xx[12] + num5 - 1L;
    long num10 = (long) xx[13] + num7;
    long num11 = (long) xx[14] + num7 + num8;
    long num12 = (long) xx[15] + num8;
    long num13 = num2 + num6;
    long num14 = num6 - num8;
    long num15 = num7 - num8;
    long num16 = num9 + num14;
    long num17 = 0L + ((long) xx[0] + num16);
    z[0] = (uint) num17;
    long num18 = (num17 >> 32 /*0x20*/) + ((long) xx[1] + num8 - num9 + num10);
    z[1] = (uint) num18;
    long num19 = (num18 >> 32 /*0x20*/) + ((long) xx[2] - num6 - num10 + num11);
    z[2] = (uint) num19;
    long num20 = (num19 >> 32 /*0x20*/) + ((long) xx[3] - num11 + num12 + num16);
    z[3] = (uint) num20;
    long num21 = (num20 >> 32 /*0x20*/) + ((long) xx[4] + num1 + num6 + num10 - num12 + num16);
    z[4] = (uint) num21;
    long num22 = (num21 >> 32 /*0x20*/) + ((long) xx[5] - num1 + num10 + num11 + num13);
    z[5] = (uint) num22;
    long num23 = (num22 >> 32 /*0x20*/) + ((long) xx[6] + num3 - num2 + num11 + num12);
    z[6] = (uint) num23;
    long num24 = (num23 >> 32 /*0x20*/) + ((long) xx[7] + num1 + num4 - num3 + num12);
    z[7] = (uint) num24;
    long num25 = (num24 >> 32 /*0x20*/) + ((long) xx[8] + num1 + num2 + num5 - num4);
    z[8] = (uint) num25;
    long num26 = (num25 >> 32 /*0x20*/) + ((long) xx[9] + num3 - num5 + num13);
    z[9] = (uint) num26;
    long num27 = (num26 >> 32 /*0x20*/) + ((long) xx[10] + num3 + num4 - num14 + num15);
    z[10] = (uint) num27;
    long num28 = (num27 >> 32 /*0x20*/) + ((long) xx[11] + num4 + num5 - num15);
    z[11] = (uint) num28;
    SecP384R1Field.Reduce32((uint) ((num28 >> 32 /*0x20*/) + 1L), z);
  }

  public static void Reduce32(uint x, uint[] z)
  {
    long num1 = 0;
    if (x != 0U)
    {
      long num2 = (long) x;
      long num3 = num1 + ((long) z[0] + num2);
      z[0] = (uint) num3;
      long num4 = (num3 >> 32 /*0x20*/) + ((long) z[1] - num2);
      z[1] = (uint) num4;
      long num5 = num4 >> 32 /*0x20*/;
      if (num5 != 0L)
      {
        long num6 = num5 + (long) z[2];
        z[2] = (uint) num6;
        num5 = num6 >> 32 /*0x20*/;
      }
      long num7 = num5 + ((long) z[3] + num2);
      z[3] = (uint) num7;
      long num8 = (num7 >> 32 /*0x20*/) + ((long) z[4] + num2);
      z[4] = (uint) num8;
      num1 = num8 >> 32 /*0x20*/;
    }
    if ((num1 == 0L || Nat.IncAt(12, z, 5) == 0U) && (z[11] != uint.MaxValue || !Nat.Gte(12, z, SecP384R1Field.P)))
      return;
    SecP384R1Field.AddPInvTo(z);
  }

  public static void Square(uint[] x, uint[] z)
  {
    uint[] numArray = Nat.Create(24);
    Nat384.Square(x, numArray);
    SecP384R1Field.Reduce(numArray, z);
  }

  public static void Square(uint[] x, uint[] z, uint[] tt)
  {
    Nat384.Square(x, tt);
    SecP384R1Field.Reduce(tt, z);
  }

  public static void SquareN(uint[] x, int n, uint[] z)
  {
    uint[] numArray = Nat.Create(24);
    Nat384.Square(x, numArray);
    SecP384R1Field.Reduce(numArray, z);
    while (--n > 0)
    {
      Nat384.Square(z, numArray);
      SecP384R1Field.Reduce(numArray, z);
    }
  }

  public static void SquareN(uint[] x, int n, uint[] z, uint[] tt)
  {
    Nat384.Square(x, tt);
    SecP384R1Field.Reduce(tt, z);
    while (--n > 0)
    {
      Nat384.Square(z, tt);
      SecP384R1Field.Reduce(tt, z);
    }
  }

  public static void Subtract(uint[] x, uint[] y, uint[] z)
  {
    if (Nat.Sub(12, x, y, z) == 0)
      return;
    SecP384R1Field.SubPInvFrom(z);
  }

  public static void SubtractExt(uint[] xx, uint[] yy, uint[] zz)
  {
    if (Nat.Sub(24, xx, yy, zz) == 0 || Nat.SubFrom(SecP384R1Field.PExtInv.Length, SecP384R1Field.PExtInv, zz) == 0)
      return;
    Nat.DecAt(24, zz, SecP384R1Field.PExtInv.Length);
  }

  public static void Twice(uint[] x, uint[] z)
  {
    if (Nat.ShiftUpBit(12, x, 0U, z) == 0U && (z[11] != uint.MaxValue || !Nat.Gte(12, z, SecP384R1Field.P)))
      return;
    SecP384R1Field.AddPInvTo(z);
  }

  private static void AddPInvTo(uint[] z)
  {
    long num1 = (long) z[0] + 1L;
    z[0] = (uint) num1;
    long num2 = (num1 >> 32 /*0x20*/) + ((long) z[1] - 1L);
    z[1] = (uint) num2;
    long num3 = num2 >> 32 /*0x20*/;
    if (num3 != 0L)
    {
      long num4 = num3 + (long) z[2];
      z[2] = (uint) num4;
      num3 = num4 >> 32 /*0x20*/;
    }
    long num5 = num3 + ((long) z[3] + 1L);
    z[3] = (uint) num5;
    long num6 = (num5 >> 32 /*0x20*/) + ((long) z[4] + 1L);
    z[4] = (uint) num6;
    if (num6 >> 32 /*0x20*/ == 0L)
      return;
    int num7 = (int) Nat.IncAt(12, z, 5);
  }

  private static void SubPInvFrom(uint[] z)
  {
    long num1 = (long) z[0] - 1L;
    z[0] = (uint) num1;
    long num2 = (num1 >> 32 /*0x20*/) + ((long) z[1] + 1L);
    z[1] = (uint) num2;
    long num3 = num2 >> 32 /*0x20*/;
    if (num3 != 0L)
    {
      long num4 = num3 + (long) z[2];
      z[2] = (uint) num4;
      num3 = num4 >> 32 /*0x20*/;
    }
    long num5 = num3 + ((long) z[3] - 1L);
    z[3] = (uint) num5;
    long num6 = (num5 >> 32 /*0x20*/) + ((long) z[4] - 1L);
    z[4] = (uint) num6;
    if (num6 >> 32 /*0x20*/ == 0L)
      return;
    Nat.DecAt(12, z, 5);
  }
}
