// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.ElGamalPublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class ElGamalPublicKeyParameters : ElGamalKeyParameters
{
  private readonly BigInteger y;

  public ElGamalPublicKeyParameters(BigInteger y, ElGamalParameters parameters)
    : base(false, parameters)
  {
    this.y = y != null ? y : throw new ArgumentNullException(nameof (y));
  }

  public BigInteger Y => this.y;

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is ElGamalPublicKeyParameters other && this.Equals(other);
  }

  protected bool Equals(ElGamalPublicKeyParameters other)
  {
    return this.y.Equals(other.y) && this.Equals((ElGamalKeyParameters) other);
  }

  public override int GetHashCode() => this.y.GetHashCode() ^ base.GetHashCode();
}
