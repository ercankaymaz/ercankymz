// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsECDHanonKeyExchange
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class TlsECDHanonKeyExchange : AbstractTlsKeyExchange
{
  protected TlsECConfig m_ecConfig;
  protected TlsAgreement m_agreement;

  private static int CheckKeyExchange(int keyExchange)
  {
    return keyExchange == 20 ? keyExchange : throw new ArgumentException("unsupported key exchange algorithm", nameof (keyExchange));
  }

  public TlsECDHanonKeyExchange(int keyExchange)
    : this(keyExchange, (TlsECConfig) null)
  {
  }

  public TlsECDHanonKeyExchange(int keyExchange, TlsECConfig ecConfig)
    : base(TlsECDHanonKeyExchange.CheckKeyExchange(keyExchange))
  {
    this.m_ecConfig = ecConfig;
  }

  public override void SkipServerCredentials()
  {
  }

  public override void ProcessServerCredentials(TlsCredentials serverCredentials)
  {
    throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public override void ProcessServerCertificate(Certificate serverCertificate)
  {
    throw new TlsFatalAlert((short) 10);
  }

  public override bool RequiresServerKeyExchange => true;

  public override byte[] GenerateServerKeyExchange()
  {
    MemoryStream output = new MemoryStream();
    TlsEccUtilities.WriteECConfig(this.m_ecConfig, (Stream) output);
    this.m_agreement = this.m_context.Crypto.CreateECDomain(this.m_ecConfig).CreateECDH();
    this.GenerateEphemeral((Stream) output);
    return output.ToArray();
  }

  public override void ProcessServerKeyExchange(Stream input)
  {
    this.m_ecConfig = TlsEccUtilities.ReceiveECDHConfig(this.m_context, input);
    byte[] point = TlsUtilities.ReadOpaque8(input, 1);
    this.m_agreement = this.m_context.Crypto.CreateECDomain(this.m_ecConfig).CreateECDH();
    this.ProcessEphemeral(point);
  }

  public override short[] GetClientCertificateTypes() => (short[]) null;

  public override void ProcessClientCredentials(TlsCredentials clientCredentials)
  {
    throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public override void GenerateClientKeyExchange(Stream output) => this.GenerateEphemeral(output);

  public override void ProcessClientCertificate(Certificate clientCertificate)
  {
    throw new TlsFatalAlert((short) 10);
  }

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
