// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Agreement.ECMqvBasicAgreement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Agreement;

public class ECMqvBasicAgreement : IBasicAgreement
{
  protected internal MqvPrivateParameters privParams;

  public virtual void Init(ICipherParameters parameters)
  {
    if (parameters is ParametersWithRandom parametersWithRandom)
      parameters = parametersWithRandom.Parameters;
    this.privParams = (MqvPrivateParameters) parameters;
  }

  public virtual int GetFieldSize()
  {
    return (this.privParams.StaticPrivateKey.Parameters.Curve.FieldSize + 7) / 8;
  }

  public virtual BigInteger CalculateAgreement(ICipherParameters pubKey)
  {
    MqvPublicParameters publicParameters = (MqvPublicParameters) pubKey;
    ECPrivateKeyParameters staticPrivateKey = this.privParams.StaticPrivateKey;
    ECDomainParameters parameters = staticPrivateKey.Parameters;
    if (!parameters.Equals((object) publicParameters.StaticPublicKey.Parameters))
      throw new InvalidOperationException("ECMQV public key components have wrong domain parameters");
    ECPoint ecPoint = ECMqvBasicAgreement.CalculateMqvAgreement(parameters, staticPrivateKey, this.privParams.EphemeralPrivateKey, this.privParams.EphemeralPublicKey, publicParameters.StaticPublicKey, publicParameters.EphemeralPublicKey).Normalize();
    return !ecPoint.IsInfinity ? ecPoint.AffineXCoord.ToBigInteger() : throw new InvalidOperationException("Infinity is not a valid agreement value for MQV");
  }

  private static ECPoint CalculateMqvAgreement(
    ECDomainParameters parameters,
    ECPrivateKeyParameters d1U,
    ECPrivateKeyParameters d2U,
    ECPublicKeyParameters Q2U,
    ECPublicKeyParameters Q1V,
    ECPublicKeyParameters Q2V)
  {
    BigInteger n1 = parameters.N;
    int n2 = (n1.BitLength + 1) / 2;
    BigInteger m = BigInteger.One.ShiftLeft(n2);
    ECCurve curve = parameters.Curve;
    ECPoint ecPoint = ECAlgorithms.CleanPoint(curve, Q2U.Q);
    ECPoint P = ECAlgorithms.CleanPoint(curve, Q1V.Q);
    ECPoint Q = ECAlgorithms.CleanPoint(curve, Q2V.Q);
    BigInteger val1 = ecPoint.AffineXCoord.ToBigInteger().Mod(m).SetBit(n2);
    BigInteger val2 = d1U.D.Multiply(val1).Add(d2U.D).Mod(n1);
    BigInteger bigInteger1 = Q.AffineXCoord.ToBigInteger().Mod(m).SetBit(n2);
    BigInteger bigInteger2 = parameters.H.Multiply(val2).Mod(n1);
    return ECAlgorithms.SumOfTwoMultiplies(P, bigInteger1.Multiply(bigInteger2).Mod(n1), Q, bigInteger2);
  }
}
