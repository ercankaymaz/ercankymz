// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.RootCaKeyUpdateContent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class RootCaKeyUpdateContent : Asn1Encodable
{
  private readonly CmpCertificate m_newWithNew;
  private readonly CmpCertificate m_newWithOld;
  private readonly CmpCertificate m_oldWithNew;

  public static RootCaKeyUpdateContent GetInstance(object obj)
  {
    if (obj == null)
      return (RootCaKeyUpdateContent) null;
    return obj is RootCaKeyUpdateContent keyUpdateContent ? keyUpdateContent : new RootCaKeyUpdateContent(Asn1Sequence.GetInstance(obj));
  }

  public static RootCaKeyUpdateContent GetInstance(
    Asn1TaggedObject taggedObject,
    bool declaredExplicit)
  {
    return RootCaKeyUpdateContent.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  public RootCaKeyUpdateContent(
    CmpCertificate newWithNew,
    CmpCertificate newWithOld,
    CmpCertificate oldWithNew)
  {
    this.m_newWithNew = newWithNew != null ? newWithNew : throw new ArgumentNullException(nameof (newWithNew));
    this.m_newWithOld = newWithOld;
    this.m_oldWithNew = oldWithNew;
  }

  private RootCaKeyUpdateContent(Asn1Sequence seq)
  {
    CmpCertificate cmpCertificate1 = seq.Count >= 1 && seq.Count <= 3 ? CmpCertificate.GetInstance((object) seq[0]) : throw new ArgumentException("expected sequence of 1 to 3 elements only");
    CmpCertificate cmpCertificate2 = (CmpCertificate) null;
    CmpCertificate cmpCertificate3 = (CmpCertificate) null;
    for (int index = 1; index < seq.Count; ++index)
    {
      Asn1TaggedObject instance = Asn1TaggedObject.GetInstance((object) seq[index]);
      if (instance.HasContextTag(0))
        cmpCertificate2 = CmpCertificate.GetInstance(instance, true);
      else if (instance.HasContextTag(1))
        cmpCertificate3 = CmpCertificate.GetInstance(instance, true);
    }
    this.m_newWithNew = cmpCertificate1;
    this.m_newWithOld = cmpCertificate2;
    this.m_oldWithNew = cmpCertificate3;
  }

  public virtual CmpCertificate NewWithNew => this.m_newWithNew;

  public virtual CmpCertificate NewWithOld => this.m_newWithOld;

  public virtual CmpCertificate OldWithNew => this.m_oldWithNew;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.m_newWithNew);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.m_newWithOld);
    elementVector.AddOptionalTagged(true, 1, (Asn1Encodable) this.m_oldWithNew);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
