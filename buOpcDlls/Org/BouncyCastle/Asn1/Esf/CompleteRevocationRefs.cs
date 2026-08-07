// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.CompleteRevocationRefs
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class CompleteRevocationRefs : Asn1Encodable
{
  private readonly Asn1Sequence m_crlOcspRefs;

  public static CompleteRevocationRefs GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (CompleteRevocationRefs) null;
      case CompleteRevocationRefs instance:
        return instance;
      case Asn1Sequence seq:
        return new CompleteRevocationRefs(seq);
      default:
        throw new ArgumentException("Unknown object in 'CompleteRevocationRefs' factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private CompleteRevocationRefs(Asn1Sequence seq)
  {
    if (seq == null)
      throw new ArgumentNullException(nameof (seq));
    seq.MapElements<CrlOcspRef>((Func<Asn1Encodable, CrlOcspRef>) (element => CrlOcspRef.GetInstance((object) element.ToAsn1Object())));
    this.m_crlOcspRefs = seq;
  }

  public CompleteRevocationRefs(params CrlOcspRef[] crlOcspRefs)
  {
    this.m_crlOcspRefs = crlOcspRefs != null ? (Asn1Sequence) new DerSequence((Asn1Encodable[]) crlOcspRefs) : throw new ArgumentNullException(nameof (crlOcspRefs));
  }

  public CompleteRevocationRefs(IEnumerable<CrlOcspRef> crlOcspRefs)
  {
    this.m_crlOcspRefs = crlOcspRefs != null ? (Asn1Sequence) new DerSequence(Asn1EncodableVector.FromEnumerable((IEnumerable<Asn1Encodable>) crlOcspRefs)) : throw new ArgumentNullException(nameof (crlOcspRefs));
  }

  public CrlOcspRef[] GetCrlOcspRefs()
  {
    return this.m_crlOcspRefs.MapElements<CrlOcspRef>((Func<Asn1Encodable, CrlOcspRef>) (element => CrlOcspRef.GetInstance((object) element.ToAsn1Object())));
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.m_crlOcspRefs;
}
