// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.Abc.Tnaf
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC.Multiplier;
using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC.Abc;

internal static class Tnaf
{
  private static readonly BigInteger MinusOne = BigInteger.One.Negate();
  private static readonly BigInteger MinusTwo = BigInteger.Two.Negate();
  private static readonly BigInteger MinusThree = BigInteger.Three.Negate();
  private static readonly BigInteger Four = BigInteger.ValueOf(4L);
  private static readonly string PRECOMP_NAME = "bc_tnaf_partmod";
  public const sbyte Width = 4;
  public static readonly ZTauElement[] Alpha0 = new ZTauElement[16 /*0x10*/]
  {
    null,
    new ZTauElement(BigInteger.One, BigInteger.Zero),
    null,
    new ZTauElement(Tnaf.MinusThree, Tnaf.MinusOne),
    null,
    new ZTauElement(Tnaf.MinusOne, Tnaf.MinusOne),
    null,
    new ZTauElement(BigInteger.One, Tnaf.MinusOne),
    null,
    new ZTauElement(Tnaf.MinusOne, BigInteger.One),
    null,
    new ZTauElement(BigInteger.One, BigInteger.One),
    null,
    new ZTauElement(BigInteger.Three, BigInteger.One),
    null,
    new ZTauElement(Tnaf.MinusOne, BigInteger.Zero)
  };
  public static readonly sbyte[][] Alpha0Tnaf = new sbyte[8][]
  {
    null,
    new sbyte[1]{ (sbyte) 1 },
    null,
    new sbyte[3]{ (sbyte) -1, (sbyte) 0, (sbyte) 1 },
    null,
    new sbyte[3]{ (sbyte) 1, (sbyte) 0, (sbyte) 1 },
    null,
    new sbyte[4]{ (sbyte) -1, (sbyte) 0, (sbyte) 0, (sbyte) 1 }
  };
  public static readonly ZTauElement[] Alpha1 = new ZTauElement[16 /*0x10*/]
  {
    null,
    new ZTauElement(BigInteger.One, BigInteger.Zero),
    null,
    new ZTauElement(Tnaf.MinusThree, BigInteger.One),
    null,
    new ZTauElement(Tnaf.MinusOne, BigInteger.One),
    null,
    new ZTauElement(BigInteger.One, BigInteger.One),
    null,
    new ZTauElement(Tnaf.MinusOne, Tnaf.MinusOne),
    null,
    new ZTauElement(BigInteger.One, Tnaf.MinusOne),
    null,
    new ZTauElement(BigInteger.Three, Tnaf.MinusOne),
    null,
    new ZTauElement(Tnaf.MinusOne, BigInteger.Zero)
  };
  public static readonly sbyte[][] Alpha1Tnaf = new sbyte[8][]
  {
    null,
    new sbyte[1]{ (sbyte) 1 },
    null,
    new sbyte[3]{ (sbyte) -1, (sbyte) 0, (sbyte) 1 },
    null,
    new sbyte[3]{ (sbyte) 1, (sbyte) 0, (sbyte) 1 },
    null,
    new sbyte[4]{ (sbyte) -1, (sbyte) 0, (sbyte) 0, (sbyte) -1 }
  };

  public static BigInteger Norm(sbyte mu, ZTauElement lambda)
  {
    BigInteger bigInteger = lambda.u.Square();
    if (mu == (sbyte) 1)
      return lambda.v.ShiftLeft(1).Add(lambda.u).Multiply(lambda.v).Add(bigInteger);
    if (mu != (sbyte) -1)
      throw new ArgumentException("mu must be 1 or -1");
    return lambda.v.ShiftLeft(1).Subtract(lambda.u).Multiply(lambda.v).Add(bigInteger);
  }

  public static SimpleBigDecimal Norm(sbyte mu, SimpleBigDecimal u, SimpleBigDecimal v)
  {
    SimpleBigDecimal simpleBigDecimal = u.Multiply(u);
    SimpleBigDecimal b1 = u.Multiply(v);
    SimpleBigDecimal b2 = v.Multiply(v).ShiftLeft(1);
    if (mu == (sbyte) 1)
      return simpleBigDecimal.Add(b1).Add(b2);
    if (mu == (sbyte) -1)
      return simpleBigDecimal.Subtract(b1).Add(b2);
    throw new ArgumentException("mu must be 1 or -1");
  }

