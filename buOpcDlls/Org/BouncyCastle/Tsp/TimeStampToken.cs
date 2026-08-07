// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tsp.TimeStampToken
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Ess;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.Tsp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Security.Certificates;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tsp;

public class TimeStampToken
{
  private readonly CmsSignedData tsToken;
  private readonly SignerInformation tsaSignerInfo;
  private readonly TimeStampTokenInfo tstInfo;
  private readonly TimeStampToken.CertID certID;

  public TimeStampToken(Org.BouncyCastle.Asn1.Cms.ContentInfo contentInfo)
    : this(new CmsSignedData(contentInfo))
  {
  }

  public TimeStampToken(CmsSignedData signedData)
  {
    this.tsToken = signedData;
    if (!this.tsToken.SignedContentType.Equals((Asn1Object) PkcsObjectIdentifiers.IdCTTstInfo))
      throw new TspValidationException("ContentInfo object not for a time stamp.");
    IList<SignerInformation> signers = this.tsToken.GetSignerInfos().GetSigners();
    IEnumerator<SignerInformation> enumerator = signers.Count == 1 ? signers.GetEnumerator() : throw new ArgumentException($"Time-stamp token signed by {signers.Count.ToString()} signers, but it must contain just the TSA signature.");
    enumerator.MoveNext();
    this.tsaSignerInfo = enumerator.Current;
    try
    {
      CmsProcessable signedContent = this.tsToken.SignedContent;
      MemoryStream memoryStream = new MemoryStream();
      MemoryStream outStream = memoryStream;
      signedContent.Write((Stream) outStream);
      this.tstInfo = new TimeStampTokenInfo(TstInfo.GetInstance((object) Asn1Object.FromByteArray(memoryStream.ToArray())));
      Org.BouncyCastle.Asn1.Cms.Attribute signedAttribute = this.tsaSignerInfo.SignedAttributes[PkcsObjectIdentifiers.IdAASigningCertificate];
      if (signedAttribute != null)
      {
        if (signedAttribute.AttrValues[0] is SigningCertificateV2)
          this.certID = new TimeStampToken.CertID(EssCertIDv2.GetInstance((object) SigningCertificateV2.GetInstance((object) signedAttribute.AttrValues[0]).GetCerts()[0]));
        else
          this.certID = new TimeStampToken.CertID(EssCertID.GetInstance((object) SigningCertificate.GetInstance((object) signedAttribute.AttrValues[0]).GetCerts()[0]));
      }
      else
        this.certID = new TimeStampToken.CertID(EssCertIDv2.GetInstance((object) SigningCertificateV2.GetInstance((object) (this.tsaSignerInfo.SignedAttributes[PkcsObjectIdentifiers.IdAASigningCertificateV2] ?? throw new TspValidationException("no signing certificate attribute found, time stamp invalid.")).AttrValues[0]).GetCerts()[0]));
    }
    catch (CmsException ex)
    {
      throw new TspException(ex.Message, ex.InnerException);
    }
  }

  public TimeStampTokenInfo TimeStampInfo => this.tstInfo;

  public SignerID SignerID => this.tsaSignerInfo.SignerID;

  public Org.BouncyCastle.Asn1.Cms.AttributeTable SignedAttributes
  {
    get => this.tsaSignerInfo.SignedAttributes;
  }

  public Org.BouncyCastle.Asn1.Cms.AttributeTable UnsignedAttributes
  {
    get => this.tsaSignerInfo.UnsignedAttributes;
  }

  public IStore<X509V2AttributeCertificate> GetAttributeCertificates()
  {
    return this.tsToken.GetAttributeCertificates();
  }

  public IStore<X509Certificate> GetCertificates() => this.tsToken.GetCertificates();

  public IStore<X509Crl> GetCrls() => this.tsToken.GetCrls();

  public void Validate(X509Certificate cert)
  {
    try
    {
      byte[] digest = DigestUtilities.CalculateDigest(this.certID.GetHashAlgorithmName(), cert.GetEncoded());
      if (!Arrays.FixedTimeEquals(this.certID.GetCertHash(), digest))
        throw new TspValidationException("certificate hash does not match certID hash.");
      if (this.certID.IssuerSerial != null)
      {
        if (!this.certID.IssuerSerial.Serial.HasValue(cert.SerialNumber))
          throw new TspValidationException("certificate serial number does not match certID for signature.");
        GeneralName[] names = this.certID.IssuerSerial.Issuer.GetNames();
        X509Name issuerX509Principal = PrincipalUtilities.GetIssuerX509Principal(cert);
        bool flag = false;
        for (int index = 0; index != names.Length; ++index)
        {
          if (names[index].TagNo == 4 && X509Name.GetInstance((object) names[index].Name).Equivalent(issuerX509Principal))
          {
            flag = true;
            break;
          }
        }
        if (!flag)
          throw new TspValidationException("certificate name does not match certID for signature. ");
      }
      TspUtil.ValidateCertificate(cert);
      cert.CheckValidity(this.tstInfo.GenTime);
      if (!this.tsaSignerInfo.Verify(cert))
        throw new TspValidationException("signature not created by certificate.");
    }
    catch (CmsException ex)
    {
      if (ex.InnerException != null)
        throw new TspException(ex.Message, ex.InnerException);
      throw new TspException("CMS exception: " + ex?.ToString(), (Exception) ex);
    }
    catch (CertificateEncodingException ex)
    {
      throw new TspException("problem processing certificate: " + ex?.ToString(), (Exception) ex);
    }
    catch (SecurityUtilityException ex)
    {
      throw new TspException("cannot find algorithm: " + ex.Message, (Exception) ex);
    }
  }

  public CmsSignedData ToCmsSignedData() => this.tsToken;

  public byte[] GetEncoded() => this.tsToken.GetEncoded("DER");

  public byte[] GetEncoded(string encoding) => this.tsToken.GetEncoded(encoding);

  private class CertID
  {
    private EssCertID certID;
    private EssCertIDv2 certIDv2;

    internal CertID(EssCertID certID)
    {
      this.certID = certID;
      this.certIDv2 = (EssCertIDv2) null;
    }

    internal CertID(EssCertIDv2 certID)
    {
      this.certIDv2 = certID;
      this.certID = (EssCertID) null;
    }

    public string GetHashAlgorithmName()
    {
      if (this.certID != null)
        return "SHA-1";
      return NistObjectIdentifiers.IdSha256.Equals((Asn1Object) this.certIDv2.HashAlgorithm.Algorithm) ? "SHA-256" : this.certIDv2.HashAlgorithm.Algorithm.Id;
    }

    public AlgorithmIdentifier GetHashAlgorithm()
    {
      return this.certID == null ? this.certIDv2.HashAlgorithm : new AlgorithmIdentifier(OiwObjectIdentifiers.IdSha1);
    }

    public byte[] GetCertHash()
    {
      return this.certID == null ? this.certIDv2.GetCertHash() : this.certID.GetCertHash();
    }

    public IssuerSerial IssuerSerial
    {
      get => this.certID == null ? this.certIDv2.IssuerSerial : this.certID.IssuerSerial;
    }
  }
}
