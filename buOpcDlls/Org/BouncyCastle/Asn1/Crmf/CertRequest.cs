// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Crmf.CertRequest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Crmf;

public class CertRequest : Asn1Encodable
{
  private readonly DerInteger certReqId;
  private readonly CertTemplate certTemplate;
  private readonly Controls controls;

  private CertRequest(Asn1Sequence seq)
  {
    this.certReqId = DerInteger.GetInstance((object) seq[0]);
    this.certTemplate = CertTemplate.GetInstance((object) seq[1]);
    if (seq.Count <= 2)
      return;
    this.controls = Controls.GetInstance((object) seq[2]);
  }

  public static CertRequest GetInstance(object obj)
  {
    if (obj is CertRequest)
      return (CertRequest) obj;
    return obj != null ? new CertRequest(Asn1Sequence.GetInstance(obj)) : (CertRequest) null;
  }

  public CertRequest(int certReqId, CertTemplate certTemplate, Controls controls)
    : this(new DerInteger(certReqId), certTemplate, controls)
  {
  }

  public CertRequest(DerInteger certReqId, CertTemplate certTemplate, Controls controls)
  {
    this.certReqId = certReqId;
    this.certTemplate = certTemplate;
    this.controls = controls;
  }

  public virtual DerInteger CertReqID => this.certReqId;

  public virtual CertTemplate CertTemplate => this.certTemplate;

  public virtual Controls Controls => this.controls;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.certReqId, (Asn1Encodable) this.certTemplate);
    elementVector.AddOptional((Asn1Encodable) this.controls);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
