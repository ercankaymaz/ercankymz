// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.CrlSource
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class CrlSource : Asn1Encodable, IAsn1Choice
{
  private readonly DistributionPointName m_dpn;
  private readonly GeneralNames m_issuer;

  public static CrlSource GetInstance(object obj)
  {
    if (obj == null)
      return (CrlSource) null;
    return obj is CrlSource crlSource ? crlSource : new CrlSource(Asn1TaggedObject.GetInstance(obj));
  }

  public static CrlSource GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return Asn1Utilities.GetInstanceFromChoice<CrlSource>(taggedObject, declaredExplicit, new Func<object, CrlSource>(CrlSource.GetInstance));
  }

  private CrlSource(Asn1TaggedObject taggedObject)
  {
    switch (taggedObject.TagNo)
    {
      case 0:
        this.m_dpn = DistributionPointName.GetInstance(taggedObject, true);
        this.m_issuer = (GeneralNames) null;
        break;
      case 1:
        this.m_dpn = (DistributionPointName) null;
        this.m_issuer = GeneralNames.GetInstance(taggedObject, true);
        break;
      default:
        throw new ArgumentException("unknown tag: " + Asn1Utilities.GetTagText(taggedObject));
    }
  }

  public CrlSource(DistributionPointName dpn, GeneralNames issuer)
  {
    this.m_dpn = dpn == null != (issuer == null) ? dpn : throw new ArgumentException("either dpn or issuer must be set");
    this.m_issuer = issuer;
  }

  public virtual DistributionPointName Dpn => this.m_dpn;

  public virtual GeneralNames Issuer => this.m_issuer;

  public override Asn1Object ToAsn1Object()
  {
    if (this.m_dpn != null)
      return (Asn1Object) new DerTaggedObject(true, 0, (Asn1Encodable) this.m_dpn);
    return this.m_issuer != null ? (Asn1Object) new DerTaggedObject(true, 1, (Asn1Encodable) this.m_issuer) : throw new InvalidOperationException();
  }
}
