// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.NtruPrime.NtruLPRimeKeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.NtruPrime;

public class NtruLPRimeKeyPairGenerator
{
  private NtruLPRimeKeyGenerationParameters _ntruPrimeParams;
  private int p;
  private int q;
  private SecureRandom random;

  private void Initialize(KeyGenerationParameters param)
  {
    this._ntruPrimeParams = (NtruLPRimeKeyGenerationParameters) param;
    this.random = param.Random;
    this.p = this._ntruPrimeParams.Parameters.P;
    this.q = this._ntruPrimeParams.Parameters.Q;
  }

  private AsymmetricCipherKeyPair GenKeyPair()
  {
    NtruPrimeEngine primeEngine = this._ntruPrimeParams.Parameters.PrimeEngine;
    byte[] numArray1 = new byte[primeEngine.PrivateKeySize];
    byte[] numArray2 = new byte[primeEngine.PublicKeySize];
    primeEngine.kem_keypair(numArray2, numArray1, this.random);
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new NtruLPRimePublicKeyParameters(this._ntruPrimeParams.Parameters, numArray2), (AsymmetricKeyParameter) new NtruLPRimePrivateKeyParameters(this._ntruPrimeParams.Parameters, numArray1));
  }

  public void Init(KeyGenerationParameters param) => this.Initialize(param);

  public AsymmetricCipherKeyPair GenerateKeyPair() => this.GenKeyPair();
}
