// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Tsp.TimeStampReq
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;

#nullable disable
namespace Org.BouncyCastle.Asn1.Tsp;

public class TimeStampReq : Asn1Encodable
{
  private readonly DerInteger version;
  private readonly MessageImprint messageImprint;
  private readonly DerObjectIdentifier tsaPolicy;
  private readonly DerInteger nonce;
  private readonly DerBoolean certReq;
  private readonly X509Extensions extensions;

  public static TimeStampReq GetInstance(object obj)
  {
    if (obj is TimeStampReq)
      return (TimeStampReq) obj;
    return obj == null ? (TimeStampReq) null : new TimeStampReq(Asn1Sequence.GetInstance(obj));
  }

  private TimeStampReq(Asn1Sequence seq)
  {
    int count = seq.Count;
    this.version = DerInteger.GetInstance((object) seq[0]);
    this.messageImprint = MessageImprint.GetInstance((object) seq[1]);
    for (int index = 2; index < count; ++index)
    {
      if (seq[index] is DerObjectIdentifier objectIdentifier)
        this.tsaPolicy = objectIdentifier;
      else if (seq[index] is DerInteger derInteger)
        this.nonce = derInteger;
      else if (seq[index] is DerBoolean derBoolean)
        this.certReq = derBoolean;
      else if (seq[index] is Asn1TaggedObject taggedObject && taggedObject.TagNo == 0)
        this.extensions = X509Extensions.GetInstance(taggedObject, false);
    }
  }

  public TimeStampReq(
    MessageImprint messageImprint,
    DerObjectIdentifier tsaPolicy,
    DerInteger nonce,
    DerBoolean certReq,
    X509Extensions extensions)
  {
    this.version = new DerInteger(1);
    this.messageImprint = messageImprint;
    this.tsaPolicy = tsaPolicy;
    this.nonce = nonce;
    this.certReq = certReq;
    this.extensions = extensions;
  }

  public DerInteger Version => this.version;

  public MessageImprint MessageImprint => this.messageImprint;

  public DerObjectIdentifier ReqPolicy => this.tsaPolicy;

  public DerInteger Nonce => this.nonce;

  public DerBoolean CertReq => this.certReq;

  public X509Extensions Extensions => this.extensions;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.version, (Asn1Encodable) this.messageImprint);
    elementVector.AddOptional((Asn1Encodable) this.tsaPolicy, (Asn1Encodable) this.nonce);
    if (this.certReq != null && this.certReq.IsTrue)
      elementVector.Add((Asn1Encodable) this.certReq);
    elementVector.AddOptionalTagged(false, 0, (Asn1Encodable) this.extensions);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
