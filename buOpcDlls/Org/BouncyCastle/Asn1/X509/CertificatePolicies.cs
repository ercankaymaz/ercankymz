// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.CertificatePolicies
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Text;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class CertificatePolicies : Asn1Encodable
{
  private readonly PolicyInformation[] policyInformation;

  private static PolicyInformation[] Copy(PolicyInformation[] policyInfo)
  {
    return (PolicyInformation[]) policyInfo.Clone();
  }

  public static CertificatePolicies GetInstance(object obj)
  {
    if (obj is CertificatePolicies)
      return (CertificatePolicies) obj;
    return obj == null ? (CertificatePolicies) null : new CertificatePolicies(Asn1Sequence.GetInstance(obj));
  }

  public static CertificatePolicies GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return CertificatePolicies.GetInstance((object) Asn1Sequence.GetInstance(obj, isExplicit));
  }

  public static CertificatePolicies FromExtensions(X509Extensions extensions)
  {
    return CertificatePolicies.GetInstance((object) X509Extensions.GetExtensionParsedValue(extensions, X509Extensions.CertificatePolicies));
  }

  public CertificatePolicies(PolicyInformation name)
  {
    this.policyInformation = new PolicyInformation[1]
    {
      name
    };
  }

  public CertificatePolicies(PolicyInformation[] policyInformation)
  {
    this.policyInformation = CertificatePolicies.Copy(policyInformation);
  }

  private CertificatePolicies(Asn1Sequence seq)
  {
    this.policyInformation = new PolicyInformation[seq.Count];
    for (int index = 0; index < seq.Count; ++index)
      this.policyInformation[index] = PolicyInformation.GetInstance((object) seq[index]);
  }

  public virtual PolicyInformation[] GetPolicyInformation()
  {
    return CertificatePolicies.Copy(this.policyInformation);
  }

  public virtual PolicyInformation GetPolicyInformation(DerObjectIdentifier policyIdentifier)
  {
    for (int index = 0; index != this.policyInformation.Length; ++index)
    {
      if (policyIdentifier.Equals((Asn1Object) this.policyInformation[index].PolicyIdentifier))
        return this.policyInformation[index];
    }
    return (PolicyInformation) null;
  }

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable[]) this.policyInformation);
  }

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder("CertificatePolicies:");
    if (this.policyInformation != null && this.policyInformation.Length != 0)
    {
      stringBuilder.Append(' ');
      stringBuilder.Append((object) this.policyInformation[0]);
      for (int index = 1; index < this.policyInformation.Length; ++index)
      {
        stringBuilder.Append(", ");
        stringBuilder.Append((object) this.policyInformation[index]);
      }
    }
    return stringBuilder.ToString();
  }
}
