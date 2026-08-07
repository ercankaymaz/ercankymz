// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.PkiMessages
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class PkiMessages : Asn1Encodable
{
  private Asn1Sequence m_content;

  public static PkiMessages GetInstance(object obj)
  {
    if (obj == null)
      return (PkiMessages) null;
    return obj is PkiMessages pkiMessages ? pkiMessages : new PkiMessages(Asn1Sequence.GetInstance(obj));
  }

  public static PkiMessages GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return PkiMessages.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  internal PkiMessages(Asn1Sequence seq) => this.m_content = seq;

  internal PkiMessages(PkiMessages other) => this.m_content = other.m_content;

  public PkiMessages(params PkiMessage[] msgs)
  {
    this.m_content = (Asn1Sequence) new DerSequence((Asn1Encodable[]) msgs);
  }

  public virtual PkiMessage[] ToPkiMessageArray()
  {
    return this.m_content.MapElements<PkiMessage>(new Func<Asn1Encodable, PkiMessage>(PkiMessage.GetInstance));
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.m_content;
}
