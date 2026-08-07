// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsDheKeyExchange
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class TlsDheKeyExchange : AbstractTlsKeyExchange
{
  protected TlsDHGroupVerifier m_dhGroupVerifier;
  protected TlsDHConfig m_dhConfig;
  protected TlsCredentialedSigner m_serverCredentials;
  protected TlsCertificate m_serverCertificate;
  protected TlsAgreement m_agreement;

  private static int CheckKeyExchange(int keyExchange)
  {
    return keyExchange == 3 || keyExchange == 5 ? keyExchange : throw new ArgumentException("unsupported key exchange algorithm", nameof (keyExchange));
  }

  public TlsDheKeyExchange(int keyExchange, TlsDHGroupVerifier dhGroupVerifier)
    : this(keyExchange, dhGroupVerifier, (TlsDHConfig) null)
  {
  }

  public TlsDheKeyExchange(int keyExchange, TlsDHConfig dhConfig)
    : this(keyExchange, (TlsDHGroupVerifier) null, dhConfig)
  {
  }

  private TlsDheKeyExchange(
    int keyExchange,
    TlsDHGroupVerifier dhGroupVerifier,
    TlsDHConfig dhConfig)
    : base(TlsDheKeyExchange.CheckKeyExchange(keyExchange))
  {
    this.m_dhGroupVerifier = dhGroupVerifier;
    this.m_dhConfig = dhConfig;
  }

  public override void SkipServerCredentials() => throw new TlsFatalAlert((short) 80 /*0x50*/);

  public override void ProcessServerCredentials(TlsCredentials serverCredentials)
  {
    this.m_serverCredentials = TlsUtilities.RequireSignerCredentials(serverCredentials);
  }

  public override void ProcessServerCertificate(Certificate serverCertificate)
  {
    this.m_serverCertificate = serverCertificate.GetCertificateAt(0);
  }

  public override bool RequiresServerKeyExchange => true;

  public override byte[] GenerateServerKeyExchange()
  {
    DigestInputBuffer digestInputBuffer = new DigestInputBuffer();
    TlsDHUtilities.WriteDHConfig(this.m_dhConfig, (Stream) digestInputBuffer);
    this.m_agreement = this.m_context.Crypto.CreateDHDomain(this.m_dhConfig).CreateDH();
    TlsUtilities.WriteOpaque16(this.m_agreement.GenerateEphemeral(), (Stream) digestInputBuffer);
    TlsUtilities.GenerateServerKeyExchangeSignature(this.m_context, this.m_serverCredentials, (byte[]) null, digestInputBuffer);
    return digestInputBuffer.ToArray();
  }

  public override void ProcessServerKeyExchange(Stream input)
  {
    DigestInputBuffer digestInputBuffer = new DigestInputBuffer();
    Stream input1 = (Stream) new TeeInputStream(input, (Stream) digestInputBuffer);
    this.m_dhConfig = TlsDHUtilities.ReceiveDHConfig(this.m_context, this.m_dhGroupVerifier, input1);
    byte[] peerValue = TlsUtilities.ReadOpaque16(input1, 1);
    TlsUtilities.VerifyServerKeyExchangeSignature(this.m_context, input, this.m_serverCertificate, (byte[]) null, digestInputBuffer);
    this.m_agreement = this.m_context.Crypto.CreateDHDomain(this.m_dhConfig).CreateDH();
    this.m_agreement.ReceivePeerValue(peerValue);
  }

  public override short[] GetClientCertificateTypes()
  {
    return new short[3]
    {
      (short) 2,
      (short) 64 /*0x40*/,
      (short) 1
    };
  }

  public override void ProcessClientCredentials(TlsCredentials clientCredentials)
  {
    TlsUtilities.RequireSignerCredentials(clientCredentials);
  }

  public override void GenerateClientKeyExchange(Stream output)
  {
    TlsUtilities.WriteOpaque16(this.m_agreement.GenerateEphemeral(), output);
  }

  public override void ProcessClientKeyExchange(Stream input)
  {
    this.m_agreement.ReceivePeerValue(TlsUtilities.ReadOpaque16(input, 1));
  }

  public override TlsSecret GeneratePreMasterSecret() => this.m_agreement.CalculateSecret();
}
