// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.NonMemoableDigest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public class NonMemoableDigest : IDigest
{
  protected readonly IDigest mBaseDigest;

  public NonMemoableDigest(IDigest baseDigest)
  {
    this.mBaseDigest = baseDigest != null ? baseDigest : throw new ArgumentNullException(nameof (baseDigest));
  }

  public virtual string AlgorithmName => this.mBaseDigest.AlgorithmName;

  public virtual int GetDigestSize() => this.mBaseDigest.GetDigestSize();

  public virtual void Update(byte input) => this.mBaseDigest.Update(input);

  public virtual void BlockUpdate(byte[] input, int inOff, int len)
  {
    this.mBaseDigest.BlockUpdate(input, inOff, len);
  }

  public virtual int DoFinal(byte[] output, int outOff) => this.mBaseDigest.DoFinal(output, outOff);

  public virtual void Reset() => this.mBaseDigest.Reset();

  public virtual int GetByteLength() => this.mBaseDigest.GetByteLength();
}
