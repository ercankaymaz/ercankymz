// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.OcspIdentifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class OcspIdentifier : Asn1Encodable
{
  private readonly ResponderID ocspResponderID;
  private readonly Asn1GeneralizedTime producedAt;

  public static OcspIdentifier GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case OcspIdentifier _:
        return (OcspIdentifier) obj;
      case Asn1Sequence _:
        return new OcspIdentifier((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Unknown object in 'OcspIdentifier' factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private OcspIdentifier(Asn1Sequence seq)
  {
    if (seq == null)
      throw new ArgumentNullException(nameof (seq));
    this.ocspResponderID = seq.Count == 2 ? ResponderID.GetInstance((object) seq[0].ToAsn1Object()) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    this.producedAt = (Asn1GeneralizedTime) seq[1].ToAsn1Object();
  }

  public OcspIdentifier(ResponderID ocspResponderID, DateTime producedAt)
  {
    this.ocspResponderID = ocspResponderID != null ? ocspResponderID : throw new ArgumentNullException(nameof (ocspResponderID));
    this.producedAt = new Asn1GeneralizedTime(producedAt);
  }

  public OcspIdentifier(ResponderID ocspResponderID, Asn1GeneralizedTime producedAt)
  {
    if (ocspResponderID == null)
      throw new ArgumentNullException(nameof (ocspResponderID));
    if (producedAt == null)
      throw new ArgumentNullException(nameof (producedAt));
    this.ocspResponderID = ocspResponderID;
    this.producedAt = producedAt;
  }

  public ResponderID OcspResponderID => this.ocspResponderID;

  public DateTime ProducedAt => this.producedAt.ToDateTime();

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.ocspResponderID, (Asn1Encodable) this.producedAt);
  }
}
