// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Cmce.GF13
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Raw;
using System.Runtime.InteropServices;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Cmce;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct GF13 : GF
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
      uint num = temp[index3];
      for (int index4 = 0; index4 < poly.Length; ++index4)
        temp[index3 - length + poly[index4]] ^= num;
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
      uint num = temp[index1];
      for (int index2 = 0; index2 < poly.Length; ++index2)
        temp[index1 - length + poly[index2]] ^= num;
    }
    for (int index = 0; index < length; ++index)
      output[index] = this.GFReduce(temp[index]);
  }

  public ushort GFFrac(ushort den, ushort num)
  {
    ushort num1 = this.GFSqMul(den, den);
    ushort num2 = this.GFSq2Mul(num1, num1);
    return this.GFSqMul(this.GFSq2Mul(this.GFSq2(this.GFSq2Mul(this.GFSq2(num2), num2)), num2), num);
  }

  public ushort GFInv(ushort den) => this.GFFrac(den, (ushort) 1);

  public ushort GFIsZero(ushort a) => (ushort) ((int) a - 1 >> 31 /*0x1F*/);

  public ushort GFMul(ushort in0, ushort in1)
  {
    int num1 = (int) in0;
    int num2 = (int) in1;
    int x = num1 * (num2 & 1);
    for (int index = 1; index < 13; ++index)
      x ^= num1 * (num2 & 1 << index);
    return this.GFReduce((uint) x);
  }

  public uint GFMulExt(ushort left, ushort right)
  {
    int num1 = (int) left;
    int num2 = (int) right;
    int num3 = num1 * (num2 & 1);
    for (int index = 1; index < 13; ++index)
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
    for (int index = 1; index < 13; ++index)
    {
      num5 ^= num1 * (num2 & 1 << index);
      num6 ^= num3 * (num4 & 1 << index);
    }
    return (uint) (num5 ^ num6);
  }

  public ushort GFReduce(uint x)
  {
    int num1 = (int) x & 8191 /*0x1FFF*/;
    uint num2 = x >> 13;
    int num3 = (int) num2 << 4 ^ (int) num2 << 3 ^ (int) num2 << 1;
    uint num4 = (uint) (num3 >>> 13);
    uint num5 = (uint) (num3 & 8191 /*0x1FFF*/);
    uint num6 = (uint) ((int) num4 << 4 ^ (int) num4 << 3 ^ (int) num4 << 1);
    int num7 = (int) num2;
    return (ushort) ((uint) (num1 ^ num7) ^ num4 ^ num5 ^ num6);
  }

  public ushort GFSq(ushort input) => this.GFReduce(Interleave.Expand16to32(input));

  public uint GFSqExt(ushort input) => Interleave.Expand16to32(input);

  private ushort GFSq2(ushort input)
  {
    input = this.GFReduce(Interleave.Expand16to32(input));
    return this.GFReduce(Interleave.Expand16to32(input));
  }

  private ushort GFSqMul(ushort input, ushort m)
  {
    long num1 = (long) input;
    long num2 = (long) m;
    long num3 = (num2 << 6) * (num1 & 64L /*0x40*/);
    long num4 = num1 ^ num1 << 7;
    long num5 = num3 ^ num2 * (num4 & 16385L) ^ (num2 << 1) * (num4 & 32770L) ^ (num2 << 2) * (num4 & 65540L /*0x010004*/) ^ (num2 << 3) * (num4 & 131080L /*0x020008*/) ^ (num2 << 4) * (num4 & 262160L /*0x040010*/) ^ (num2 << 5) * (num4 & 524320L /*0x080020*/);
    long num6 = num5 & 137371844608L /*0x1FFC000000*/;
    return this.GFReduce((uint) (num5 ^ num6 >> 18 ^ num6 >> 20 ^ num6 >> 24 ^ num6 >> 26) & 67108863U /*0x03FFFFFF*/);
  }

  private ushort GFSq2Mul(ushort input, ushort m)
  {
    long num1 = (long) input;
    long num2 = (long) m;
    long num3 = (num2 << 18) * (num1 & 64L /*0x40*/);
    long num4 = num1 ^ num1 << 21;
    long num5 = num3 ^ num2 * (num4 & 268435457L /*0x10000001*/) ^ (num2 << 3) * (num4 & 536870914L /*0x20000002*/) ^ (num2 << 6) * (num4 & 1073741828L /*0x40000004*/) ^ (num2 << 9) * (num4 & 2147483656L /*0x80000008*/) ^ (num2 << 12) * (num4 & 4294967312L /*0x0100000010*/) ^ (num2 << 15) * (num4 & 8589934624L /*0x0200000020*/);
    long num6 = num5 & 2305834213120671744L /*0x1FFFF80000000000*/;
    long num7 = num5 ^ num6 >> 18 ^ num6 >> 20 ^ num6 >> 24 ^ num6 >> 26;
    long num8 = num7 & 8796025913344L /*0x07FFFC000000*/;
    return this.GFReduce((uint) (num7 ^ num8 >> 18 ^ num8 >> 20 ^ num8 >> 24 ^ num8 >> 26) & 67108863U /*0x03FFFFFF*/);
  }
}
