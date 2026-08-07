// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.FpFieldElement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC;

public class FpFieldElement : AbstractFpFieldElement
{
  private readonly BigInteger q;
  private readonly BigInteger r;
  private readonly BigInteger x;

  internal static BigInteger CalculateResidue(BigInteger p)
  {
    int bitLength = p.BitLength;
    if (bitLength >= 96 /*0x60*/)
    {
      if (p.ShiftRight(bitLength - 64 /*0x40*/).LongValue == -1L)
        return BigInteger.One.ShiftLeft(bitLength).Subtract(p);
      if ((bitLength & 7) == 0)
        return BigInteger.One.ShiftLeft(bitLength << 1).Divide(p).Negate();
    }
    return (BigInteger) null;
  }

  internal FpFieldElement(BigInteger q, BigInteger r, BigInteger x)
  {
    this.q = q;
    this.r = r;
    this.x = x;
  }

  public override BigInteger ToBigInteger() => this.x;

  public override string FieldName => "Fp";

  public override int FieldSize => this.q.BitLength;

  public BigInteger Q => this.q;

  public override ECFieldElement Add(ECFieldElement b)
  {
    return (ECFieldElement) new FpFieldElement(this.q, this.r, this.ModAdd(this.x, b.ToBigInteger()));
  }

  public override ECFieldElement AddOne()
  {
    BigInteger x = this.x.Add(BigInteger.One);
    if (x.CompareTo(this.q) == 0)
      x = BigInteger.Zero;
    return (ECFieldElement) new FpFieldElement(this.q, this.r, x);
  }

  public override ECFieldElement Subtract(ECFieldElement b)
  {
    return (ECFieldElement) new FpFieldElement(this.q, this.r, this.ModSubtract(this.x, b.ToBigInteger()));
  }

  public override ECFieldElement Multiply(ECFieldElement b)
  {
    return (ECFieldElement) new FpFieldElement(this.q, this.r, this.ModMult(this.x, b.ToBigInteger()));
  }

  public override ECFieldElement MultiplyMinusProduct(
    ECFieldElement b,
    ECFieldElement x,
    ECFieldElement y)
  {
    BigInteger x1 = this.x;
    BigInteger bigInteger1 = b.ToBigInteger();
    BigInteger bigInteger2 = x.ToBigInteger();
    BigInteger bigInteger3 = y.ToBigInteger();
    BigInteger bigInteger4 = x1.Multiply(bigInteger1);
    BigInteger val = bigInteger3;
    BigInteger n = bigInteger2.Multiply(val);
    return (ECFieldElement) new FpFieldElement(this.q, this.r, this.ModReduce(bigInteger4.Subtract(n)));
  }

  public override ECFieldElement MultiplyPlusProduct(
    ECFieldElement b,
    ECFieldElement x,
    ECFieldElement y)
  {
    BigInteger x1 = this.x;
    BigInteger bigInteger1 = b.ToBigInteger();
    BigInteger bigInteger2 = x.ToBigInteger();
    BigInteger bigInteger3 = y.ToBigInteger();
    BigInteger val = bigInteger1;
    BigInteger x2 = x1.Multiply(val).Add(bigInteger2.Multiply(bigInteger3));
    if (this.r != null && this.r.SignValue < 0 && x2.BitLength > this.q.BitLength << 1)
      x2 = x2.Subtract(this.q.ShiftLeft(this.q.BitLength));
    return (ECFieldElement) new FpFieldElement(this.q, this.r, this.ModReduce(x2));
  }

  public override ECFieldElement Divide(ECFieldElement b)
  {
    return (ECFieldElement) new FpFieldElement(this.q, this.r, this.ModMult(this.x, this.ModInverse(b.ToBigInteger())));
  }

  public override ECFieldElement Negate()
  {
    return this.x.SignValue != 0 ? (ECFieldElement) new FpFieldElement(this.q, this.r, this.q.Subtract(this.x)) : (ECFieldElement) this;
  }

  public override ECFieldElement Square()
  {
    return (ECFieldElement) new FpFieldElement(this.q, this.r, this.ModMult(this.x, this.x));
  }

  public override ECFieldElement SquareMinusProduct(ECFieldElement x, ECFieldElement y)
  {
    BigInteger x1 = this.x;
    BigInteger bigInteger1 = x.ToBigInteger();
    BigInteger bigInteger2 = y.ToBigInteger();
    return (ECFieldElement) new FpFieldElement(this.q, this.r, this.ModReduce(x1.Multiply(x1).Subtract(bigInteger1.Multiply(bigInteger2))));
  }

