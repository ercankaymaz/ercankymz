// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.NaccacheSternKeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public class NaccacheSternKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private static readonly int[] smallPrimes = new int[101]
  {
    3,
    5,
    7,
    11,
    13,
    17,
    19,
    23,
    29,
    31 /*0x1F*/,
    37,
    41,
    43,
    47,
    53,
    59,
    61,
    67,
    71,
    73,
    79,
    83,
    89,
    97,
    101,
    103,
    107,
    109,
    113,
    (int) sbyte.MaxValue,
    131,
    137,
    139,
    149,
    151,
    157,
    163,
    167,
    173,
    179,
    181,
    191,
    193,
    197,
    199,
    211,
    223,
    227,
    229,
    233,
    239,
    241,
    251,
    257,
    263,
    269,
    271,
    277,
    281,
    283,
    293,
    307,
    311,
    313,
    317,
    331,
    337,
    347,
    349,
    353,
    359,
    367,
    373,
    379,
    383,
    389,
    397,
    401,
    409,
    419,
    421,
    431,
    433,
    439,
    443,
    449,
    457,
    461,
    463,
    467,
    479,
    487,
    491,
    499,
    503,
    509,
    521,
    523,
    541,
    547,
    557
  };
  private NaccacheSternKeyGenerationParameters param;

  public void Init(KeyGenerationParameters parameters)
  {
    this.param = (NaccacheSternKeyGenerationParameters) parameters;
  }

  public AsymmetricCipherKeyPair GenerateKeyPair()
  {
    int strength = this.param.Strength;
    SecureRandom random = this.param.Random;
    int certainty = this.param.Certainty;
    IList<BigInteger> smallPrimes = NaccacheSternKeyPairGenerator.PermuteList<BigInteger>(NaccacheSternKeyPairGenerator.FindFirstPrimes(this.param.CountSmallPrimes), random);
    BigInteger val1 = BigInteger.One;
    BigInteger val2 = BigInteger.One;
    for (int index = 0; index < smallPrimes.Count / 2; ++index)
      val1 = val1.Multiply(smallPrimes[index]);
    for (int index = smallPrimes.Count / 2; index < smallPrimes.Count; ++index)
      val2 = val2.Multiply(smallPrimes[index]);
    BigInteger bigInteger1 = val1.Multiply(val2);
    int num1 = strength - bigInteger1.BitLength - 48 /*0x30*/;
    BigInteger prime1 = NaccacheSternKeyPairGenerator.GeneratePrime(num1 / 2 + 1, certainty, random);
    BigInteger prime2 = NaccacheSternKeyPairGenerator.GeneratePrime(num1 / 2 + 1, certainty, random);
    long num2 = 0;
    BigInteger val3 = prime1.Multiply(val1).ShiftLeft(1);
    BigInteger val4 = prime2.Multiply(val2).ShiftLeft(1);
    BigInteger prime3;
    BigInteger val5;
    BigInteger prime4;
    BigInteger bigInteger2;
    do
    {
      do
      {
        ++num2;
        prime4 = NaccacheSternKeyPairGenerator.GeneratePrime(24, certainty, random);
        bigInteger2 = prime4.Multiply(val3).Add(BigInteger.One);
      }
      while (!bigInteger2.IsProbablePrime(certainty, true));
      do
      {
        do
        {
          prime3 = NaccacheSternKeyPairGenerator.GeneratePrime(24, certainty, random);
        }
        while (prime4.Equals(prime3));
        val5 = prime3.Multiply(val4).Add(BigInteger.One);
      }
      while (!val5.IsProbablePrime(certainty, true));
    }
    while (!bigInteger1.Gcd(prime4.Multiply(prime3)).Equals(BigInteger.One) || bigInteger2.Multiply(val5).BitLength < strength);
    BigInteger bigInteger3 = bigInteger2.Multiply(val5);
    BigInteger phiN = bigInteger2.Subtract(BigInteger.One).Multiply(val5.Subtract(BigInteger.One));
    long num3 = 0;
    BigInteger g;
    bool flag;
    do
    {
      List<BigInteger> bigIntegerList = new List<BigInteger>();
      for (int index = 0; index != smallPrimes.Count; ++index)
      {
        BigInteger val6 = smallPrimes[index];
        BigInteger e = phiN.Divide(val6);
        BigInteger prime5;
        do
        {
          ++num3;
          prime5 = NaccacheSternKeyPairGenerator.GeneratePrime(strength, certainty, random);
        }
        while (prime5.ModPow(e, bigInteger3).Equals(BigInteger.One));
        bigIntegerList.Add(prime5);
      }
      g = BigInteger.One;
      for (int index = 0; index < smallPrimes.Count; ++index)
      {
        BigInteger bigInteger4 = bigIntegerList[index];
        BigInteger val7 = smallPrimes[index];
        g = g.Multiply(bigInteger4.ModPow(bigInteger1.Divide(val7), bigInteger3)).Mod(bigInteger3);
      }
      flag = false;
      for (int index = 0; index < smallPrimes.Count; ++index)
      {
        if (g.ModPow(phiN.Divide(smallPrimes[index]), bigInteger3).Equals(BigInteger.One))
        {
          flag = true;
          break;
        }
      }
    }
    while (flag || g.ModPow(phiN.ShiftRight(2), bigInteger3).Equals(BigInteger.One) || g.ModPow(phiN.Divide(prime4), bigInteger3).Equals(BigInteger.One) || g.ModPow(phiN.Divide(prime3), bigInteger3).Equals(BigInteger.One) || g.ModPow(phiN.Divide(prime1), bigInteger3).Equals(BigInteger.One) || g.ModPow(phiN.Divide(prime2), bigInteger3).Equals(BigInteger.One));
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new NaccacheSternKeyParameters(false, g, bigInteger3, bigInteger1.BitLength), (AsymmetricKeyParameter) new NaccacheSternPrivateKeyParameters(g, bigInteger3, bigInteger1.BitLength, smallPrimes, phiN));
  }

  private static BigInteger GeneratePrime(int bitLength, int certainty, SecureRandom rand)
  {
    return new BigInteger(bitLength, certainty, (Random) rand);
  }

  private static IList<T> PermuteList<T>(IList<T> arr, SecureRandom rand)
  {
    List<T> objList = new List<T>(arr.Count);
    foreach (T obj in (IEnumerable<T>) arr)
    {
      int index = rand.Next(objList.Count + 1);
      objList.Insert(index, obj);
    }
    return (IList<T>) objList;
  }

  private static IList<BigInteger> FindFirstPrimes(int count)
  {
    List<BigInteger> firstPrimes = new List<BigInteger>(count);
    for (int index = 0; index != count; ++index)
      firstPrimes.Add(BigInteger.ValueOf((long) NaccacheSternKeyPairGenerator.smallPrimes[index]));
    return (IList<BigInteger>) firstPrimes;
  }
}
