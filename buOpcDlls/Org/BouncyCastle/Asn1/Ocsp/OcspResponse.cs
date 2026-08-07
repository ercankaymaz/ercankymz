// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Ocsp.OcspResponse
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Ocsp;

public class OcspResponse : Asn1Encodable
{
  private readonly OcspResponseStatus responseStatus;
  private readonly ResponseBytes responseBytes;

  public static OcspResponse GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return OcspResponse.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static OcspResponse GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case OcspResponse _:
        return (OcspResponse) obj;
      case Asn1Sequence _:
        return new OcspResponse((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public OcspResponse(OcspResponseStatus responseStatus, ResponseBytes responseBytes)
  {
    this.responseStatus = responseStatus != null ? responseStatus : throw new ArgumentNullException(nameof (responseStatus));
    this.responseBytes = responseBytes;
  }

  private OcspResponse(Asn1Sequence seq)
  {
    this.responseStatus = new OcspResponseStatus(DerEnumerated.GetInstance((object) seq[0]));
    if (seq.Count != 2)
      return;
    this.responseBytes = ResponseBytes.GetInstance((Asn1TaggedObject) seq[1], true);
  }

  public OcspResponseStatus ResponseStatus => this.responseStatus;

  public ResponseBytes ResponseBytes => this.responseBytes;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.responseStatus);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.responseBytes);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