  public override ECFieldElement SquarePlusProduct(ECFieldElement x, ECFieldElement y)
  {
    BigInteger x1 = this.x;
    BigInteger bigInteger1 = x.ToBigInteger();
    BigInteger bigInteger2 = y.ToBigInteger();
    BigInteger x2 = x1.Multiply(x1).Add(bigInteger1.Multiply(bigInteger2));
    if (this.r != null && this.r.SignValue < 0 && x2.BitLength > this.q.BitLength << 1)
      x2 = x2.Subtract(this.q.ShiftLeft(this.q.BitLength));
    return (ECFieldElement) new FpFieldElement(this.q, this.r, this.ModReduce(x2));
  }

  public override ECFieldElement Invert()
  {
    return (ECFieldElement) new FpFieldElement(this.q, this.r, this.ModInverse(this.x));
  }

  public override ECFieldElement Sqrt()
  {
    if (this.IsZero || this.IsOne)
      return (ECFieldElement) this;
    if (!this.q.TestBit(0))
      throw new NotImplementedException("even value of q");
    if (this.q.TestBit(1))
      return this.CheckSqrt((ECFieldElement) new FpFieldElement(this.q, this.r, this.x.ModPow(this.q.ShiftRight(2).Add(BigInteger.One), this.q)));
    if (this.q.TestBit(2))
    {
      BigInteger bigInteger1 = this.x.ModPow(this.q.ShiftRight(3), this.q);
      BigInteger bigInteger2 = this.ModMult(bigInteger1, this.x);
      if (this.ModMult(bigInteger2, bigInteger1).Equals(BigInteger.One))
        return this.CheckSqrt((ECFieldElement) new FpFieldElement(this.q, this.r, bigInteger2));
      BigInteger x2 = BigInteger.Two.ModPow(this.q.ShiftRight(2), this.q);
      return this.CheckSqrt((ECFieldElement) new FpFieldElement(this.q, this.r, this.ModMult(bigInteger2, x2)));
    }
    BigInteger e = this.q.ShiftRight(1);
    if (!this.x.ModPow(e, this.q).Equals(BigInteger.One))
      return (ECFieldElement) null;
    BigInteger x = this.x;
    BigInteger bigInteger3 = this.ModDouble(this.ModDouble(x));
    BigInteger k = e.Add(BigInteger.One);
    BigInteger other = this.q.Subtract(BigInteger.One);
    BigInteger bigInteger4;
    BigInteger bigInteger5;
    do
    {
      BigInteger bigInteger6;
      do
      {
        bigInteger6 = BigInteger.Arbitrary(this.q.BitLength);
      }
      while (bigInteger6.CompareTo(this.q) >= 0 || !this.ModReduce(bigInteger6.Multiply(bigInteger6).Subtract(bigInteger3)).ModPow(e, this.q).Equals(other));
      BigInteger[] bigIntegerArray = this.LucasSequence(bigInteger6, x, k);
      bigInteger4 = bigIntegerArray[0];
      bigInteger5 = bigIntegerArray[1];
      if (this.ModMult(bigInteger5, bigInteger5).Equals(bigInteger3))
        goto label_15;
    }
    while (bigInteger4.Equals(BigInteger.One) || bigInteger4.Equals(other));
    goto label_16;
label_15:
    return (ECFieldElement) new FpFieldElement(this.q, this.r, this.ModHalfAbs(bigInteger5));
label_16:
    return (ECFieldElement) null;
  }

  private ECFieldElement CheckSqrt(ECFieldElement z)
  {
    return !z.Square().Equals((ECFieldElement) this) ? (ECFieldElement) null : z;
  }

