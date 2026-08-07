// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Sike.SikeKemExtractor
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Sike;

[Obsolete("Will be removed")]
public sealed class SikeKemExtractor : IEncapsulatedSecretExtractor
{
  private readonly SikeKeyParameters key;
  private SikeEngine engine;

  public SikeKemExtractor(SikePrivateKeyParameters privParams)
  {
    this.key = (SikeKeyParameters) privParams;
    this.InitCipher(this.key.Parameters);
  }

  private void InitCipher(SikeParameters param) => this.engine = param.GetEngine();

  public byte[] ExtractSecret(byte[] encapsulation)
  {
    return this.ExtractSecret(encapsulation, (int) this.engine.GetDefaultSessionKeySize());
  }

  public byte[] ExtractSecret(byte[] encapsulation, int sessionKeySizeInBits)
  {
    Console.Error.WriteLine("WARNING: the SIKE algorithm is only for research purposes, insecure");
    byte[] ss = new byte[sessionKeySizeInBits / 8];
    this.engine.crypto_kem_dec(ss, encapsulation, ((SikePrivateKeyParameters) this.key).GetPrivateKey());
    return ss;
  }

  public int EncapsulationLength => this.engine.GetCipherTextSize();
}
