// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.Primes
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Math;

public static class Primes
{
  public static readonly int SmallFactorLimit = 211;
  private static readonly BigInteger One = BigInteger.One;
  private static readonly BigInteger Two = BigInteger.Two;
  private static readonly BigInteger Three = BigInteger.Three;

  public static Primes.STOutput GenerateSTRandomPrime(IDigest hash, int length, byte[] inputSeed)
  {
    if (hash == null)
      throw new ArgumentNullException(nameof (hash));
    if (length < 2)
      throw new ArgumentException("must be >= 2", nameof (length));
    if (inputSeed == null)
      throw new ArgumentNullException(nameof (inputSeed));
    if (inputSeed.Length == 0)
      throw new ArgumentException("cannot be empty", nameof (inputSeed));
    return Primes.ImplSTRandomPrime(hash, length, Arrays.Clone(inputSeed));
  }

  public static Primes.MROutput EnhancedMRProbablePrimeTest(
    BigInteger candidate,
    SecureRandom random,
    int iterations)
  {
    Primes.CheckCandidate(candidate, nameof (candidate));
    if (random == null)
      throw new ArgumentNullException(nameof (random));
    if (iterations < 1)
      throw new ArgumentException("must be > 0", nameof (iterations));
    if (candidate.BitLength == 2)
      return Primes.MROutput.ProbablyPrime();
    if (!candidate.TestBit(0))
      return Primes.MROutput.ProvablyCompositeWithFactor(Primes.Two);
    BigInteger m = candidate;
    BigInteger other = candidate.Subtract(Primes.One);
    BigInteger max = candidate.Subtract(Primes.Two);
    int lowestSetBit = other.GetLowestSetBit();
    BigInteger e = other.ShiftRight(lowestSetBit);
    for (int index1 = 0; index1 < iterations; ++index1)
    {
      BigInteger randomInRange = BigIntegers.CreateRandomInRange(Primes.Two, max, random);
      BigInteger factor1 = randomInRange.Gcd(m);
      if (factor1.CompareTo(Primes.One) > 0)
        return Primes.MROutput.ProvablyCompositeWithFactor(factor1);
      BigInteger bigInteger1 = randomInRange.ModPow(e, m);
      if (!bigInteger1.Equals(Primes.One) && !bigInteger1.Equals(other))
      {
        bool flag = false;
        BigInteger bigInteger2 = bigInteger1;
        for (int index2 = 1; index2 < lowestSetBit; ++index2)
        {
          bigInteger1 = bigInteger1.Square().Mod(m);
          if (!bigInteger1.Equals(other))
          {
            if (!bigInteger1.Equals(Primes.One))
              bigInteger2 = bigInteger1;
            else
              break;
          }
          else
          {
            flag = true;
            break;
          }
        }
        if (!flag)
        {
          if (!bigInteger1.Equals(Primes.One))
          {
            bigInteger2 = bigInteger1;
            BigInteger bigInteger3 = bigInteger1.Square().Mod(m);
            if (!bigInteger3.Equals(Primes.One))
              bigInteger2 = bigInteger3;
          }
          BigInteger factor2 = bigInteger2.Subtract(Primes.One).Gcd(m);
          return factor2.CompareTo(Primes.One) > 0 ? Primes.MROutput.ProvablyCompositeWithFactor(factor2) : Primes.MROutput.ProvablyCompositeNotPrimePower();
        }
      }
    }
    return Primes.MROutput.ProbablyPrime();
  }

  public static bool HasAnySmallFactors(BigInteger candidate)
  {
    Primes.CheckCandidate(candidate, nameof (candidate));
    return Primes.ImplHasAnySmallFactors(candidate);
  }

