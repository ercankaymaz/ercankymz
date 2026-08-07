// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tsp.TimeStampRequestGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Tsp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Tsp;

public class TimeStampRequestGenerator
{
  private DerObjectIdentifier reqPolicy;
  private DerBoolean certReq;
  private Dictionary<DerObjectIdentifier, X509Extension> m_extensions = new Dictionary<DerObjectIdentifier, X509Extension>();
  private List<DerObjectIdentifier> m_ordering = new List<DerObjectIdentifier>();

  public void SetReqPolicy(string reqPolicy) => this.reqPolicy = new DerObjectIdentifier(reqPolicy);

  public void SetCertReq(bool certReq) => this.certReq = DerBoolean.GetInstance(certReq);

  public virtual void AddExtension(DerObjectIdentifier oid, bool critical, Asn1Encodable extValue)
  {
    this.AddExtension(oid, critical, extValue.GetEncoded());
  }

  public virtual void AddExtension(DerObjectIdentifier oid, bool critical, byte[] extValue)
  {
    this.m_extensions.Add(oid, new X509Extension(critical, (Asn1OctetString) new DerOctetString(extValue)));
    this.m_ordering.Add(oid);
  }

  public TimeStampRequest Generate(string digestAlgorithm, byte[] digest)
  {
    return this.Generate(digestAlgorithm, digest, (BigInteger) null);
  }

  public TimeStampRequest Generate(string digestAlgorithmOid, byte[] digest, BigInteger nonce)
  {
    if (digestAlgorithmOid == null)
      throw new ArgumentException("No digest algorithm specified");
    MessageImprint messageImprint = new MessageImprint(new AlgorithmIdentifier(new DerObjectIdentifier(digestAlgorithmOid), (Asn1Encodable) DerNull.Instance), digest);
    X509Extensions x509Extensions = (X509Extensions) null;
    if (this.m_ordering.Count > 0)
      x509Extensions = new X509Extensions((IList<DerObjectIdentifier>) this.m_ordering, (IDictionary<DerObjectIdentifier, X509Extension>) this.m_extensions);
    DerInteger derInteger = nonce == null ? (DerInteger) null : new DerInteger(nonce);
    DerObjectIdentifier reqPolicy = this.reqPolicy;
    DerInteger nonce1 = derInteger;
    DerBoolean certReq = this.certReq;
    X509Extensions extensions = x509Extensions;
    return new TimeStampRequest(new TimeStampReq(messageImprint, reqPolicy, nonce1, certReq, extensions));
  }

  public virtual TimeStampRequest Generate(DerObjectIdentifier digestAlgorithm, byte[] digest)
  {
    return this.Generate(digestAlgorithm.Id, digest);
  }

  public virtual TimeStampRequest Generate(
    DerObjectIdentifier digestAlgorithm,
    byte[] digest,
    BigInteger nonce)
  {
    return this.Generate(digestAlgorithm.Id, digest, nonce);
  }
}
