// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Agreement.Kdf.ConcatenationKdfGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Agreement.Kdf;

public sealed class ConcatenationKdfGenerator : IDerivationFunction
{
  private readonly IDigest m_digest;
  private readonly int m_hLen;
  private byte[] m_buffer;

  public ConcatenationKdfGenerator(IDigest digest)
  {
    this.m_digest = digest;
    this.m_hLen = digest.GetDigestSize();
  }

  public void Init(IDerivationParameters param)
  {
    byte[] numArray = param is KdfParameters kdfParameters ? kdfParameters.GetSharedSecret() : throw new ArgumentException("KDF parameters required for ConcatenationKdfGenerator");
    byte[] iv = kdfParameters.GetIV();
    this.m_buffer = new byte[4 + numArray.Length + (iv == null ? 0 : iv.Length) + this.m_hLen];
    numArray.CopyTo((Array) this.m_buffer, 4);
    iv?.CopyTo((Array) this.m_buffer, 4 + numArray.Length);
  }

  public IDigest Digest => this.m_digest;

  public int GenerateBytes(byte[] output, int outOff, int length)
  {
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, length, "output buffer too small");
    int num1 = this.m_buffer.Length - this.m_hLen;
    uint n = 1;
    this.m_digest.Reset();
    int num2 = outOff + length;
    for (int index = num2 - this.m_hLen; outOff <= index; outOff += this.m_hLen)
    {
      Pack.UInt32_To_BE(n++, this.m_buffer, 0);
      this.m_digest.BlockUpdate(this.m_buffer, 0, num1);
      this.m_digest.DoFinal(output, outOff);
    }
    if (outOff < num2)
    {
      Pack.UInt32_To_BE(n, this.m_buffer, 0);
      this.m_digest.BlockUpdate(this.m_buffer, 0, num1);
      this.m_digest.DoFinal(this.m_buffer, num1);
      Array.Copy((Array) this.m_buffer, num1, (Array) output, outOff, num2 - outOff);
    }
    return length;
  }
}
