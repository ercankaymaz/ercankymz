// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.SM3Digest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public class SM3Digest : GeneralDigest
{
  private const int DIGEST_LENGTH = 32 /*0x20*/;
  private const int BLOCK_SIZE = 16 /*0x10*/;
  private uint[] V = new uint[8];
  private uint[] inwords = new uint[16 /*0x10*/];
  private int xOff;
  private uint[] W = new uint[68];
  private static readonly uint[] T = new uint[64 /*0x40*/];

  static SM3Digest()
  {
    for (int index = 0; index < 16 /*0x10*/; ++index)
      SM3Digest.T[index] = (uint) (2043430169 << index) | 2043430169U >> 32 /*0x20*/ - index;
    for (int index = 16 /*0x10*/; index < 64 /*0x40*/; ++index)
    {
      int num = index % 32 /*0x20*/;
      SM3Digest.T[index] = (uint) (2055708042 << num) | 2055708042U >> 32 /*0x20*/ - num;
    }
  }

  public SM3Digest() => this.Reset();

  public SM3Digest(SM3Digest t)
    : base((GeneralDigest) t)
  {
    this.CopyIn(t);
  }

  private void CopyIn(SM3Digest t)
  {
    Array.Copy((Array) t.V, 0, (Array) this.V, 0, this.V.Length);
    Array.Copy((Array) t.inwords, 0, (Array) this.inwords, 0, this.inwords.Length);
    this.xOff = t.xOff;
  }

  public override string AlgorithmName => "SM3";

  public override int GetDigestSize() => 32 /*0x20*/;

  public override IMemoable Copy() => (IMemoable) new SM3Digest(this);

  public override void Reset(IMemoable other)
  {
    SM3Digest t = (SM3Digest) other;
    this.CopyIn((GeneralDigest) t);
    this.CopyIn(t);
  }

  public override void Reset()
  {
    base.Reset();
    this.V[0] = 1937774191U;
    this.V[1] = 1226093241U;
    this.V[2] = 388252375U;
    this.V[3] = 3666478592U;
    this.V[4] = 2842636476U;
    this.V[5] = 372324522U;
    this.V[6] = 3817729613U;
    this.V[7] = 2969243214U;
    this.xOff = 0;
  }

  public override int DoFinal(byte[] output, int outOff)
  {
    this.Finish();
    Pack.UInt32_To_BE(this.V, output, outOff);
    this.Reset();
    return 32 /*0x20*/;
  }

  internal override void ProcessWord(byte[] input, int inOff)
  {
    this.inwords[this.xOff++] = Pack.BE_To_UInt32(input, inOff);
    if (this.xOff < 16 /*0x10*/)
      return;
    this.ProcessBlock();
  }

  internal override void ProcessLength(long bitLength)
  {
    if (this.xOff > 14)
    {
      this.inwords[this.xOff] = 0U;
      ++this.xOff;
      this.ProcessBlock();
    }
    for (; this.xOff < 14; ++this.xOff)
      this.inwords[this.xOff] = 0U;
    this.inwords[this.xOff++] = (uint) (bitLength >> 32 /*0x20*/);
    this.inwords[this.xOff++] = (uint) bitLength;
  }

  private uint P0(uint x)
  {
    uint num1 = x << 9 | x >> 23;
    uint num2 = x << 17 | x >> 15;
    return x ^ num1 ^ num2;
  }

  private uint P1(uint x)
  {
    uint num1 = x << 15 | x >> 17;
    uint num2 = x << 23 | x >> 9;
    return x ^ num1 ^ num2;
  }

  private uint FF0(uint x, uint y, uint z) => x ^ y ^ z;

  private uint FF1(uint x, uint y, uint z)
  {
    return (uint) ((int) x & (int) y | (int) x & (int) z | (int) y & (int) z);
  }

  private uint GG0(uint x, uint y, uint z) => x ^ y ^ z;

  private uint GG1(uint x, uint y, uint z) => (uint) ((int) x & (int) y | ~(int) x & (int) z);

  internal override void ProcessBlock()
  {
    for (int index = 0; index < 16 /*0x10*/; ++index)
      this.W[index] = this.inwords[index];
    for (int index = 16 /*0x10*/; index < 68; ++index)
    {
      uint num1 = this.W[index - 3];
      uint num2 = num1 << 15 | num1 >> 17;
      uint num3 = this.W[index - 13];
      uint num4 = num3 << 7 | num3 >> 25;
      this.W[index] = this.P1(this.W[index - 16 /*0x10*/] ^ this.W[index - 9] ^ num2) ^ num4 ^ this.W[index - 6];
    }
    uint x1 = this.V[0];
    uint y1 = this.V[1];
    uint z1 = this.V[2];
    uint num5 = this.V[3];
    uint x2 = this.V[4];
    uint y2 = this.V[5];
    uint z2 = this.V[6];
    uint num6 = this.V[7];
    for (int index = 0; index < 16 /*0x10*/; ++index)
    {
      uint num7 = x1 << 12 | x1 >> 20;
      uint num8 = num7 + x2 + SM3Digest.T[index];
      uint num9 = num8 << 7 | num8 >> 25;
      uint num10 = num9 ^ num7;
      uint num11 = this.W[index];
      uint num12 = num11 ^ this.W[index + 4];
      int num13 = (int) this.FF0(x1, y1, z1) + (int) num5 + (int) num10 + (int) num12;
      uint x3 = this.GG0(x2, y2, z2) + num6 + num9 + num11;
      num5 = z1;
      z1 = y1 << 9 | y1 >> 23;
      y1 = x1;
      x1 = (uint) num13;
      num6 = z2;
      z2 = y2 << 19 | y2 >> 13;
      y2 = x2;
      x2 = this.P0(x3);
    }
    for (int index = 16 /*0x10*/; index < 64 /*0x40*/; ++index)
    {
      uint num14 = x1 << 12 | x1 >> 20;
      uint num15 = num14 + x2 + SM3Digest.T[index];
      uint num16 = num15 << 7 | num15 >> 25;
      uint num17 = num16 ^ num14;
      uint num18 = this.W[index];
      uint num19 = num18 ^ this.W[index + 4];
      int num20 = (int) this.FF1(x1, y1, z1) + (int) num5 + (int) num17 + (int) num19;
      uint x4 = this.GG1(x2, y2, z2) + num6 + num16 + num18;
      num5 = z1;
      z1 = y1 << 9 | y1 >> 23;
      y1 = x1;
      x1 = (uint) num20;
      num6 = z2;
      z2 = y2 << 19 | y2 >> 13;
      y2 = x2;
      x2 = this.P0(x4);
    }
    this.V[0] ^= x1;
    this.V[1] ^= y1;
    this.V[2] ^= z1;
    this.V[3] ^= num5;
    this.V[4] ^= x2;
    this.V[5] ^= y2;
    this.V[6] ^= z2;
    this.V[7] ^= num6;
    this.xOff = 0;
  }
}
