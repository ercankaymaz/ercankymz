// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.OriginatorInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class OriginatorInfo : Asn1Encodable
{
  private Asn1Set certs;
  private Asn1Set crls;

  public OriginatorInfo(Asn1Set certs, Asn1Set crls)
  {
    this.certs = certs;
    this.crls = crls;
  }

  public OriginatorInfo(Asn1Sequence seq)
  {
    switch (seq.Count)
    {
      case 0:
        break;
      case 1:
        Asn1TaggedObject taggedObject = (Asn1TaggedObject) seq[0];
        switch (taggedObject.TagNo)
        {
          case 0:
            this.certs = Asn1Set.GetInstance(taggedObject, false);
            return;
          case 1:
            this.crls = Asn1Set.GetInstance(taggedObject, false);
            return;
          default:
            throw new ArgumentException("Bad tag in OriginatorInfo: " + taggedObject.TagNo.ToString());
        }
      case 2:
        this.certs = Asn1Set.GetInstance((Asn1TaggedObject) seq[0], false);
        this.crls = Asn1Set.GetInstance((Asn1TaggedObject) seq[1], false);
        break;
      default:
        throw new ArgumentException("OriginatorInfo too big");
    }
  }

  public static OriginatorInfo GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return OriginatorInfo.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static OriginatorInfo GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case OriginatorInfo _:
        return (OriginatorInfo) obj;
      case Asn1Sequence _:
        return new OriginatorInfo((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid OriginatorInfo: " + Platform.GetTypeName(obj));
    }
  }

  public Asn1Set Certificates => this.certs;

  public Asn1Set Crls => this.crls;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(2);
    elementVector.AddOptionalTagged(false, 0, (Asn1Encodable) this.certs);
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.crls);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
