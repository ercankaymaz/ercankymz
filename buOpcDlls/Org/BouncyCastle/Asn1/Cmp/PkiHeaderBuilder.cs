// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.PkiHeaderBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class PkiHeaderBuilder
{
  private DerInteger pvno;
  private GeneralName sender;
  private GeneralName recipient;
  private Asn1GeneralizedTime messageTime;
  private AlgorithmIdentifier protectionAlg;
  private Asn1OctetString senderKID;
  private Asn1OctetString recipKID;
  private Asn1OctetString transactionID;
  private Asn1OctetString senderNonce;
  private Asn1OctetString recipNonce;
  private PkiFreeText freeText;
  private Asn1Sequence generalInfo;

  public PkiHeaderBuilder(int pvno, GeneralName sender, GeneralName recipient)
    : this(new DerInteger(pvno), sender, recipient)
  {
  }

  private PkiHeaderBuilder(DerInteger pvno, GeneralName sender, GeneralName recipient)
  {
    this.pvno = pvno;
    this.sender = sender;
    this.recipient = recipient;
  }

  public virtual PkiHeaderBuilder SetMessageTime(Asn1GeneralizedTime time)
  {
    this.messageTime = time;
    return this;
  }

  public virtual PkiHeaderBuilder SetProtectionAlg(AlgorithmIdentifier aid)
  {
    this.protectionAlg = aid;
    return this;
  }

  public virtual PkiHeaderBuilder SetSenderKID(byte[] kid)
  {
    return this.SetSenderKID(kid == null ? (Asn1OctetString) null : (Asn1OctetString) new DerOctetString(kid));
  }

  public virtual PkiHeaderBuilder SetSenderKID(Asn1OctetString kid)
  {
    this.senderKID = kid;
    return this;
  }

  public virtual PkiHeaderBuilder SetRecipKID(byte[] kid)
  {
    return this.SetRecipKID(kid == null ? (Asn1OctetString) null : (Asn1OctetString) new DerOctetString(kid));
  }

  public virtual PkiHeaderBuilder SetRecipKID(Asn1OctetString kid)
  {
    this.recipKID = kid;
    return this;
  }

  public virtual PkiHeaderBuilder SetTransactionID(byte[] tid)
  {
    return this.SetTransactionID(tid == null ? (Asn1OctetString) null : (Asn1OctetString) new DerOctetString(tid));
  }

  public virtual PkiHeaderBuilder SetTransactionID(Asn1OctetString tid)
  {
    this.transactionID = tid;
    return this;
  }

  public virtual PkiHeaderBuilder SetSenderNonce(byte[] nonce)
  {
    return this.SetSenderNonce(nonce == null ? (Asn1OctetString) null : (Asn1OctetString) new DerOctetString(nonce));
  }

  public virtual PkiHeaderBuilder SetSenderNonce(Asn1OctetString nonce)
  {
    this.senderNonce = nonce;
    return this;
  }

  public virtual PkiHeaderBuilder SetRecipNonce(byte[] nonce)
  {
    return this.SetRecipNonce(nonce == null ? (Asn1OctetString) null : (Asn1OctetString) new DerOctetString(nonce));
  }

  public virtual PkiHeaderBuilder SetRecipNonce(Asn1OctetString nonce)
  {
    this.recipNonce = nonce;
    return this;
  }

  public virtual PkiHeaderBuilder SetFreeText(PkiFreeText text)
  {
    this.freeText = text;
    return this;
  }

  public virtual PkiHeaderBuilder SetGeneralInfo(InfoTypeAndValue genInfo)
  {
    return this.SetGeneralInfo(PkiHeaderBuilder.MakeGeneralInfoSeq(genInfo));
  }

  public virtual PkiHeaderBuilder SetGeneralInfo(InfoTypeAndValue[] genInfos)
  {
    return this.SetGeneralInfo(PkiHeaderBuilder.MakeGeneralInfoSeq(genInfos));
  }

  public virtual PkiHeaderBuilder SetGeneralInfo(Asn1Sequence seqOfInfoTypeAndValue)
  {
    this.generalInfo = seqOfInfoTypeAndValue;
    return this;
  }

  private static Asn1Sequence MakeGeneralInfoSeq(InfoTypeAndValue generalInfo)
  {
    return (Asn1Sequence) new DerSequence((Asn1Encodable) generalInfo);
  }

  private static Asn1Sequence MakeGeneralInfoSeq(InfoTypeAndValue[] generalInfos)
  {
    return generalInfos != null ? (Asn1Sequence) new DerSequence((Asn1Encodable[]) generalInfos) : (Asn1Sequence) null;
  }

  public virtual PkiHeader Build()
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
    this.messageTime = (Asn1GeneralizedTime) null;
    this.protectionAlg = (AlgorithmIdentifier) null;
    this.senderKID = (Asn1OctetString) null;
    this.recipKID = (Asn1OctetString) null;
    this.transactionID = (Asn1OctetString) null;
    this.senderNonce = (Asn1OctetString) null;
    this.recipNonce = (Asn1OctetString) null;
    this.freeText = (PkiFreeText) null;
    this.generalInfo = (Asn1Sequence) null;
    return PkiHeader.GetInstance((object) new DerSequence(elementVector));
  }
}
