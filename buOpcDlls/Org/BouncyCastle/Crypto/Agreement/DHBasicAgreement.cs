// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Agreement.DHBasicAgreement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Agreement;

public class DHBasicAgreement : IBasicAgreement
{
  private DHPrivateKeyParameters key;
  private DHParameters dhParams;

  public virtual void Init(ICipherParameters parameters)
  {
    if (parameters is ParametersWithRandom parametersWithRandom)
      parameters = parametersWithRandom.Parameters;
    this.key = parameters is DHPrivateKeyParameters privateKeyParameters ? privateKeyParameters : throw new ArgumentException("DHBasicAgreement expects DHPrivateKeyParameters");
    this.dhParams = this.key.Parameters;
  }

  public virtual int GetFieldSize() => (this.key.Parameters.P.BitLength + 7) / 8;

  public virtual BigInteger CalculateAgreement(ICipherParameters pubKey)
  {
    if (this.key == null)
      throw new InvalidOperationException("Agreement algorithm not initialised");
    DHPublicKeyParameters publicKeyParameters = (DHPublicKeyParameters) pubKey;
    if (!publicKeyParameters.Parameters.Equals((object) this.dhParams))
      throw new ArgumentException("Diffie-Hellman public key has wrong parameters.");
    BigInteger p = this.dhParams.P;
    BigInteger y = publicKeyParameters.Y;
    if (y == null || y.CompareTo(BigInteger.One) <= 0 || y.CompareTo(p.Subtract(BigInteger.One)) >= 0)
      throw new ArgumentException("Diffie-Hellman public key is weak");
    BigInteger bigInteger = y.ModPow(this.key.X, p);
    return !bigInteger.Equals(BigInteger.One) ? bigInteger : throw new InvalidOperationException("Shared key can't be 1");
  }
}
