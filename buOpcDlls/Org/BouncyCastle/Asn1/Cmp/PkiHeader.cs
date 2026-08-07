// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.PkiHeader
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class PkiHeader : Asn1Encodable
{
  public static readonly GeneralName NULL_NAME = new GeneralName(X509Name.GetInstance((object) new DerSequence()));
  public static readonly int CMP_1999 = 1;
  public static readonly int CMP_2000 = 2;
  private readonly DerInteger pvno;
  private readonly GeneralName sender;
  private readonly GeneralName recipient;
  private readonly Asn1GeneralizedTime messageTime;
  private readonly AlgorithmIdentifier protectionAlg;
  private readonly Asn1OctetString senderKID;
  private readonly Asn1OctetString recipKID;
  private readonly Asn1OctetString transactionID;
  private readonly Asn1OctetString senderNonce;
  private readonly Asn1OctetString recipNonce;
  private readonly PkiFreeText freeText;
  private readonly Asn1Sequence generalInfo;

  public static PkiHeader GetInstance(object obj)
  {
    if (obj == null)
      return (PkiHeader) null;
    return obj is PkiHeader pkiHeader ? pkiHeader : new PkiHeader(Asn1Sequence.GetInstance(obj));
  }

  public static PkiHeader GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return PkiHeader.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private PkiHeader(Asn1Sequence seq)
  {
    this.pvno = DerInteger.GetInstance((object) seq[0]);
    this.sender = GeneralName.GetInstance((object) seq[1]);
    this.recipient = GeneralName.GetInstance((object) seq[2]);
    for (int index = 3; index < seq.Count; ++index)
    {
      Asn1TaggedObject instance = Asn1TaggedObject.GetInstance((object) seq[index]);
      if (128 /*0x80*/ == instance.TagClass)
      {
        switch (instance.TagNo)
        {
          case 0:
            this.messageTime = Asn1GeneralizedTime.GetInstance(instance, true);
            continue;
          case 1:
            this.protectionAlg = AlgorithmIdentifier.GetInstance(instance, true);
            continue;
          case 2:
            this.senderKID = Asn1OctetString.GetInstance(instance, true);
            continue;
          case 3:
            this.recipKID = Asn1OctetString.GetInstance(instance, true);
            continue;
          case 4:
            this.transactionID = Asn1OctetString.GetInstance(instance, true);
            continue;
          case 5:
            this.senderNonce = Asn1OctetString.GetInstance(instance, true);
            continue;
          case 6:
            this.recipNonce = Asn1OctetString.GetInstance(instance, true);
            continue;
          case 7:
            this.freeText = PkiFreeText.GetInstance(instance, true);
            continue;
          case 8:
            this.generalInfo = Asn1Sequence.GetInstance(instance, true);
            continue;
          default:
            throw new ArgumentException("unknown tag number: " + instance.TagNo.ToString(), nameof (seq));
        }
      }
    }
  }

  public PkiHeader(int pvno, GeneralName sender, GeneralName recipient)
    : this(new DerInteger(pvno), sender, recipient)
  {
  }

  private PkiHeader(DerInteger pvno, GeneralName sender, GeneralName recipient)
  {
    this.pvno = pvno;
    this.sender = sender;
    this.recipient = recipient;
  }

  public virtual DerInteger Pvno => this.pvno;

  public virtual GeneralName Sender => this.sender;

  public virtual GeneralName Recipient => this.recipient;

  public virtual Asn1GeneralizedTime MessageTime => this.messageTime;

  public virtual AlgorithmIdentifier ProtectionAlg => this.protectionAlg;

  public virtual Asn1OctetString SenderKID => this.senderKID;

  public virtual Asn1OctetString RecipKID => this.recipKID;

  public virtual Asn1OctetString TransactionID => this.transactionID;

  public virtual Asn1OctetString SenderNonce => this.senderNonce;

  public virtual Asn1OctetString RecipNonce => this.recipNonce;

  public virtual PkiFreeText FreeText => this.freeText;

  public virtual InfoTypeAndValue[] GetGeneralInfo()
  {
    return this.generalInfo?.MapElements<InfoTypeAndValue>(new Func<Asn1Encodable, InfoTypeAndValue>(InfoTypeAndValue.GetInstance));
  }

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(new Asn1Encodable[3]
    {
      (Asn1Encodable) this.pvno,
      (Asn1Encodable) this.sender,
      (Asn1Encodable) this.recipient
    });
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.messageTime);
    elementVector.AddOptionalTagged(true, 1, (Asn1Encodable) this.protectionAlg);
    elementVector.AddOptionalTagged(true, 2, (Asn1Encodable) this.senderKID);
    elementVector.AddOptionalTagged(true, 3, (Asn1Encodable) this.recipKID);
    elementVector.AddOptionalTagged(true, 4, (Asn1Encodable) this.transactionID);
    elementVector.AddOptionalTagged(true, 5, (Asn1Encodable) this.senderNonce);
    elementVector.AddOptionalTagged(true, 6, (Asn1Encodable) this.recipNonce);
    elementVector.AddOptionalTagged(true, 7, (Asn1Encodable) this.freeText);
    elementVector.AddOptionalTagged(true, 8, (Asn1Encodable) this.generalInfo);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
