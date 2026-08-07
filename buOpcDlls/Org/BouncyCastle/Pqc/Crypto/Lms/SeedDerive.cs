// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.SeedDerive
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class SeedDerive
{
  private readonly byte[] m_I;
  private readonly byte[] m_masterSeed;
  private readonly IDigest m_digest;

  public SeedDerive(byte[] I, byte[] masterSeed, IDigest digest)
  {
    this.m_I = I;
    this.m_masterSeed = masterSeed;
    this.m_digest = digest;
  }

  public int Q { get; set; }

  public int J { get; set; }

  public byte[] I => this.m_I;

  public byte[] MasterSeed => this.m_masterSeed;

  public byte[] DeriveSeed(bool incJ, byte[] target, int offset)
  {
    if (target.Length - offset < this.m_digest.GetDigestSize())
      throw new ArgumentException("target length is less than digest size.", nameof (target));
    int q = this.Q;
    int j = this.J;
    this.m_digest.BlockUpdate(this.I, 0, this.I.Length);
    this.m_digest.Update((byte) (q >> 24));
    this.m_digest.Update((byte) (q >> 16 /*0x10*/));
    this.m_digest.Update((byte) (q >> 8));
    this.m_digest.Update((byte) q);
    this.m_digest.Update((byte) (j >> 8));
    this.m_digest.Update((byte) j);
    this.m_digest.Update(byte.MaxValue);
    this.m_digest.BlockUpdate(this.m_masterSeed, 0, this.m_masterSeed.Length);
    this.m_digest.DoFinal(target, offset);
    if (incJ)
      ++this.J;
    return target;
  }
}
