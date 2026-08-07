// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.SM2KeyExchangePrivateParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Math.EC.Multiplier;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class SM2KeyExchangePrivateParameters : ICipherParameters
{
  private readonly bool mInitiator;
  private readonly ECPrivateKeyParameters mStaticPrivateKey;
  private readonly ECPoint mStaticPublicPoint;
  private readonly ECPrivateKeyParameters mEphemeralPrivateKey;
  private readonly ECPoint mEphemeralPublicPoint;

  public SM2KeyExchangePrivateParameters(
    bool initiator,
    ECPrivateKeyParameters staticPrivateKey,
    ECPrivateKeyParameters ephemeralPrivateKey)
  {
    if (staticPrivateKey == null)
      throw new ArgumentNullException(nameof (staticPrivateKey));
    if (ephemeralPrivateKey == null)
      throw new ArgumentNullException(nameof (ephemeralPrivateKey));
    ECDomainParameters parameters = staticPrivateKey.Parameters;
    if (!parameters.Equals((object) ephemeralPrivateKey.Parameters))
      throw new ArgumentException("Static and ephemeral private keys have different domain parameters");
    ECMultiplier ecMultiplier = (ECMultiplier) new FixedPointCombMultiplier();
    this.mInitiator = initiator;
    this.mStaticPrivateKey = staticPrivateKey;
    this.mStaticPublicPoint = ecMultiplier.Multiply(parameters.G, staticPrivateKey.D).Normalize();
    this.mEphemeralPrivateKey = ephemeralPrivateKey;
    this.mEphemeralPublicPoint = ecMultiplier.Multiply(parameters.G, ephemeralPrivateKey.D).Normalize();
  }

  public virtual bool IsInitiator => this.mInitiator;

  public virtual ECPrivateKeyParameters StaticPrivateKey => this.mStaticPrivateKey;

  public virtual ECPoint StaticPublicPoint => this.mStaticPublicPoint;

  public virtual ECPrivateKeyParameters EphemeralPrivateKey => this.mEphemeralPrivateKey;

  public virtual ECPoint EphemeralPublicPoint => this.mEphemeralPublicPoint;
}
