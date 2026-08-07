// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.NaccacheSternEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class NaccacheSternEngine : IAsymmetricBlockCipher
{
  private bool forEncryption;
  private NaccacheSternKeyParameters key;
  private IList<BigInteger>[] lookup;

  public string AlgorithmName => "NaccacheStern";

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.forEncryption = forEncryption;
    if (parameters is ParametersWithRandom parametersWithRandom)
      parameters = parametersWithRandom.Parameters;
    this.key = (NaccacheSternKeyParameters) parameters;
    if (this.forEncryption)
      return;
    NaccacheSternPrivateKeyParameters key = (NaccacheSternPrivateKeyParameters) this.key;
    IList<BigInteger> smallPrimesList = key.SmallPrimesList;
    this.lookup = new IList<BigInteger>[smallPrimesList.Count];
    for (int index1 = 0; index1 < smallPrimesList.Count; ++index1)
    {
      BigInteger val = smallPrimesList[index1];
      int intValue = val.IntValue;
      this.lookup[index1] = (IList<BigInteger>) new List<BigInteger>(intValue);
      this.lookup[index1].Add(BigInteger.One);
      BigInteger bigInteger = BigInteger.Zero;
      for (int index2 = 1; index2 < intValue; ++index2)
      {
        bigInteger = bigInteger.Add(key.PhiN);
        BigInteger e = bigInteger.Divide(val);
        this.lookup[index1].Add(key.G.ModPow(e, key.Modulus));
      }
    }
  }

  public virtual int GetInputBlockSize()
  {
    return this.forEncryption ? (this.key.LowerSigmaBound + 7) / 8 - 1 : this.key.Modulus.BitLength / 8 + 1;
  }

  public virtual int GetOutputBlockSize()
  {
    return this.forEncryption ? this.key.Modulus.BitLength / 8 + 1 : (this.key.LowerSigmaBound + 7) / 8 - 1;
  }

  public virtual byte[] ProcessBlock(byte[] inBytes, int inOff, int length)
  {
    if (this.key == null)
      throw new InvalidOperationException("NaccacheStern engine not initialised");
    if (length > this.GetInputBlockSize() + 1)
      throw new DataLengthException("input too large for Naccache-Stern cipher.\n");
    if (!this.forEncryption && length < this.GetInputBlockSize())
      throw new InvalidCipherTextException("BlockLength does not match modulus for Naccache-Stern cipher.\n");
    BigInteger plain = new BigInteger(1, inBytes, inOff, length);
    if (this.forEncryption)
      return this.Encrypt(plain);
    List<BigInteger> congruences = new List<BigInteger>();
    NaccacheSternPrivateKeyParameters key = (NaccacheSternPrivateKeyParameters) this.key;
    IList<BigInteger> smallPrimesList = key.SmallPrimesList;
    for (int index = 0; index < smallPrimesList.Count; ++index)
    {
      BigInteger bigInteger = plain.ModPow(key.PhiN.Divide(smallPrimesList[index]), key.Modulus);
      IList<BigInteger> bigIntegerList = this.lookup[index];
      if (this.lookup[index].Count == smallPrimesList[index].IntValue)
      {
        int num = bigIntegerList.IndexOf(bigInteger);
        if (num == -1)
          throw new InvalidCipherTextException("Lookup failed");
        congruences.Add(BigInteger.ValueOf((long) num));
      }
      else
        throw new InvalidCipherTextException($"Error in lookup Array for {smallPrimesList[index].IntValue.ToString()}: Size mismatch. Expected ArrayList with length {smallPrimesList[index].IntValue.ToString()} but found ArrayList of length {this.lookup[index].Count.ToString()}");
    }
    return NaccacheSternEngine.ChineseRemainder((IList<BigInteger>) congruences, smallPrimesList).ToByteArray();
  }

  public virtual byte[] Encrypt(BigInteger plain)
  {
    byte[] destinationArray = new byte[this.key.Modulus.BitLength / 8 + 1];
    byte[] byteArray = this.key.G.ModPow(plain, this.key.Modulus).ToByteArray();
    Array.Copy((Array) byteArray, 0, (Array) destinationArray, destinationArray.Length - byteArray.Length, byteArray.Length);
    return destinationArray;
  }

  public virtual byte[] AddCryptedBlocks(byte[] block1, byte[] block2)
  {
    if (this.forEncryption)
    {
      if (block1.Length > this.GetOutputBlockSize() || block2.Length > this.GetOutputBlockSize())
        throw new InvalidCipherTextException("BlockLength too large for simple addition.\n");
    }
    else if (block1.Length > this.GetInputBlockSize() || block2.Length > this.GetInputBlockSize())
      throw new InvalidCipherTextException("BlockLength too large for simple addition.\n");
    BigInteger bigInteger = new BigInteger(1, block1).Multiply(new BigInteger(1, block2)).Mod(this.key.Modulus);
    byte[] destinationArray = new byte[this.key.Modulus.BitLength / 8 + 1];
    byte[] byteArray = bigInteger.ToByteArray();
    Array.Copy((Array) byteArray, 0, (Array) destinationArray, destinationArray.Length - byteArray.Length, byteArray.Length);
    return destinationArray;
  }

  public virtual byte[] ProcessData(byte[] data)
  {
    if (data.Length <= this.GetInputBlockSize())
      return this.ProcessBlock(data, 0, data.Length);
    int inputBlockSize = this.GetInputBlockSize();
    int outputBlockSize = this.GetOutputBlockSize();
    int inOff = 0;
    int length = 0;
    byte[] sourceArray = new byte[(data.Length / inputBlockSize + 1) * outputBlockSize];
    while (inOff < data.Length)
    {
      byte[] numArray;
      if (inOff + inputBlockSize < data.Length)
      {
        numArray = this.ProcessBlock(data, inOff, inputBlockSize);
        inOff += inputBlockSize;
      }
      else
      {
        numArray = this.ProcessBlock(data, inOff, data.Length - inOff);
        inOff += data.Length - inOff;
      }
      if (numArray == null)
        throw new InvalidCipherTextException("cipher returned null");
      numArray.CopyTo((Array) sourceArray, length);
      length += numArray.Length;
    }
    byte[] destinationArray = new byte[length];
    Array.Copy((Array) sourceArray, 0, (Array) destinationArray, 0, length);
    return destinationArray;
  }

  private static BigInteger ChineseRemainder(
    IList<BigInteger> congruences,
    IList<BigInteger> primes)
  {
    BigInteger bigInteger1 = BigInteger.Zero;
    BigInteger m = BigInteger.One;
    for (int index = 0; index < primes.Count; ++index)
      m = m.Multiply(primes[index]);
    for (int index = 0; index < primes.Count; ++index)
    {
      BigInteger prime = primes[index];
      BigInteger bigInteger2 = m.Divide(prime);
      BigInteger bigInteger3 = bigInteger2.Multiply(bigInteger2.ModInverse(prime)).Multiply(congruences[index]);
      bigInteger1 = bigInteger1.Add(bigInteger3);
    }
    return bigInteger1.Mod(m);
  }
}
