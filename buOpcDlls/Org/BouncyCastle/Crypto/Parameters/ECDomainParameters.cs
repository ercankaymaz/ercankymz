// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.ECDomainParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class ECDomainParameters
{
  private readonly ECCurve curve;
  private readonly byte[] seed;
  private readonly ECPoint g;
  private readonly BigInteger n;
  private readonly BigInteger h;
  private BigInteger hInv;

  public ECDomainParameters(X9ECParameters x9)
    : this(x9.Curve, x9.G, x9.N, x9.H, x9.GetSeed())
  {
  }

  public ECDomainParameters(ECCurve curve, ECPoint g, BigInteger n)
    : this(curve, g, n, BigInteger.One, (byte[]) null)
  {
  }

  public ECDomainParameters(ECCurve curve, ECPoint g, BigInteger n, BigInteger h)
    : this(curve, g, n, h, (byte[]) null)
  {
  }

  public ECDomainParameters(ECCurve curve, ECPoint g, BigInteger n, BigInteger h, byte[] seed)
  {
    if (curve == null)
      throw new ArgumentNullException(nameof (curve));
    if (g == null)
      throw new ArgumentNullException(nameof (g));
    if (n == null)
      throw new ArgumentNullException(nameof (n));
    this.curve = curve;
    this.g = ECDomainParameters.ValidatePublicPoint(curve, g);
    this.n = n;
    this.h = h;
    this.seed = Arrays.Clone(seed);
  }

  public ECCurve Curve => this.curve;

  public ECPoint G => this.g;

  public BigInteger N => this.n;

  public BigInteger H => this.h;

  public BigInteger HInv
  {
    get
    {
      lock (this)
      {
        if (this.hInv == null)
          this.hInv = BigIntegers.ModOddInverseVar(this.n, this.h);
        return this.hInv;
      }
    }
  }

  public byte[] GetSeed() => Arrays.Clone(this.seed);

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is ECDomainParameters other && this.Equals(other);
  }

  protected virtual bool Equals(ECDomainParameters other)
  {
    return this.curve.Equals(other.curve) && this.g.Equals(other.g) && this.n.Equals(other.n);
  }

  public override int GetHashCode()
  {
    return ((1028 ^ this.curve.GetHashCode()) * 257 ^ this.g.GetHashCode()) * 257 ^ this.n.GetHashCode();
  }

  public BigInteger ValidatePrivateScalar(BigInteger d)
  {
    if (d == null)
      throw new ArgumentNullException(nameof (d), "Scalar cannot be null");
    if (d.CompareTo(BigInteger.One) < 0 || d.CompareTo(this.N) >= 0)
      throw new ArgumentException("Scalar is not in the interval [1, n - 1]", nameof (d));
    return d;
  }

  public ECPoint ValidatePublicPoint(ECPoint q)
  {
    return ECDomainParameters.ValidatePublicPoint(this.Curve, q);
  }

  internal static ECPoint ValidatePublicPoint(ECCurve c, ECPoint q)
  {
    q = q != null ? ECAlgorithms.ImportPoint(c, q).Normalize() : throw new ArgumentNullException(nameof (q), "Point cannot be null");
    if (q.IsInfinity)
      throw new ArgumentException("Point at infinity", nameof (q));
    return q.IsValid() ? q : throw new ArgumentException("Point not on curve", nameof (q));
  }
}