  public static ZTauElement Round(SimpleBigDecimal lambda0, SimpleBigDecimal lambda1, sbyte mu)
  {
    int scale = lambda0.Scale;
    if (lambda1.Scale != scale)
      throw new ArgumentException("lambda0 and lambda1 do not have same scale");
    if (mu != (sbyte) 1 && mu != (sbyte) -1)
      throw new ArgumentException("mu must be 1 or -1");
    BigInteger b1 = lambda0.Round();
    BigInteger b2 = lambda1.Round();
    SimpleBigDecimal b3 = lambda0.Subtract(b1);
    SimpleBigDecimal b4 = lambda1.Subtract(b2);
    SimpleBigDecimal simpleBigDecimal1 = b3.Add(b3);
    SimpleBigDecimal simpleBigDecimal2 = mu != (sbyte) 1 ? simpleBigDecimal1.Subtract(b4) : simpleBigDecimal1.Add(b4);
    SimpleBigDecimal b5 = b4.Add(b4).Add(b4);
    SimpleBigDecimal b6 = b5.Add(b4);
    SimpleBigDecimal simpleBigDecimal3;
    SimpleBigDecimal simpleBigDecimal4;
    if (mu == (sbyte) 1)
    {
      simpleBigDecimal3 = b3.Subtract(b5);
      simpleBigDecimal4 = b3.Add(b6);
    }
    else
    {
      simpleBigDecimal3 = b3.Add(b5);
      simpleBigDecimal4 = b3.Subtract(b6);
    }
    sbyte num1 = 0;
    sbyte num2 = 0;
    if (simpleBigDecimal2.CompareTo(BigInteger.One) >= 0)
    {
      if (simpleBigDecimal3.CompareTo(Tnaf.MinusOne) < 0)
        num2 = mu;
      else
        num1 = (sbyte) 1;
    }
    else if (simpleBigDecimal4.CompareTo(BigInteger.Two) >= 0)
      num2 = mu;
    if (simpleBigDecimal2.CompareTo(Tnaf.MinusOne) < 0)
    {
      if (simpleBigDecimal3.CompareTo(BigInteger.One) >= 0)
        num2 = -mu;
      else
        num1 = (sbyte) -1;
    }
    else if (simpleBigDecimal4.CompareTo(Tnaf.MinusTwo) < 0)
      num2 = -mu;
    return new ZTauElement(b1.Add(BigInteger.ValueOf((long) num1)), b2.Add(BigInteger.ValueOf((long) num2)));
  }

  public static SimpleBigDecimal ApproximateDivisionByN(
    BigInteger k,
    BigInteger s,
    BigInteger vm,
    sbyte a,
    int m,
    int c)
  {
    int num = (m + 5) / 2 + c;
    BigInteger val1 = k.ShiftRight(m - num - 2 + (int) a);
    BigInteger bigInteger1 = s.Multiply(val1);
    BigInteger val2 = bigInteger1.ShiftRight(m);
    BigInteger bigInteger2 = bigInteger1.Add(vm.Multiply(val2));
    BigInteger bigInt = bigInteger2.ShiftRight(num - c);
    if (bigInteger2.TestBit(num - c - 1))
      bigInt = bigInt.Add(BigInteger.One);
    return new SimpleBigDecimal(bigInt, c);
  }

  public static sbyte[] TauAdicNaf(sbyte mu, ZTauElement lambda)
  {
    if (mu != (sbyte) 1 && mu != (sbyte) -1)
      throw new ArgumentException("mu must be 1 or -1");
    int bitLength = Tnaf.Norm(mu, lambda).BitLength;
    sbyte[] sourceArray = new sbyte[bitLength > 30 ? bitLength + 4 : 34];
    int index = 0;
    int num = 0;
    BigInteger bigInteger1 = lambda.u;
    BigInteger bigInteger2 = lambda.v;
    while (!bigInteger1.Equals(BigInteger.Zero) || !bigInteger2.Equals(BigInteger.Zero))
    {
      if (bigInteger1.TestBit(0))
      {
        sourceArray[index] = (sbyte) BigInteger.Two.Subtract(bigInteger1.Subtract(bigInteger2.ShiftLeft(1)).Mod(Tnaf.Four)).IntValue;
        bigInteger1 = sourceArray[index] != (sbyte) 1 ? bigInteger1.Add(BigInteger.One) : bigInteger1.ClearBit(0);
        num = index;
      }
      else
        sourceArray[index] = (sbyte) 0;
      BigInteger bigInteger3 = bigInteger1;
      BigInteger n = bigInteger1.ShiftRight(1);
      bigInteger1 = mu != (sbyte) 1 ? bigInteger2.Subtract(n) : bigInteger2.Add(n);
      bigInteger2 = bigInteger3.ShiftRight(1).Negate();
      ++index;
    }
    int length = num + 1;
    sbyte[] destinationArray = new sbyte[length];
    Array.Copy((Array) sourceArray, 0, (Array) destinationArray, 0, length);
    return destinationArray;
  }

