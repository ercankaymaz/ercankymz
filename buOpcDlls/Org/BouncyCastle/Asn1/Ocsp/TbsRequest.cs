// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Ocsp.TbsRequest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Ocsp;

public class TbsRequest : Asn1Encodable
{
  private static readonly DerInteger V1 = new DerInteger(0);
  private readonly DerInteger version;
  private readonly GeneralName requestorName;
  private readonly Asn1Sequence requestList;
  private readonly X509Extensions requestExtensions;
  private bool versionSet;

  public static TbsRequest GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return TbsRequest.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static TbsRequest GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case TbsRequest _:
        return (TbsRequest) obj;
      case Asn1Sequence _:
        return new TbsRequest((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public TbsRequest(
    GeneralName requestorName,
    Asn1Sequence requestList,
    X509Extensions requestExtensions)
  {
    this.version = TbsRequest.V1;
    this.requestorName = requestorName;
    this.requestList = requestList;
    this.requestExtensions = requestExtensions;
  }

  private TbsRequest(Asn1Sequence seq)
  {
    int index1 = 0;
    Asn1Encodable asn1Encodable = seq[0];
    if (asn1Encodable is Asn1TaggedObject)
    {
      Asn1TaggedObject taggedObject = (Asn1TaggedObject) asn1Encodable;
      if (taggedObject.TagNo == 0)
      {
        this.versionSet = true;
        this.version = DerInteger.GetInstance(taggedObject, true);
        ++index1;
      }
      else
        this.version = TbsRequest.V1;
    }
    else
      this.version = TbsRequest.V1;
    if (seq[index1] is Asn1TaggedObject)
      this.requestorName = GeneralName.GetInstance((Asn1TaggedObject) seq[index1++], true);
    Asn1Sequence asn1Sequence = seq;
    int index2 = index1;
    int index3 = index2 + 1;
    this.requestList = (Asn1Sequence) asn1Sequence[index2];
    if (seq.Count != index3 + 1)
      return;
    this.requestExtensions = X509Extensions.GetInstance((Asn1TaggedObject) seq[index3], true);
  }

  public DerInteger Version => this.version;

  public GeneralName RequestorName => this.requestorName;

  public Asn1Sequence RequestList => this.requestList;

  public X509Extensions RequestExtensions => this.requestExtensions;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(4);
    if (!this.version.Equals((Asn1Object) TbsRequest.V1) || this.versionSet)
      elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 0, (Asn1Encodable) this.version));
    elementVector.AddOptionalTagged(true, 1, (Asn1Encodable) this.requestorName);
    elementVector.Add((Asn1Encodable) this.requestList);
    elementVector.AddOptionalTagged(true, 2, (Asn1Encodable) this.requestExtensions);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
