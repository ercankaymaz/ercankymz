// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.CompleteCertificateRefs
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class CompleteCertificateRefs : Asn1Encodable
{
  private readonly Asn1Sequence m_otherCertIDs;

  public static CompleteCertificateRefs GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (CompleteCertificateRefs) null;
      case CompleteCertificateRefs instance:
        return instance;
      case Asn1Sequence seq:
        return new CompleteCertificateRefs(seq);
      default:
        throw new ArgumentException("Unknown object in 'CompleteCertificateRefs' factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private CompleteCertificateRefs(Asn1Sequence seq)
  {
    if (seq == null)
      throw new ArgumentNullException(nameof (seq));
    seq.MapElements<OtherCertID>((Func<Asn1Encodable, OtherCertID>) (element => OtherCertID.GetInstance((object) element.ToAsn1Object())));
    this.m_otherCertIDs = seq;
  }

  public CompleteCertificateRefs(params OtherCertID[] otherCertIDs)
  {
    this.m_otherCertIDs = otherCertIDs != null ? (Asn1Sequence) new DerSequence((Asn1Encodable[]) otherCertIDs) : throw new ArgumentNullException(nameof (otherCertIDs));
  }

  public CompleteCertificateRefs(IEnumerable<OtherCertID> otherCertIDs)
  {
    this.m_otherCertIDs = otherCertIDs != null ? (Asn1Sequence) new DerSequence(Asn1EncodableVector.FromEnumerable((IEnumerable<Asn1Encodable>) otherCertIDs)) : throw new ArgumentNullException(nameof (otherCertIDs));
  }

  public OtherCertID[] GetOtherCertIDs()
  {
    return this.m_otherCertIDs.MapElements<OtherCertID>((Func<Asn1Encodable, OtherCertID>) (element => OtherCertID.GetInstance((object) element.ToAsn1Object())));
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.m_otherCertIDs;
}
