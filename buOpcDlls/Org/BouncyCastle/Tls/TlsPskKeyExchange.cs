// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsPskKeyExchange
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class TlsPskKeyExchange : AbstractTlsKeyExchange
{
  protected TlsPskIdentity m_pskIdentity;
  protected TlsPskIdentityManager m_pskIdentityManager;
  protected TlsDHGroupVerifier m_dhGroupVerifier;
  protected byte[] m_psk_identity_hint;
  protected byte[] m_psk;
  protected TlsDHConfig m_dhConfig;
  protected TlsECConfig m_ecConfig;
  protected TlsAgreement m_agreement;
  protected TlsCredentialedDecryptor m_serverCredentials;
  protected TlsEncryptor m_serverEncryptor;
  protected TlsSecret m_preMasterSecret;

  private static int CheckKeyExchange(int keyExchange)
  {
    switch (keyExchange)
    {
      case 13:
      case 14:
      case 15:
      case 24:
        return keyExchange;
      default:
        throw new ArgumentException("unsupported key exchange algorithm", nameof (keyExchange));
    }
  }

  public TlsPskKeyExchange(
    int keyExchange,
    TlsPskIdentity pskIdentity,
    TlsDHGroupVerifier dhGroupVerifier)
    : this(keyExchange, pskIdentity, (TlsPskIdentityManager) null, dhGroupVerifier, (TlsDHConfig) null, (TlsECConfig) null)
  {
  }

  public TlsPskKeyExchange(
    int keyExchange,
    TlsPskIdentityManager pskIdentityManager,
    TlsDHConfig dhConfig,
    TlsECConfig ecConfig)
    : this(keyExchange, (TlsPskIdentity) null, pskIdentityManager, (TlsDHGroupVerifier) null, dhConfig, ecConfig)
  {
  }

  private TlsPskKeyExchange(
    int keyExchange,
    TlsPskIdentity pskIdentity,
    TlsPskIdentityManager pskIdentityManager,
    TlsDHGroupVerifier dhGroupVerifier,
    TlsDHConfig dhConfig,
    TlsECConfig ecConfig)
    : base(TlsPskKeyExchange.CheckKeyExchange(keyExchange))
  {
    this.m_pskIdentity = pskIdentity;
    this.m_pskIdentityManager = pskIdentityManager;
    this.m_dhGroupVerifier = dhGroupVerifier;
    this.m_dhConfig = dhConfig;
    this.m_ecConfig = ecConfig;
  }

  public override void SkipServerCredentials()
  {
    if (this.m_keyExchange == 15)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public override void ProcessServerCredentials(TlsCredentials serverCredentials)
  {
    if (this.m_keyExchange != 15)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    this.m_serverCredentials = TlsUtilities.RequireDecryptorCredentials(serverCredentials);
  }

  public override void ProcessServerCertificate(Certificate serverCertificate)
  {
    if (this.m_keyExchange != 15)
      throw new TlsFatalAlert((short) 10);
    this.m_serverEncryptor = serverCertificate.GetCertificateAt(0).CreateEncryptor(3);
  }

  public override byte[] GenerateServerKeyExchange()
  {
    this.m_psk_identity_hint = this.m_pskIdentityManager.GetHint();
    if (this.m_psk_identity_hint == null && !this.RequiresServerKeyExchange)
      return (byte[]) null;
    MemoryStream output = new MemoryStream();
    if (this.m_psk_identity_hint == null)
      TlsUtilities.WriteOpaque16(TlsUtilities.EmptyBytes, (Stream) output);
    else
      TlsUtilities.WriteOpaque16(this.m_psk_identity_hint, (Stream) output);
    if (this.m_keyExchange == 14)
    {
      if (this.m_dhConfig == null)
        throw new TlsFatalAlert((short) 80 /*0x50*/);
      TlsDHUtilities.WriteDHConfig(this.m_dhConfig, (Stream) output);
      this.m_agreement = this.m_context.Crypto.CreateDHDomain(this.m_dhConfig).CreateDH();
      this.GenerateEphemeralDH((Stream) output);
    }
    else if (this.m_keyExchange == 24)
    {
      if (this.m_ecConfig == null)
        throw new TlsFatalAlert((short) 80 /*0x50*/);
      TlsEccUtilities.WriteECConfig(this.m_ecConfig, (Stream) output);
      this.m_agreement = this.m_context.Crypto.CreateECDomain(this.m_ecConfig).CreateECDH();
      this.GenerateEphemeralECDH((Stream) output);
    }
    return output.ToArray();
  }

  public override bool RequiresServerKeyExchange
  {
    get
    {
      switch (this.m_keyExchange)
      {
        case 14:
        case 24:
          return true;
        default:
          return false;
      }
    }
  }

  public override void ProcessServerKeyExchange(Stream input)
  {
    this.m_psk_identity_hint = TlsUtilities.ReadOpaque16(input);
    if (this.m_keyExchange == 14)
    {
      this.m_dhConfig = TlsDHUtilities.ReceiveDHConfig(this.m_context, this.m_dhGroupVerifier, input);
      byte[] y = TlsUtilities.ReadOpaque16(input, 1);
      this.m_agreement = this.m_context.Crypto.CreateDHDomain(this.m_dhConfig).CreateDH();
      this.ProcessEphemeralDH(y);
    }
    else
    {
      if (this.m_keyExchange != 24)
        return;
      this.m_ecConfig = TlsEccUtilities.ReceiveECDHConfig(this.m_context, input);
      byte[] point = TlsUtilities.ReadOpaque8(input, 1);
      this.m_agreement = this.m_context.Crypto.CreateECDomain(this.m_ecConfig).CreateECDH();
      this.ProcessEphemeralECDH(point);
    }
  }

  public override void ProcessClientCredentials(TlsCredentials clientCredentials)
  {
    throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public override void GenerateClientKeyExchange(Stream output)
  {
    if (this.m_psk_identity_hint == null)
      this.m_pskIdentity.SkipIdentityHint();
    else
      this.m_pskIdentity.NotifyIdentityHint(this.m_psk_identity_hint);
    byte[] pskIdentity = this.m_pskIdentity.GetPskIdentity();
    if (pskIdentity == null)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    this.m_psk = this.m_pskIdentity.GetPsk();
    if (this.m_psk == null)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    TlsUtilities.WriteOpaque16(pskIdentity, output);
    this.m_context.SecurityParameters.m_pskIdentity = Arrays.Clone(pskIdentity);
    if (this.m_keyExchange == 14)
      this.GenerateEphemeralDH(output);
    else if (this.m_keyExchange == 24)
    {
      this.GenerateEphemeralECDH(output);
    }
    else
    {
      if (this.m_keyExchange != 15)
        return;
      this.m_preMasterSecret = TlsUtilities.GenerateEncryptedPreMasterSecret(this.m_context, this.m_serverEncryptor, output);
    }
  }

  public override void ProcessClientKeyExchange(Stream input)
  {
    byte[] identity = TlsUtilities.ReadOpaque16(input);
    this.m_psk = this.m_pskIdentityManager.GetPsk(identity);
    if (this.m_psk == null)
      throw new TlsFatalAlert((short) 115);
    this.m_context.SecurityParameters.m_pskIdentity = identity;
    if (this.m_keyExchange == 14)
      this.ProcessEphemeralDH(TlsUtilities.ReadOpaque16(input, 1));
    else if (this.m_keyExchange == 24)
    {
      this.ProcessEphemeralECDH(TlsUtilities.ReadOpaque8(input, 1));
    }
    else
    {
      if (this.m_keyExchange != 15)
        return;
      this.m_preMasterSecret = this.m_serverCredentials.Decrypt(new TlsCryptoParameters(this.m_context), TlsUtilities.ReadEncryptedPms(this.m_context, input));
    }
  }

  public override TlsSecret GeneratePreMasterSecret()
  {
    byte[] otherSecret = this.GenerateOtherSecret(this.m_psk.Length);
    MemoryStream output = new MemoryStream(4 + otherSecret.Length + this.m_psk.Length);
    TlsUtilities.WriteOpaque16(otherSecret, (Stream) output);
    TlsUtilities.WriteOpaque16(this.m_psk, (Stream) output);
    Array.Clear((Array) this.m_psk, 0, this.m_psk.Length);
    this.m_psk = (byte[]) null;
    return this.m_context.Crypto.CreateSecret(output.ToArray());
  }

  protected virtual void GenerateEphemeralDH(Stream output)
  {
    TlsUtilities.WriteOpaque16(this.m_agreement.GenerateEphemeral(), output);
  }

  protected virtual void GenerateEphemeralECDH(Stream output)
  {
    TlsUtilities.WriteOpaque8(this.m_agreement.GenerateEphemeral(), output);
  }

  protected virtual byte[] GenerateOtherSecret(int pskLength)
  {
    if (this.m_keyExchange == 13)
      return new byte[pskLength];
    if ((this.m_keyExchange == 14 || this.m_keyExchange == 24) && this.m_agreement != null)
      return this.m_agreement.CalculateSecret().Extract();
    return this.m_keyExchange == 15 && this.m_preMasterSecret != null ? this.m_preMasterSecret.Extract() : throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  protected virtual void ProcessEphemeralDH(byte[] y) => this.m_agreement.ReceivePeerValue(y);

  protected virtual void ProcessEphemeralECDH(byte[] point)
  {
    TlsEccUtilities.CheckPointEncoding(this.m_ecConfig.NamedGroup, point);
    this.m_agreement.ReceivePeerValue(point);
  }
}
