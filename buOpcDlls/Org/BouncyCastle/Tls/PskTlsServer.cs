// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.PskTlsServer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class PskTlsServer : AbstractTlsServer
{
  private static readonly int[] DefaultCipherSuites = new int[12]
  {
    52396,
    49208,
    49207,
    49206,
    49205,
    52397,
    171,
    170,
    179,
    178,
    145,
    144 /*0x90*/
  };
  protected readonly TlsPskIdentityManager m_pskIdentityManager;

  public PskTlsServer(TlsCrypto crypto, TlsPskIdentityManager pskIdentityManager)
    : base(crypto)
  {
    this.m_pskIdentityManager = pskIdentityManager;
  }

  protected virtual TlsCredentialedDecryptor GetRsaEncryptionCredentials()
  {
    throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  protected override ProtocolVersion[] GetSupportedVersions() => ProtocolVersion.TLSv12.Only();

  protected override int[] GetSupportedCipherSuites()
  {
    return TlsUtilities.GetSupportedCipherSuites(this.Crypto, PskTlsServer.DefaultCipherSuites);
  }

  public override TlsCredentials GetCredentials()
  {
    switch (this.m_context.SecurityParameters.KeyExchangeAlgorithm)
    {
      case 13:
      case 14:
      case 24:
        return (TlsCredentials) null;
      case 15:
        return (TlsCredentials) this.GetRsaEncryptionCredentials();
      default:
        throw new TlsFatalAlert((short) 80 /*0x50*/);
    }
  }

  public override TlsPskIdentityManager GetPskIdentityManager() => this.m_pskIdentityManager;
}
