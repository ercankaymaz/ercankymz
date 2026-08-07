// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Saber.SaberKemExtractor
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Saber;

public sealed class SaberKemExtractor : IEncapsulatedSecretExtractor
{
  private readonly SaberKeyParameters key;
  private SaberEngine engine;

  public SaberKemExtractor(SaberKeyParameters privParams)
  {
    this.key = privParams;
    this.InitCipher(this.key.Parameters);
  }

  private void InitCipher(SaberParameters param) => this.engine = param.Engine;

  public byte[] ExtractSecret(byte[] encapsulation)
  {
    byte[] k = new byte[this.engine.GetSessionKeySize()];
    this.engine.crypto_kem_dec(k, encapsulation, ((SaberPrivateKeyParameters) this.key).GetPrivateKey());
    return k;
  }

  public int EncapsulationLength => this.engine.GetCipherTextSize();
}
