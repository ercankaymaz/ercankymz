// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber.KyberPrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber;

public sealed class KyberPrivateKeyParameters : KyberKeyParameters
{
  private readonly byte[] m_s;
  private readonly byte[] m_hpk;
  private readonly byte[] m_nonce;
  private readonly byte[] m_t;
  private readonly byte[] m_rho;

  public KyberPrivateKeyParameters(
    KyberParameters parameters,
    byte[] s,
    byte[] hpk,
    byte[] nonce,
    byte[] t,
    byte[] rho)
    : base(true, parameters)
  {
    this.m_s = Arrays.Clone(s);
    this.m_hpk = Arrays.Clone(hpk);
    this.m_nonce = Arrays.Clone(nonce);
    this.m_t = Arrays.Clone(t);
    this.m_rho = Arrays.Clone(rho);
  }

  public byte[] GetEncoded()
  {
    return Arrays.ConcatenateAll(this.m_s, this.m_t, this.m_rho, this.m_hpk, this.m_nonce);
  }

  internal byte[] S => this.m_s;

  internal byte[] Hpk => this.m_hpk;

  internal byte[] Nonce => this.m_nonce;

  internal byte[] T => this.m_t;

  internal byte[] Rho => this.m_rho;
}
