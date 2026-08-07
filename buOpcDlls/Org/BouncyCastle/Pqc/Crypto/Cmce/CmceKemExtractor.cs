// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Cmce.CmceKemExtractor
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Cmce;

public sealed class CmceKemExtractor : IEncapsulatedSecretExtractor
{
  private ICmceEngine engine;
  private CmceKeyParameters key;

  public CmceKemExtractor(CmcePrivateKeyParameters privParams)
  {
    this.key = (CmceKeyParameters) privParams;
    this.InitCipher(this.key.Parameters);
  }

  private void InitCipher(CmceParameters param)
  {
    this.engine = param.Engine;
    CmcePrivateKeyParameters key = (CmcePrivateKeyParameters) this.key;
    if (key.privateKey.Length >= this.engine.PrivateKeySize)
      return;
    this.key = (CmceKeyParameters) new CmcePrivateKeyParameters(key.Parameters, this.engine.DecompressPrivateKey(key.privateKey));
  }

  public byte[] ExtractSecret(byte[] encapsulation)
  {
    return this.ExtractSecret(encapsulation, this.engine.DefaultSessionKeySize);
  }

  private byte[] ExtractSecret(byte[] encapsulation, int sessionKeySizeInBits)
  {
    byte[] key = new byte[sessionKeySizeInBits / 8];
    this.engine.KemDec(key, encapsulation, ((CmcePrivateKeyParameters) this.key).privateKey);
    return key;
  }

  public int EncapsulationLength => this.engine.CipherTextSize;
}
