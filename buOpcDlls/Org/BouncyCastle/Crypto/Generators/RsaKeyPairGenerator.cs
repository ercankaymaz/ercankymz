// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.RsaKeyPairGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC.Multiplier;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public class RsaKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
{
  private static readonly int[] SPECIAL_E_VALUES = new int[5]
  {
    3,
    5,
    17,
    257,
    65537 /*0x010001*/
  };
  private static readonly int SPECIAL_E_HIGHEST = RsaKeyPairGenerator.SPECIAL_E_VALUES[RsaKeyPairGenerator.SPECIAL_E_VALUES.Length - 1];
  private static readonly int SPECIAL_E_BITS = BigInteger.ValueOf((long) RsaKeyPairGenerator.SPECIAL_E_HIGHEST).BitLength;
  protected static readonly BigInteger One = BigInteger.One;
  protected static readonly BigInteger DefaultPublicExponent = BigInteger.ValueOf(65537L /*0x010001*/);
  protected const int DefaultTests = 100;
  protected RsaKeyGenerationParameters parameters;

  public virtual void Init(KeyGenerationParameters parameters)
  {
    if (parameters is RsaKeyGenerationParameters)
      this.parameters = (RsaKeyGenerationParameters) parameters;
    else
      this.parameters = new RsaKeyGenerationParameters(RsaKeyPairGenerator.DefaultPublicExponent, parameters.Random, parameters.Strength, 100);
  }

  public virtual AsymmetricCipherKeyPair GenerateKeyPair()
  {
    int bitlength1;
    BigInteger publicExponent;
    BigInteger bigInteger1;
    BigInteger bigInteger2;
    BigInteger bigInteger3;
    BigInteger n;
    BigInteger bigInteger4;
    BigInteger privateExponent;
    do
    {
      int strength = this.parameters.Strength;
      int bitlength2 = (strength + 1) / 2;
      bitlength1 = strength - bitlength2;
      int num1 = strength / 3;
      int num2 = strength >> 2;
      publicExponent = this.parameters.PublicExponent;
      bigInteger1 = this.ChooseRandomPrime(bitlength2, publicExponent);
      while (true)
      {
        do
        {
          bigInteger2 = this.ChooseRandomPrime(bitlength1, publicExponent);
        }
        while (bigInteger2.Subtract(bigInteger1).Abs().BitLength < num1);
        bigInteger3 = bigInteger1.Multiply(bigInteger2);
        if (bigInteger3.BitLength != strength)
          bigInteger1 = bigInteger1.Max(bigInteger2);
        else if (WNafUtilities.GetNafWeight(bigInteger3) < num2)
          bigInteger1 = this.ChooseRandomPrime(bitlength2, publicExponent);
        else
          break;
      }
      if (bigInteger1.CompareTo(bigInteger2) < 0)
      {
        BigInteger bigInteger5 = bigInteger1;
        bigInteger1 = bigInteger2;
        bigInteger2 = bigInteger5;
      }
      n = bigInteger1.Subtract(RsaKeyPairGenerator.One);
      bigInteger4 = bigInteger2.Subtract(RsaKeyPairGenerator.One);
      BigInteger val = n.Gcd(bigInteger4);
      BigInteger m = n.Divide(val).Multiply(bigInteger4);
      privateExponent = publicExponent.ModInverse(m);
    }
    while (privateExponent.BitLength <= bitlength1);
    BigInteger dP = privateExponent.Remainder(n);
    BigInteger dQ = privateExponent.Remainder(bigInteger4);
    BigInteger qInv = BigIntegers.ModOddInverse(bigInteger1, bigInteger2);
    return new AsymmetricCipherKeyPair((AsymmetricKeyParameter) new RsaKeyParameters(false, bigInteger3, publicExponent), (AsymmetricKeyParameter) new RsaPrivateCrtKeyParameters(bigInteger3, publicExponent, privateExponent, bigInteger1, bigInteger2, dP, dQ, qInv));
  }

  protected virtual BigInteger ChooseRandomPrime(int bitlength, BigInteger e)
  {
    bool flag = e.BitLength <= RsaKeyPairGenerator.SPECIAL_E_BITS && Arrays.Contains(RsaKeyPairGenerator.SPECIAL_E_VALUES, e.IntValue);
    BigInteger bigInteger;
    do
    {
      bigInteger = new BigInteger(bitlength, 1, (Random) this.parameters.Random);
    }
    while (bigInteger.Mod(e).Equals(RsaKeyPairGenerator.One) || !bigInteger.IsProbablePrime(this.parameters.Certainty, true) || !flag && !e.Gcd(bigInteger.Subtract(RsaKeyPairGenerator.One)).Equals(RsaKeyPairGenerator.One));
    return bigInteger;
  }
}
