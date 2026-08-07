// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.AbstractF2mCurve
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.Field;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC;

public abstract class AbstractF2mCurve(int m, int k1, int k2, int k3) : ECCurve(AbstractF2mCurve.BuildField(m, k1, k2, k3))
{
  public static BigInteger Inverse(int m, int[] ks, BigInteger x)
  {
    LongArray longArray = new LongArray(x);
    longArray = longArray.ModInverse(m, ks);
    return longArray.ToBigInteger();
  }

  private static IFiniteField BuildField(int m, int k1, int k2, int k3)
  {
    int[] exponents;
    if ((k2 | k3) != 0)
      exponents = new int[5]{ 0, k1, k2, k3, m };
    else
      exponents = new int[3]{ 0, k1, m };
    return (IFiniteField) FiniteFields.GetBinaryExtensionField(exponents);
  }

  public override ECPoint CreatePoint(BigInteger x, BigInteger y)
  {
    ECFieldElement ecFieldElement = this.FromBigInteger(x);
    ECFieldElement y1 = this.FromBigInteger(y);
    switch (this.CoordinateSystem)
    {
      case 5:
      case 6:
        if (ecFieldElement.IsZero)
        {
          if (!y1.Square().Equals(this.B))
            throw new ArgumentException();
          break;
        }
        y1 = y1.Divide(ecFieldElement).Add(ecFieldElement);
        break;
    }
    return this.CreateRawPoint(ecFieldElement, y1);
  }

  public override bool IsValidFieldElement(BigInteger x)
  {
    return x != null && x.SignValue >= 0 && x.BitLength <= this.FieldSize;
  }

  public override ECFieldElement RandomFieldElement(SecureRandom r)
  {
    return this.FromBigInteger(BigIntegers.CreateRandomBigInteger(this.FieldSize, r));
  }

  public override ECFieldElement RandomFieldElementMult(SecureRandom r)
  {
    int fieldSize = this.FieldSize;
    return this.FromBigInteger(AbstractF2mCurve.ImplRandomFieldElementMult(r, fieldSize)).Multiply(this.FromBigInteger(AbstractF2mCurve.ImplRandomFieldElementMult(r, fieldSize)));
  }

  protected override ECPoint DecompressPoint(int yTilde, BigInteger X1)
  {
    ECFieldElement ecFieldElement1 = this.FromBigInteger(X1);
    ECFieldElement y = (ECFieldElement) null;
    if (ecFieldElement1.IsZero)
    {
      y = this.B.Sqrt();
    }
    else
    {
      ECFieldElement ecFieldElement2 = this.SolveQuadraticEquation(ecFieldElement1.Square().Invert().Multiply(this.B).Add(this.A).Add(ecFieldElement1));
      if (ecFieldElement2 != null)
      {
        if (ecFieldElement2.TestBitZero() != (yTilde == 1))
          ecFieldElement2 = ecFieldElement2.AddOne();
        switch (this.CoordinateSystem)
        {
          case 5:
          case 6:
            y = ecFieldElement2.Add(ecFieldElement1);
            break;
          default:
            y = ecFieldElement2.Multiply(ecFieldElement1);
            break;
        }
      }
    }
    return y != null ? this.CreateRawPoint(ecFieldElement1, y) : throw new ArgumentException("Invalid point compression");
  }

  internal ECFieldElement SolveQuadraticEquation(ECFieldElement beta)
  {
    AbstractF2mFieldElement abstractF2mFieldElement = (AbstractF2mFieldElement) beta;
    bool hasFastTrace;
    if ((hasFastTrace = abstractF2mFieldElement.HasFastTrace) && abstractF2mFieldElement.Trace() != 0)
      return (ECFieldElement) null;
    int fieldSize = this.FieldSize;
    if ((fieldSize & 1) != 0)
    {
      ECFieldElement b = abstractF2mFieldElement.HalfTrace();
      return !hasFastTrace && !b.Square().Add(b).Add(beta).IsZero ? (ECFieldElement) null : b;
    }
    if (beta.IsZero)
      return beta;
    ECFieldElement ecFieldElement1 = this.FromBigInteger(BigInteger.Zero);
    ECFieldElement b1;
    do
    {
      ECFieldElement b2 = this.FromBigInteger(BigInteger.Arbitrary(fieldSize));
      b1 = ecFieldElement1;
      ECFieldElement ecFieldElement2 = beta;
      for (int index = 1; index < fieldSize; ++index)
      {
        ECFieldElement ecFieldElement3 = ecFieldElement2.Square();
        b1 = b1.Square().Add(ecFieldElement3.Multiply(b2));
        ecFieldElement2 = ecFieldElement3.Add(beta);
      }
      if (!ecFieldElement2.IsZero)
        goto label_14;
    }
    while (b1.Square().Add(b1).IsZero);
    goto label_15;
label_14:
    return (ECFieldElement) null;
label_15:
    return b1;
  }

  public virtual bool IsKoblitz
  {
    get
    {
      if (this.m_order == null || this.m_cofactor == null || !this.m_b.IsOne)
        return false;
      return this.m_a.IsZero || this.m_a.IsOne;
    }
  }

  private static BigInteger ImplRandomFieldElementMult(SecureRandom r, int m)
  {
    BigInteger randomBigInteger;
    do
    {
      randomBigInteger = BigIntegers.CreateRandomBigInteger(m, r);
    }
    while (randomBigInteger.SignValue <= 0);
    return randomBigInteger;
  }
}
