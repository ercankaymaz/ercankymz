// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.ShortenedDigest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public class ShortenedDigest : IDigest
{
  private IDigest baseDigest;
  private int length;

  public ShortenedDigest(IDigest baseDigest, int length)
  {
    if (baseDigest == null)
      throw new ArgumentNullException(nameof (baseDigest));
    this.baseDigest = length <= baseDigest.GetDigestSize() ? baseDigest : throw new ArgumentException("baseDigest output not large enough to support length");
    this.length = length;
  }

  public string AlgorithmName => $"{this.baseDigest.AlgorithmName}({(this.length * 8).ToString()})";

  public int GetDigestSize() => this.length;

  public void Update(byte input) => this.baseDigest.Update(input);

  public void BlockUpdate(byte[] input, int inOff, int length)
  {
    this.baseDigest.BlockUpdate(input, inOff, length);
  }

  public int DoFinal(byte[] output, int outOff)
  {
    byte[] numArray = new byte[this.baseDigest.GetDigestSize()];
    this.baseDigest.DoFinal(numArray, 0);
    Array.Copy((Array) numArray, 0, (Array) output, outOff, this.length);
    return this.length;
  }

  public void Reset() => this.baseDigest.Reset();

  public int GetByteLength() => this.baseDigest.GetByteLength();
}