  public static bool IsMRProbablePrime(BigInteger candidate, SecureRandom random, int iterations)
  {
    Primes.CheckCandidate(candidate, nameof (candidate));
    if (random == null)
      throw new ArgumentException("cannot be null", nameof (random));
    if (iterations < 1)
      throw new ArgumentException("must be > 0", nameof (iterations));
    if (candidate.BitLength == 2)
      return true;
    if (!candidate.TestBit(0))
      return false;
    BigInteger w = candidate;
    BigInteger wSubOne = candidate.Subtract(Primes.One);
    BigInteger max = candidate.Subtract(Primes.Two);
    int lowestSetBit = wSubOne.GetLowestSetBit();
    BigInteger m = wSubOne.ShiftRight(lowestSetBit);
    for (int index = 0; index < iterations; ++index)
    {
      BigInteger randomInRange = BigIntegers.CreateRandomInRange(Primes.Two, max, random);
      if (!Primes.ImplMRProbablePrimeToBase(w, wSubOne, m, lowestSetBit, randomInRange))
        return false;
    }
    return true;
  }

  public static bool IsMRProbablePrimeToBase(BigInteger candidate, BigInteger baseValue)
  {
    Primes.CheckCandidate(candidate, nameof (candidate));
    Primes.CheckCandidate(baseValue, nameof (baseValue));
    if (baseValue.CompareTo(candidate.Subtract(Primes.One)) >= 0)
      throw new ArgumentException("must be < ('candidate' - 1)", nameof (baseValue));
    if (candidate.BitLength == 2)
      return true;
    BigInteger w = candidate;
    BigInteger bigInteger1 = candidate.Subtract(Primes.One);
    int lowestSetBit = bigInteger1.GetLowestSetBit();
    BigInteger bigInteger2 = bigInteger1.ShiftRight(lowestSetBit);
    BigInteger wSubOne = bigInteger1;
    BigInteger m = bigInteger2;
    int a = lowestSetBit;
    BigInteger b = baseValue;
    return Primes.ImplMRProbablePrimeToBase(w, wSubOne, m, a, b);
  }

  private static void CheckCandidate(BigInteger n, string name)
  {
    if (n == null || n.SignValue < 1 || n.BitLength < 2)
      throw new ArgumentException("must be non-null and >= 2", name);
  }

  private static bool ImplHasAnySmallFactors(BigInteger x)
  {
    int intValue1 = x.Mod(BigInteger.ValueOf(223092870L)).IntValue;
    if (intValue1 % 2 == 0 || intValue1 % 3 == 0 || intValue1 % 5 == 0 || intValue1 % 7 == 0 || intValue1 % 11 == 0 || intValue1 % 13 == 0 || intValue1 % 17 == 0 || intValue1 % 19 == 0 || intValue1 % 23 == 0)
      return true;
    int intValue2 = x.Mod(BigInteger.ValueOf(58642669L)).IntValue;
    if (intValue2 % 29 == 0 || intValue2 % 31 /*0x1F*/ == 0 || intValue2 % 37 == 0 || intValue2 % 41 == 0 || intValue2 % 43 == 0)
      return true;
    int intValue3 = x.Mod(BigInteger.ValueOf(600662303L)).IntValue;
    if (intValue3 % 47 == 0 || intValue3 % 53 == 0 || intValue3 % 59 == 0 || intValue3 % 61 == 0 || intValue3 % 67 == 0)
      return true;
    int intValue4 = x.Mod(BigInteger.ValueOf(33984931L)).IntValue;
    if (intValue4 % 71 == 0 || intValue4 % 73 == 0 || intValue4 % 79 == 0 || intValue4 % 83 == 0)
      return true;
    int intValue5 = x.Mod(BigInteger.ValueOf(89809099L)).IntValue;
    if (intValue5 % 89 == 0 || intValue5 % 97 == 0 || intValue5 % 101 == 0 || intValue5 % 103 == 0)
      return true;
    int intValue6 = x.Mod(BigInteger.ValueOf(167375713L)).IntValue;
    if (intValue6 % 107 == 0 || intValue6 % 109 == 0 || intValue6 % 113 == 0 || intValue6 % (int) sbyte.MaxValue == 0)
      return true;
    int intValue7 = x.Mod(BigInteger.ValueOf(371700317L)).IntValue;
    if (intValue7 % 131 == 0 || intValue7 % 137 == 0 || intValue7 % 139 == 0 || intValue7 % 149 == 0)
      return true;
    int intValue8 = x.Mod(BigInteger.ValueOf(645328247L)).IntValue;
    if (intValue8 % 151 == 0 || intValue8 % 157 == 0 || intValue8 % 163 == 0 || intValue8 % 167 == 0)
      return true;
    int intValue9 = x.Mod(BigInteger.ValueOf(1070560157L)).IntValue;
    if (intValue9 % 173 == 0 || intValue9 % 179 == 0 || intValue9 % 181 == 0 || intValue9 % 191 == 0)
      return true;
    int intValue10 = x.Mod(BigInteger.ValueOf(1596463769L)).IntValue;
    return intValue10 % 193 == 0 || intValue10 % 197 == 0 || intValue10 % 199 == 0 || intValue10 % 211 == 0;
  }

