// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.DHPublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class DHPublicKeyParameters : DHKeyParameters
{
  private readonly BigInteger m_y;

  private static BigInteger Validate(BigInteger y, DHParameters dhParams)
  {
    if (y == null)
      throw new ArgumentNullException(nameof (y));
    BigInteger p = dhParams.P;
    if (y.CompareTo(BigInteger.Two) < 0 || y.CompareTo(p.Subtract(BigInteger.Two)) > 0)
      throw new ArgumentException("invalid DH public key", nameof (y));
    BigInteger q = dhParams.Q;
    if (q == null)
      return y;
    if (p.TestBit(0) && p.BitLength - 1 == q.BitLength && p.ShiftRight(1).Equals(q))
    {
      if (1 == DHPublicKeyParameters.Legendre(y, p))
        return y;
    }
    else if (BigInteger.One.Equals(y.ModPow(q, p)))
      return y;
    throw new ArgumentException("value does not appear to be in correct group", nameof (y));
  }

  public DHPublicKeyParameters(BigInteger y, DHParameters parameters)
    : base(false, parameters)
  {
    this.m_y = DHPublicKeyParameters.Validate(y, parameters);
  }

  public DHPublicKeyParameters(
    BigInteger y,
    DHParameters parameters,
    DerObjectIdentifier algorithmOid)
    : base(false, parameters, algorithmOid)
  {
    this.m_y = DHPublicKeyParameters.Validate(y, parameters);
  }

  public virtual BigInteger Y => this.m_y;

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is DHPublicKeyParameters other && this.Equals(other);
  }

  protected bool Equals(DHPublicKeyParameters other)
  {
    return this.m_y.Equals(other.m_y) && this.Equals((DHKeyParameters) other);
  }

  public override int GetHashCode() => this.m_y.GetHashCode() ^ base.GetHashCode();

  private static int Legendre(BigInteger a, BigInteger b)
  {
    int bitLength = b.BitLength;
    int lengthForBits = Nat.GetLengthForBits(bitLength);
    uint[] numArray1 = Nat.FromBigInteger(bitLength, a);
    uint[] numArray2 = Nat.FromBigInteger(bitLength, b);
    int num1 = 0;
    while (true)
    {
      while (numArray1[0] == 0U)
      {
        int num2 = (int) Nat.ShiftDownWord(lengthForBits, numArray1, 0U);
      }
      int bits = Integers.NumberOfTrailingZeros((int) numArray1[0]);
      if (bits > 0)
      {
        int num3 = (int) Nat.ShiftDownBits(lengthForBits, numArray1, bits, 0U);
        int num4 = (int) numArray2[0];
        num1 ^= (num4 ^ num4 >> 1) & bits << 1;
      }
      int num5 = Nat.Compare(lengthForBits, numArray1, numArray2);
      if (num5 != 0)
      {
        if (num5 < 0)
        {
          num1 ^= (int) numArray1[0] & (int) numArray2[0];
          uint[] numArray3 = numArray1;
          numArray1 = numArray2;
          numArray2 = numArray3;
        }
        while (numArray1[lengthForBits - 1] == 0U)
          --lengthForBits;
        Nat.Sub(lengthForBits, numArray1, numArray2, numArray1);
      }
      else
        break;
    }
    return !Nat.IsOne(lengthForBits, numArray2) ? 0 : 1 - (num1 & 2);
  }
}
