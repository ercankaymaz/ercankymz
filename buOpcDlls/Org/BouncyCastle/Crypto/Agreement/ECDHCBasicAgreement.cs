// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Agreement.ECDHCBasicAgreement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Agreement;

public class ECDHCBasicAgreement : IBasicAgreement
{
  private ECPrivateKeyParameters privKey;

  public virtual void Init(ICipherParameters parameters)
  {
    if (parameters is ParametersWithRandom parametersWithRandom)
      parameters = parametersWithRandom.Parameters;
    this.privKey = parameters is ECPrivateKeyParameters privateKeyParameters ? privateKeyParameters : throw new ArgumentException("ECDHCBasicAgreement expects ECPrivateKeyParameters");
  }

  public virtual int GetFieldSize() => (this.privKey.Parameters.Curve.FieldSize + 7) / 8;

  public virtual BigInteger CalculateAgreement(ICipherParameters pubKey)
  {
    ECPublicKeyParameters publicKeyParameters = (ECPublicKeyParameters) pubKey;
    ECDomainParameters parameters = this.privKey.Parameters;
    if (!parameters.Equals((object) publicKeyParameters.Parameters))
      throw new InvalidOperationException("ECDHC public key has wrong domain parameters");
    BigInteger b = parameters.H.Multiply(this.privKey.D).Mod(parameters.N);
    ECPoint ecPoint1 = ECAlgorithms.CleanPoint(parameters.Curve, publicKeyParameters.Q);
    ECPoint ecPoint2 = !ecPoint1.IsInfinity ? ecPoint1.Multiply(b).Normalize() : throw new InvalidOperationException("Infinity is not a valid public key for ECDHC");
    return !ecPoint2.IsInfinity ? ecPoint2.AffineXCoord.ToBigInteger() : throw new InvalidOperationException("Infinity is not a valid agreement value for ECDHC");
  }
}
