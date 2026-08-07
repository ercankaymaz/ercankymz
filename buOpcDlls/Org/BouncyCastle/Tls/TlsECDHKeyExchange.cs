// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsECDHKeyExchange
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class TlsECDHKeyExchange(int keyExchange) : AbstractTlsKeyExchange(TlsECDHKeyExchange.CheckKeyExchange(keyExchange))
{
  protected TlsCredentialedAgreement m_agreementCredentials;
  protected TlsCertificate m_ecdhPeerCertificate;

  private static int CheckKeyExchange(int keyExchange)
  {
    return keyExchange == 16 /*0x10*/ || keyExchange == 18 ? keyExchange : throw new ArgumentException("unsupported key exchange algorithm", nameof (keyExchange));
  }

  public override void SkipServerCredentials() => throw new TlsFatalAlert((short) 80 /*0x50*/);

  public override void ProcessServerCredentials(TlsCredentials serverCredentials)
  {
    this.m_agreementCredentials = TlsUtilities.RequireAgreementCredentials(serverCredentials);
  }

  public override void ProcessServerCertificate(Certificate serverCertificate)
  {
    this.m_ecdhPeerCertificate = serverCertificate.GetCertificateAt(0).CheckUsageInRole(2);
  }

  public override short[] GetClientCertificateTypes()
  {
    return new short[2]{ (short) 66, (short) 65 };
  }

  public override void SkipClientCredentials() => throw new TlsFatalAlert((short) 10);

  public override void ProcessClientCredentials(TlsCredentials clientCredentials)
  {
    this.m_agreementCredentials = TlsUtilities.RequireAgreementCredentials(clientCredentials);
  }

  public override void GenerateClientKeyExchange(Stream output)
  {
  }

  public override void ProcessClientCertificate(Certificate clientCertificate)
  {
    this.m_ecdhPeerCertificate = clientCertificate.GetCertificateAt(0).CheckUsageInRole(2);
  }

  public override void ProcessClientKeyExchange(Stream input)
  {
  }

  public override bool RequiresCertificateVerify => false;

  public override TlsSecret GeneratePreMasterSecret()
  {
    return this.m_agreementCredentials.GenerateAgreement(this.m_ecdhPeerCertificate);
  }
}
