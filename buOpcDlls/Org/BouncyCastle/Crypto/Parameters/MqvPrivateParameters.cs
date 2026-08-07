// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.MqvPrivateParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC.Multiplier;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class MqvPrivateParameters : ICipherParameters
{
  private readonly ECPrivateKeyParameters staticPrivateKey;
  private readonly ECPrivateKeyParameters ephemeralPrivateKey;
  private readonly ECPublicKeyParameters ephemeralPublicKey;

  public MqvPrivateParameters(
    ECPrivateKeyParameters staticPrivateKey,
    ECPrivateKeyParameters ephemeralPrivateKey)
    : this(staticPrivateKey, ephemeralPrivateKey, (ECPublicKeyParameters) null)
  {
  }

  public MqvPrivateParameters(
    ECPrivateKeyParameters staticPrivateKey,
    ECPrivateKeyParameters ephemeralPrivateKey,
    ECPublicKeyParameters ephemeralPublicKey)
  {
    if (staticPrivateKey == null)
      throw new ArgumentNullException(nameof (staticPrivateKey));
    if (ephemeralPrivateKey == null)
      throw new ArgumentNullException(nameof (ephemeralPrivateKey));
    ECDomainParameters parameters = staticPrivateKey.Parameters;
    if (!parameters.Equals((object) ephemeralPrivateKey.Parameters))
      throw new ArgumentException("Static and ephemeral private keys have different domain parameters");
    if (ephemeralPublicKey == null)
      ephemeralPublicKey = new ECPublicKeyParameters(new FixedPointCombMultiplier().Multiply(parameters.G, ephemeralPrivateKey.D), parameters);
    else if (!parameters.Equals((object) ephemeralPublicKey.Parameters))
      throw new ArgumentException("Ephemeral public key has different domain parameters");
    this.staticPrivateKey = staticPrivateKey;
    this.ephemeralPrivateKey = ephemeralPrivateKey;
    this.ephemeralPublicKey = ephemeralPublicKey;
  }

  public virtual ECPrivateKeyParameters StaticPrivateKey => this.staticPrivateKey;

  public virtual ECPrivateKeyParameters EphemeralPrivateKey => this.ephemeralPrivateKey;

  public virtual ECPublicKeyParameters EphemeralPublicKey => this.ephemeralPublicKey;
}
