// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.CAKeyUpdAnnContent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class CAKeyUpdAnnContent : Asn1Encodable
{
  private readonly CmpCertificate m_oldWithNew;
  private readonly CmpCertificate m_newWithOld;
  private readonly CmpCertificate m_newWithNew;

  public static CAKeyUpdAnnContent GetInstance(object obj)
  {
    if (obj == null)
      return (CAKeyUpdAnnContent) null;
    return obj is CAKeyUpdAnnContent keyUpdAnnContent ? keyUpdAnnContent : new CAKeyUpdAnnContent(Asn1Sequence.GetInstance(obj));
  }

  public static CAKeyUpdAnnContent GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return CAKeyUpdAnnContent.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private CAKeyUpdAnnContent(Asn1Sequence seq)
  {
    this.m_oldWithNew = CmpCertificate.GetInstance((object) seq[0]);
    this.m_newWithOld = CmpCertificate.GetInstance((object) seq[1]);
    this.m_newWithNew = CmpCertificate.GetInstance((object) seq[2]);
  }

  public virtual CmpCertificate OldWithNew => this.m_oldWithNew;

  public virtual CmpCertificate NewWithOld => this.m_newWithOld;

  public virtual CmpCertificate NewWithNew => this.m_newWithNew;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence(new Asn1Encodable[3]
    {
      (Asn1Encodable) this.m_oldWithNew,
      (Asn1Encodable) this.m_newWithOld,
      (Asn1Encodable) this.m_newWithNew
    });
  }
}
