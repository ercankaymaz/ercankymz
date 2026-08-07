// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.KekIdentifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class KekIdentifier : Asn1Encodable
{
  private Asn1OctetString keyIdentifier;
  private Asn1GeneralizedTime date;
  private OtherKeyAttribute other;

  public KekIdentifier(byte[] keyIdentifier, Asn1GeneralizedTime date, OtherKeyAttribute other)
  {
    this.keyIdentifier = (Asn1OctetString) new DerOctetString(keyIdentifier);
    this.date = date;
    this.other = other;
  }

  public KekIdentifier(Asn1Sequence seq)
  {
    this.keyIdentifier = (Asn1OctetString) seq[0];
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
        throw new ArgumentException("Invalid KekIdentifier");
    }
  }

  public static KekIdentifier GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return KekIdentifier.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static KekIdentifier GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case KekIdentifier _:
        return (KekIdentifier) obj;
      case Asn1Sequence _:
        return new KekIdentifier((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid KekIdentifier: " + Platform.GetTypeName(obj));
    }
  }

  public Asn1OctetString KeyIdentifier => this.keyIdentifier;

  public Asn1GeneralizedTime Date => this.date;

  public OtherKeyAttribute Other => this.other;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.keyIdentifier);
    elementVector.AddOptional((Asn1Encodable) this.date, (Asn1Encodable) this.other);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
