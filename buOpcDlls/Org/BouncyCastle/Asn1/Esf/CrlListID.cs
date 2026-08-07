// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.CrlListID
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class CrlListID : Asn1Encodable
{
  private readonly Asn1Sequence m_crls;

  public static CrlListID GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (CrlListID) null;
      case CrlListID instance:
        return instance;
      case Asn1Sequence seq:
        return new CrlListID(seq);
      default:
        throw new ArgumentException("Unknown object in 'CrlListID' factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private CrlListID(Asn1Sequence seq)
  {
    if (seq == null)
      throw new ArgumentNullException(nameof (seq));
    this.m_crls = seq.Count == 1 ? (Asn1Sequence) seq[0].ToAsn1Object() : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    this.m_crls.MapElements<CrlValidatedID>((Func<Asn1Encodable, CrlValidatedID>) (element => CrlValidatedID.GetInstance((object) element.ToAsn1Object())));
  }

  public CrlListID(params CrlValidatedID[] crls)
  {
    this.m_crls = crls != null ? (Asn1Sequence) new DerSequence((Asn1Encodable[]) crls) : throw new ArgumentNullException(nameof (crls));
  }

  public CrlListID(IEnumerable<CrlValidatedID> crls)
  {
    this.m_crls = crls != null ? (Asn1Sequence) new DerSequence(Asn1EncodableVector.FromEnumerable((IEnumerable<Asn1Encodable>) crls)) : throw new ArgumentNullException(nameof (crls));
  }

  public CrlValidatedID[] GetCrls()
  {
    return this.m_crls.MapElements<CrlValidatedID>((Func<Asn1Encodable, CrlValidatedID>) (element => CrlValidatedID.GetInstance((object) element.ToAsn1Object())));
  }

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.m_crls);
  }
}
