// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsRsaEncryptor
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

internal sealed class BcTlsRsaEncryptor : TlsEncryptor
{
  private readonly BcTlsCrypto m_crypto;
  private readonly RsaKeyParameters m_pubKeyRsa;

  private static RsaKeyParameters CheckPublicKey(RsaKeyParameters pubKeyRsa)
  {
    return pubKeyRsa != null && !pubKeyRsa.IsPrivate ? pubKeyRsa : throw new ArgumentException("No public RSA key provided", nameof (pubKeyRsa));
  }

  internal BcTlsRsaEncryptor(BcTlsCrypto crypto, RsaKeyParameters pubKeyRsa)
  {
    this.m_crypto = crypto;
    this.m_pubKeyRsa = BcTlsRsaEncryptor.CheckPublicKey(pubKeyRsa);
  }

  public byte[] Encrypt(byte[] input, int inOff, int length)
  {
    try
    {
      Pkcs1Encoding pkcs1Encoding = new Pkcs1Encoding((IAsymmetricBlockCipher) new RsaBlindedEngine());
      pkcs1Encoding.Init(true, (ICipherParameters) new ParametersWithRandom((ICipherParameters) this.m_pubKeyRsa, this.m_crypto.SecureRandom));
      return pkcs1Encoding.ProcessBlock(input, inOff, length);
    }
    catch (InvalidCipherTextException ex)
    {
      throw new TlsFatalAlert((short) 80 /*0x50*/, (Exception) ex);
    }
  }
}
