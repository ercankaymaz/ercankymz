// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.DefaultTlsServer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class DefaultTlsServer : AbstractTlsServer
{
  private static readonly int[] DefaultCipherSuites = new int[23]
  {
    4867,
    4866,
    4865,
    52392,
    49200,
    49199,
    49192,
    49191,
    49172,
    49171,
    52394,
    159,
    158,
    107,
    103,
    57,
    51,
    157,
    156,
    61,
    60,
    53,
    47
  };

  public DefaultTlsServer(TlsCrypto crypto)
    : base(crypto)
  {
  }

  protected virtual TlsCredentialedSigner GetDsaSignerCredentials()
  {
    throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  protected virtual TlsCredentialedSigner GetECDsaSignerCredentials()
  {
    throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  protected virtual TlsCredentialedDecryptor GetRsaEncryptionCredentials()
  {
    throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  protected virtual TlsCredentialedSigner GetRsaSignerCredentials()
  {
    throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  protected override int[] GetSupportedCipherSuites()
  {
    return TlsUtilities.GetSupportedCipherSuites(this.Crypto, DefaultTlsServer.DefaultCipherSuites);
  }

  public override TlsCredentials GetCredentials()
  {
    switch (this.m_context.SecurityParameters.KeyExchangeAlgorithm)
    {
      case 1:
        return (TlsCredentials) this.GetRsaEncryptionCredentials();
      case 3:
        return (TlsCredentials) this.GetDsaSignerCredentials();
      case 5:
      case 19:
        return (TlsCredentials) this.GetRsaSignerCredentials();
      case 17:
        return (TlsCredentials) this.GetECDsaSignerCredentials();
      default:
        throw new TlsFatalAlert((short) 80 /*0x50*/);
    }
  }
}
