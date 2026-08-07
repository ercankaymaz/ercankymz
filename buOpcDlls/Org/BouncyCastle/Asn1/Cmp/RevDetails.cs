// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.RevDetails
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Asn1.X509;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class RevDetails : Asn1Encodable
{
  private readonly CertTemplate m_certDetails;
  private readonly X509Extensions m_crlEntryDetails;

  public static RevDetails GetInstance(object obj)
  {
    if (obj == null)
      return (RevDetails) null;
    return obj is RevDetails revDetails ? revDetails : new RevDetails(Asn1Sequence.GetInstance(obj));
  }

  public static RevDetails GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return RevDetails.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private RevDetails(Asn1Sequence seq)
  {
    this.m_certDetails = CertTemplate.GetInstance((object) seq[0]);
    if (seq.Count <= 1)
      return;
    this.m_crlEntryDetails = X509Extensions.GetInstance((object) seq[1]);
  }

  public RevDetails(CertTemplate certDetails)
    : this(certDetails, (X509Extensions) null)
  {
  }

  public RevDetails(CertTemplate certDetails, X509Extensions crlEntryDetails)
  {
    this.m_certDetails = certDetails;
    this.m_crlEntryDetails = crlEntryDetails;
  }

  public virtual CertTemplate CertDetails => this.m_certDetails;

  public virtual X509Extensions CrlEntryDetails => this.m_crlEntryDetails;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.m_certDetails);
    elementVector.AddOptional((Asn1Encodable) this.m_crlEntryDetails);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
