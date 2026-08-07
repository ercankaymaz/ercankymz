// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.Mgf1BytesGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public sealed class Mgf1BytesGenerator : IDerivationFunction
{
  private readonly IDigest m_digest;
  private readonly int m_hLen;
  private byte[] m_buffer;

  public Mgf1BytesGenerator(IDigest digest)
  {
    this.m_digest = digest;
    this.m_hLen = digest.GetDigestSize();
  }

  public void Init(IDerivationParameters parameters)
  {
    if (!(parameters is MgfParameters mgfParameters))
      throw new ArgumentException("MGF parameters required for MGF1Generator");
    this.m_buffer = new byte[mgfParameters.SeedLength + 4 + this.m_hLen];
    mgfParameters.GetSeed(this.m_buffer, 0);
  }

  public IDigest Digest => this.m_digest;

  public int GenerateBytes(byte[] output, int outOff, int length)
  {
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, length, "output buffer too small");
    int num1 = this.m_buffer.Length - this.m_hLen;
    int off = num1 - 4;
    uint n = 0;
    this.m_digest.Reset();
    int num2 = outOff + length;
    for (int index = num2 - this.m_hLen; outOff <= index; outOff += this.m_hLen)
    {
      Pack.UInt32_To_BE(n++, this.m_buffer, off);
      this.m_digest.BlockUpdate(this.m_buffer, 0, num1);
      this.m_digest.DoFinal(output, outOff);
    }
    if (outOff < num2)
    {
      Pack.UInt32_To_BE(n, this.m_buffer, off);
      this.m_digest.BlockUpdate(this.m_buffer, 0, num1);
      this.m_digest.DoFinal(this.m_buffer, num1);
      Array.Copy((Array) this.m_buffer, num1, (Array) output, outOff, num2 - outOff);
    }
    return length;
  }
}
