// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsECDheKeyExchange
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class TlsECDheKeyExchange : AbstractTlsKeyExchange
{
  protected TlsECConfig m_ecConfig;
  protected TlsCredentialedSigner m_serverCredentials;
  protected TlsCertificate m_serverCertificate;
  protected TlsAgreement m_agreement;

  private static int CheckKeyExchange(int keyExchange)
  {
    return keyExchange == 17 || keyExchange == 19 ? keyExchange : throw new ArgumentException("unsupported key exchange algorithm", nameof (keyExchange));
  }

  public TlsECDheKeyExchange(int keyExchange)
    : this(keyExchange, (TlsECConfig) null)
  {
  }

  public TlsECDheKeyExchange(int keyExchange, TlsECConfig ecConfig)
    : base(TlsECDheKeyExchange.CheckKeyExchange(keyExchange))
  {
    this.m_ecConfig = ecConfig;
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
    TlsEccUtilities.WriteECConfig(this.m_ecConfig, (Stream) digestInputBuffer);
    this.m_agreement = this.m_context.Crypto.CreateECDomain(this.m_ecConfig).CreateECDH();
    this.GenerateEphemeral((Stream) digestInputBuffer);
    TlsUtilities.GenerateServerKeyExchangeSignature(this.m_context, this.m_serverCredentials, (byte[]) null, digestInputBuffer);
    return digestInputBuffer.ToArray();
  }

  public override void ProcessServerKeyExchange(Stream input)
  {
    DigestInputBuffer digestInputBuffer = new DigestInputBuffer();
    Stream input1 = (Stream) new TeeInputStream(input, (Stream) digestInputBuffer);
    this.m_ecConfig = TlsEccUtilities.ReceiveECDHConfig(this.m_context, input1);
    byte[] point = TlsUtilities.ReadOpaque8(input1, 1);
    TlsUtilities.VerifyServerKeyExchangeSignature(this.m_context, input, this.m_serverCertificate, (byte[]) null, digestInputBuffer);
    this.m_agreement = this.m_context.Crypto.CreateECDomain(this.m_ecConfig).CreateECDH();
    this.ProcessEphemeral(point);
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

  public override void GenerateClientKeyExchange(Stream output) => this.GenerateEphemeral(output);

  public override void ProcessClientKeyExchange(Stream input)
  {
    this.ProcessEphemeral(TlsUtilities.ReadOpaque8(input, 1));
  }

  public override TlsSecret GeneratePreMasterSecret() => this.m_agreement.CalculateSecret();

  protected virtual void GenerateEphemeral(Stream output)
  {
    TlsUtilities.WriteOpaque8(this.m_agreement.GenerateEphemeral(), output);
  }

  protected virtual void ProcessEphemeral(byte[] point)
  {
    TlsEccUtilities.CheckPointEncoding(this.m_ecConfig.NamedGroup, point);
    this.m_agreement.ReceivePeerValue(point);
  }
}
