// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium.DilithiumKeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;

public class DilithiumKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private SecureRandom random;
  private DilithiumParameters parameters;

  public void Init(KeyGenerationParameters param)
  {
    this.random = param.Random;
    this.parameters = ((DilithiumKeyGenerationParameters) param).Parameters;
  }

  public AsymmetricCipherKeyPair GenerateKeyPair()
  {
    byte[] rho;
    byte[] key;
    byte[] tr;
    byte[] s1_;
    byte[] s2_;
    byte[] t0_;
    byte[] encT1;
    this.parameters.GetEngine(this.random).GenerateKeyPair(out rho, out key, out tr, out s1_, out s2_, out t0_, out encT1);
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new DilithiumPublicKeyParameters(this.parameters, rho, encT1), (AsymmetricKeyParameter) new DilithiumPrivateKeyParameters(this.parameters, rho, key, tr, s1_, s2_, t0_, encT1));
  }
}
