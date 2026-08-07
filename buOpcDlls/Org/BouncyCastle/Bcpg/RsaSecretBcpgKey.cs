// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.RsaSecretBcpgKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class RsaSecretBcpgKey : BcpgObject, IBcpgKey
{
  private readonly MPInteger d;
  private readonly MPInteger p;
  private readonly MPInteger q;
  private readonly MPInteger u;
  private readonly BigInteger expP;
  private readonly BigInteger expQ;
  private readonly BigInteger crt;

  public RsaSecretBcpgKey(BcpgInputStream bcpgIn)
  {
    this.d = new MPInteger(bcpgIn);
    this.p = new MPInteger(bcpgIn);
    this.q = new MPInteger(bcpgIn);
    this.u = new MPInteger(bcpgIn);
    this.expP = this.d.Value.Remainder(this.p.Value.Subtract(BigInteger.One));
    this.expQ = this.d.Value.Remainder(this.q.Value.Subtract(BigInteger.One));
    this.crt = BigIntegers.ModOddInverse(this.p.Value, this.q.Value);
  }

  public RsaSecretBcpgKey(BigInteger d, BigInteger p, BigInteger q)
  {
    int num = p.CompareTo(q);
    if (num >= 0)
    {
      if (num == 0)
        throw new ArgumentException("p and q cannot be equal");
      BigInteger bigInteger = p;
      p = q;
      q = bigInteger;
    }
    this.d = new MPInteger(d);
    this.p = new MPInteger(p);
    this.q = new MPInteger(q);
    this.u = new MPInteger(BigIntegers.ModOddInverse(q, p));
    this.expP = d.Remainder(p.Subtract(BigInteger.One));
    this.expQ = d.Remainder(q.Subtract(BigInteger.One));
    this.crt = BigIntegers.ModOddInverse(p, q);
  }

  public BigInteger Modulus => this.p.Value.Multiply(this.q.Value);

  public BigInteger PrivateExponent => this.d.Value;

  public BigInteger PrimeP => this.p.Value;

  public BigInteger PrimeQ => this.q.Value;

  public BigInteger PrimeExponentP => this.expP;

  public BigInteger PrimeExponentQ => this.expQ;

  public BigInteger CrtCoefficient => this.crt;

  public string Format => "PGP";

  public override byte[] GetEncoded()
  {
    try
    {
      return base.GetEncoded();
    }
    catch (Exception ex)
    {
      return (byte[]) null;
    }
  }

  public override void Encode(BcpgOutputStream bcpgOut)
  {
    bcpgOut.WriteObjects((BcpgObject) this.d, (BcpgObject) this.p, (BcpgObject) this.q, (BcpgObject) this.u);
  }
}
