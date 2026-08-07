// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.V2Form
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class V2Form : Asn1Encodable
{
  internal GeneralNames issuerName;
  internal IssuerSerial baseCertificateID;
  internal ObjectDigestInfo objectDigestInfo;

  public static V2Form GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return V2Form.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static V2Form GetInstance(object obj)
  {
    if (obj is V2Form)
      return (V2Form) obj;
    return obj != null ? new V2Form(Asn1Sequence.GetInstance(obj)) : (V2Form) null;
  }

  public V2Form(GeneralNames issuerName)
    : this(issuerName, (IssuerSerial) null, (ObjectDigestInfo) null)
  {
  }

  public V2Form(GeneralNames issuerName, IssuerSerial baseCertificateID)
    : this(issuerName, baseCertificateID, (ObjectDigestInfo) null)
  {
  }

  public V2Form(GeneralNames issuerName, ObjectDigestInfo objectDigestInfo)
    : this(issuerName, (IssuerSerial) null, objectDigestInfo)
  {
  }

  public V2Form(
    GeneralNames issuerName,
    IssuerSerial baseCertificateID,
    ObjectDigestInfo objectDigestInfo)
  {
    this.issuerName = issuerName;
    this.baseCertificateID = baseCertificateID;
    this.objectDigestInfo = objectDigestInfo;
  }

  private V2Form(Asn1Sequence seq)
  {
    if (seq.Count > 3)
      throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    int num = 0;
    if (!(seq[0] is Asn1TaggedObject))
    {
      ++num;
      this.issuerName = GeneralNames.GetInstance((object) seq[0]);
    }
    for (int index = num; index != seq.Count; ++index)
    {
      Asn1TaggedObject instance = Asn1TaggedObject.GetInstance((object) seq[index]);
      if (instance.TagNo == 0)
        this.baseCertificateID = IssuerSerial.GetInstance(instance, false);
      else
        this.objectDigestInfo = instance.TagNo == 1 ? ObjectDigestInfo.GetInstance(instance, false) : throw new ArgumentException("Bad tag number: " + instance.TagNo.ToString());
    }
  }

  public GeneralNames IssuerName => this.issuerName;

  public IssuerSerial BaseCertificateID => this.baseCertificateID;

  public ObjectDigestInfo ObjectDigestInfo => this.objectDigestInfo;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(3);
    elementVector.AddOptional((Asn1Encodable) this.issuerName);
    elementVector.AddOptionalTagged(false, 0, (Asn1Encodable) this.baseCertificateID);
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.objectDigestInfo);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
