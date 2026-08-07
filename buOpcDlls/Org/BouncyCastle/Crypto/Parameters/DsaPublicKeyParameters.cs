// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.DsaPublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class DsaPublicKeyParameters : DsaKeyParameters
{
  private readonly BigInteger y;

  private static BigInteger Validate(BigInteger y, DsaParameters parameters)
  {
    if (parameters != null && (y.CompareTo(BigInteger.Two) < 0 || y.CompareTo(parameters.P.Subtract(BigInteger.Two)) > 0 || !y.ModPow(parameters.Q, parameters.P).Equals(BigInteger.One)))
      throw new ArgumentException("y value does not appear to be in correct group");
    return y;
  }

  public DsaPublicKeyParameters(BigInteger y, DsaParameters parameters)
    : base(false, parameters)
  {
    this.y = y != null ? DsaPublicKeyParameters.Validate(y, parameters) : throw new ArgumentNullException(nameof (y));
  }

  public BigInteger Y => this.y;

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is DsaPublicKeyParameters other && this.Equals(other);
  }

  protected bool Equals(DsaPublicKeyParameters other)
  {
    return this.y.Equals(other.y) && this.Equals((DsaKeyParameters) other);
  }

  public override int GetHashCode() => this.y.GetHashCode() ^ base.GetHashCode();
}
