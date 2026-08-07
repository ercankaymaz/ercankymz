// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.DsaParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class DsaParameters : ICipherParameters
{
  private readonly BigInteger p;
  private readonly BigInteger q;
  private readonly BigInteger g;
  private readonly DsaValidationParameters validation;

  public DsaParameters(BigInteger p, BigInteger q, BigInteger g)
    : this(p, q, g, (DsaValidationParameters) null)
  {
  }

  public DsaParameters(
    BigInteger p,
    BigInteger q,
    BigInteger g,
    DsaValidationParameters parameters)
  {
    if (p == null)
      throw new ArgumentNullException(nameof (p));
    if (q == null)
      throw new ArgumentNullException(nameof (q));
    if (g == null)
      throw new ArgumentNullException(nameof (g));
    this.p = p;
    this.q = q;
    this.g = g;
    this.validation = parameters;
  }

  public BigInteger P => this.p;

  public BigInteger Q => this.q;

  public BigInteger G => this.g;

  public DsaValidationParameters ValidationParameters => this.validation;

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is DsaParameters other && this.Equals(other);
  }

  protected bool Equals(DsaParameters other)
  {
    return this.p.Equals(other.p) && this.q.Equals(other.q) && this.g.Equals(other.g);
  }

  public override int GetHashCode()
  {
    return this.p.GetHashCode() ^ this.q.GetHashCode() ^ this.g.GetHashCode();
  }
}
