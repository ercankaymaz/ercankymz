// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.RecipientKeyIdentifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class RecipientKeyIdentifier : Asn1Encodable
{
  private Asn1OctetString subjectKeyIdentifier;
  private Asn1GeneralizedTime date;
  private OtherKeyAttribute other;

  public RecipientKeyIdentifier(
    Asn1OctetString subjectKeyIdentifier,
    Asn1GeneralizedTime date,
    OtherKeyAttribute other)
  {
    this.subjectKeyIdentifier = subjectKeyIdentifier;
    this.date = date;
    this.other = other;
  }

  public RecipientKeyIdentifier(byte[] subjectKeyIdentifier)
    : this(subjectKeyIdentifier, (Asn1GeneralizedTime) null, (OtherKeyAttribute) null)
  {
  }

  public RecipientKeyIdentifier(
    byte[] subjectKeyIdentifier,
    Asn1GeneralizedTime date,
    OtherKeyAttribute other)
  {
    this.subjectKeyIdentifier = (Asn1OctetString) new DerOctetString(subjectKeyIdentifier);
    this.date = date;
    this.other = other;
  }

  public RecipientKeyIdentifier(Asn1Sequence seq)
  {
    this.subjectKeyIdentifier = Asn1OctetString.GetInstance((object) seq[0]);
    switch (seq.Count)
    {
      case 1:
        break;
      case 2:
        if (seq[1] is Asn1GeneralizedTime asn1GeneralizedTime)
        {
          this.date = asn1GeneralizedTime;
          break;
        }
        this.other = OtherKeyAttribute.GetInstance((object) seq[2]);
        break;
      case 3:
        this.date = (Asn1GeneralizedTime) seq[1];
        this.other = OtherKeyAttribute.GetInstance((object) seq[2]);
        break;
      default:
        throw new ArgumentException("Invalid RecipientKeyIdentifier");
    }
  }

  public static RecipientKeyIdentifier GetInstance(Asn1TaggedObject ato, bool explicitly)
  {
    return RecipientKeyIdentifier.GetInstance((object) Asn1Sequence.GetInstance(ato, explicitly));
  }

  public static RecipientKeyIdentifier GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case RecipientKeyIdentifier _:
        return (RecipientKeyIdentifier) obj;
      case Asn1Sequence _:
        return new RecipientKeyIdentifier((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid RecipientKeyIdentifier: " + Platform.GetTypeName(obj));
    }
  }

  public Asn1OctetString SubjectKeyIdentifier => this.subjectKeyIdentifier;

  public Asn1GeneralizedTime Date => this.date;

  public OtherKeyAttribute OtherKeyAttribute => this.other;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.subjectKeyIdentifier);
    elementVector.AddOptional((Asn1Encodable) this.date, (Asn1Encodable) this.other);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
