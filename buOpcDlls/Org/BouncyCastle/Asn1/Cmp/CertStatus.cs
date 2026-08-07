// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.CertStatus
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class CertStatus : Asn1Encodable
{
  private readonly Asn1OctetString m_certHash;
  private readonly DerInteger m_certReqID;
  private readonly PkiStatusInfo m_statusInfo;
  private readonly AlgorithmIdentifier m_hashAlg;

  public static CertStatus GetInstance(object obj)
  {
    if (obj == null)
      return (CertStatus) null;
    return obj is CertStatus certStatus ? certStatus : new CertStatus(Asn1Sequence.GetInstance(obj));
  }

  public static CertStatus GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return CertStatus.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private CertStatus(Asn1Sequence seq)
  {
    this.m_certHash = Asn1OctetString.GetInstance((object) seq[0]);
    this.m_certReqID = DerInteger.GetInstance((object) seq[1]);
    if (seq.Count <= 2)
      return;
    for (int index = 2; index < seq.Count; ++index)
    {
      Asn1Object asn1Object = seq[index].ToAsn1Object();
      if (asn1Object is Asn1Sequence asn1Sequence)
        this.m_statusInfo = PkiStatusInfo.GetInstance((object) asn1Sequence);
      if (asn1Object is Asn1TaggedObject asn1TaggedObject)
        this.m_hashAlg = asn1TaggedObject.TagNo == 0 ? AlgorithmIdentifier.GetInstance(asn1TaggedObject, true) : throw new ArgumentException("unknown tag " + asn1TaggedObject.TagNo.ToString());
    }
  }

  public CertStatus(byte[] certHash, BigInteger certReqID)
  {
    this.m_certHash = (Asn1OctetString) new DerOctetString(certHash);
    this.m_certReqID = new DerInteger(certReqID);
  }

  public CertStatus(byte[] certHash, BigInteger certReqID, PkiStatusInfo statusInfo)
  {
    this.m_certHash = (Asn1OctetString) new DerOctetString(certHash);
    this.m_certReqID = new DerInteger(certReqID);
    this.m_statusInfo = statusInfo;
  }

  public CertStatus(
    byte[] certHash,
    BigInteger certReqID,
    PkiStatusInfo statusInfo,
    AlgorithmIdentifier hashAlg)
  {
    this.m_certHash = (Asn1OctetString) new DerOctetString(certHash);
    this.m_certReqID = new DerInteger(certReqID);
    this.m_statusInfo = statusInfo;
    this.m_hashAlg = hashAlg;
  }

  public virtual Asn1OctetString CertHash => this.m_certHash;

  public virtual DerInteger CertReqID => this.m_certReqID;

  public virtual PkiStatusInfo StatusInfo => this.m_statusInfo;

  public virtual AlgorithmIdentifier HashAlg => this.m_hashAlg;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.m_certHash, (Asn1Encodable) this.m_certReqID);
    elementVector.AddOptional((Asn1Encodable) this.m_statusInfo);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.m_hashAlg);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
