// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.CertResponse
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class CertResponse : Asn1Encodable
{
  private readonly DerInteger m_certReqId;
  private readonly PkiStatusInfo m_status;
  private readonly CertifiedKeyPair m_certifiedKeyPair;
  private readonly Asn1OctetString m_rspInfo;

  public static CertResponse GetInstance(object obj)
  {
    if (obj == null)
      return (CertResponse) null;
    return obj is CertResponse certResponse ? certResponse : new CertResponse(Asn1Sequence.GetInstance(obj));
  }

  public static CertResponse GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return CertResponse.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private CertResponse(Asn1Sequence seq)
  {
    this.m_certReqId = DerInteger.GetInstance((object) seq[0]);
    this.m_status = PkiStatusInfo.GetInstance((object) seq[1]);
    if (seq.Count < 3)
      return;
    if (seq.Count == 3)
    {
      Asn1Encodable asn1Encodable = seq[2];
      if (asn1Encodable is Asn1OctetString)
        this.m_rspInfo = Asn1OctetString.GetInstance((object) asn1Encodable);
      else
        this.m_certifiedKeyPair = CertifiedKeyPair.GetInstance((object) asn1Encodable);
    }
    else
    {
      this.m_certifiedKeyPair = CertifiedKeyPair.GetInstance((object) seq[2]);
      this.m_rspInfo = Asn1OctetString.GetInstance((object) seq[3]);
    }
  }

  public CertResponse(DerInteger certReqId, PkiStatusInfo status)
    : this(certReqId, status, (CertifiedKeyPair) null, (Asn1OctetString) null)
  {
  }

  public CertResponse(
    DerInteger certReqId,
    PkiStatusInfo status,
    CertifiedKeyPair certifiedKeyPair,
    Asn1OctetString rspInfo)
  {
    if (certReqId == null)
      throw new ArgumentNullException(nameof (certReqId));
    if (status == null)
      throw new ArgumentNullException(nameof (status));
    this.m_certReqId = certReqId;
    this.m_status = status;
    this.m_certifiedKeyPair = certifiedKeyPair;
    this.m_rspInfo = rspInfo;
  }

  public virtual DerInteger CertReqID => this.m_certReqId;

  public virtual PkiStatusInfo Status => this.m_status;

  public virtual CertifiedKeyPair CertifiedKeyPair => this.m_certifiedKeyPair;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.m_certReqId, (Asn1Encodable) this.m_status);
    elementVector.AddOptional((Asn1Encodable) this.m_certifiedKeyPair, (Asn1Encodable) this.m_rspInfo);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
