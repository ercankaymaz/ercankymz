// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.ElGamalPrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class ElGamalPrivateKeyParameters : ElGamalKeyParameters
{
  private readonly BigInteger x;

  public ElGamalPrivateKeyParameters(BigInteger x, ElGamalParameters parameters)
    : base(true, parameters)
  {
    this.x = x != null ? x : throw new ArgumentNullException(nameof (x));
  }

  public BigInteger X => this.x;

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is ElGamalPrivateKeyParameters other && this.Equals(other);
  }

  protected bool Equals(ElGamalPrivateKeyParameters other)
  {
    return other.x.Equals(this.x) && this.Equals((ElGamalKeyParameters) other);
  }

  public override int GetHashCode() => this.x.GetHashCode() ^ base.GetHashCode();
}
