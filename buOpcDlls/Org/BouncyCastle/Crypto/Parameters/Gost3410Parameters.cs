// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.Gost3410Parameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class Gost3410Parameters : ICipherParameters
{
  private readonly BigInteger p;
  private readonly BigInteger q;
  private readonly BigInteger a;
  private readonly Gost3410ValidationParameters validation;

  public Gost3410Parameters(BigInteger p, BigInteger q, BigInteger a)
    : this(p, q, a, (Gost3410ValidationParameters) null)
  {
  }

  public Gost3410Parameters(
    BigInteger p,
    BigInteger q,
    BigInteger a,
    Gost3410ValidationParameters validation)
  {
    if (p == null)
      throw new ArgumentNullException(nameof (p));
    if (q == null)
      throw new ArgumentNullException(nameof (q));
    if (a == null)
      throw new ArgumentNullException(nameof (a));
    this.p = p;
    this.q = q;
    this.a = a;
    this.validation = validation;
  }

  public BigInteger P => this.p;

  public BigInteger Q => this.q;

  public BigInteger A => this.a;

  public Gost3410ValidationParameters ValidationParameters => this.validation;

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is Gost3410Parameters other && this.Equals(other);
  }

  protected bool Equals(Gost3410Parameters other)
  {
    return this.p.Equals(other.p) && this.q.Equals(other.q) && this.a.Equals(other.a);
  }

  public override int GetHashCode()
  {
    return this.p.GetHashCode() ^ this.q.GetHashCode() ^ this.a.GetHashCode();
  }
}
