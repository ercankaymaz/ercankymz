// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.AbstractFpCurve
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Field;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Math.EC;

public abstract class AbstractFpCurve : ECCurve
{
  private static readonly HashSet<BigInteger> KnownQs = new HashSet<BigInteger>();

  protected AbstractFpCurve(BigInteger q)
    : this(q, false)
  {
  }

  internal AbstractFpCurve(BigInteger q, bool isInternal)
    : base(FiniteFields.GetPrimeField(q))
  {
    if (!isInternal)
    {
      bool flag;
      lock (AbstractFpCurve.KnownQs)
        flag = !AbstractFpCurve.KnownQs.Contains(q);
      if (flag)
      {
        int integer1 = AbstractFpCurve.ImplGetInteger("Org.BouncyCastle.EC.Fp_MaxSize", 1042);
        int integer2 = AbstractFpCurve.ImplGetInteger("Org.BouncyCastle.EC.Fp_Certainty", 100);
        int bitLength = q.BitLength;
        int num = bitLength;
        if (integer1 < num)
          throw new ArgumentException("Fp q value out of range");
        if (Primes.HasAnySmallFactors(q) || !Primes.IsMRProbablePrime(q, SecureRandom.ArbitraryRandom, AbstractFpCurve.ImplGetNumberOfIterations(bitLength, integer2)))
          throw new ArgumentException("Fp q value not prime");
      }
    }
    lock (AbstractFpCurve.KnownQs)
      AbstractFpCurve.KnownQs.Add(q);
  }

  public override bool IsValidFieldElement(BigInteger x)
  {
    return x != null && x.SignValue >= 0 && x.CompareTo(this.Field.Characteristic) < 0;
  }

  public override ECFieldElement RandomFieldElement(SecureRandom r)
  {
    BigInteger characteristic = this.Field.Characteristic;
    return this.FromBigInteger(AbstractFpCurve.ImplRandomFieldElement(r, characteristic)).Multiply(this.FromBigInteger(AbstractFpCurve.ImplRandomFieldElement(r, characteristic)));
  }

  public override ECFieldElement RandomFieldElementMult(SecureRandom r)
  {
    BigInteger characteristic = this.Field.Characteristic;
    return this.FromBigInteger(AbstractFpCurve.ImplRandomFieldElementMult(r, characteristic)).Multiply(this.FromBigInteger(AbstractFpCurve.ImplRandomFieldElementMult(r, characteristic)));
  }

  protected override ECPoint DecompressPoint(int yTilde, BigInteger X1)
  {
    ECFieldElement ecFieldElement = this.FromBigInteger(X1);
    ECFieldElement y = ecFieldElement.Square().Add(this.A).Multiply(ecFieldElement).Add(this.B).Sqrt();
    if (y == null)
      throw new ArgumentException("Invalid point compression");
    if (y.TestBitZero() != (yTilde == 1))
      y = y.Negate();
    return this.CreateRawPoint(ecFieldElement, y);
  }

  private static int ImplGetInteger(string envVariable, int defaultValue)
  {
    string environmentVariable = Platform.GetEnvironmentVariable(envVariable);
    return environmentVariable == null ? defaultValue : int.Parse(environmentVariable);
  }

  private static int ImplGetNumberOfIterations(int bits, int certainty)
  {
    if (bits >= 1536 /*0x0600*/)
    {
      if (certainty <= 100)
        return 3;
      return certainty > 128 /*0x80*/ ? 4 + (certainty - 128 /*0x80*/ + 1) / 2 : 4;
    }
    if (bits >= 1024 /*0x0400*/)
    {
      if (certainty <= 100)
        return 4;
      return certainty > 112 /*0x70*/ ? 5 + (certainty - 112 /*0x70*/ + 1) / 2 : 5;
    }
    if (bits >= 512 /*0x0200*/)
    {
      if (certainty <= 80 /*0x50*/)
        return 5;
      return certainty > 100 ? 7 + (certainty - 100 + 1) / 2 : 7;
    }
    return certainty > 80 /*0x50*/ ? 40 + (certainty - 80 /*0x50*/ + 1) / 2 : 40;
  }

  private static BigInteger ImplRandomFieldElement(SecureRandom r, BigInteger p)
  {
    BigInteger randomBigInteger;
    do
    {
      randomBigInteger = BigIntegers.CreateRandomBigInteger(p.BitLength, r);
    }
    while (randomBigInteger.CompareTo(p) >= 0);
    return randomBigInteger;
  }

  private static BigInteger ImplRandomFieldElementMult(SecureRandom r, BigInteger p)
  {
    BigInteger randomBigInteger;
    do
    {
      randomBigInteger = BigIntegers.CreateRandomBigInteger(p.BitLength, r);
    }
    while (randomBigInteger.SignValue <= 0 || randomBigInteger.CompareTo(p) >= 0);
    return randomBigInteger;
  }
}
