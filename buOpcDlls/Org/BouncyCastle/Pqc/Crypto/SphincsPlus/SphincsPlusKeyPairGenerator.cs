// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.SphincsPlus.SphincsPlusKeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.SphincsPlus;

public sealed class SphincsPlusKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private SecureRandom random;
  private SphincsPlusParameters parameters;

  public void Init(KeyGenerationParameters param)
  {
    this.random = param.Random;
    this.parameters = ((SphincsPlusKeyGenerationParameters) param).Parameters;
  }

  public AsymmetricCipherKeyPair GenerateKeyPair()
  {
    SphincsPlusEngine engine = this.parameters.GetEngine();
    byte[] numArray1;
    SK sk;
    if (engine is SphincsPlusEngine.HarakaSEngine)
    {
      byte[] sourceArray = this.SecRand(engine.N * 3);
      byte[] numArray2 = new byte[engine.N];
      byte[] numArray3 = new byte[engine.N];
      numArray1 = new byte[engine.N];
      Array.Copy((Array) sourceArray, 0, (Array) numArray2, 0, engine.N);
      Array.Copy((Array) sourceArray, engine.N, (Array) numArray3, 0, engine.N);
      Array.Copy((Array) sourceArray, engine.N << 1, (Array) numArray1, 0, engine.N);
      sk = new SK(numArray2, numArray3);
    }
    else
    {
      sk = new SK(this.SecRand(engine.N), this.SecRand(engine.N));
      numArray1 = this.SecRand(engine.N);
    }
    engine.Init(numArray1);
    PK pk = new PK(numArray1, new HT(engine, sk.seed, numArray1).HTPubKey);
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new SphincsPlusPublicKeyParameters(this.parameters, pk), (AsymmetricKeyParameter) new SphincsPlusPrivateKeyParameters(this.parameters, sk, pk));
  }

  private byte[] SecRand(int n) => SecureRandom.GetNextBytes(this.random, n);
}
