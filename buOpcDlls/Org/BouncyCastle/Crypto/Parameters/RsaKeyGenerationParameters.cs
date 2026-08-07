// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.RsaKeyGenerationParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class RsaKeyGenerationParameters : KeyGenerationParameters
{
  private readonly BigInteger publicExponent;
  private readonly int certainty;

  public RsaKeyGenerationParameters(
    BigInteger publicExponent,
    SecureRandom random,
    int strength,
    int certainty)
    : base(random, strength)
  {
    this.publicExponent = publicExponent;
    this.certainty = certainty;
  }

  public BigInteger PublicExponent => this.publicExponent;

  public int Certainty => this.certainty;

  public override bool Equals(object obj)
  {
    return obj is RsaKeyGenerationParameters generationParameters && this.certainty == generationParameters.certainty && this.publicExponent.Equals(generationParameters.publicExponent);
  }

  public override int GetHashCode()
  {
    return this.certainty.GetHashCode() ^ this.publicExponent.GetHashCode();
  }
}