  public static AbstractF2mPoint Tau(AbstractF2mPoint p) => p.Tau();

  public static sbyte GetMu(AbstractF2mCurve curve)
  {
    BigInteger bigInteger = curve.A.ToBigInteger();
    if (bigInteger.SignValue == 0)
      return -1;
    if (bigInteger.Equals(BigInteger.One))
      return 1;
    throw new ArgumentException("No Koblitz curve (ABC), TNAF multiplication not possible");
  }

  public static sbyte GetMu(ECFieldElement curveA) => curveA.IsZero ? (sbyte) -1 : (sbyte) 1;

  public static sbyte GetMu(int curveA) => curveA == 0 ? (sbyte) -1 : (sbyte) 1;

  public static BigInteger[] GetLucas(sbyte mu, int k, bool doV)
  {
    if (mu != (sbyte) 1 && mu != (sbyte) -1)
      throw new ArgumentException("mu must be 1 or -1");
    BigInteger bigInteger1;
    BigInteger bigInteger2;
    if (doV)
    {
      bigInteger1 = BigInteger.Two;
      bigInteger2 = BigInteger.ValueOf((long) mu);
    }
    else
    {
      bigInteger1 = BigInteger.Zero;
      bigInteger2 = BigInteger.One;
    }
    for (int index = 1; index < k; ++index)
    {
      BigInteger bigInteger3 = bigInteger2;
      if (mu < (sbyte) 0)
        bigInteger3 = bigInteger3.Negate();
      BigInteger bigInteger4 = bigInteger3.Subtract(bigInteger1.ShiftLeft(1));
      bigInteger1 = bigInteger2;
      bigInteger2 = bigInteger4;
    }
    return new BigInteger[2]{ bigInteger1, bigInteger2 };
  }

  public static BigInteger GetTw(sbyte mu, int w)
  {
    if (w == 4)
      return mu == (sbyte) 1 ? BigInteger.ValueOf(6L) : BigInteger.ValueOf(10L);
    BigInteger[] lucas = Tnaf.GetLucas(mu, w, false);
    BigInteger m = BigInteger.Zero.SetBit(w);
    BigInteger val = lucas[1].ModInverse(m);
    return lucas[0].ShiftLeft(1).Multiply(val).Mod(m);
  }

  public static BigInteger[] GetSi(AbstractF2mCurve curve)
  {
    if (!curve.IsKoblitz)
      throw new ArgumentException("si is defined for Koblitz curves only");
    return Tnaf.GetSi(curve.FieldSize, curve.A.ToBigInteger().IntValue, curve.Cofactor);
  }

  public static BigInteger[] GetSi(int fieldSize, int curveA, BigInteger cofactor)
  {
    int mu = (int) Tnaf.GetMu(curveA);
    int shiftsForCofactor = Tnaf.GetShiftsForCofactor(cofactor);
    BigInteger[] lucas = Tnaf.GetLucas((sbyte) mu, fieldSize + 3 - curveA, false);
    if (mu == 1)
    {
      lucas[0] = lucas[0].Negate();
      lucas[1] = lucas[1].Negate();
    }
    return new BigInteger[2]
    {
      BigInteger.One.Add(lucas[1]).ShiftRight(shiftsForCofactor),
      BigInteger.One.Add(lucas[0]).ShiftRight(shiftsForCofactor).Negate()
    };
  }

