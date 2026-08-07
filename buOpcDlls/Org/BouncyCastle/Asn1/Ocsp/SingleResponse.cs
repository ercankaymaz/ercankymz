// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Ocsp.SingleResponse
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Ocsp;

public class SingleResponse : Asn1Encodable
{
  private readonly CertID certID;
  private readonly CertStatus certStatus;
  private readonly Asn1GeneralizedTime thisUpdate;
  private readonly Asn1GeneralizedTime nextUpdate;
  private readonly X509Extensions singleExtensions;

  public SingleResponse(
    CertID certID,
    CertStatus certStatus,
    Asn1GeneralizedTime thisUpdate,
    Asn1GeneralizedTime nextUpdate,
    X509Extensions singleExtensions)
  {
    this.certID = certID;
    this.certStatus = certStatus;
    this.thisUpdate = thisUpdate;
    this.nextUpdate = nextUpdate;
    this.singleExtensions = singleExtensions;
  }

  public SingleResponse(Asn1Sequence seq)
  {
    this.certID = CertID.GetInstance((object) seq[0]);
    this.certStatus = CertStatus.GetInstance((object) seq[1]);
    this.thisUpdate = (Asn1GeneralizedTime) seq[2];
    if (seq.Count > 4)
    {
      this.nextUpdate = Asn1GeneralizedTime.GetInstance((Asn1TaggedObject) seq[3], true);
      this.singleExtensions = X509Extensions.GetInstance((Asn1TaggedObject) seq[4], true);
    }
    else
    {
      if (seq.Count <= 3)
        return;
      Asn1TaggedObject taggedObject = (Asn1TaggedObject) seq[3];
      if (taggedObject.TagNo == 0)
        this.nextUpdate = Asn1GeneralizedTime.GetInstance(taggedObject, true);
      else
        this.singleExtensions = X509Extensions.GetInstance(taggedObject, true);
    }
  }

  public static SingleResponse GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return SingleResponse.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static SingleResponse GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case SingleResponse _:
        return (SingleResponse) obj;
      case Asn1Sequence _:
        return new SingleResponse((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public CertID CertId => this.certID;

  public CertStatus CertStatus => this.certStatus;

  public Asn1GeneralizedTime ThisUpdate => this.thisUpdate;

  public Asn1GeneralizedTime NextUpdate => this.nextUpdate;

  public X509Extensions SingleExtensions => this.singleExtensions;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(new Asn1Encodable[3]
    {
      (Asn1Encodable) this.certID,
      (Asn1Encodable) this.certStatus,
      (Asn1Encodable) this.thisUpdate
    });
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.nextUpdate);
    elementVector.AddOptionalTagged(true, 1, (Asn1Encodable) this.singleExtensions);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
