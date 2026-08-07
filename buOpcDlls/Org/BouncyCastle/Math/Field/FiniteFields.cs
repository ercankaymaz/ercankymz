// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.Field.FiniteFields
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Math.Field;

public abstract class FiniteFields
{
  internal static readonly IFiniteField GF_2 = (IFiniteField) new PrimeField(BigInteger.ValueOf(2L));
  internal static readonly IFiniteField GF_3 = (IFiniteField) new PrimeField(BigInteger.ValueOf(3L));

  public static IPolynomialExtensionField GetBinaryExtensionField(int[] exponents)
  {
    if (exponents[0] != 0)
      throw new ArgumentException("Irreducible polynomials in GF(2) must have constant term", nameof (exponents));
    for (int index = 1; index < exponents.Length; ++index)
    {
      if (exponents[index] <= exponents[index - 1])
        throw new ArgumentException("Polynomial exponents must be monotonically increasing", nameof (exponents));
    }
    return (IPolynomialExtensionField) new GenericPolynomialExtensionField(FiniteFields.GF_2, (IPolynomial) new GF2Polynomial(exponents));
  }

  public static IFiniteField GetPrimeField(BigInteger characteristic)
  {
    int bitLength = characteristic.BitLength;
    if (characteristic.SignValue <= 0 || bitLength < 2)
      throw new ArgumentException("Must be >= 2", nameof (characteristic));
    if (bitLength < 3)
    {
      switch (characteristic.IntValue)
      {
        case 2:
          return FiniteFields.GF_2;
        case 3:
          return FiniteFields.GF_3;
      }
    }
    return (IFiniteField) new PrimeField(characteristic);
  }
}