  private static bool ImplMRProbablePrimeToBase(
    BigInteger w,
    BigInteger wSubOne,
    BigInteger m,
    int a,
    BigInteger b)
  {
    BigInteger bigInteger = b.ModPow(m, w);
    if (bigInteger.Equals(Primes.One) || bigInteger.Equals(wSubOne))
      return true;
    for (int index = 1; index < a; ++index)
    {
      bigInteger = bigInteger.Square().Mod(w);
      if (bigInteger.Equals(wSubOne))
        return true;
      if (bigInteger.Equals(Primes.One))
        return false;
    }
    return false;
  }

  private static Primes.STOutput ImplSTRandomPrime(IDigest d, int length, byte[] primeSeed)
  {
    int digestSize = d.GetDigestSize();
    int length1 = System.Math.Max(4, digestSize);
    if (length < 33)
    {
      int primeGenCounter = 0;
      byte[] numArray1 = new byte[length1];
      byte[] numArray2 = new byte[length1];
      uint x;
      do
      {
        Primes.Hash(d, primeSeed, numArray1, length1 - digestSize);
        Primes.Inc(primeSeed, 1);
        Primes.Hash(d, primeSeed, numArray2, length1 - digestSize);
        Primes.Inc(primeSeed, 1);
        x = (Pack.BE_To_UInt32(numArray1, length1 - 4) ^ Pack.BE_To_UInt32(numArray2, length1 - 4)) & uint.MaxValue >> 32 /*0x20*/ - length | (uint) (1 << length - 1 | 1);
        ++primeGenCounter;
        if (Primes.IsPrime32(x))
          goto label_4;
      }
      while (primeGenCounter <= 4 * length);
      goto label_5;
label_4:
      return new Primes.STOutput(BigInteger.ValueOf((long) x), primeSeed, primeGenCounter);
label_5:
      throw new InvalidOperationException("Too many iterations in Shawe-Taylor Random_Prime Routine");
    }
    Primes.STOutput stOutput = Primes.ImplSTRandomPrime(d, (length + 3) / 2, primeSeed);
    BigInteger prime = stOutput.Prime;
    primeSeed = stOutput.PrimeSeed;
    int primeGenCounter1 = stOutput.PrimeGenCounter;
    int num1 = 8 * digestSize;
    int num2 = (length - 1) / num1;
    int num3 = primeGenCounter1;
    BigInteger bigInteger1 = Primes.HashGen(d, primeSeed, num2 + 1).Mod(Primes.One.ShiftLeft(length - 1)).SetBit(length - 1);
    BigInteger val = prime.ShiftLeft(1);
    BigInteger one = Primes.One;
    BigInteger bigInteger2 = bigInteger1.Subtract(one).Divide(val).Add(Primes.One).ShiftLeft(1);
    int num4 = 0;
    BigInteger bigInteger3 = bigInteger2.Multiply(prime).Add(Primes.One);
    while (true)
    {
      if (bigInteger3.BitLength > length)
        goto label_12;
label_7:
      ++primeGenCounter1;
      if (Primes.ImplHasAnySmallFactors(bigInteger3))
      {
        Primes.Inc(primeSeed, num2 + 1);
      }
      else
      {
        BigInteger bigInteger4 = Primes.HashGen(d, primeSeed, num2 + 1).Mod(bigInteger3.Subtract(Primes.Three)).Add(Primes.Two);
        bigInteger2 = bigInteger2.Add(BigInteger.ValueOf((long) num4));
        num4 = 0;
        BigInteger e = bigInteger2;
        BigInteger m = bigInteger3;
        BigInteger bigInteger5 = bigInteger4.ModPow(e, m);
        if (bigInteger3.Gcd(bigInteger5.Subtract(Primes.One)).Equals(Primes.One) && bigInteger5.ModPow(prime, bigInteger3).Equals(Primes.One))
          goto label_15;
      }
      if (primeGenCounter1 < 4 * length + num3)
      {
        num4 += 2;
        bigInteger3 = bigInteger3.Add(val);
        continue;
      }
      break;
label_12:
      bigInteger2 = Primes.One.ShiftLeft(length - 1).Subtract(Primes.One).Divide(val).Add(Primes.One).ShiftLeft(1);
      bigInteger3 = bigInteger2.Multiply(prime).Add(Primes.One);
      goto label_7;
    }
    throw new InvalidOperationException("Too many iterations in Shawe-Taylor Random_Prime Routine");
label_15:
    return new Primes.STOutput(bigInteger3, primeSeed, primeGenCounter1);
  }

