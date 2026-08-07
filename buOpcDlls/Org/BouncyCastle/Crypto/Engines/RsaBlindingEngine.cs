// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.RsaBlindingEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class RsaBlindingEngine : IAsymmetricBlockCipher
{
  private readonly IRsa core;
  private RsaKeyParameters key;
  private BigInteger blindingFactor;
  private bool forEncryption;

  public RsaBlindingEngine()
    : this((IRsa) new RsaCoreEngine())
  {
  }

  public RsaBlindingEngine(IRsa rsa) => this.core = rsa;

  public virtual string AlgorithmName => "RSA";

  public virtual void Init(bool forEncryption, ICipherParameters param)
  {
    RsaBlindingParameters blindingParameters = !(param is ParametersWithRandom parametersWithRandom) ? (RsaBlindingParameters) param : (RsaBlindingParameters) parametersWithRandom.Parameters;
    this.core.Init(forEncryption, (ICipherParameters) blindingParameters.PublicKey);
    this.forEncryption = forEncryption;
    this.key = blindingParameters.PublicKey;
    this.blindingFactor = blindingParameters.BlindingFactor;
  }

  public virtual int GetInputBlockSize() => this.core.GetInputBlockSize();

  public virtual int GetOutputBlockSize() => this.core.GetOutputBlockSize();

  public virtual byte[] ProcessBlock(byte[] inBuf, int inOff, int inLen)
  {
    BigInteger bigInteger = this.core.ConvertInput(inBuf, inOff, inLen);
    return this.core.ConvertOutput(!this.forEncryption ? this.UnblindMessage(bigInteger) : this.BlindMessage(bigInteger));
  }

  private BigInteger BlindMessage(BigInteger msg)
  {
    BigInteger blindingFactor = this.blindingFactor;
    return msg.Multiply(blindingFactor.ModPow(this.key.Exponent, this.key.Modulus)).Mod(this.key.Modulus);
  }

  private BigInteger UnblindMessage(BigInteger blindedMsg)
  {
    BigInteger modulus = this.key.Modulus;
    return blindedMsg.Multiply(BigIntegers.ModOddInverse(modulus, this.blindingFactor)).Mod(modulus);
  }
}