  private static int GetShiftsForCofactor(BigInteger h)
  {
    if (h != null && h.BitLength < 4)
    {
      switch (h.IntValue)
      {
        case 2:
          return 1;
        case 4:
          return 2;
      }
    }
    throw new ArgumentException("h (Cofactor) must be 2 or 4");
  }

  public static ZTauElement PartModReduction(
    AbstractF2mCurve curve,
    BigInteger k,
    sbyte a,
    sbyte mu,
    sbyte c)
  {
    Tnaf.PartModPreCompCallback callback = new Tnaf.PartModPreCompCallback(curve, mu, true);
    Tnaf.PartModPreCompInfo partModPreCompInfo = (Tnaf.PartModPreCompInfo) curve.Precompute(Tnaf.PRECOMP_NAME, (IPreCompCallback) callback);
    BigInteger lucas = partModPreCompInfo.Lucas;
    BigInteger s0 = partModPreCompInfo.S0;
    BigInteger s1 = partModPreCompInfo.S1;
    BigInteger bigInteger = mu != (sbyte) 1 ? s0.Subtract(s1) : s0.Add(s1);
    int fieldSize = curve.FieldSize;
    ZTauElement ztauElement = Tnaf.Round(Tnaf.ApproximateDivisionByN(k, s0, lucas, a, fieldSize, (int) c), Tnaf.ApproximateDivisionByN(k, s1, lucas, a, fieldSize, (int) c), mu);
    return new ZTauElement(k.Subtract(bigInteger.Multiply(ztauElement.u)).Subtract(s1.Multiply(ztauElement.v).ShiftLeft(1)), s1.Multiply(ztauElement.u).Subtract(s0.Multiply(ztauElement.v)));
  }

  public static AbstractF2mPoint MultiplyRTnaf(AbstractF2mPoint p, BigInteger k)
  {
    AbstractF2mCurve curve = (AbstractF2mCurve) p.Curve;
    int intValue = curve.A.ToBigInteger().IntValue;
    sbyte mu = Tnaf.GetMu(intValue);
    ZTauElement lambda = Tnaf.PartModReduction(curve, k, (sbyte) intValue, mu, (sbyte) 10);
    return Tnaf.MultiplyTnaf(p, lambda);
  }

  public static AbstractF2mPoint MultiplyTnaf(AbstractF2mPoint p, ZTauElement lambda)
  {
    AbstractF2mCurve curve = (AbstractF2mCurve) p.Curve;
    AbstractF2mPoint pNeg = (AbstractF2mPoint) p.Negate();
    sbyte[] u = Tnaf.TauAdicNaf(Tnaf.GetMu(curve.A), lambda);
    return Tnaf.MultiplyFromTnaf(p, pNeg, u);
  }

  public static AbstractF2mPoint MultiplyFromTnaf(
    AbstractF2mPoint p,
    AbstractF2mPoint pNeg,
    sbyte[] u)
  {
    AbstractF2mPoint abstractF2mPoint1 = (AbstractF2mPoint) p.Curve.Infinity;
    int pow = 0;
    for (int index = u.Length - 1; index >= 0; --index)
    {
      ++pow;
      sbyte num = u[index];
      if (num != (sbyte) 0)
      {
        AbstractF2mPoint abstractF2mPoint2 = abstractF2mPoint1.TauPow(pow);
        pow = 0;
        ECPoint b = num > (sbyte) 0 ? (ECPoint) p : (ECPoint) pNeg;
        abstractF2mPoint1 = (AbstractF2mPoint) abstractF2mPoint2.Add(b);
      }
    }
    if (pow > 0)
      abstractF2mPoint1 = abstractF2mPoint1.TauPow(pow);
    return abstractF2mPoint1;
  }

