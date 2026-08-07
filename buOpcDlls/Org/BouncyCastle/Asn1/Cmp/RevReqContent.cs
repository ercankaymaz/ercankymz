// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.RevReqContent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class RevReqContent : Asn1Encodable
{
  private readonly Asn1Sequence m_content;

  public static RevReqContent GetInstance(object obj)
  {
    if (obj == null)
      return (RevReqContent) null;
    return obj is RevReqContent revReqContent ? revReqContent : new RevReqContent(Asn1Sequence.GetInstance(obj));
  }

  public static RevReqContent GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return RevReqContent.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private RevReqContent(Asn1Sequence seq) => this.m_content = seq;

  public RevReqContent(RevDetails revDetails)
  {
    this.m_content = (Asn1Sequence) new DerSequence((Asn1Encodable) revDetails);
  }

  public RevReqContent(params RevDetails[] revDetailsArray)
  {
    this.m_content = (Asn1Sequence) new DerSequence((Asn1Encodable[]) revDetailsArray);
  }

  public virtual RevDetails[] ToRevDetailsArray()
  {
    return this.m_content.MapElements<RevDetails>(new Func<Asn1Encodable, RevDetails>(RevDetails.GetInstance));
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.m_content;
}
