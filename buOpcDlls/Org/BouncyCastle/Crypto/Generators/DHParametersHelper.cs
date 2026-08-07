// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.DHParametersHelper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC.Multiplier;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

internal class DHParametersHelper
{
  private static readonly BigInteger Six = BigInteger.ValueOf(6L);
  private static readonly int[][] primeLists = BigInteger.primeLists;
  private static readonly int[] primeProducts = BigInteger.primeProducts;
  private static readonly BigInteger[] BigPrimeProducts = DHParametersHelper.ConstructBigPrimeProducts(DHParametersHelper.primeProducts);

  private static BigInteger[] ConstructBigPrimeProducts(int[] primeProducts)
  {
    BigInteger[] bigIntegerArray = new BigInteger[primeProducts.Length];
    for (int index = 0; index < bigIntegerArray.Length; ++index)
      bigIntegerArray[index] = BigInteger.ValueOf((long) primeProducts[index]);
    return bigIntegerArray;
  }

  internal static BigInteger[] GenerateSafePrimes(int size, int certainty, SecureRandom random)
  {
    int bitLength = size - 1;
    int num1 = size >> 2;
    BigInteger bigInteger;
    BigInteger k;
    if (size <= 32 /*0x20*/)
    {
      do
      {
        bigInteger = new BigInteger(bitLength, 2, (Random) random);
        k = bigInteger.ShiftLeft(1).Add(BigInteger.One);
      }
      while (!k.IsProbablePrime(certainty, true) || certainty > 2 && !bigInteger.IsProbablePrime(certainty, true));
    }
    else
    {
      do
      {
        do
        {
          bigInteger = new BigInteger(bitLength, 0, (Random) random);
label_12:
          for (int index = 0; index < DHParametersHelper.primeLists.Length; ++index)
          {
            int num2 = bigInteger.Remainder(DHParametersHelper.BigPrimeProducts[index]).IntValue;
            if (index == 0)
            {
              int num3 = num2 % 3;
              if (num3 != 2)
              {
                int num4 = 2 * num3 + 2;
                bigInteger = bigInteger.Add(BigInteger.ValueOf((long) num4));
                num2 = (num2 + num4) % DHParametersHelper.primeProducts[index];
              }
            }
            foreach (int num5 in DHParametersHelper.primeLists[index])
            {
              int num6 = num2 % num5;
              if (num6 == 0 || num6 == num5 >> 1)
              {
                bigInteger = bigInteger.Add(DHParametersHelper.Six);
                goto label_12;
              }
            }
          }
        }
        while (bigInteger.BitLength != bitLength || !bigInteger.RabinMillerTest(2, (Random) random, true));
        k = bigInteger.ShiftLeft(1).Add(BigInteger.One);
      }
      while (!k.RabinMillerTest(certainty, (Random) random, true) || certainty > 2 && !bigInteger.RabinMillerTest(certainty - 2, (Random) random, true) || WNafUtilities.GetNafWeight(k) < num1);
    }
    return new BigInteger[2]{ k, bigInteger };
  }

  internal static BigInteger SelectGenerator(BigInteger p, BigInteger q, SecureRandom random)
  {
    BigInteger max = p.Subtract(BigInteger.Two);
    BigInteger bigInteger;
    do
    {
      bigInteger = BigIntegers.CreateRandomInRange(BigInteger.Two, max, random).ModPow(BigInteger.Two, p);
    }
    while (bigInteger.Equals(BigInteger.One));
    return bigInteger;
  }
}
