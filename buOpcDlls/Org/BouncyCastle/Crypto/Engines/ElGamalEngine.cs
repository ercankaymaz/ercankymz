// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.ElGamalEngine
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

public class ElGamalEngine : IAsymmetricBlockCipher
{
  private ElGamalKeyParameters key;
  private SecureRandom random;
  private bool forEncryption;
  private int bitSize;

  public virtual string AlgorithmName => "ElGamal";

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    if (parameters is ParametersWithRandom parametersWithRandom)
    {
      this.key = (ElGamalKeyParameters) parametersWithRandom.Parameters;
      this.random = parametersWithRandom.Random;
    }
    else
    {
      this.key = (ElGamalKeyParameters) parameters;
      this.random = forEncryption ? CryptoServicesRegistrar.GetSecureRandom() : (SecureRandom) null;
    }
    this.forEncryption = forEncryption;
    this.bitSize = this.key.Parameters.P.BitLength;
    if (forEncryption)
    {
      if (!(this.key is ElGamalPublicKeyParameters))
        throw new ArgumentException("ElGamalPublicKeyParameters are required for encryption.");
    }
    else if (!(this.key is ElGamalPrivateKeyParameters))
      throw new ArgumentException("ElGamalPrivateKeyParameters are required for decryption.");
  }

  public virtual int GetInputBlockSize()
  {
    return this.forEncryption ? (this.bitSize - 1) / 8 : 2 * ((this.bitSize + 7) / 8);
  }

  public virtual int GetOutputBlockSize()
  {
    return this.forEncryption ? 2 * ((this.bitSize + 7) / 8) : (this.bitSize - 1) / 8;
  }

  public virtual byte[] ProcessBlock(byte[] input, int inOff, int length)
  {
    if (this.key == null)
      throw new InvalidOperationException("ElGamal engine not initialised");
    int num = this.forEncryption ? (this.bitSize - 1 + 7) / 8 : this.GetInputBlockSize();
    if (length > num)
      throw new DataLengthException("input too large for ElGamal cipher.\n");
    BigInteger p = this.key.Parameters.P;
    byte[] buf1;
    if (this.key is ElGamalPrivateKeyParameters)
    {
      int length1 = length / 2;
      BigInteger bigInteger = new BigInteger(1, input, inOff, length1);
      BigInteger val = new BigInteger(1, input, inOff + length1, length1);
      ElGamalPrivateKeyParameters key = (ElGamalPrivateKeyParameters) this.key;
      BigInteger e = p.Subtract(BigInteger.One).Subtract(key.X);
      BigInteger m = p;
      buf1 = bigInteger.ModPow(e, m).Multiply(val).Mod(p).ToByteArrayUnsigned();
    }
    else
    {
      BigInteger bigInteger = new BigInteger(1, input, inOff, length);
      if (bigInteger.BitLength >= p.BitLength)
        throw new DataLengthException("input too large for ElGamal cipher.\n");
      ElGamalPublicKeyParameters key = (ElGamalPublicKeyParameters) this.key;
      BigInteger other = p.Subtract(BigInteger.Two);
      BigInteger e;
      do
      {
        e = new BigInteger(p.BitLength, (Random) this.random);
      }
      while (e.SignValue == 0 || e.CompareTo(other) > 0);
      BigInteger n1 = this.key.Parameters.G.ModPow(e, p);
      BigInteger n2 = bigInteger.Multiply(key.Y.ModPow(e, p)).Mod(p);
      buf1 = new byte[this.GetOutputBlockSize()];
      int len1 = buf1.Length / 2;
      BigIntegers.AsUnsignedByteArray(n1, buf1, 0, len1);
      byte[] buf2 = buf1;
      int off = len1;
      int len2 = buf1.Length - len1;
      BigIntegers.AsUnsignedByteArray(n2, buf2, off, len2);
    }
    return buf1;
  }
}
