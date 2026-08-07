// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.RsaCoreEngine
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

public class RsaCoreEngine : IRsa
{
  private RsaKeyParameters key;
  private bool forEncryption;
  private int bitSize;

  private void CheckInitialised()
  {
    if (this.key == null)
      throw new InvalidOperationException("RSA engine not initialised");
  }

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    if (parameters is ParametersWithRandom parametersWithRandom)
      parameters = parametersWithRandom.Parameters;
    this.key = parameters is RsaKeyParameters rsaKeyParameters ? rsaKeyParameters : throw new InvalidKeyException("Not an RSA key");
    this.forEncryption = forEncryption;
    this.bitSize = this.key.Modulus.BitLength;
  }

  public virtual int GetInputBlockSize()
  {
    this.CheckInitialised();
    return this.forEncryption ? (this.bitSize - 1) / 8 : (this.bitSize + 7) / 8;
  }

  public virtual int GetOutputBlockSize()
  {
    this.CheckInitialised();
    return this.forEncryption ? (this.bitSize + 7) / 8 : (this.bitSize - 1) / 8;
  }

  public virtual BigInteger ConvertInput(byte[] inBuf, int inOff, int inLen)
  {
    this.CheckInitialised();
    int num = (this.bitSize + 7) / 8;
    if (inLen > num)
      throw new DataLengthException("input too large for RSA cipher.");
    BigInteger bigInteger = new BigInteger(1, inBuf, inOff, inLen);
    if (bigInteger.CompareTo(this.key.Modulus) < 0)
      return bigInteger;
    throw new DataLengthException("input too large for RSA cipher.");
  }

  public virtual byte[] ConvertOutput(BigInteger result)
  {
    this.CheckInitialised();
    return !this.forEncryption ? BigIntegers.AsUnsignedByteArray(result) : BigIntegers.AsUnsignedByteArray(this.GetOutputBlockSize(), result);
  }

  public virtual BigInteger ProcessBlock(BigInteger input)
  {
    this.CheckInitialised();
    if (!(this.key is RsaPrivateCrtKeyParameters key))
      return input.ModPow(this.key.Exponent, this.key.Modulus);
    BigInteger p = key.P;
    BigInteger q = key.Q;
    BigInteger dp = key.DP;
    BigInteger dq = key.DQ;
    BigInteger qinv = key.QInv;
    BigInteger bigInteger1 = input.Remainder(p).ModPow(dp, p);
    BigInteger bigInteger2 = input.Remainder(q).ModPow(dq, q);
    BigInteger n = bigInteger2;
    return bigInteger1.Subtract(n).Multiply(qinv).Mod(p).Multiply(q).Add(bigInteger2);
  }
}
