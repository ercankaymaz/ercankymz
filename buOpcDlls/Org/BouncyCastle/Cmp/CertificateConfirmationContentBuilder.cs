// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cmp.CertificateConfirmationContentBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Cmp;

public sealed class CertificateConfirmationContentBuilder
{
  private static readonly DefaultSignatureAlgorithmIdentifierFinder SigAlgFinder = new DefaultSignatureAlgorithmIdentifierFinder();
  private readonly DefaultDigestAlgorithmIdentifierFinder m_digestAlgFinder;
  private readonly IList<X509Certificate> m_acceptedCerts = (IList<X509Certificate>) new List<X509Certificate>();
  private readonly IList<BigInteger> m_acceptedReqIDs = (IList<BigInteger>) new List<BigInteger>();

  public CertificateConfirmationContentBuilder()
    : this(new DefaultDigestAlgorithmIdentifierFinder())
  {
  }

  public CertificateConfirmationContentBuilder(
    DefaultDigestAlgorithmIdentifierFinder digestAlgFinder)
  {
    this.m_digestAlgFinder = digestAlgFinder;
  }

  public CertificateConfirmationContentBuilder AddAcceptedCertificate(
    X509Certificate certHolder,
    BigInteger certReqId)
  {
    this.m_acceptedCerts.Add(certHolder);
    this.m_acceptedReqIDs.Add(certReqId);
    return this;
  }

  public CertificateConfirmationContent Build()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(this.m_acceptedCerts.Count);
    for (int index = 0; index != this.m_acceptedCerts.Count; ++index)
    {
      X509Certificate acceptedCert = this.m_acceptedCerts[index];
      BigInteger acceptedReqId = this.m_acceptedReqIDs[index];
      byte[] digest = DigestUtilities.CalculateDigest((this.m_digestAlgFinder.Find(CertificateConfirmationContentBuilder.SigAlgFinder.Find(acceptedCert.SigAlgName) ?? throw new CmpException("cannot find algorithm identifier for signature name")) ?? throw new CmpException("cannot find algorithm for digest from signature")).Algorithm, acceptedCert.GetEncoded());
      elementVector.Add((Asn1Encodable) new CertStatus(digest, acceptedReqId));
    }
    return new CertificateConfirmationContent(CertConfirmContent.GetInstance((object) new DerSequence(elementVector)), this.m_digestAlgFinder);
  }
}
