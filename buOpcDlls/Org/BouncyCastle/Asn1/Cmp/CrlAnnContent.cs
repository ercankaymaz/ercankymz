// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.CrlAnnContent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class CrlAnnContent : Asn1Encodable
{
  private readonly Asn1Sequence m_content;

  public static CrlAnnContent GetInstance(object obj)
  {
    if (obj == null)
      return (CrlAnnContent) null;
    return obj is CrlAnnContent crlAnnContent ? crlAnnContent : new CrlAnnContent(Asn1Sequence.GetInstance(obj));
  }

  public static CrlAnnContent GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return CrlAnnContent.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private CrlAnnContent(Asn1Sequence seq) => this.m_content = seq;

  public CrlAnnContent(CertificateList crl)
  {
    this.m_content = (Asn1Sequence) new DerSequence((Asn1Encodable) crl);
  }

  public virtual CertificateList[] ToCertificateListArray()
  {
    return this.m_content.MapElements<CertificateList>(new Func<Asn1Encodable, CertificateList>(CertificateList.GetInstance));
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.m_content;
}
