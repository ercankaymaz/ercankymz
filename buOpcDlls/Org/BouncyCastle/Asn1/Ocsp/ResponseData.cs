// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Ocsp.ResponseData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Ocsp;

public class ResponseData : Asn1Encodable
{
  private static readonly DerInteger V1 = new DerInteger(0);
  private readonly bool versionPresent;
  private readonly DerInteger version;
  private readonly ResponderID responderID;
  private readonly Asn1GeneralizedTime producedAt;
  private readonly Asn1Sequence responses;
  private readonly X509Extensions responseExtensions;

  public static ResponseData GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return ResponseData.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static ResponseData GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case ResponseData _:
        return (ResponseData) obj;
      case Asn1Sequence _:
        return new ResponseData((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public ResponseData(
    DerInteger version,
    ResponderID responderID,
    Asn1GeneralizedTime producedAt,
    Asn1Sequence responses,
    X509Extensions responseExtensions)
  {
    this.version = version;
    this.responderID = responderID;
    this.producedAt = producedAt;
    this.responses = responses;
    this.responseExtensions = responseExtensions;
  }

  public ResponseData(
    ResponderID responderID,
    Asn1GeneralizedTime producedAt,
    Asn1Sequence responses,
    X509Extensions responseExtensions)
    : this(ResponseData.V1, responderID, producedAt, responses, responseExtensions)
  {
  }

  private ResponseData(Asn1Sequence seq)
  {
    int num1 = 0;
    if (seq[0] is Asn1TaggedObject taggedObject)
    {
      if (taggedObject.TagNo == 0)
      {
        this.versionPresent = true;
        this.version = DerInteger.GetInstance(taggedObject, true);
        ++num1;
      }
      else
        this.version = ResponseData.V1;
    }
    else
      this.version = ResponseData.V1;
    Asn1Sequence asn1Sequence1 = seq;
    int index1 = num1;
    int num2 = index1 + 1;
    this.responderID = ResponderID.GetInstance((object) asn1Sequence1[index1]);
    Asn1Sequence asn1Sequence2 = seq;
    int index2 = num2;
    int num3 = index2 + 1;
    this.producedAt = (Asn1GeneralizedTime) asn1Sequence2[index2];
    Asn1Sequence asn1Sequence3 = seq;
    int index3 = num3;
    int index4 = index3 + 1;
    this.responses = (Asn1Sequence) asn1Sequence3[index3];
    if (seq.Count <= index4)
      return;
    this.responseExtensions = X509Extensions.GetInstance((Asn1TaggedObject) seq[index4], true);
  }

  public DerInteger Version => this.version;

  public ResponderID ResponderID => this.responderID;

  public Asn1GeneralizedTime ProducedAt => this.producedAt;

  public Asn1Sequence Responses => this.responses;

  public X509Extensions ResponseExtensions => this.responseExtensions;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(3);
    if (this.versionPresent || !this.version.Equals((Asn1Object) ResponseData.V1))
      elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 0, (Asn1Encodable) this.version));
    elementVector.Add((Asn1Encodable) this.responderID, (Asn1Encodable) this.producedAt, (Asn1Encodable) this.responses);
    elementVector.AddOptionalTagged(true, 1, (Asn1Encodable) this.responseExtensions);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
