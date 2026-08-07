// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.OtherCertID
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class OtherCertID : Asn1Encodable
{
  private readonly OtherHash otherCertHash;
  private readonly IssuerSerial issuerSerial;

  public static OtherCertID GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case OtherCertID _:
        return (OtherCertID) obj;
      case Asn1Sequence _:
        return new OtherCertID((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Unknown object in 'OtherCertID' factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private OtherCertID(Asn1Sequence seq)
  {
    if (seq == null)
      throw new ArgumentNullException(nameof (seq));
    this.otherCertHash = seq.Count >= 1 && seq.Count <= 2 ? OtherHash.GetInstance((object) seq[0].ToAsn1Object()) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    if (seq.Count <= 1)
      return;
    this.issuerSerial = IssuerSerial.GetInstance((object) seq[1].ToAsn1Object());
  }

  public OtherCertID(OtherHash otherCertHash)
    : this(otherCertHash, (IssuerSerial) null)
  {
  }

  public OtherCertID(OtherHash otherCertHash, IssuerSerial issuerSerial)
  {
    this.otherCertHash = otherCertHash != null ? otherCertHash : throw new ArgumentNullException(nameof (otherCertHash));
    this.issuerSerial = issuerSerial;
  }

  public OtherHash OtherCertHash => this.otherCertHash;

  public IssuerSerial IssuerSerial => this.issuerSerial;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.otherCertHash.ToAsn1Object());
    if (this.issuerSerial != null)
      elementVector.Add((Asn1Encodable) this.issuerSerial.ToAsn1Object());
    return (Asn1Object) new DerSequence(elementVector);
  }
}
