// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.OtherSigningCertificate
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class OtherSigningCertificate : Asn1Encodable
{
  private readonly Asn1Sequence m_certs;
  private readonly Asn1Sequence m_policies;

  public static OtherSigningCertificate GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (OtherSigningCertificate) null;
      case OtherSigningCertificate instance:
        return instance;
      case Asn1Sequence seq:
        return new OtherSigningCertificate(seq);
      default:
        throw new ArgumentException("Unknown object in 'OtherSigningCertificate' factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private OtherSigningCertificate(Asn1Sequence seq)
  {
    if (seq == null)
      throw new ArgumentNullException(nameof (seq));
    this.m_certs = seq.Count >= 1 && seq.Count <= 2 ? Asn1Sequence.GetInstance((object) seq[0].ToAsn1Object()) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    if (seq.Count <= 1)
      return;
    this.m_policies = Asn1Sequence.GetInstance((object) seq[1].ToAsn1Object());
  }

  public OtherSigningCertificate(params OtherCertID[] certs)
    : this(certs, (PolicyInformation[]) null)
  {
  }

  public OtherSigningCertificate(OtherCertID[] certs, params PolicyInformation[] policies)
  {
    this.m_certs = certs != null ? (Asn1Sequence) new DerSequence((Asn1Encodable[]) certs) : throw new ArgumentNullException(nameof (certs));
    if (policies == null)
      return;
    this.m_policies = (Asn1Sequence) new DerSequence((Asn1Encodable[]) policies);
  }

  public OtherSigningCertificate(IEnumerable<OtherCertID> certs)
    : this(certs, (IEnumerable<PolicyInformation>) null)
  {
  }

  public OtherSigningCertificate(
    IEnumerable<OtherCertID> certs,
    IEnumerable<PolicyInformation> policies)
  {
    this.m_certs = certs != null ? (Asn1Sequence) new DerSequence(Asn1EncodableVector.FromEnumerable((IEnumerable<Asn1Encodable>) certs)) : throw new ArgumentNullException(nameof (certs));
    if (policies == null)
      return;
    this.m_policies = (Asn1Sequence) new DerSequence(Asn1EncodableVector.FromEnumerable((IEnumerable<Asn1Encodable>) policies));
  }

  public OtherCertID[] GetCerts()
  {
    return this.m_certs.MapElements<OtherCertID>((Func<Asn1Encodable, OtherCertID>) (element => OtherCertID.GetInstance((object) element.ToAsn1Object())));
  }

  public PolicyInformation[] GetPolicies()
  {
    return this.m_policies?.MapElements<PolicyInformation>((Func<Asn1Encodable, PolicyInformation>) (element => PolicyInformation.GetInstance((object) element.ToAsn1Object())));
  }

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.m_certs);
    elementVector.AddOptional((Asn1Encodable) this.m_policies);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
