// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.RsaBlindingParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class RsaBlindingParameters : ICipherParameters
{
  private readonly RsaKeyParameters publicKey;
  private readonly BigInteger blindingFactor;

  public RsaBlindingParameters(RsaKeyParameters publicKey, BigInteger blindingFactor)
  {
    this.publicKey = !publicKey.IsPrivate ? publicKey : throw new ArgumentException("RSA parameters should be for a public key");
    this.blindingFactor = blindingFactor;
  }

  public RsaKeyParameters PublicKey => this.publicKey;

  public BigInteger BlindingFactor => this.blindingFactor;
}
