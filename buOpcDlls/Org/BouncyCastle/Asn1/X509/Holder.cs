// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.Holder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class Holder : Asn1Encodable
{
  internal readonly IssuerSerial baseCertificateID;
  internal readonly GeneralNames entityName;
  internal readonly ObjectDigestInfo objectDigestInfo;
  private readonly int version;

  public static Holder GetInstance(object obj)
  {
    switch (obj)
    {
      case Holder _:
        return (Holder) obj;
      case Asn1Sequence _:
        return new Holder((Asn1Sequence) obj);
      case Asn1TaggedObject _:
        return new Holder((Asn1TaggedObject) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public Holder(Asn1TaggedObject tagObj)
  {
    switch (tagObj.TagNo)
    {
      case 0:
        this.baseCertificateID = IssuerSerial.GetInstance(tagObj, true);
        break;
      case 1:
        this.entityName = GeneralNames.GetInstance(tagObj, true);
        break;
      default:
        throw new ArgumentException("unknown tag in Holder");
    }
    this.version = 0;
  }

  private Holder(Asn1Sequence seq)
  {
    if (seq.Count > 3)
      throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    for (int index = 0; index != seq.Count; ++index)
    {
      Asn1TaggedObject instance = Asn1TaggedObject.GetInstance((object) seq[index]);
      switch (instance.TagNo)
      {
        case 0:
          this.baseCertificateID = IssuerSerial.GetInstance(instance, false);
          break;
        case 1:
          this.entityName = GeneralNames.GetInstance(instance, false);
          break;
        case 2:
          this.objectDigestInfo = ObjectDigestInfo.GetInstance(instance, false);
          break;
        default:
          throw new ArgumentException("unknown tag in Holder");
      }
    }
    this.version = 1;
  }

  public Holder(IssuerSerial baseCertificateID)
    : this(baseCertificateID, 1)
  {
  }

  public Holder(IssuerSerial baseCertificateID, int version)
  {
    this.baseCertificateID = baseCertificateID;
    this.version = version;
  }

  public int Version => this.version;

  public Holder(GeneralNames entityName)
    : this(entityName, 1)
  {
  }

  public Holder(GeneralNames entityName, int version)
  {
    this.entityName = entityName;
    this.version = version;
  }

  public Holder(ObjectDigestInfo objectDigestInfo)
  {
    this.objectDigestInfo = objectDigestInfo;
    this.version = 1;
  }

  public IssuerSerial BaseCertificateID => this.baseCertificateID;

  public GeneralNames EntityName => this.entityName;

  public ObjectDigestInfo ObjectDigestInfo => this.objectDigestInfo;

  public override Asn1Object ToAsn1Object()
  {
    if (this.version == 1)
    {
      Asn1EncodableVector elementVector = new Asn1EncodableVector(3);
      elementVector.AddOptionalTagged(false, 0, (Asn1Encodable) this.baseCertificateID);
      elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.entityName);
      elementVector.AddOptionalTagged(false, 2, (Asn1Encodable) this.objectDigestInfo);
      return (Asn1Object) new DerSequence(elementVector);
    }
    return this.entityName != null ? (Asn1Object) new DerTaggedObject(true, 1, (Asn1Encodable) this.entityName) : (Asn1Object) new DerTaggedObject(true, 0, (Asn1Encodable) this.baseCertificateID);
  }
}
