// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.DHParameter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class DHParameter : Asn1Encodable
{
  internal DerInteger p;
  internal DerInteger g;
  internal DerInteger l;

  public DHParameter(BigInteger p, BigInteger g, int l)
  {
    this.p = new DerInteger(p);
    this.g = new DerInteger(g);
    if (l == 0)
      return;
    this.l = new DerInteger(l);
  }

  public DHParameter(Asn1Sequence seq)
  {
    IEnumerator<Asn1Encodable> enumerator = seq.GetEnumerator();
    enumerator.MoveNext();
    this.p = (DerInteger) enumerator.Current;
    enumerator.MoveNext();
    this.g = (DerInteger) enumerator.Current;
    if (!enumerator.MoveNext())
      return;
    this.l = (DerInteger) enumerator.Current;
  }

  public BigInteger P => this.p.PositiveValue;

  public BigInteger G => this.g.PositiveValue;

  public BigInteger L => this.l != null ? this.l.PositiveValue : (BigInteger) null;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.p, (Asn1Encodable) this.g);
    elementVector.AddOptional((Asn1Encodable) this.l);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
