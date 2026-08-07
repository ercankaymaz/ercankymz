// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsDHanonKeyExchange
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class TlsDHanonKeyExchange : AbstractTlsKeyExchange
{
  protected TlsDHGroupVerifier m_dhGroupVerifier;
  protected TlsDHConfig m_dhConfig;
  protected TlsAgreement m_agreement;

  private static int CheckKeyExchange(int keyExchange)
  {
    return keyExchange == 11 ? keyExchange : throw new ArgumentException("unsupported key exchange algorithm", nameof (keyExchange));
  }

  public TlsDHanonKeyExchange(int keyExchange, TlsDHGroupVerifier dhGroupVerifier)
    : this(keyExchange, dhGroupVerifier, (TlsDHConfig) null)
  {
  }

  public TlsDHanonKeyExchange(int keyExchange, TlsDHConfig dhConfig)
    : this(keyExchange, (TlsDHGroupVerifier) null, dhConfig)
  {
  }

  private TlsDHanonKeyExchange(
    int keyExchange,
    TlsDHGroupVerifier dhGroupVerifier,
    TlsDHConfig dhConfig)
    : base(TlsDHanonKeyExchange.CheckKeyExchange(keyExchange))
  {
    this.m_dhGroupVerifier = dhGroupVerifier;
    this.m_dhConfig = dhConfig;
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
    TlsDHUtilities.WriteDHConfig(this.m_dhConfig, (Stream) output);
    this.m_agreement = this.m_context.Crypto.CreateDHDomain(this.m_dhConfig).CreateDH();
    TlsUtilities.WriteOpaque16(this.m_agreement.GenerateEphemeral(), (Stream) output);
    return output.ToArray();
  }

  public override void ProcessServerKeyExchange(Stream input)
  {
    this.m_dhConfig = TlsDHUtilities.ReceiveDHConfig(this.m_context, this.m_dhGroupVerifier, input);
    byte[] peerValue = TlsUtilities.ReadOpaque16(input, 1);
    this.m_agreement = this.m_context.Crypto.CreateDHDomain(this.m_dhConfig).CreateDH();
    this.m_agreement.ReceivePeerValue(peerValue);
  }

  public override short[] GetClientCertificateTypes() => (short[]) null;

  public override void ProcessClientCredentials(TlsCredentials clientCredentials)
  {
    throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public override void GenerateClientKeyExchange(Stream output)
  {
    TlsUtilities.WriteOpaque16(this.m_agreement.GenerateEphemeral(), output);
  }

  public override void ProcessClientCertificate(Certificate clientCertificate)
  {
    throw new TlsFatalAlert((short) 10);
  }

  public override void ProcessClientKeyExchange(Stream input)
  {
    this.m_agreement.ReceivePeerValue(TlsUtilities.ReadOpaque16(input, 1));
  }

  public override TlsSecret GeneratePreMasterSecret() => this.m_agreement.CalculateSecret();
}
