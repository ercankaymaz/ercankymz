// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.PkiMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class PkiMessage : Asn1Encodable
{
  private readonly PkiHeader header;
  private readonly PkiBody body;
  private readonly DerBitString protection;
  private readonly Asn1Sequence extraCerts;

  public static PkiMessage GetInstance(object obj)
  {
    if (obj == null)
      return (PkiMessage) null;
    return obj is PkiMessage pkiMessage ? pkiMessage : new PkiMessage(Asn1Sequence.GetInstance(obj));
  }

  public static PkiMessage GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return PkiMessage.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private PkiMessage(Asn1Sequence seq)
  {
    this.header = PkiHeader.GetInstance((object) seq[0]);
    this.body = PkiBody.GetInstance((object) seq[1]);
    for (int index = 2; index < seq.Count; ++index)
    {
      Asn1TaggedObject instance = Asn1TaggedObject.GetInstance((object) seq[index]);
      if (instance.HasContextTag(0))
        this.protection = DerBitString.GetInstance(instance, true);
      else if (instance.HasContextTag(1))
        this.extraCerts = Asn1Sequence.GetInstance(instance, true);
    }
  }

  public PkiMessage(
    PkiHeader header,
    PkiBody body,
    DerBitString protection,
    CmpCertificate[] extraCerts)
  {
    this.header = header;
    this.body = body;
    this.protection = protection;
    if (extraCerts == null)
      return;
    this.extraCerts = (Asn1Sequence) new DerSequence((Asn1Encodable[]) extraCerts);
  }

  public PkiMessage(PkiHeader header, PkiBody body, DerBitString protection)
    : this(header, body, protection, (CmpCertificate[]) null)
  {
  }

  public PkiMessage(PkiHeader header, PkiBody body)
    : this(header, body, (DerBitString) null, (CmpCertificate[]) null)
  {
  }

  public virtual PkiHeader Header => this.header;

  public virtual PkiBody Body => this.body;

  public virtual DerBitString Protection => this.protection;

  public virtual CmpCertificate[] GetExtraCerts()
  {
    return this.extraCerts?.MapElements<CmpCertificate>(new Func<Asn1Encodable, CmpCertificate>(CmpCertificate.GetInstance));
  }

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.header, (Asn1Encodable) this.body);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.protection);
    elementVector.AddOptionalTagged(true, 1, (Asn1Encodable) this.extraCerts);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
