// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Agreement.JPake.JPakePrimeOrderGroup
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Agreement.JPake;

public class JPakePrimeOrderGroup
{
  private readonly BigInteger p;
  private readonly BigInteger q;
  private readonly BigInteger g;

  public JPakePrimeOrderGroup(BigInteger p, BigInteger q, BigInteger g)
    : this(p, q, g, false)
  {
  }

  public JPakePrimeOrderGroup(BigInteger p, BigInteger q, BigInteger g, bool skipChecks)
  {
    JPakeUtilities.ValidateNotNull((object) p, nameof (p));
    JPakeUtilities.ValidateNotNull((object) q, nameof (q));
    JPakeUtilities.ValidateNotNull((object) g, nameof (g));
    if (!skipChecks)
    {
      if (!p.Subtract(JPakeUtilities.One).Mod(q).Equals(JPakeUtilities.Zero))
        throw new ArgumentException("p-1 must be evenly divisible by q");
      if (g.CompareTo(BigInteger.Two) == -1 || g.CompareTo(p.Subtract(JPakeUtilities.One)) == 1)
        throw new ArgumentException("g must be in [2, p-1]");
      if (!g.ModPow(q, p).Equals(JPakeUtilities.One))
        throw new ArgumentException("g^q mod p must equal 1");
      if (!p.IsProbablePrime(20))
        throw new ArgumentException("p must be prime");
      if (!q.IsProbablePrime(20))
        throw new ArgumentException("q must be prime");
    }
    this.p = p;
    this.q = q;
    this.g = g;
  }

  public virtual BigInteger P => this.p;

  public virtual BigInteger Q => this.q;

  public virtual BigInteger G => this.g;
}
