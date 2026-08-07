// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.PolicyQualifierInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class PolicyQualifierInfo : Asn1Encodable
{
  private readonly DerObjectIdentifier policyQualifierId;
  private readonly Asn1Encodable qualifier;

  public PolicyQualifierInfo(DerObjectIdentifier policyQualifierId, Asn1Encodable qualifier)
  {
    this.policyQualifierId = policyQualifierId;
    this.qualifier = qualifier;
  }

  public PolicyQualifierInfo(string cps)
  {
    this.policyQualifierId = (DerObjectIdentifier) PolicyQualifierID.IdQtCps;
    this.qualifier = (Asn1Encodable) new DerIA5String(cps);
  }

  private PolicyQualifierInfo(Asn1Sequence seq)
  {
    this.policyQualifierId = seq.Count == 2 ? DerObjectIdentifier.GetInstance((object) seq[0]) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    this.qualifier = seq[1];
  }

  public static PolicyQualifierInfo GetInstance(object obj)
  {
    if (obj is PolicyQualifierInfo)
      return (PolicyQualifierInfo) obj;
    return obj == null ? (PolicyQualifierInfo) null : new PolicyQualifierInfo(Asn1Sequence.GetInstance(obj));
  }

  public virtual DerObjectIdentifier PolicyQualifierId => this.policyQualifierId;

  public virtual Asn1Encodable Qualifier => this.qualifier;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.policyQualifierId, this.qualifier);
  }
}
