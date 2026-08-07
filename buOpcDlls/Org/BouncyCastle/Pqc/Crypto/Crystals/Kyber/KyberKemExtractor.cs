// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber.KyberKemExtractor
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber;

public sealed class KyberKemExtractor : IEncapsulatedSecretExtractor
{
  private readonly KyberKeyParameters m_key;
  private readonly KyberEngine m_engine;

  public KyberKemExtractor(KyberKeyParameters privParams)
  {
    this.m_key = privParams;
    this.m_engine = this.m_key.Parameters.Engine;
  }

  public byte[] ExtractSecret(byte[] encapsulation)
  {
    byte[] sharedSecret = new byte[this.m_engine.CryptoBytes];
    this.m_engine.KemDecrypt(sharedSecret, encapsulation, ((KyberPrivateKeyParameters) this.m_key).GetEncoded());
    return sharedSecret;
  }

  public int EncapsulationLength => this.m_engine.CryptoCipherTextBytes;
}
