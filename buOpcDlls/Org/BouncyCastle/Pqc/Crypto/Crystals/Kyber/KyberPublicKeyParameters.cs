// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber.KyberPublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber;

public sealed class KyberPublicKeyParameters : KyberKeyParameters
{
  private readonly byte[] m_t;
  private readonly byte[] m_rho;

  public byte[] GetEncoded() => Arrays.Concatenate(this.m_t, this.m_rho);

  public KyberPublicKeyParameters(KyberParameters parameters, byte[] encoding)
    : base(false, parameters)
  {
    this.m_t = Arrays.CopyOfRange(encoding, 0, encoding.Length - KyberEngine.SymBytes);
    this.m_rho = Arrays.CopyOfRange(encoding, encoding.Length - KyberEngine.SymBytes, encoding.Length);
  }

  public KyberPublicKeyParameters(KyberParameters parameters, byte[] t, byte[] rho)
    : base(false, parameters)
  {
    this.m_t = Arrays.Clone(t);
    this.m_rho = Arrays.Clone(rho);
  }

  internal byte[] T => this.m_t;

  internal byte[] Rho => this.m_rho;
}
