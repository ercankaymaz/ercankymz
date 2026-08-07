// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.IssuerSerial
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class IssuerSerial : Asn1Encodable
{
  internal readonly GeneralNames issuer;
  internal readonly DerInteger serial;
  internal readonly DerBitString issuerUid;

  public static IssuerSerial GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case IssuerSerial _:
        return (IssuerSerial) obj;
      case Asn1Sequence _:
        return new IssuerSerial((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public static IssuerSerial GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return IssuerSerial.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  private IssuerSerial(Asn1Sequence seq)
  {
    this.issuer = seq.Count == 2 || seq.Count == 3 ? GeneralNames.GetInstance((object) seq[0]) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    this.serial = DerInteger.GetInstance((object) seq[1]);
    if (seq.Count != 3)
      return;
    this.issuerUid = DerBitString.GetInstance((object) seq[2]);
  }

  public IssuerSerial(GeneralNames issuer, DerInteger serial)
  {
    this.issuer = issuer;
    this.serial = serial;
  }

  public GeneralNames Issuer => this.issuer;

  public DerInteger Serial => this.serial;

  public DerBitString IssuerUid => this.issuerUid;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.issuer, (Asn1Encodable) this.serial);
    elementVector.AddOptional((Asn1Encodable) this.issuerUid);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
