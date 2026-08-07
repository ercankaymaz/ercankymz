// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.TlsCryptoParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto;

public class TlsCryptoParameters
{
  private readonly TlsContext m_context;

  public TlsCryptoParameters(TlsContext context) => this.m_context = context;

  public SecurityParameters SecurityParameters => this.m_context.SecurityParameters;

  public ProtocolVersion ClientVersion => this.m_context.ClientVersion;

  public ProtocolVersion RsaPreMasterSecretVersion => this.m_context.RsaPreMasterSecretVersion;

  public virtual ProtocolVersion ServerVersion => this.m_context.ServerVersion;

  public bool IsServer => this.m_context.IsServer;

  public TlsNonceGenerator NonceGenerator => this.m_context.NonceGenerator;
}
