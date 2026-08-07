// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.PopoDecKeyChallContent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class PopoDecKeyChallContent : Asn1Encodable
{
  private readonly Asn1Sequence m_content;

  public static PopoDecKeyChallContent GetInstance(object obj)
  {
    if (obj == null)
      return (PopoDecKeyChallContent) null;
    return obj is PopoDecKeyChallContent decKeyChallContent ? decKeyChallContent : new PopoDecKeyChallContent(Asn1Sequence.GetInstance(obj));
  }

  public static PopoDecKeyChallContent GetInstance(
    Asn1TaggedObject taggedObject,
    bool declaredExplicit)
  {
    return PopoDecKeyChallContent.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private PopoDecKeyChallContent(Asn1Sequence seq) => this.m_content = seq;

  public virtual Challenge[] ToChallengeArray()
  {
    return this.m_content.MapElements<Challenge>(new Func<Asn1Encodable, Challenge>(Challenge.GetInstance));
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.m_content;
}
