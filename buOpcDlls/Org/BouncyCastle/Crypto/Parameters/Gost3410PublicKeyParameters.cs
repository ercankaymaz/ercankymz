// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.Gost3410PublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class Gost3410PublicKeyParameters : Gost3410KeyParameters
{
  private readonly BigInteger y;

  public Gost3410PublicKeyParameters(BigInteger y, Gost3410Parameters parameters)
    : base(false, parameters)
  {
    if (y.SignValue < 1 || y.CompareTo(this.Parameters.P) >= 0)
      throw new ArgumentException("Invalid y for GOST3410 public key", nameof (y));
    this.y = y;
  }

  public Gost3410PublicKeyParameters(BigInteger y, DerObjectIdentifier publicKeyParamSet)
    : base(false, publicKeyParamSet)
  {
    if (y.SignValue < 1 || y.CompareTo(this.Parameters.P) >= 0)
      throw new ArgumentException("Invalid y for GOST3410 public key", nameof (y));
    this.y = y;
  }

  public BigInteger Y => this.y;
}
