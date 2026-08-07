// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.ShakeDigest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public class ShakeDigest : KeccakDigest, IXof, IDigest
{
  private static int CheckBitLength(int bitLength)
  {
    return bitLength == 128 /*0x80*/ || bitLength == 256 /*0x0100*/ ? bitLength : throw new ArgumentException(bitLength.ToString() + " not supported for SHAKE", nameof (bitLength));
  }

  public ShakeDigest()
    : this(128 /*0x80*/)
  {
  }

  public ShakeDigest(int bitLength)
    : base(ShakeDigest.CheckBitLength(bitLength))
  {
  }

  public ShakeDigest(ShakeDigest source)
    : base((KeccakDigest) source)
  {
  }

  public override string AlgorithmName => "SHAKE" + this.fixedOutputLength.ToString();

  public override int GetDigestSize() => this.fixedOutputLength >> 2;

  public override int DoFinal(byte[] output, int outOff)
  {
    return this.OutputFinal(output, outOff, this.GetDigestSize());
  }

  public virtual int OutputFinal(byte[] output, int outOff, int outLen)
  {
    int num = this.Output(output, outOff, outLen);
    this.Reset();
    return num;
  }

  public virtual int Output(byte[] output, int outOff, int outLen)
  {
    if (!this.squeezing)
      this.AbsorbBits(15, 4);
    this.Squeeze(output, outOff, (long) outLen << 3);
    return outLen;
  }

  protected override int DoFinal(byte[] output, int outOff, byte partialByte, int partialBits)
  {
    return this.OutputFinal(output, outOff, this.GetDigestSize(), partialByte, partialBits);
  }

  protected virtual int OutputFinal(
    byte[] output,
    int outOff,
    int outLen,
    byte partialByte,
    int partialBits)
  {
    if (partialBits < 0 || partialBits > 7)
      throw new ArgumentException("must be in the range [0,7]", nameof (partialBits));
    int data = (int) partialByte & (1 << partialBits) - 1 | 15 << partialBits;
    int bits = partialBits + 4;
    if (bits >= 8)
    {
      this.Absorb((byte) data);
      bits -= 8;
      data >>= 8;
    }
    if (bits > 0)
      this.AbsorbBits(data, bits);
    this.Squeeze(output, outOff, (long) outLen << 3);
    this.Reset();
    return outLen;
  }

  public override IMemoable Copy() => (IMemoable) new ShakeDigest(this);
}
