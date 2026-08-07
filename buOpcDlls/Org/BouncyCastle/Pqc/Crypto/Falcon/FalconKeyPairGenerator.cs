// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Falcon.FalconKeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Falcon;

public class FalconKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private FalconKeyGenerationParameters parameters;
  private SecureRandom random;
  private FalconNist nist;
  private uint logn;
  private uint noncelen;
  private int pk_size;

  public void Init(KeyGenerationParameters param)
  {
    this.parameters = (FalconKeyGenerationParameters) param;
    this.random = param.Random;
    this.logn = (uint) ((FalconKeyGenerationParameters) param).Parameters.LogN;
    this.noncelen = (uint) ((FalconKeyGenerationParameters) param).Parameters.NonceLength;
    this.nist = new FalconNist(this.random, this.logn, this.noncelen);
    this.pk_size = 1 + 14 * (1 << (int) this.logn) / 8;
  }

  public AsymmetricCipherKeyPair GenerateKeyPair()
  {
    byte[] pk;
    byte[] fEnc;
    byte[] gEnc;
    byte[] FEnc;
    this.nist.crypto_sign_keypair(out pk, out fEnc, out gEnc, out FEnc);
    FalconParameters parameters = this.parameters.Parameters;
    FalconPrivateKeyParameters privateParameter = new FalconPrivateKeyParameters(parameters, fEnc, gEnc, FEnc, pk);
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new FalconPublicKeyParameters(parameters, pk), (AsymmetricKeyParameter) privateParameter);
  }
}
