// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.OcspListID
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class OcspListID : Asn1Encodable
{
  private readonly Asn1Sequence m_ocspResponses;

  public static OcspListID GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (OcspListID) null;
      case OcspListID instance:
        return instance;
      case Asn1Sequence seq:
        return new OcspListID(seq);
      default:
        throw new ArgumentException("Unknown object in 'OcspListID' factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private OcspListID(Asn1Sequence seq)
  {
    if (seq == null)
      throw new ArgumentNullException(nameof (seq));
    this.m_ocspResponses = seq.Count == 1 ? (Asn1Sequence) seq[0].ToAsn1Object() : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    this.m_ocspResponses.MapElements<OcspResponsesID>((Func<Asn1Encodable, OcspResponsesID>) (element => OcspResponsesID.GetInstance((object) element.ToAsn1Object())));
  }

  public OcspListID(params OcspResponsesID[] ocspResponses)
  {
    this.m_ocspResponses = ocspResponses != null ? (Asn1Sequence) new DerSequence((Asn1Encodable[]) ocspResponses) : throw new ArgumentNullException(nameof (ocspResponses));
  }

  public OcspListID(IEnumerable<OcspResponsesID> ocspResponses)
  {
    this.m_ocspResponses = ocspResponses != null ? (Asn1Sequence) new DerSequence(Asn1EncodableVector.FromEnumerable((IEnumerable<Asn1Encodable>) ocspResponses)) : throw new ArgumentNullException(nameof (ocspResponses));
  }

  public OcspResponsesID[] GetOcspResponses()
  {
    return this.m_ocspResponses.MapElements<OcspResponsesID>((Func<Asn1Encodable, OcspResponsesID>) (element => OcspResponsesID.GetInstance((object) element.ToAsn1Object())));
  }

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.m_ocspResponses);
  }
}
