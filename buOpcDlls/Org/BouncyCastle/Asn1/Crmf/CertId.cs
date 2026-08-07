// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Crmf.CertId
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Crmf;

public class CertId : Asn1Encodable
{
  private readonly GeneralName issuer;
  private readonly DerInteger serialNumber;

  private CertId(Asn1Sequence seq)
  {
    this.issuer = GeneralName.GetInstance((object) seq[0]);
    this.serialNumber = DerInteger.GetInstance((object) seq[1]);
  }

  public static CertId GetInstance(object obj)
  {
    switch (obj)
    {
      case CertId _:
        return (CertId) obj;
      case Asn1Sequence _:
        return new CertId((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid object: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public static CertId GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return CertId.GetInstance((object) Asn1Sequence.GetInstance(obj, isExplicit));
  }

  public virtual GeneralName Issuer => this.issuer;

  public virtual DerInteger SerialNumber => this.serialNumber;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.issuer, (Asn1Encodable) this.serialNumber);
  }
}
