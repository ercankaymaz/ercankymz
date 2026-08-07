// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Custom.Sec.SecP128R1Field
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Custom.Sec;

internal class SecP128R1Field
{
  internal static readonly uint[] P = new uint[4]
  {
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    4294967293U
  };
  private static readonly uint[] PExt = new uint[8]
  {
    1U,
    0U,
    0U,
    4U,
    4294967294U,
    uint.MaxValue,
    3U,
    4294967292U
  };
  private static readonly uint[] PExtInv = new uint[8]
  {
    uint.MaxValue,
    uint.MaxValue,
    uint.MaxValue,
    4294967291U,
    1U,
    0U,
    4294967292U,
    3U
  };
  private const uint P3 = 4294967293;
  private const uint PExt7 = 4294967292;

  public static void Add(uint[] x, uint[] y, uint[] z)
  {
    if (Nat128.Add(x, y, z) == 0U && (z[3] < 4294967293U || !Nat128.Gte(z, SecP128R1Field.P)))
      return;
    SecP128R1Field.AddPInvTo(z);
  }

  public static void AddExt(uint[] xx, uint[] yy, uint[] zz)
  {
    if (Nat256.Add(xx, yy, zz) == 0U && (zz[7] < 4294967292U || !Nat256.Gte(zz, SecP128R1Field.PExt)))
      return;
    int num = (int) Nat.AddTo(SecP128R1Field.PExtInv.Length, SecP128R1Field.PExtInv, zz);
  }

  public static void AddOne(uint[] x, uint[] z)
  {
    if (Nat.Inc(4, x, z) == 0U && (z[3] < 4294967293U || !Nat128.Gte(z, SecP128R1Field.P)))
      return;
    SecP128R1Field.AddPInvTo(z);
  }

  public static uint[] FromBigInteger(BigInteger x)
  {
    uint[] numArray = Nat.FromBigInteger(128 /*0x80*/, x);
    if (numArray[3] >= 4294967293U && Nat128.Gte(numArray, SecP128R1Field.P))
      Nat128.SubFrom(SecP128R1Field.P, numArray);
    return numArray;
  }

  public static void Half(uint[] x, uint[] z)
  {
    if (((int) x[0] & 1) == 0)
    {
      int num1 = (int) Nat.ShiftDownBit(4, x, 0U, z);
    }
    else
    {
      uint c = Nat128.Add(x, SecP128R1Field.P, z);
      int num2 = (int) Nat.ShiftDownBit(4, z, c);
    }
  }

  public static void Inv(uint[] x, uint[] z) => Mod.CheckedModOddInverse(SecP128R1Field.P, x, z);

  public static int IsZero(uint[] x)
  {
    uint num = 0;
    for (int index = 0; index < 4; ++index)
      num |= x[index];
    return (int) (num >> 1 | num & 1U) - 1 >> 31 /*0x1F*/;
  }

  public static void Multiply(uint[] x, uint[] y, uint[] z)
  {
    uint[] ext = Nat128.CreateExt();
    Nat128.Mul(x, y, ext);
    SecP128R1Field.Reduce(ext, z);
  }

  public static void MultiplyAddToExt(uint[] x, uint[] y, uint[] zz)
  {
    if (Nat128.MulAddTo(x, y, zz) == 0U && (zz[7] < 4294967292U || !Nat256.Gte(zz, SecP128R1Field.PExt)))
      return;
    int num = (int) Nat.AddTo(SecP128R1Field.PExtInv.Length, SecP128R1Field.PExtInv, zz);
  }

  public static void Negate(uint[] x, uint[] z)
  {
    if (SecP128R1Field.IsZero(x) != 0)
      Nat128.Sub(SecP128R1Field.P, SecP128R1Field.P, z);
    else
      Nat128.Sub(SecP128R1Field.P, x, z);
  }

  public static void Random(SecureRandom r, uint[] z)
  {
    byte[] numArray = new byte[16 /*0x10*/];
    do
    {
      r.NextBytes(numArray);
      Pack.LE_To_UInt32(numArray, 0, z, 0, 4);
    }
    while (Nat.LessThan(4, z, SecP128R1Field.P) == 0);
  }

  public static void RandomMult(SecureRandom r, uint[] z)
  {
    do
    {
      SecP128R1Field.Random(r, z);
    }
    while (SecP128R1Field.IsZero(z) != 0);
  }

