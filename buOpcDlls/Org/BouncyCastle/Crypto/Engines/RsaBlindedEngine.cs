// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.RsaBlindedEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class RsaBlindedEngine : IAsymmetricBlockCipher
{
  private readonly IRsa core;
  private RsaKeyParameters key;
  private SecureRandom random;

  public RsaBlindedEngine()
    : this((IRsa) new RsaCoreEngine())
  {
  }

  public RsaBlindedEngine(IRsa rsa) => this.core = rsa;

  public virtual string AlgorithmName => "RSA";

  public virtual void Init(bool forEncryption, ICipherParameters param)
  {
    this.core.Init(forEncryption, param);
    if (param is ParametersWithRandom parametersWithRandom)
    {
      this.key = (RsaKeyParameters) parametersWithRandom.Parameters;
      if (this.key is RsaPrivateCrtKeyParameters)
        this.random = parametersWithRandom.Random;
      else
        this.random = (SecureRandom) null;
    }
    else
    {
      this.key = (RsaKeyParameters) param;
      if (this.key is RsaPrivateCrtKeyParameters)
        this.random = CryptoServicesRegistrar.GetSecureRandom();
      else
        this.random = (SecureRandom) null;
    }
  }

  public virtual int GetInputBlockSize() => this.core.GetInputBlockSize();

  public virtual int GetOutputBlockSize() => this.core.GetOutputBlockSize();

  public virtual byte[] ProcessBlock(byte[] inBuf, int inOff, int inLen)
  {
    if (this.key == null)
      throw new InvalidOperationException("RSA engine not initialised");
    BigInteger bigInteger = this.core.ConvertInput(inBuf, inOff, inLen);
    BigInteger result;
    if (this.key is RsaPrivateCrtKeyParameters key)
    {
      BigInteger publicExponent = key.PublicExponent;
      BigInteger modulus = key.Modulus;
      BigInteger randomInRange = BigIntegers.CreateRandomInRange(BigInteger.One, modulus.Subtract(BigInteger.One), this.random);
      result = this.core.ProcessBlock(randomInRange.ModPow(publicExponent, modulus).Multiply(bigInteger).Mod(modulus)).Multiply(BigIntegers.ModOddInverse(modulus, randomInRange)).Mod(modulus);
      if (!bigInteger.Equals(result.ModPow(publicExponent, modulus)))
        throw new InvalidOperationException("RSA engine faulty decryption/signing detected");
    }
    else
      result = this.core.ProcessBlock(bigInteger);
    return this.core.ConvertOutput(result);
  }
}