  public static sbyte[] TauAdicWNaf(
    sbyte mu,
    ZTauElement lambda,
    int width,
    int tw,
    ZTauElement[] alpha)
  {
    if (mu != (sbyte) 1 && mu != (sbyte) -1)
      throw new ArgumentException("mu must be 1 or -1");
    int bitLength = Tnaf.Norm(mu, lambda).BitLength;
    sbyte[] numArray1 = new sbyte[bitLength > 30 ? bitLength + 4 + width : 34 + width];
    int num1 = (1 << width) - 1;
    int num2 = 32 /*0x20*/ - width;
    BigInteger bigInteger1 = lambda.u;
    BigInteger bigInteger2 = lambda.v;
    int index1 = 0;
    int[] numArray2 = new int[alpha.Length];
    int[] numArray3 = new int[alpha.Length];
    for (int index2 = 1; index2 < alpha.Length; index2 += 2)
    {
      numArray2[index2] = alpha[index2].u.IntValueExact;
      numArray3[index2] = alpha[index2].v.IntValueExact;
    }
    BigInteger n;
    for (; bigInteger1.BitLength > 62 || bigInteger2.BitLength > 62; bigInteger2 = n.Negate())
    {
      if (bigInteger1.TestBit(0))
      {
        int num3 = bigInteger1.IntValue + bigInteger2.IntValue * tw;
        int index3 = num3 & num1;
        numArray1[index1] = (sbyte) (num3 << num2 >> num2);
        bigInteger1 = bigInteger1.Subtract(alpha[index3].u);
        bigInteger2 = bigInteger2.Subtract(alpha[index3].v);
      }
      ++index1;
      n = bigInteger1.ShiftRight(1);
      bigInteger1 = mu != (sbyte) 1 ? bigInteger2.Subtract(n) : bigInteger2.Add(n);
    }
    long num4 = bigInteger1.LongValueExact;
    long num5;
    for (long index4 = bigInteger2.LongValueExact; (num4 | index4) != 0L; index4 = -num5)
    {
      if ((num4 & 1L) != 0L)
      {
        int num6 = (int) num4 + (int) index4 * tw;
        int index5 = num6 & num1;
        numArray1[index1] = (sbyte) (num6 << num2 >> num2);
        num4 -= (long) numArray2[index5];
        index4 -= (long) numArray3[index5];
      }
      ++index1;
      num5 = num4 >> 1;
      num4 = mu != (sbyte) 1 ? index4 - num5 : index4 + num5;
    }
    return numArray1;
  }

  public static AbstractF2mPoint[] GetPreComp(AbstractF2mPoint p, sbyte a)
  {
    AbstractF2mPoint pNeg = (AbstractF2mPoint) p.Negate();
    sbyte[][] numArray = a == (sbyte) 0 ? Tnaf.Alpha0Tnaf : Tnaf.Alpha1Tnaf;
    AbstractF2mPoint[] points = new AbstractF2mPoint[numArray.Length + 1 >>> 1];
    points[0] = p;
    int length = numArray.Length;
    for (uint index = 3; (long) index < (long) length; index += 2U)
      points[(int) (index >> 1)] = Tnaf.MultiplyFromTnaf(p, pNeg, numArray[(int) index]);
    p.Curve.NormalizeAll((ECPoint[]) points);
    return points;
  }

  private sealed class PartModPreCompCallback : IPreCompCallback
  {
    private readonly AbstractF2mCurve m_curve;
    private readonly sbyte m_mu;
    private readonly bool m_doV;

    internal PartModPreCompCallback(AbstractF2mCurve curve, sbyte mu, bool doV)
    {
      this.m_curve = curve;
      this.m_mu = mu;
      this.m_doV = doV;
    }

    public PreCompInfo Precompute(PreCompInfo existing)
    {
      if (existing is Tnaf.PartModPreCompInfo)
        return existing;
      BigInteger lucas = !this.m_curve.IsKoblitz ? Tnaf.GetLucas(this.m_mu, this.m_curve.FieldSize, this.m_doV)[1] : BigInteger.One.ShiftLeft(this.m_curve.FieldSize).Add(BigInteger.One).Subtract(this.m_curve.Order.Multiply(this.m_curve.Cofactor));
      BigInteger[] si = Tnaf.GetSi(this.m_curve);
      return (PreCompInfo) new Tnaf.PartModPreCompInfo(lucas, si[0], si[1]);
    }
  }

  private sealed class PartModPreCompInfo : PreCompInfo
  {
    private readonly BigInteger m_lucas;
    private readonly BigInteger m_s0;
    private readonly BigInteger m_s1;

    internal PartModPreCompInfo(BigInteger lucas, BigInteger s0, BigInteger s1)
    {
      this.m_lucas = lucas;
      this.m_s0 = s0;
      this.m_s1 = s1;
    }

    internal BigInteger Lucas => this.m_lucas;

    internal BigInteger S0 => this.m_s0;

    internal BigInteger S1 => this.m_s1;
  }
}
