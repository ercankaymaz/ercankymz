// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X9.DHDomainParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.X9;

public class DHDomainParameters : Asn1Encodable
{
  private readonly DerInteger p;
  private readonly DerInteger g;
  private readonly DerInteger q;
  private readonly DerInteger j;
  private readonly DHValidationParms validationParms;

  public static DHDomainParameters GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return DHDomainParameters.GetInstance((object) Asn1Sequence.GetInstance(obj, isExplicit));
  }

  public static DHDomainParameters GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case DHDomainParameters _:
        return (DHDomainParameters) obj;
      case Asn1Sequence _:
        return new DHDomainParameters((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid DHDomainParameters: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public DHDomainParameters(
    DerInteger p,
    DerInteger g,
    DerInteger q,
    DerInteger j,
    DHValidationParms validationParms)
  {
    if (p == null)
      throw new ArgumentNullException(nameof (p));
    if (g == null)
      throw new ArgumentNullException(nameof (g));
    if (q == null)
      throw new ArgumentNullException(nameof (q));
    this.p = p;
    this.g = g;
    this.q = q;
    this.j = j;
    this.validationParms = validationParms;
  }

  private DHDomainParameters(Asn1Sequence seq)
  {
    IEnumerator<Asn1Encodable> e = seq.Count >= 3 && seq.Count <= 5 ? seq.GetEnumerator() : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    this.p = DerInteger.GetInstance((object) DHDomainParameters.GetNext(e));
    this.g = DerInteger.GetInstance((object) DHDomainParameters.GetNext(e));
    this.q = DerInteger.GetInstance((object) DHDomainParameters.GetNext(e));
    Asn1Encodable next = DHDomainParameters.GetNext(e);
    if (next != null && next is DerInteger)
    {
      this.j = DerInteger.GetInstance((object) next);
      next = DHDomainParameters.GetNext(e);
    }
    if (next == null)
      return;
    this.validationParms = DHValidationParms.GetInstance((object) next.ToAsn1Object());
  }

  private static Asn1Encodable GetNext(IEnumerator<Asn1Encodable> e)
  {
    return !e.MoveNext() ? (Asn1Encodable) null : e.Current;
  }

  public DerInteger P => this.p;

  public DerInteger G => this.g;

  public DerInteger Q => this.q;

  public DerInteger J => this.j;

  public DHValidationParms ValidationParms => this.validationParms;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(new Asn1Encodable[3]
    {
      (Asn1Encodable) this.p,
      (Asn1Encodable) this.g,
      (Asn1Encodable) this.q
    });
    elementVector.AddOptional((Asn1Encodable) this.j, (Asn1Encodable) this.validationParms);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
