// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Ocsp.OcspRequest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Ocsp;

public class OcspRequest : Asn1Encodable
{
  private readonly TbsRequest tbsRequest;
  private readonly Signature optionalSignature;

  public static OcspRequest GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return OcspRequest.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static OcspRequest GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case OcspRequest _:
        return (OcspRequest) obj;
      case Asn1Sequence _:
        return new OcspRequest((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public OcspRequest(TbsRequest tbsRequest, Signature optionalSignature)
  {
    this.tbsRequest = tbsRequest != null ? tbsRequest : throw new ArgumentNullException(nameof (tbsRequest));
    this.optionalSignature = optionalSignature;
  }

  private OcspRequest(Asn1Sequence seq)
  {
    this.tbsRequest = TbsRequest.GetInstance((object) seq[0]);
    if (seq.Count != 2)
      return;
    this.optionalSignature = Signature.GetInstance((Asn1TaggedObject) seq[1], true);
  }

  public TbsRequest TbsRequest => this.tbsRequest;

  public Signature OptionalSignature => this.optionalSignature;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.tbsRequest);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.optionalSignature);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