  private BigInteger[] LucasSequence(BigInteger P, BigInteger Q, BigInteger k)
  {
    int bitLength = k.BitLength;
    int lowestSetBit = k.GetLowestSetBit();
    BigInteger x1_1 = BigInteger.One;
    BigInteger val = BigInteger.Two;
    BigInteger bigInteger1 = P;
    BigInteger bigInteger2 = BigInteger.One;
    BigInteger x2_1 = BigInteger.One;
    for (int n = bitLength - 1; n >= lowestSetBit + 1; --n)
    {
      bigInteger2 = this.ModMult(bigInteger2, x2_1);
      if (k.TestBit(n))
      {
        x2_1 = this.ModMult(bigInteger2, Q);
        x1_1 = this.ModMult(x1_1, bigInteger1);
        val = this.ModReduce(bigInteger1.Multiply(val).Subtract(P.Multiply(bigInteger2)));
        bigInteger1 = this.ModReduce(bigInteger1.Multiply(bigInteger1).Subtract(x2_1.ShiftLeft(1)));
      }
      else
      {
        x2_1 = bigInteger2;
        x1_1 = this.ModReduce(x1_1.Multiply(val).Subtract(bigInteger2));
        bigInteger1 = this.ModReduce(bigInteger1.Multiply(val).Subtract(P.Multiply(bigInteger2)));
        val = this.ModReduce(val.Multiply(val).Subtract(bigInteger2.ShiftLeft(1)));
      }
    }
    BigInteger bigInteger3 = this.ModMult(bigInteger2, x2_1);
    BigInteger x2_2 = this.ModMult(bigInteger3, Q);
    BigInteger x1_2 = this.ModReduce(x1_1.Multiply(val).Subtract(bigInteger3));
    BigInteger bigInteger4 = this.ModReduce(bigInteger1.Multiply(val).Subtract(P.Multiply(bigInteger3)));
    BigInteger bigInteger5 = this.ModMult(bigInteger3, x2_2);
    for (int index = 1; index <= lowestSetBit; ++index)
    {
      x1_2 = this.ModMult(x1_2, bigInteger4);
      bigInteger4 = this.ModReduce(bigInteger4.Multiply(bigInteger4).Subtract(bigInteger5.ShiftLeft(1)));
      bigInteger5 = this.ModMult(bigInteger5, bigInteger5);
    }
    return new BigInteger[2]{ x1_2, bigInteger4 };
  }

  protected virtual BigInteger ModAdd(BigInteger x1, BigInteger x2)
  {
    BigInteger bigInteger = x1.Add(x2);
    if (bigInteger.CompareTo(this.q) >= 0)
      bigInteger = bigInteger.Subtract(this.q);
    return bigInteger;
  }

  protected virtual BigInteger ModDouble(BigInteger x)
  {
    BigInteger bigInteger = x.ShiftLeft(1);
    if (bigInteger.CompareTo(this.q) >= 0)
      bigInteger = bigInteger.Subtract(this.q);
    return bigInteger;
  }

  protected virtual BigInteger ModHalf(BigInteger x)
  {
    if (x.TestBit(0))
      x = this.q.Add(x);
    return x.ShiftRight(1);
  }

  protected virtual BigInteger ModHalfAbs(BigInteger x)
  {
    if (x.TestBit(0))
      x = this.q.Subtract(x);
    return x.ShiftRight(1);
  }

  protected virtual BigInteger ModInverse(BigInteger x) => BigIntegers.ModOddInverse(this.q, x);

  protected virtual BigInteger ModMult(BigInteger x1, BigInteger x2)
  {
    return this.ModReduce(x1.Multiply(x2));
  }

  protected virtual BigInteger ModReduce(BigInteger x)
  {
    if (this.r == null)
    {
      x = x.Mod(this.q);
    }
    else
    {
      bool flag1;
      if (flag1 = x.SignValue < 0)
        x = x.Abs();
      int bitLength = this.q.BitLength;
      if (this.r.SignValue > 0)
      {
        BigInteger n = BigInteger.One.ShiftLeft(bitLength);
        bool flag2 = this.r.Equals(BigInteger.One);
        BigInteger bigInteger1;
        BigInteger bigInteger2;
        for (; x.BitLength > bitLength + 1; x = bigInteger1.Add(bigInteger2))
        {
          bigInteger1 = x.ShiftRight(bitLength);
          bigInteger2 = x.Remainder(n);
          if (!flag2)
            bigInteger1 = bigInteger1.Multiply(this.r);
        }
      }
      else
      {
        int num = (bitLength - 1 & 31 /*0x1F*/) + 1;
        BigInteger bigInteger = this.r.Negate().Multiply(x.ShiftRight(bitLength - num)).ShiftRight(bitLength + num).Multiply(this.q);
        BigInteger n1 = BigInteger.One.ShiftLeft(bitLength + num);
        BigInteger n2 = bigInteger.Remainder(n1);
        x = x.Remainder(n1);
        x = x.Subtract(n2);
        if (x.SignValue < 0)
          x = x.Add(n1);
      }
      while (x.CompareTo(this.q) >= 0)
        x = x.Subtract(this.q);
      if (flag1 && x.SignValue != 0)
        x = this.q.Subtract(x);
    }
    return x;
  }

  protected virtual BigInteger ModSubtract(BigInteger x1, BigInteger x2)
  {
    BigInteger bigInteger = x1.Subtract(x2);
    if (bigInteger.SignValue < 0)
      bigInteger = bigInteger.Add(this.q);
    return bigInteger;
  }

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is FpFieldElement other && this.Equals(other);
  }

  public virtual bool Equals(FpFieldElement other)
  {
    return this.q.Equals(other.q) && this.Equals((ECFieldElement) other);
  }

  public override int GetHashCode() => this.q.GetHashCode() ^ base.GetHashCode();
}