  public static void Reduce(uint[] xx, uint[] z)
  {
    ulong num1 = (ulong) xx[0];
    ulong num2 = (ulong) xx[1];
    ulong num3 = (ulong) xx[2];
    ulong num4 = (ulong) xx[3];
    ulong num5 = (ulong) xx[4];
    ulong num6 = (ulong) xx[5];
    ulong num7 = (ulong) xx[6];
    ulong num8 = (ulong) xx[7];
    ulong num9 = num4 + num8;
    ulong num10 = num7 + (num8 << 1);
    ulong num11 = num3 + num10;
    ulong num12 = num6 + (num10 << 1);
    ulong num13 = num2 + num12;
    ulong num14 = num5 + (num12 << 1);
    ulong num15 = num1 + num14;
    ulong num16 = num9 + (num14 << 1);
    z[0] = (uint) num15;
    ulong num17 = num13 + (num15 >> 32 /*0x20*/);
    z[1] = (uint) num17;
    ulong num18 = num11 + (num17 >> 32 /*0x20*/);
    z[2] = (uint) num18;
    ulong num19 = num16 + (num18 >> 32 /*0x20*/);
    z[3] = (uint) num19;
    SecP128R1Field.Reduce32((uint) (num19 >> 32 /*0x20*/), z);
  }

  public static void Reduce32(uint x, uint[] z)
  {
    ulong num1;
    for (; x != 0U; x = (uint) (num1 >> 32 /*0x20*/))
    {
      ulong num2 = (ulong) x;
      ulong num3 = (ulong) z[0] + num2;
      z[0] = (uint) num3;
      ulong num4 = num3 >> 32 /*0x20*/;
      if (num4 != 0UL)
      {
        ulong num5 = num4 + (ulong) z[1];
        z[1] = (uint) num5;
        ulong num6 = (num5 >> 32 /*0x20*/) + (ulong) z[2];
        z[2] = (uint) num6;
        num4 = num6 >> 32 /*0x20*/;
      }
      num1 = num4 + ((ulong) z[3] + (num2 << 1));
      z[3] = (uint) num1;
    }
    if (z[3] < 4294967293U || !Nat128.Gte(z, SecP128R1Field.P))
      return;
    SecP128R1Field.AddPInvTo(z);
  }

  public static void Square(uint[] x, uint[] z)
  {
    uint[] ext = Nat128.CreateExt();
    Nat128.Square(x, ext);
    SecP128R1Field.Reduce(ext, z);
  }

  public static void SquareN(uint[] x, int n, uint[] z)
  {
    uint[] ext = Nat128.CreateExt();
    Nat128.Square(x, ext);
    SecP128R1Field.Reduce(ext, z);
    while (--n > 0)
    {
      Nat128.Square(z, ext);
      SecP128R1Field.Reduce(ext, z);
    }
  }

  public static void Subtract(uint[] x, uint[] y, uint[] z)
  {
    if (Nat128.Sub(x, y, z) == 0)
      return;
    SecP128R1Field.SubPInvFrom(z);
  }

  public static void SubtractExt(uint[] xx, uint[] yy, uint[] zz)
  {
    if (Nat.Sub(10, xx, yy, zz) == 0)
      return;
    Nat.SubFrom(SecP128R1Field.PExtInv.Length, SecP128R1Field.PExtInv, zz);
  }

  public static void Twice(uint[] x, uint[] z)
  {
    if (Nat.ShiftUpBit(4, x, 0U, z) == 0U && (z[3] < 4294967293U || !Nat128.Gte(z, SecP128R1Field.P)))
      return;
    SecP128R1Field.AddPInvTo(z);
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
      long num4 = (num3 >> 32 /*0x20*/) + (long) z[2];
      z[2] = (uint) num4;
      num2 = num4 >> 32 /*0x20*/;
    }
    long num5 = num2 + ((long) z[3] + 2L);
    z[3] = (uint) num5;
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
      long num4 = (num3 >> 32 /*0x20*/) + (long) z[2];
      z[2] = (uint) num4;
      num2 = num4 >> 32 /*0x20*/;
    }
    long num5 = num2 + ((long) z[3] - 2L);
    z[3] = (uint) num5;
  }
}
