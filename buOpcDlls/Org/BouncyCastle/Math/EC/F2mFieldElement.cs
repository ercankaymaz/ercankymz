// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.F2mFieldElement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC;

public class F2mFieldElement : AbstractF2mFieldElement
{
  public const int Gnb = 1;
  public const int Tpb = 2;
  public const int Ppb = 3;
  private int representation;
  private int m;
  private int[] ks;
  internal LongArray x;

  internal F2mFieldElement(int m, int[] ks, LongArray x)
  {
    this.m = m;
    this.representation = ks.Length == 1 ? 2 : 3;
    this.ks = ks;
    this.x = x;
  }

  public override int BitLength => this.x.Degree();

  public override bool IsOne => this.x.IsOne();

  public override bool IsZero => this.x.IsZero();

  public override bool TestBitZero() => this.x.TestBitZero();

  public override BigInteger ToBigInteger() => this.x.ToBigInteger();

  public override string FieldName => "F2m";

  public override int FieldSize => this.m;

  public static void CheckFieldElements(ECFieldElement a, ECFieldElement b)
  {
    F2mFieldElement f2mFieldElement1 = a is F2mFieldElement && b is F2mFieldElement ? (F2mFieldElement) a : throw new ArgumentException("Field elements are not both instances of F2mFieldElement");
    F2mFieldElement f2mFieldElement2 = (F2mFieldElement) b;
    if (f2mFieldElement1.representation != f2mFieldElement2.representation)
      throw new ArgumentException("One of the F2m field elements has incorrect representation");
    if (f2mFieldElement1.m != f2mFieldElement2.m || !Arrays.AreEqual(f2mFieldElement1.ks, f2mFieldElement2.ks))
      throw new ArgumentException("Field elements are not elements of the same field F2m");
  }

  public override ECFieldElement Add(ECFieldElement b)
  {
    LongArray x = this.x.Copy();
    F2mFieldElement f2mFieldElement = (F2mFieldElement) b;
    x.AddShiftedByWords(f2mFieldElement.x, 0);
    return (ECFieldElement) new F2mFieldElement(this.m, this.ks, x);
  }

  public override ECFieldElement AddOne()
  {
    return (ECFieldElement) new F2mFieldElement(this.m, this.ks, this.x.AddOne());
  }

  public override ECFieldElement Subtract(ECFieldElement b) => this.Add(b);

  public override ECFieldElement Multiply(ECFieldElement b)
  {
    return (ECFieldElement) new F2mFieldElement(this.m, this.ks, this.x.ModMultiply(((F2mFieldElement) b).x, this.m, this.ks));
  }

  public override ECFieldElement MultiplyMinusProduct(
    ECFieldElement b,
    ECFieldElement x,
    ECFieldElement y)
  {
    return this.MultiplyPlusProduct(b, x, y);
  }

  public override ECFieldElement MultiplyPlusProduct(
    ECFieldElement b,
    ECFieldElement x,
    ECFieldElement y)
  {
    LongArray x1 = this.x;
    LongArray x2 = ((F2mFieldElement) b).x;
    LongArray x3 = ((F2mFieldElement) x).x;
    LongArray x4 = ((F2mFieldElement) y).x;
    LongArray a = x1.Multiply(x2, this.m, this.ks);
    LongArray other = x3.Multiply(x4, this.m, this.ks);
    if (LongArray.AreAliased(ref a, ref x1) || LongArray.AreAliased(ref a, ref x2))
      a = a.Copy();
    a.AddShiftedByWords(other, 0);
    a.Reduce(this.m, this.ks);
    return (ECFieldElement) new F2mFieldElement(this.m, this.ks, a);
  }

  public override ECFieldElement Divide(ECFieldElement b) => this.Multiply(b.Invert());

  public override ECFieldElement Negate() => (ECFieldElement) this;

  public override ECFieldElement Square()
  {
    return (ECFieldElement) new F2mFieldElement(this.m, this.ks, this.x.ModSquare(this.m, this.ks));
  }

  public override ECFieldElement SquareMinusProduct(ECFieldElement x, ECFieldElement y)
  {
    return this.SquarePlusProduct(x, y);
  }

  public override ECFieldElement SquarePlusProduct(ECFieldElement x, ECFieldElement y)
  {
    LongArray x1 = this.x;
    LongArray x2 = ((F2mFieldElement) x).x;
    LongArray x3 = ((F2mFieldElement) y).x;
    LongArray a = x1.Square(this.m, this.ks);
    LongArray other = x2.Multiply(x3, this.m, this.ks);
    if (LongArray.AreAliased(ref a, ref x1))
      a = a.Copy();
    a.AddShiftedByWords(other, 0);
    a.Reduce(this.m, this.ks);
    return (ECFieldElement) new F2mFieldElement(this.m, this.ks, a);
  }

  public override ECFieldElement SquarePow(int pow)
  {
    return pow >= 1 ? (ECFieldElement) new F2mFieldElement(this.m, this.ks, this.x.ModSquareN(pow, this.m, this.ks)) : (ECFieldElement) this;
  }

  public override ECFieldElement Invert()
  {
    return (ECFieldElement) new F2mFieldElement(this.m, this.ks, this.x.ModInverse(this.m, this.ks));
  }

  public override ECFieldElement Sqrt()
  {
    return !this.x.IsZero() && !this.x.IsOne() ? this.SquarePow(this.m - 1) : (ECFieldElement) this;
  }

  public int Representation => this.representation;

  public int M => this.m;

  public int K1 => this.ks[0];

  public int K2 => this.ks.Length < 2 ? 0 : this.ks[1];

  public int K3 => this.ks.Length < 3 ? 0 : this.ks[2];

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is F2mFieldElement other && this.Equals(other);
  }

  public virtual bool Equals(F2mFieldElement other)
  {
    return this.m == other.m && this.representation == other.representation && Arrays.AreEqual(this.ks, other.ks) && this.x.Equals((object) other.x);
  }

  public override int GetHashCode() => this.x.GetHashCode() ^ this.m ^ Arrays.GetHashCode(this.ks);
}
