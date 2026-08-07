// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.PrivateKeyUsagePeriod
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class PrivateKeyUsagePeriod : Asn1Encodable
{
  private Asn1GeneralizedTime _notBefore;
  private Asn1GeneralizedTime _notAfter;

  public static PrivateKeyUsagePeriod GetInstance(object obj)
  {
    switch (obj)
    {
      case PrivateKeyUsagePeriod _:
        return (PrivateKeyUsagePeriod) obj;
      case Asn1Sequence _:
        return new PrivateKeyUsagePeriod((Asn1Sequence) obj);
      case X509Extension _:
        return PrivateKeyUsagePeriod.GetInstance((object) X509Extension.ConvertValueToObject((X509Extension) obj));
      default:
        throw new ArgumentException("unknown object in GetInstance: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private PrivateKeyUsagePeriod(Asn1Sequence seq)
  {
    foreach (Asn1TaggedObject taggedObject in seq)
    {
      if (taggedObject.TagNo == 0)
        this._notBefore = Asn1GeneralizedTime.GetInstance(taggedObject, false);
      else if (taggedObject.TagNo == 1)
        this._notAfter = Asn1GeneralizedTime.GetInstance(taggedObject, false);
    }
  }

  public Asn1GeneralizedTime NotBefore => this._notBefore;

  public Asn1GeneralizedTime NotAfter => this._notAfter;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(2);
    elementVector.AddOptionalTagged(false, 0, (Asn1Encodable) this._notBefore);
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this._notAfter);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
