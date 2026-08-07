// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.Raw.Nat512
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Math.Raw;

internal static class Nat512
{
  public static void Mul(uint[] x, uint[] y, uint[] zz)
  {
    Nat256.Mul(x, y, zz);
    Nat256.Mul(x, 8, y, 8, zz, 16 /*0x10*/);
    uint eachOther = Nat256.AddToEachOther(zz, 8, zz, 16 /*0x10*/);
    uint cIn = eachOther + Nat256.AddTo(zz, 0, zz, 8, 0U);
    uint num1 = eachOther + Nat256.AddTo(zz, 24, zz, 16 /*0x10*/, cIn);
    uint[] numArray1 = Nat256.Create();
    uint[] numArray2 = Nat256.Create();
    bool flag = Nat256.Diff(x, 8, x, 0, numArray1, 0) != Nat256.Diff(y, 8, y, 0, numArray2, 0);
    uint[] ext = Nat256.CreateExt();
    Nat256.Mul(numArray1, numArray2, ext);
    int num2 = (int) Nat.AddWordAt(32 /*0x20*/, num1 + (flag ? Nat.AddTo(16 /*0x10*/, ext, 0, zz, 8) : (uint) Nat.SubFrom(16 /*0x10*/, ext, 0, zz, 8)), zz, 24);
  }

  public static void Square(uint[] x, uint[] zz)
  {
    Nat256.Square(x, zz);
    Nat256.Square(x, 8, zz, 16 /*0x10*/);
    uint eachOther = Nat256.AddToEachOther(zz, 8, zz, 16 /*0x10*/);
    uint cIn = eachOther + Nat256.AddTo(zz, 0, zz, 8, 0U);
    uint num1 = eachOther + Nat256.AddTo(zz, 24, zz, 16 /*0x10*/, cIn);
    uint[] numArray = Nat256.Create();
    Nat256.Diff(x, 8, x, 0, numArray, 0);
    uint[] ext = Nat256.CreateExt();
    Nat256.Square(numArray, ext);
    int num2 = (int) Nat.AddWordAt(32 /*0x20*/, num1 + (uint) Nat.SubFrom(16 /*0x10*/, ext, 0, zz, 8), zz, 24);
  }

  public static void Xor(uint[] x, int xOff, uint[] y, int yOff, uint[] z, int zOff)
  {
    for (int index = 0; index < 16 /*0x10*/; index += 4)
    {
      z[zOff + index] = x[xOff + index] ^ y[yOff + index];
      z[zOff + index + 1] = x[xOff + index + 1] ^ y[yOff + index + 1];
      z[zOff + index + 2] = x[xOff + index + 2] ^ y[yOff + index + 2];
      z[zOff + index + 3] = x[xOff + index + 3] ^ y[yOff + index + 3];
    }
  }

  public static void XorTo(uint[] x, int xOff, uint[] z, int zOff)
  {
    for (int index = 0; index < 16 /*0x10*/; index += 4)
    {
      z[zOff + index] ^= x[xOff + index];
      z[zOff + index + 1] ^= x[xOff + index + 1];
      z[zOff + index + 2] ^= x[xOff + index + 2];
      z[zOff + index + 3] ^= x[xOff + index + 3];
    }
  }

  public static void Xor64(ulong[] x, int xOff, ulong[] y, int yOff, ulong[] z, int zOff)
  {
    for (int index = 0; index < 8; index += 4)
    {
      z[zOff + index] = x[xOff + index] ^ y[yOff + index];
      z[zOff + index + 1] = x[xOff + index + 1] ^ y[yOff + index + 1];
      z[zOff + index + 2] = x[xOff + index + 2] ^ y[yOff + index + 2];
      z[zOff + index + 3] = x[xOff + index + 3] ^ y[yOff + index + 3];
    }
  }

  public static void XorTo64(ulong[] x, int xOff, ulong[] z, int zOff)
  {
    for (int index = 0; index < 8; index += 4)
    {
      z[zOff + index] ^= x[xOff + index];
      z[zOff + index + 1] ^= x[xOff + index + 1];
      z[zOff + index + 2] ^= x[xOff + index + 2];
      z[zOff + index + 3] ^= x[xOff + index + 3];
    }
  }
}
