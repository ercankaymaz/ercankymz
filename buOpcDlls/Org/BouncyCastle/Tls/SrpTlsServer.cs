// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.SrpTlsServer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class SrpTlsServer : AbstractTlsServer
{
  private static readonly int[] DefaultCipherSuites = new int[6]
  {
    49186,
    49183,
    49185,
    49182,
    49184,
    49181
  };
  protected readonly TlsSrpIdentityManager m_srpIdentityManager;
  protected byte[] m_srpIdentity;
  protected TlsSrpLoginParameters m_srpLoginParameters;

  public SrpTlsServer(TlsCrypto crypto, TlsSrpIdentityManager srpIdentityManager)
    : base(crypto)
  {
    this.m_srpIdentityManager = srpIdentityManager;
  }

  protected virtual TlsCredentialedSigner GetDsaSignerCredentials()
  {
    throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  protected virtual TlsCredentialedSigner GetRsaSignerCredentials()
  {
    throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  protected override ProtocolVersion[] GetSupportedVersions() => ProtocolVersion.TLSv12.Only();

  protected override int[] GetSupportedCipherSuites()
  {
    return TlsUtilities.GetSupportedCipherSuites(this.Crypto, SrpTlsServer.DefaultCipherSuites);
  }

  public override void ProcessClientExtensions(IDictionary<int, byte[]> clientExtensions)
  {
    base.ProcessClientExtensions(clientExtensions);
    this.m_srpIdentity = TlsSrpUtilities.GetSrpExtension(clientExtensions);
  }

  public override int GetSelectedCipherSuite()
  {
    int selectedCipherSuite = base.GetSelectedCipherSuite();
    if (!TlsSrpUtilities.IsSrpCipherSuite(selectedCipherSuite))
      return selectedCipherSuite;
    if (this.m_srpIdentity != null)
      this.m_srpLoginParameters = this.m_srpIdentityManager.GetLoginParameters(this.m_srpIdentity);
    if (this.m_srpLoginParameters != null)
      return selectedCipherSuite;
    throw new TlsFatalAlert((short) 115);
  }

  public override TlsCredentials GetCredentials()
  {
    switch (this.m_context.SecurityParameters.KeyExchangeAlgorithm)
    {
      case 21:
        return (TlsCredentials) null;
      case 22:
        return (TlsCredentials) this.GetDsaSignerCredentials();
      case 23:
        return (TlsCredentials) this.GetRsaSignerCredentials();
      default:
        throw new TlsFatalAlert((short) 80 /*0x50*/);
    }
  }

  public override TlsSrpLoginParameters GetSrpLoginParameters() => this.m_srpLoginParameters;
}
