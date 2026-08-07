// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Cmce.GF12
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using System.Runtime.InteropServices;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Cmce;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct GF12 : GF
{
  public void GFMulPoly(
    int length,
    int[] poly,
    ushort[] output,
    ushort[] left,
    ushort[] right,
    uint[] temp)
  {
    temp[0] = this.GFMulExt(left[0], right[0]);
    for (int index1 = 1; index1 < length; ++index1)
    {
      temp[index1 + index1 - 1] = 0U;
      ushort num1 = left[index1];
      ushort num2 = right[index1];
      for (int index2 = 0; index2 < index1; ++index2)
        temp[index1 + index2] ^= this.GFMulExtPar(num1, right[index2], left[index2], num2);
      temp[index1 + index1] = this.GFMulExt(num1, num2);
    }
    for (int index3 = (length - 1) * 2; index3 >= length; --index3)
    {
      uint x = temp[index3];
      for (int index4 = 0; index4 < poly.Length - 1; ++index4)
        temp[index3 - length + poly[index4]] ^= x;
      temp[index3 - length] ^= this.GFMulExt(this.GFReduce(x), (ushort) 2);
    }
    for (int index = 0; index < length; ++index)
      output[index] = this.GFReduce(temp[index]);
  }

  public void GFSqrPoly(int length, int[] poly, ushort[] output, ushort[] input, uint[] temp)
  {
    temp[0] = this.GFSqExt(input[0]);
    for (int index = 1; index < length; ++index)
    {
      temp[index + index - 1] = 0U;
      temp[index + index] = this.GFSqExt(input[index]);
    }
    for (int index1 = (length - 1) * 2; index1 >= length; --index1)
    {
      uint x = temp[index1];
      for (int index2 = 0; index2 < poly.Length - 1; ++index2)
        temp[index1 - length + poly[index2]] ^= x;
      temp[index1 - length] ^= this.GFMulExt(this.GFReduce(x), (ushort) 2);
    }
    for (int index = 0; index < length; ++index)
      output[index] = this.GFReduce(temp[index]);
  }

  public ushort GFFrac(ushort den, ushort num) => this.GFMul(this.GFInv(den), num);

  public ushort GFInv(ushort input)
  {
    ushort num1 = this.GFMul(this.GFSq(input), input);
    ushort num2 = this.GFMul(this.GFSq(this.GFSq(num1)), num1);
    return this.GFSq(this.GFMul(this.GFSq(this.GFMul(this.GFSq(this.GFSq(this.GFMul(this.GFSq(this.GFSq(this.GFSq(this.GFSq(num2)))), num2))), num1)), input));
  }

  public ushort GFIsZero(ushort a) => (ushort) ((int) a - 1 >> 31 /*0x1F*/);

  public ushort GFMul(ushort left, ushort right)
  {
    int num1 = (int) left;
    int num2 = (int) right;
    int x = num1 * (num2 & 1);
    for (int index = 1; index < 12; ++index)
      x ^= num1 * (num2 & 1 << index);
    return this.GFReduce((uint) x);
  }

  public uint GFMulExt(ushort left, ushort right)
  {
    int num1 = (int) left;
    int num2 = (int) right;
    int num3 = num1 * (num2 & 1);
    for (int index = 1; index < 12; ++index)
      num3 ^= num1 * (num2 & 1 << index);
    return (uint) num3;
  }

  private uint GFMulExtPar(ushort left0, ushort right0, ushort left1, ushort right1)
  {
    int num1 = (int) left0;
    int num2 = (int) right0;
    int num3 = (int) left1;
    int num4 = (int) right1;
    int num5 = num1 * (num2 & 1);
    int num6 = num3 * (num4 & 1);
    for (int index = 1; index < 12; ++index)
    {
      num5 ^= num1 * (num2 & 1 << index);
      num6 ^= num3 * (num4 & 1 << index);
    }
    return (uint) (num5 ^ num6);
  }

  public ushort GFReduce(uint x)
  {
    int num1 = (int) x & 4095 /*0x0FFF*/;
    uint num2 = x >> 12;
    uint num3 = (x & 2093056U) >> 9;
    uint num4 = (x & 14680064U /*0xE00000*/) >> 18;
    uint num5 = x >> 21;
    int num6 = (int) num2;
    return (ushort) ((uint) (num1 ^ num6) ^ num3 ^ num4 ^ num5);
  }

  public ushort GFSq(ushort input) => this.GFReduce(Interleave.Expand16to32(input));

  public uint GFSqExt(ushort input) => Interleave.Expand16to32(input);
}
