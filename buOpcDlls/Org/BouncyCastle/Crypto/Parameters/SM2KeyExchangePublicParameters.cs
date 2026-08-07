// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.SM2KeyExchangePublicParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class SM2KeyExchangePublicParameters : ICipherParameters
{
  private readonly ECPublicKeyParameters mStaticPublicKey;
  private readonly ECPublicKeyParameters mEphemeralPublicKey;

  public SM2KeyExchangePublicParameters(
    ECPublicKeyParameters staticPublicKey,
    ECPublicKeyParameters ephemeralPublicKey)
  {
    if (staticPublicKey == null)
      throw new ArgumentNullException(nameof (staticPublicKey));
    if (ephemeralPublicKey == null)
      throw new ArgumentNullException(nameof (ephemeralPublicKey));
    if (!staticPublicKey.Parameters.Equals((object) ephemeralPublicKey.Parameters))
      throw new ArgumentException("Static and ephemeral public keys have different domain parameters");
    this.mStaticPublicKey = staticPublicKey;
    this.mEphemeralPublicKey = ephemeralPublicKey;
  }

  public virtual ECPublicKeyParameters StaticPublicKey => this.mStaticPublicKey;

  public virtual ECPublicKeyParameters EphemeralPublicKey => this.mEphemeralPublicKey;
}
