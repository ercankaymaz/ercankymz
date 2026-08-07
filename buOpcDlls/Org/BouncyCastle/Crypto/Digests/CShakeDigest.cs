// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.CShakeDigest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public class CShakeDigest : ShakeDigest
{
  private static readonly byte[] padding = new byte[100];
  private readonly byte[] diff;

  private static byte[] EncodeString(byte[] str)
  {
    return Arrays.IsNullOrEmpty(str) ? XofUtilities.LeftEncode(0L) : Arrays.Concatenate(XofUtilities.LeftEncode((long) str.Length * 8L), str);
  }

  public CShakeDigest(int bitLength, byte[] N, byte[] S)
    : base(bitLength)
  {
    if (N != null && N.Length != 0 || S != null && S.Length != 0)
    {
      this.diff = Arrays.ConcatenateAll(XofUtilities.LeftEncode((long) (this.rate / 8)), CShakeDigest.EncodeString(N), CShakeDigest.EncodeString(S));
      this.DiffPadAndAbsorb();
    }
    else
      this.diff = (byte[]) null;
  }

  public CShakeDigest(CShakeDigest source)
    : base((ShakeDigest) source)
  {
    this.diff = Arrays.Clone(source.diff);
  }

  private void DiffPadAndAbsorb()
  {
    int num1 = this.rate / 8;
    this.Absorb(this.diff, 0, this.diff.Length);
    int num2 = this.diff.Length % num1;
    if (num2 == 0)
      return;
    int len;
    for (len = num1 - num2; len > CShakeDigest.padding.Length; len -= CShakeDigest.padding.Length)
      this.Absorb(CShakeDigest.padding, 0, CShakeDigest.padding.Length);
    this.Absorb(CShakeDigest.padding, 0, len);
  }

  public override string AlgorithmName => "CSHAKE" + this.fixedOutputLength.ToString();

  public override int Output(byte[] output, int outOff, int outLen)
  {
    if (this.diff == null)
      return base.Output(output, outOff, outLen);
    if (!this.squeezing)
      this.AbsorbBits(0, 2);
    this.Squeeze(output, outOff, (long) outLen << 3);
    return outLen;
  }

  public override void Reset()
  {
    base.Reset();
    if (this.diff == null)
      return;
    this.DiffPadAndAbsorb();
  }
}
