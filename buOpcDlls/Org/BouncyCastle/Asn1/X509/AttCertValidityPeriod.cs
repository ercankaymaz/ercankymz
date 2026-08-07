// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.AttCertValidityPeriod
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class AttCertValidityPeriod : Asn1Encodable
{
  private readonly Asn1GeneralizedTime notBeforeTime;
  private readonly Asn1GeneralizedTime notAfterTime;

  public static AttCertValidityPeriod GetInstance(object obj)
  {
    switch (obj)
    {
      case AttCertValidityPeriod _:
      case null:
        return (AttCertValidityPeriod) obj;
      case Asn1Sequence _:
        return new AttCertValidityPeriod((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public static AttCertValidityPeriod GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return AttCertValidityPeriod.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  private AttCertValidityPeriod(Asn1Sequence seq)
  {
    this.notBeforeTime = seq.Count == 2 ? Asn1GeneralizedTime.GetInstance((object) seq[0]) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    this.notAfterTime = Asn1GeneralizedTime.GetInstance((object) seq[1]);
  }

  public AttCertValidityPeriod(Asn1GeneralizedTime notBeforeTime, Asn1GeneralizedTime notAfterTime)
  {
    this.notBeforeTime = notBeforeTime;
    this.notAfterTime = notAfterTime;
  }

  public Asn1GeneralizedTime NotBeforeTime => this.notBeforeTime;

  public Asn1GeneralizedTime NotAfterTime => this.notAfterTime;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.notBeforeTime, (Asn1Encodable) this.notAfterTime);
  }
}
