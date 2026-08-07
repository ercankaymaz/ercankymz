// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class RsaKeyParameters : AsymmetricKeyParameter
{
  private static readonly BigInteger SmallPrimesProduct = new BigInteger("8138e8a0fcf3a4e84a771d40fd305d7f4aa59306d7251de54d98af8fe95729a1f73d893fa424cd2edc8636a6c3285e022b0e3866a565ae8108eed8591cd4fe8d2ce86165a978d719ebf647f362d33fca29cd179fb42401cbaf3df0c614056f9c8f3cfd51e474afb6bc6974f78db8aba8e9e517fded658591ab7502bd41849462f", 16 /*0x10*/);
  private readonly BigInteger modulus;
  private readonly BigInteger exponent;

  private static BigInteger Validate(BigInteger modulus)
  {
    if ((modulus.IntValue & 1) == 0)
      throw new ArgumentException("RSA modulus is even", nameof (modulus));
    if (!modulus.Gcd(RsaKeyParameters.SmallPrimesProduct).Equals(BigInteger.One))
      throw new ArgumentException("RSA modulus has a small prime factor");
    return RsaKeyParameters.AsInteger("Org.BouncyCastle.Rsa.MaxSize", 15360) >= modulus.BitLength ? modulus : throw new ArgumentException("modulus value out of range");
  }

  public RsaKeyParameters(bool isPrivate, BigInteger modulus, BigInteger exponent)
    : base(isPrivate)
  {
    if (modulus == null)
      throw new ArgumentNullException(nameof (modulus));
    if (exponent == null)
      throw new ArgumentNullException(nameof (exponent));
    if (modulus.SignValue <= 0)
      throw new ArgumentException("Not a valid RSA modulus", nameof (modulus));
    if (exponent.SignValue <= 0)
      throw new ArgumentException("Not a valid RSA exponent", nameof (exponent));
    if (!isPrivate && (exponent.IntValue & 1) == 0)
      throw new ArgumentException("RSA publicExponent is even", nameof (exponent));
    this.modulus = RsaKeyParameters.Validate(modulus);
    this.exponent = exponent;
  }

  public BigInteger Modulus => this.modulus;

  public BigInteger Exponent => this.exponent;

  public override bool Equals(object obj)
  {
    return obj is RsaKeyParameters rsaKeyParameters && rsaKeyParameters.IsPrivate == this.IsPrivate && rsaKeyParameters.Modulus.Equals(this.modulus) && rsaKeyParameters.Exponent.Equals(this.exponent);
  }

  public override int GetHashCode()
  {
    return this.modulus.GetHashCode() ^ this.exponent.GetHashCode() ^ this.IsPrivate.GetHashCode();
  }

  internal static int AsInteger(string envVariable, int defaultValue)
  {
    string environmentVariable = Platform.GetEnvironmentVariable(envVariable);
    return environmentVariable == null ? defaultValue : int.Parse(environmentVariable);
  }
}