  private static void Hash(IDigest d, byte[] input, byte[] output, int outPos)
  {
    d.BlockUpdate(input, 0, input.Length);
    d.DoFinal(output, outPos);
  }

  private static BigInteger HashGen(IDigest d, byte[] seed, int count)
  {
    int digestSize = d.GetDigestSize();
    int outPos = count * digestSize;
    byte[] numArray = new byte[outPos];
    for (int index = 0; index < count; ++index)
    {
      outPos -= digestSize;
      Primes.Hash(d, seed, numArray, outPos);
      Primes.Inc(seed, 1);
    }
    return new BigInteger(1, numArray);
  }

  private static void Inc(byte[] seed, int c)
  {
    for (int length = seed.Length; c > 0 && --length >= 0; c >>= 8)
    {
      c += (int) seed[length];
      seed[length] = (byte) c;
    }
  }

  private static bool IsPrime32(uint x)
  {
    if (x < 32U /*0x20*/)
      return (1 << (int) x & 545925292) != 0;
    if (((long) (1 << (int) (x % 30U)) & 2693408898L) == 0L)
      return false;
    uint[] numArray = new uint[8]
    {
      1U,
      7U,
      11U,
      13U,
      17U,
      19U,
      23U,
      29U
    };
    uint num1 = 0;
    int index = 1;
    while (true)
    {
      for (; index < numArray.Length; ++index)
      {
        uint num2 = num1 + numArray[index];
        if (x % num2 == 0U)
          return false;
      }
      num1 += 30U;
      if (num1 >> 16 /*0x10*/ == 0U && num1 * num1 < x)
        index = 0;
      else
        break;
    }
    return true;
  }

  public sealed class MROutput
  {
    private readonly bool m_provablyComposite;
    private readonly BigInteger m_factor;

    internal static Primes.MROutput ProbablyPrime()
    {
      return new Primes.MROutput(false, (BigInteger) null);
    }

    internal static Primes.MROutput ProvablyCompositeWithFactor(BigInteger factor)
    {
      return new Primes.MROutput(true, factor);
    }

    internal static Primes.MROutput ProvablyCompositeNotPrimePower()
    {
      return new Primes.MROutput(true, (BigInteger) null);
    }

    private MROutput(bool provablyComposite, BigInteger factor)
    {
      this.m_provablyComposite = provablyComposite;
      this.m_factor = factor;
    }

    public BigInteger Factor => this.m_factor;

    public bool IsProvablyComposite => this.m_provablyComposite;

    public bool IsNotPrimePower => this.m_provablyComposite && this.m_factor == null;
  }

  public sealed class STOutput
  {
    private readonly BigInteger m_prime;
    private readonly byte[] m_primeSeed;
    private readonly int m_primeGenCounter;

    internal STOutput(BigInteger prime, byte[] primeSeed, int primeGenCounter)
    {
      this.m_prime = prime;
      this.m_primeSeed = primeSeed;
      this.m_primeGenCounter = primeGenCounter;
    }

    public BigInteger Prime => this.m_prime;

    public byte[] PrimeSeed => this.m_primeSeed;

    public int PrimeGenCounter => this.m_primeGenCounter;
  }
}
