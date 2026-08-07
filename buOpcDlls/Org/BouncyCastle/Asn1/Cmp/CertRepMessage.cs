// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.CertRepMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class CertRepMessage : Asn1Encodable
{
  private readonly Asn1Sequence m_caPubs;
  private readonly Asn1Sequence m_response;

  public static CertRepMessage GetInstance(object obj)
  {
    if (obj == null)
      return (CertRepMessage) null;
    return obj is CertRepMessage certRepMessage ? certRepMessage : new CertRepMessage(Asn1Sequence.GetInstance(obj));
  }

  public static CertRepMessage GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return CertRepMessage.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private CertRepMessage(Asn1Sequence seq)
  {
    int index = 0;
    if (seq.Count > 1)
      this.m_caPubs = Asn1Sequence.GetInstance((Asn1TaggedObject) seq[index++], true);
    this.m_response = Asn1Sequence.GetInstance((object) seq[index]);
  }

  public CertRepMessage(CmpCertificate[] caPubs, CertResponse[] response)
  {
    if (response == null)
      throw new ArgumentNullException(nameof (response));
    if (caPubs != null)
      this.m_caPubs = (Asn1Sequence) new DerSequence((Asn1Encodable[]) caPubs);
    this.m_response = (Asn1Sequence) new DerSequence((Asn1Encodable[]) response);
  }

  public virtual CmpCertificate[] GetCAPubs()
  {
    return this.m_caPubs != null ? this.m_caPubs.MapElements<CmpCertificate>(new Func<Asn1Encodable, CmpCertificate>(CmpCertificate.GetInstance)) : (CmpCertificate[]) null;
  }

  public virtual CertResponse[] GetResponse()
  {
    return this.m_response.MapElements<CertResponse>(new Func<Asn1Encodable, CertResponse>(CertResponse.GetInstance));
  }

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(2);
    elementVector.AddOptionalTagged(true, 1, (Asn1Encodable) this.m_caPubs);
    elementVector.Add((Asn1Encodable) this.m_response);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
