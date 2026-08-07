// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.MqvPublicParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class MqvPublicParameters : ICipherParameters
{
  private readonly ECPublicKeyParameters staticPublicKey;
  private readonly ECPublicKeyParameters ephemeralPublicKey;

  public MqvPublicParameters(
    ECPublicKeyParameters staticPublicKey,
    ECPublicKeyParameters ephemeralPublicKey)
  {
    if (staticPublicKey == null)
      throw new ArgumentNullException(nameof (staticPublicKey));
    if (ephemeralPublicKey == null)
      throw new ArgumentNullException(nameof (ephemeralPublicKey));
    if (!staticPublicKey.Parameters.Equals((object) ephemeralPublicKey.Parameters))
      throw new ArgumentException("Static and ephemeral public keys have different domain parameters");
    this.staticPublicKey = staticPublicKey;
    this.ephemeralPublicKey = ephemeralPublicKey;
  }

  public virtual ECPublicKeyParameters StaticPublicKey => this.staticPublicKey;

  public virtual ECPublicKeyParameters EphemeralPublicKey => this.ephemeralPublicKey;
}
