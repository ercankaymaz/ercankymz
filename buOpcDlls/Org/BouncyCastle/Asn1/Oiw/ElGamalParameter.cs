// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Oiw.ElGamalParameter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Oiw;

public class ElGamalParameter : Asn1Encodable
{
  internal DerInteger p;
  internal DerInteger g;

  public ElGamalParameter(BigInteger p, BigInteger g)
  {
    this.p = new DerInteger(p);
    this.g = new DerInteger(g);
  }

  public ElGamalParameter(Asn1Sequence seq)
  {
    this.p = seq.Count == 2 ? DerInteger.GetInstance((object) seq[0]) : throw new ArgumentException("Wrong number of elements in sequence", nameof (seq));
    this.g = DerInteger.GetInstance((object) seq[1]);
  }

  public BigInteger P => this.p.PositiveValue;

  public BigInteger G => this.g.PositiveValue;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.p, (Asn1Encodable) this.g);
  }
}
