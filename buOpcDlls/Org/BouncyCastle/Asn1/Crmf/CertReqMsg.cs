// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Crmf.CertReqMsg
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Crmf;

public class CertReqMsg : Asn1Encodable
{
  private readonly CertRequest certReq;
  private readonly ProofOfPossession popo;
  private readonly Asn1Sequence regInfo;

  private CertReqMsg(Asn1Sequence seq)
  {
    this.certReq = CertRequest.GetInstance((object) seq[0]);
    for (int index = 1; index < seq.Count; ++index)
    {
      object obj = (object) seq[index];
      switch (obj)
      {
        case Asn1TaggedObject _:
        case ProofOfPossession _:
          this.popo = ProofOfPossession.GetInstance(obj);
          break;
        default:
          this.regInfo = Asn1Sequence.GetInstance(obj);
          break;
      }
    }
  }

  public static CertReqMsg GetInstance(object obj)
  {
    if (obj is CertReqMsg)
      return (CertReqMsg) obj;
    return obj != null ? new CertReqMsg(Asn1Sequence.GetInstance(obj)) : (CertReqMsg) null;
  }

  public static CertReqMsg GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return CertReqMsg.GetInstance((object) Asn1Sequence.GetInstance(obj, isExplicit));
  }

  public CertReqMsg(CertRequest certReq, ProofOfPossession popo, AttributeTypeAndValue[] regInfo)
  {
    this.certReq = certReq != null ? certReq : throw new ArgumentNullException(nameof (certReq));
    this.popo = popo;
    if (regInfo == null)
      return;
    this.regInfo = (Asn1Sequence) new DerSequence((Asn1Encodable[]) regInfo);
  }

  public virtual CertRequest CertReq => this.certReq;

  public virtual ProofOfPossession Popo => this.popo;

  public virtual AttributeTypeAndValue[] GetRegInfo()
  {
    if (this.regInfo == null)
      return (AttributeTypeAndValue[]) null;
    AttributeTypeAndValue[] regInfo = new AttributeTypeAndValue[this.regInfo.Count];
    for (int index = 0; index != regInfo.Length; ++index)
      regInfo[index] = AttributeTypeAndValue.GetInstance((object) this.regInfo[index]);
    return regInfo;
  }

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.certReq);
    elementVector.AddOptional((Asn1Encodable) this.popo, (Asn1Encodable) this.regInfo);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
