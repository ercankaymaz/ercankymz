// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Hqc.HqcKeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Hqc;

public class HqcKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private int n;
  private int k;
  private int delta;
  private int w;
  private int wr;
  private int we;
  private int N_BYTE;
  private HqcKeyGenerationParameters hqcKeyGenerationParameters;
  private SecureRandom random;

  public AsymmetricCipherKeyPair GenerateKeyPair()
  {
    byte[] numArray = new byte[48 /*0x30*/];
    this.random.NextBytes(numArray);
    return this.GenKeyPair(numArray);
  }

  public AsymmetricCipherKeyPair GenerateKeyPairWithSeed(byte[] seed) => this.GenKeyPair(seed);

  public void Init(KeyGenerationParameters parameters)
  {
    this.hqcKeyGenerationParameters = (HqcKeyGenerationParameters) parameters;
    this.random = parameters.Random;
    this.n = this.hqcKeyGenerationParameters.Parameters.N;
    this.k = this.hqcKeyGenerationParameters.Parameters.K;
    this.delta = this.hqcKeyGenerationParameters.Parameters.Delta;
    this.w = this.hqcKeyGenerationParameters.Parameters.W;
    this.wr = this.hqcKeyGenerationParameters.Parameters.Wr;
    this.we = this.hqcKeyGenerationParameters.Parameters.We;
    this.N_BYTE = (this.n + 7) / 8;
  }

  private AsymmetricCipherKeyPair GenKeyPair(byte[] seed)
  {
    HqcEngine engine = this.hqcKeyGenerationParameters.Parameters.Engine;
    byte[] pk1 = new byte[40 + this.N_BYTE];
    byte[] sk1 = new byte[80 /*0x50*/ + this.N_BYTE];
    byte[] pk2 = pk1;
    byte[] sk2 = sk1;
    byte[] seed1 = seed;
    engine.GenKeyPair(pk2, sk2, seed1);
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new HqcPublicKeyParameters(this.hqcKeyGenerationParameters.Parameters, pk1), (AsymmetricKeyParameter) new HqcPrivateKeyParameters(this.hqcKeyGenerationParameters.Parameters, sk1));
  }
}
