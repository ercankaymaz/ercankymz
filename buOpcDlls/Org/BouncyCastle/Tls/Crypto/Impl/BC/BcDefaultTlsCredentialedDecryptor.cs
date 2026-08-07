// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcDefaultTlsCredentialedDecryptor
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public class BcDefaultTlsCredentialedDecryptor : TlsCredentialedDecryptor, TlsCredentials
{
  protected readonly BcTlsCrypto m_crypto;
  protected readonly Certificate m_certificate;
  protected readonly AsymmetricKeyParameter m_privateKey;

  public BcDefaultTlsCredentialedDecryptor(
    BcTlsCrypto crypto,
    Certificate certificate,
    AsymmetricKeyParameter privateKey)
  {
    if (crypto == null)
      throw new ArgumentNullException(nameof (crypto));
    if (certificate == null)
      throw new ArgumentNullException(nameof (certificate));
    if (certificate.IsEmpty)
      throw new ArgumentException("cannot be empty", nameof (certificate));
    if (privateKey == null)
      throw new ArgumentNullException(nameof (privateKey));
    if (!privateKey.IsPrivate)
      throw new ArgumentException("must be private", nameof (privateKey));
    if (!(privateKey is RsaKeyParameters))
      throw new ArgumentException("'privateKey' type not supported: " + privateKey.GetType().FullName);
    this.m_crypto = crypto;
    this.m_certificate = certificate;
    this.m_privateKey = privateKey;
  }

  public virtual Certificate Certificate => this.m_certificate;

  public virtual TlsSecret Decrypt(TlsCryptoParameters cryptoParams, byte[] ciphertext)
  {
    return this.SafeDecryptPreMasterSecret(cryptoParams, (RsaKeyParameters) this.m_privateKey, ciphertext);
  }

  protected virtual TlsSecret SafeDecryptPreMasterSecret(
    TlsCryptoParameters cryptoParams,
    RsaKeyParameters rsaServerPrivateKey,
    byte[] encryptedPreMasterSecret)
  {
    SecureRandom secureRandom = this.m_crypto.SecureRandom;
    ProtocolVersion masterSecretVersion = cryptoParams.RsaPreMasterSecretVersion;
    bool flag = false;
    byte[] numArray = new byte[48 /*0x30*/];
    secureRandom.NextBytes(numArray);
    byte[] data = Arrays.Clone(numArray);
    try
    {
      Pkcs1Encoding pkcs1Encoding = new Pkcs1Encoding((IAsymmetricBlockCipher) new RsaBlindedEngine(), numArray);
      pkcs1Encoding.Init(false, (ICipherParameters) new ParametersWithRandom((ICipherParameters) rsaServerPrivateKey, secureRandom));
      data = pkcs1Encoding.ProcessBlock(encryptedPreMasterSecret, 0, encryptedPreMasterSecret.Length);
    }
    catch (Exception ex)
    {
    }
    if (!flag || TlsImplUtilities.IsTlsV11(masterSecretVersion))
    {
      int num = (masterSecretVersion.MajorVersion ^ (int) data[0] & (int) byte.MaxValue | masterSecretVersion.MinorVersion ^ (int) data[1] & (int) byte.MaxValue) - 1 >> 31 /*0x1F*/;
      for (int index = 0; index < 48 /*0x30*/; ++index)
        data[index] = (byte) ((int) data[index] & num | (int) numArray[index] & ~num);
    }
    return this.m_crypto.CreateSecret(data);
  }
}
