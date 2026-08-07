// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Ocsp.ResponseBytes
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Ocsp;

public class ResponseBytes : Asn1Encodable
{
  private readonly DerObjectIdentifier responseType;
  private readonly Asn1OctetString response;

  public static ResponseBytes GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return ResponseBytes.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static ResponseBytes GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case ResponseBytes _:
        return (ResponseBytes) obj;
      case Asn1Sequence _:
        return new ResponseBytes((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public ResponseBytes(DerObjectIdentifier responseType, Asn1OctetString response)
  {
    if (responseType == null)
      throw new ArgumentNullException(nameof (responseType));
    if (response == null)
      throw new ArgumentNullException(nameof (response));
    this.responseType = responseType;
    this.response = response;
  }

  private ResponseBytes(Asn1Sequence seq)
  {
    this.responseType = seq.Count == 2 ? DerObjectIdentifier.GetInstance((object) seq[0]) : throw new ArgumentException("Wrong number of elements in sequence", nameof (seq));
    this.response = Asn1OctetString.GetInstance((object) seq[1]);
  }

  public DerObjectIdentifier ResponseType => this.responseType;

  public Asn1OctetString Response => this.response;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.responseType, (Asn1Encodable) this.response);
  }
}
