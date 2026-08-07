// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.CertBag
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class CertBag : Asn1Encodable
{
  private readonly DerObjectIdentifier m_certID;
  private readonly Asn1Object m_certValue;

  public static CertBag GetInstance(object obj)
  {
    if (obj is CertBag instance)
      return instance;
    return obj == null ? (CertBag) null : new CertBag(Asn1Sequence.GetInstance(obj));
  }

  private CertBag(Asn1Sequence seq)
  {
    this.m_certID = seq.Count == 2 ? DerObjectIdentifier.GetInstance((object) seq[0]) : throw new ArgumentException("Wrong number of elements in sequence", nameof (seq));
    this.m_certValue = Asn1TaggedObject.GetInstance((object) seq[1]).GetObject();
  }

  public CertBag(DerObjectIdentifier certID, Asn1Object certValue)
  {
    this.m_certID = certID;
    this.m_certValue = certValue;
  }

  public virtual DerObjectIdentifier CertID => this.m_certID;

  public virtual Asn1Object CertValue => this.m_certValue;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.m_certID, (Asn1Encodable) new DerTaggedObject(0, (Asn1Encodable) this.m_certValue));
  }
}
