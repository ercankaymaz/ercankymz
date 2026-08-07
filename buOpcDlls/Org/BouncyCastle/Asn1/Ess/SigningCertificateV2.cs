// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Ess.SigningCertificateV2
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Ess;

public class SigningCertificateV2 : Asn1Encodable
{
  private readonly Asn1Sequence certs;
  private readonly Asn1Sequence policies;

  public static SigningCertificateV2 GetInstance(object o)
  {
    switch (o)
    {
      case null:
      case SigningCertificateV2 _:
        return (SigningCertificateV2) o;
      case Asn1Sequence _:
        return new SigningCertificateV2((Asn1Sequence) o);
      default:
        throw new ArgumentException($"unknown object in 'SigningCertificateV2' factory : {Platform.GetTypeName(o)}.");
    }
  }

  private SigningCertificateV2(Asn1Sequence seq)
  {
    this.certs = seq.Count >= 1 && seq.Count <= 2 ? Asn1Sequence.GetInstance((object) seq[0].ToAsn1Object()) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    if (seq.Count <= 1)
      return;
    this.policies = Asn1Sequence.GetInstance((object) seq[1].ToAsn1Object());
  }

  public SigningCertificateV2(EssCertIDv2 cert)
  {
    this.certs = (Asn1Sequence) new DerSequence((Asn1Encodable) cert);
  }

  public SigningCertificateV2(EssCertIDv2[] certs)
  {
    this.certs = (Asn1Sequence) new DerSequence((Asn1Encodable[]) certs);
  }

  public SigningCertificateV2(EssCertIDv2[] certs, PolicyInformation[] policies)
  {
    this.certs = (Asn1Sequence) new DerSequence((Asn1Encodable[]) certs);
    if (policies == null)
      return;
    this.policies = (Asn1Sequence) new DerSequence((Asn1Encodable[]) policies);
  }

  public EssCertIDv2[] GetCerts()
  {
    EssCertIDv2[] certs = new EssCertIDv2[this.certs.Count];
    for (int index = 0; index != this.certs.Count; ++index)
      certs[index] = EssCertIDv2.GetInstance((object) this.certs[index]);
    return certs;
  }

  public PolicyInformation[] GetPolicies()
  {
    if (this.policies == null)
      return (PolicyInformation[]) null;
    PolicyInformation[] policies = new PolicyInformation[this.policies.Count];
    for (int index = 0; index != this.policies.Count; ++index)
      policies[index] = PolicyInformation.GetInstance((object) this.policies[index]);
    return policies;
  }

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.certs);
    elementVector.AddOptional((Asn1Encodable) this.policies);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
