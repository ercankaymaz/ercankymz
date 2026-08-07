// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.V2TbsCertListGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class V2TbsCertListGenerator
{
  private DerInteger version = new DerInteger(1);
  private AlgorithmIdentifier signature;
  private X509Name issuer;
  private Time thisUpdate;
  private Time nextUpdate;
  private X509Extensions extensions;
  private List<Asn1Sequence> crlEntries;

  public void SetSignature(AlgorithmIdentifier signature) => this.signature = signature;

  public void SetIssuer(X509Name issuer) => this.issuer = issuer;

  public void SetThisUpdate(Asn1UtcTime thisUpdate) => this.thisUpdate = new Time(thisUpdate);

  public void SetNextUpdate(Asn1UtcTime nextUpdate)
  {
    this.nextUpdate = nextUpdate != null ? new Time(nextUpdate) : (Time) null;
  }

  public void SetThisUpdate(Time thisUpdate) => this.thisUpdate = thisUpdate;

  public void SetNextUpdate(Time nextUpdate) => this.nextUpdate = nextUpdate;

  public void AddCrlEntry(Asn1Sequence crlEntry)
  {
    if (this.crlEntries == null)
      this.crlEntries = new List<Asn1Sequence>();
    this.crlEntries.Add(crlEntry);
  }

  public void AddCrlEntry(DerInteger userCertificate, Asn1UtcTime revocationDate, int reason)
  {
    this.AddCrlEntry(userCertificate, new Time(revocationDate), reason);
  }

  public void AddCrlEntry(DerInteger userCertificate, Time revocationDate, int reason)
  {
    this.AddCrlEntry(userCertificate, revocationDate, reason, (Asn1GeneralizedTime) null);
  }

  public void AddCrlEntry(
    DerInteger userCertificate,
    Time revocationDate,
    int reason,
    Asn1GeneralizedTime invalidityDate)
  {
    List<DerObjectIdentifier> oids = new List<DerObjectIdentifier>();
    List<X509Extension> values = new List<X509Extension>();
    if (reason != 0)
    {
      CrlReason crlReason = new CrlReason(reason);
      try
      {
        oids.Add(X509Extensions.ReasonCode);
        values.Add(new X509Extension(false, (Asn1OctetString) new DerOctetString(crlReason.GetEncoded())));
      }
      catch (IOException ex)
      {
        throw new ArgumentException("error encoding reason: " + ex?.ToString());
      }
    }
    if (invalidityDate != null)
    {
      try
      {
        oids.Add(X509Extensions.InvalidityDate);
        values.Add(new X509Extension(false, (Asn1OctetString) new DerOctetString(invalidityDate.GetEncoded())));
      }
      catch (IOException ex)
      {
        throw new ArgumentException("error encoding invalidityDate: " + ex?.ToString());
      }
    }
    if (oids.Count != 0)
      this.AddCrlEntry(userCertificate, revocationDate, new X509Extensions((IList<DerObjectIdentifier>) oids, (IList<X509Extension>) values));
    else
      this.AddCrlEntry(userCertificate, revocationDate, (X509Extensions) null);
  }

  public void AddCrlEntry(
    DerInteger userCertificate,
    Time revocationDate,
    X509Extensions extensions)
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) userCertificate, (Asn1Encodable) revocationDate);
    if (extensions != null)
      elementVector.Add((Asn1Encodable) extensions);
    this.AddCrlEntry((Asn1Sequence) new DerSequence(elementVector));
  }

  public void SetExtensions(X509Extensions extensions) => this.extensions = extensions;

  public Asn1Sequence GeneratePreTbsCertList()
  {
    if (this.signature != null)
      throw new InvalidOperationException("signature should not be set in PreTBSCertList generator");
    if (this.issuer == null || this.thisUpdate == null)
      throw new InvalidOperationException("Not all mandatory fields set in V2 PreTBSCertList generator");
    return this.GenerateTbsCertificateStructure();
  }

  public TbsCertificateList GenerateTbsCertList()
  {
    if (this.signature == null || this.issuer == null || this.thisUpdate == null)
      throw new InvalidOperationException("Not all mandatory fields set in V2 TbsCertList generator.");
    return TbsCertificateList.GetInstance((object) this.GenerateTbsCertificateStructure());
  }

  private Asn1Sequence GenerateTbsCertificateStructure()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(7);
    elementVector.Add((Asn1Encodable) this.version);
    elementVector.AddOptional((Asn1Encodable) this.signature);
    elementVector.Add((Asn1Encodable) this.issuer);
    elementVector.Add((Asn1Encodable) this.thisUpdate);
    elementVector.AddOptional((Asn1Encodable) this.nextUpdate);
    if (this.crlEntries != null && this.crlEntries.Count > 0)
      elementVector.Add((Asn1Encodable) new DerSequence((Asn1Encodable[]) this.crlEntries.ToArray()));
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.extensions);
    return (Asn1Sequence) new DerSequence(elementVector);
  }
}
