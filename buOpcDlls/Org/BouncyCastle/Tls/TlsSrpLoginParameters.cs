// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsSrpLoginParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class TlsSrpLoginParameters
{
  protected byte[] m_identity;
  protected TlsSrpConfig m_srpConfig;
  protected BigInteger m_verifier;
  protected byte[] m_salt;

  public TlsSrpLoginParameters(
    byte[] identity,
    TlsSrpConfig srpConfig,
    BigInteger verifier,
    byte[] salt)
  {
    this.m_identity = Arrays.Clone(identity);
    this.m_srpConfig = srpConfig;
    this.m_verifier = verifier;
    this.m_salt = Arrays.Clone(salt);
  }

  public virtual TlsSrpConfig Config => this.m_srpConfig;

  public virtual byte[] Identity => this.m_identity;

  public virtual byte[] Salt => this.m_salt;

  public virtual BigInteger Verifier => this.m_verifier;
}
