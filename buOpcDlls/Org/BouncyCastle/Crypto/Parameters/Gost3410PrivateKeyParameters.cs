// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.Gost3410PrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class Gost3410PrivateKeyParameters : Gost3410KeyParameters
{
  private readonly BigInteger x;

  public Gost3410PrivateKeyParameters(BigInteger x, Gost3410Parameters parameters)
    : base(true, parameters)
  {
    if (x.SignValue < 1 || x.BitLength > 256 /*0x0100*/ || x.CompareTo(this.Parameters.Q) >= 0)
      throw new ArgumentException("Invalid x for GOST3410 private key", nameof (x));
    this.x = x;
  }

  public Gost3410PrivateKeyParameters(BigInteger x, DerObjectIdentifier publicKeyParamSet)
    : base(true, publicKeyParamSet)
  {
    if (x.SignValue < 1 || x.BitLength > 256 /*0x0100*/ || x.CompareTo(this.Parameters.Q) >= 0)
      throw new ArgumentException("Invalid x for GOST3410 private key", nameof (x));
    this.x = x;
  }

  public BigInteger X => this.x;
}
