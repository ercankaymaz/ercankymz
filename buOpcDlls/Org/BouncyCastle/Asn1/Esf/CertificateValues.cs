// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.CertificateValues
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class CertificateValues : Asn1Encodable
{
  private readonly Asn1Sequence m_certificates;

  public static CertificateValues GetInstance(object obj)
  {
    if (obj == null)
      return (CertificateValues) null;
    return obj is CertificateValues certificateValues ? certificateValues : new CertificateValues(Asn1Sequence.GetInstance(obj));
  }

  public static CertificateValues GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return CertificateValues.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private CertificateValues(Asn1Sequence seq)
  {
    if (seq == null)
      throw new ArgumentNullException(nameof (seq));
    seq.MapElements<X509CertificateStructure>((Func<Asn1Encodable, X509CertificateStructure>) (element => X509CertificateStructure.GetInstance((object) element.ToAsn1Object())));
    this.m_certificates = seq;
  }

  public CertificateValues(params X509CertificateStructure[] certificates)
  {
    this.m_certificates = certificates != null ? (Asn1Sequence) new DerSequence((Asn1Encodable[]) certificates) : throw new ArgumentNullException(nameof (certificates));
  }

  public CertificateValues(IEnumerable<X509CertificateStructure> certificates)
  {
    this.m_certificates = certificates != null ? (Asn1Sequence) new DerSequence(Asn1EncodableVector.FromEnumerable((IEnumerable<Asn1Encodable>) certificates)) : throw new ArgumentNullException(nameof (certificates));
  }

  public X509CertificateStructure[] GetCertificates()
  {
    return this.m_certificates.MapElements<X509CertificateStructure>((Func<Asn1Encodable, X509CertificateStructure>) (element => X509CertificateStructure.GetInstance((object) element.ToAsn1Object())));
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.m_certificates;
}
