// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsRsaKeyExchange
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class TlsRsaKeyExchange(int keyExchange) : AbstractTlsKeyExchange(TlsRsaKeyExchange.CheckKeyExchange(keyExchange))
{
  protected TlsCredentialedDecryptor m_serverCredentials;
  protected TlsEncryptor m_serverEncryptor;
  protected TlsSecret m_preMasterSecret;

  private static int CheckKeyExchange(int keyExchange)
  {
    return keyExchange == 1 ? keyExchange : throw new ArgumentException("unsupported key exchange algorithm", nameof (keyExchange));
  }

  public override void SkipServerCredentials() => throw new TlsFatalAlert((short) 80 /*0x50*/);

  public override void ProcessServerCredentials(TlsCredentials serverCredentials)
  {
    this.m_serverCredentials = TlsUtilities.RequireDecryptorCredentials(serverCredentials);
  }

  public override void ProcessServerCertificate(Certificate serverCertificate)
  {
    this.m_serverEncryptor = serverCertificate.GetCertificateAt(0).CreateEncryptor(3);
  }

  public override short[] GetClientCertificateTypes()
  {
    return new short[3]
    {
      (short) 1,
      (short) 2,
      (short) 64 /*0x40*/
    };
  }

  public override void ProcessClientCredentials(TlsCredentials clientCredentials)
  {
    TlsUtilities.RequireSignerCredentials(clientCredentials);
  }

  public override void GenerateClientKeyExchange(Stream output)
  {
    this.m_preMasterSecret = TlsUtilities.GenerateEncryptedPreMasterSecret(this.m_context, this.m_serverEncryptor, output);
  }

  public override void ProcessClientKeyExchange(Stream input)
  {
    this.m_preMasterSecret = this.m_serverCredentials.Decrypt(new TlsCryptoParameters(this.m_context), TlsUtilities.ReadEncryptedPms(this.m_context, input));
  }

  public override TlsSecret GeneratePreMasterSecret()
  {
    TlsSecret preMasterSecret = this.m_preMasterSecret;
    this.m_preMasterSecret = (TlsSecret) null;
    return preMasterSecret;
  }
}
