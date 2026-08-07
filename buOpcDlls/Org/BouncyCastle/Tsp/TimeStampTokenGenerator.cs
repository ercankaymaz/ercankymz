// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tsp.TimeStampTokenGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Ess;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.Tsp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Operators;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.Utilities.Date;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tsp;

public class TimeStampTokenGenerator
{
  private int accuracySeconds = -1;
  private int accuracyMillis = -1;
  private int accuracyMicros = -1;
  private bool ordering;
  private GeneralName tsa;
  private DerObjectIdentifier tsaPolicyOID;
  private IStore<X509Certificate> x509Certs;
  private IStore<X509Crl> x509Crls;
  private IStore<X509V2AttributeCertificate> x509AttrCerts;
  private SignerInfoGenerator signerInfoGenerator;
  private IDigestFactory digestCalculator;
  private Resolution resolution;

  public Resolution Resolution
  {
    get => this.resolution;
    set => this.resolution = value;
  }

  public TimeStampTokenGenerator(
    AsymmetricKeyParameter key,
    X509Certificate cert,
    string digestOID,
    string tsaPolicyOID)
    : this(key, cert, digestOID, tsaPolicyOID, (Org.BouncyCastle.Asn1.Cms.AttributeTable) null, (Org.BouncyCastle.Asn1.Cms.AttributeTable) null)
  {
  }

  public TimeStampTokenGenerator(
    SignerInfoGenerator signerInfoGen,
    IDigestFactory digestCalculator,
    DerObjectIdentifier tsaPolicy,
    bool isIssuerSerialIncluded)
  {
    this.signerInfoGenerator = signerInfoGen;
    this.digestCalculator = digestCalculator;
    this.tsaPolicyOID = tsaPolicy;
    X509Certificate cert = this.signerInfoGenerator.certificate != null ? this.signerInfoGenerator.certificate : throw new ArgumentException("SignerInfoGenerator must have an associated certificate");
    TspUtil.ValidateCertificate(cert);
    try
    {
      byte[] encoded = cert.GetEncoded();
      IStreamCalculator<IBlockResult> calculator = digestCalculator.CreateCalculator();
      using (Stream stream = calculator.Stream)
        stream.Write(encoded, 0, encoded.Length);
      if (((AlgorithmIdentifier) digestCalculator.AlgorithmDetails).Algorithm.Equals((Asn1Object) OiwObjectIdentifiers.IdSha1))
      {
        EssCertID essCertID = new EssCertID(calculator.GetResult().Collect(), isIssuerSerialIncluded ? new IssuerSerial(new GeneralNames(new GeneralName(cert.IssuerDN)), new DerInteger(cert.SerialNumber)) : (IssuerSerial) null);
        this.signerInfoGenerator = signerInfoGen.NewBuilder().WithSignedAttributeGenerator((CmsAttributeTableGenerator) new TimeStampTokenGenerator.TableGen(signerInfoGen, essCertID)).Build(signerInfoGen.contentSigner, signerInfoGen.certificate);
      }
      else
      {
        AlgorithmIdentifier algorithmIdentifier = new AlgorithmIdentifier(((AlgorithmIdentifier) digestCalculator.AlgorithmDetails).Algorithm);
        EssCertIDv2 essCertID = new EssCertIDv2(calculator.GetResult().Collect(), isIssuerSerialIncluded ? new IssuerSerial(new GeneralNames(new GeneralName(cert.IssuerDN)), new DerInteger(cert.SerialNumber)) : (IssuerSerial) null);
        this.signerInfoGenerator = signerInfoGen.NewBuilder().WithSignedAttributeGenerator((CmsAttributeTableGenerator) new TimeStampTokenGenerator.TableGen2(signerInfoGen, essCertID)).Build(signerInfoGen.contentSigner, signerInfoGen.certificate);
      }
    }
    catch (Exception ex)
    {
      throw new TspException("Exception processing certificate", ex);
    }
  }

  public TimeStampTokenGenerator(
    AsymmetricKeyParameter key,
    X509Certificate cert,
    string digestOID,
    string tsaPolicyOID,
    Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttr,
    Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttr)
    : this(TimeStampTokenGenerator.makeInfoGenerator(key, cert, digestOID, signedAttr, unsignedAttr), (IDigestFactory) Asn1DigestFactory.Get(OiwObjectIdentifiers.IdSha1), tsaPolicyOID != null ? new DerObjectIdentifier(tsaPolicyOID) : (DerObjectIdentifier) null, false)
  {
  }

  internal static SignerInfoGenerator makeInfoGenerator(
    AsymmetricKeyParameter key,
    X509Certificate cert,
    string digestOID,
    Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttr,
    Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttr)
  {
    TspUtil.ValidateCertificate(cert);
    IDictionary<DerObjectIdentifier, object> attrs = signedAttr == null ? (IDictionary<DerObjectIdentifier, object>) new Dictionary<DerObjectIdentifier, object>() : signedAttr.ToDictionary();
    Asn1SignatureFactory contentSigner = new Asn1SignatureFactory($"{CmsSignedHelper.Instance.GetDigestAlgName(digestOID)}with{CmsSignedHelper.Instance.GetEncryptionAlgName(CmsSignedHelper.Instance.GetEncOid(key, digestOID))}", key);
    return new SignerInfoGeneratorBuilder().WithSignedAttributeGenerator((CmsAttributeTableGenerator) new DefaultSignedAttributeTableGenerator(new Org.BouncyCastle.Asn1.Cms.AttributeTable(attrs))).WithUnsignedAttributeGenerator((CmsAttributeTableGenerator) new SimpleAttributeTableGenerator(unsignedAttr)).Build((ISignatureFactory) contentSigner, cert);
  }

  public void SetAttributeCertificates(
    IStore<X509V2AttributeCertificate> attributeCertificates)
  {
    this.x509AttrCerts = attributeCertificates;
  }

  public void SetCertificates(IStore<X509Certificate> certificates)
  {
    this.x509Certs = certificates;
  }

  public void SetCrls(IStore<X509Crl> crls) => this.x509Crls = crls;

  public void SetAccuracySeconds(int accuracySeconds) => this.accuracySeconds = accuracySeconds;

  public void SetAccuracyMillis(int accuracyMillis) => this.accuracyMillis = accuracyMillis;

  public void SetAccuracyMicros(int accuracyMicros) => this.accuracyMicros = accuracyMicros;

  public void SetOrdering(bool ordering) => this.ordering = ordering;

  public void SetTsa(GeneralName tsa) => this.tsa = tsa;

  public TimeStampToken Generate(
    TimeStampRequest request,
    BigInteger serialNumber,
    DateTime genTime)
  {
    return this.Generate(request, serialNumber, genTime, (X509Extensions) null);
  }

  public TimeStampToken Generate(
    TimeStampRequest request,
    BigInteger serialNumber,
    DateTime genTime,
    X509Extensions additionalExtensions)
  {
    MessageImprint messageImprint = new MessageImprint(new AlgorithmIdentifier(new DerObjectIdentifier(request.MessageImprintAlgOid), (Asn1Encodable) DerNull.Instance), request.GetMessageImprintDigest());
    Accuracy accuracy = (Accuracy) null;
    if (this.accuracySeconds > 0 || this.accuracyMillis > 0 || this.accuracyMicros > 0)
    {
      DerInteger seconds = (DerInteger) null;
      if (this.accuracySeconds > 0)
        seconds = new DerInteger(this.accuracySeconds);
      DerInteger millis = (DerInteger) null;
      if (this.accuracyMillis > 0)
        millis = new DerInteger(this.accuracyMillis);
      DerInteger micros = (DerInteger) null;
      if (this.accuracyMicros > 0)
        micros = new DerInteger(this.accuracyMicros);
      accuracy = new Accuracy(seconds, millis, micros);
    }
    DerBoolean ordering = (DerBoolean) null;
    if (this.ordering)
      ordering = DerBoolean.GetInstance(this.ordering);
    DerInteger nonce = (DerInteger) null;
    if (request.Nonce != null)
      nonce = new DerInteger(request.Nonce);
    DerObjectIdentifier tsaPolicyId = this.tsaPolicyOID;
    if (request.ReqPolicy != null)
      tsaPolicyId = new DerObjectIdentifier(request.ReqPolicy);
    if (tsaPolicyId == null)
      throw new TspValidationException("request contains no policy", 256 /*0x0100*/);
    X509Extensions extensions = request.Extensions;
    if (additionalExtensions != null)
    {
      X509ExtensionsGenerator extensionsGenerator = new X509ExtensionsGenerator();
      if (extensions != null)
      {
        foreach (object extensionOid in extensions.ExtensionOids)
        {
          DerObjectIdentifier instance = DerObjectIdentifier.GetInstance(extensionOid);
          extensionsGenerator.AddExtension(instance, extensions.GetExtension(DerObjectIdentifier.GetInstance((object) instance)));
        }
      }
      foreach (object extensionOid in additionalExtensions.ExtensionOids)
      {
        DerObjectIdentifier instance = DerObjectIdentifier.GetInstance(extensionOid);
        extensionsGenerator.AddExtension(instance, additionalExtensions.GetExtension(DerObjectIdentifier.GetInstance((object) instance)));
      }
      extensions = extensionsGenerator.Generate();
    }
    Asn1GeneralizedTime genTime1 = new Asn1GeneralizedTime(TimeStampTokenGenerator.WithResolution(genTime, this.resolution));
    TstInfo tstInfo = new TstInfo(tsaPolicyId, messageImprint, new DerInteger(serialNumber), genTime1, accuracy, ordering, nonce, this.tsa, extensions);
    try
    {
      CmsSignedDataGenerator signedDataGenerator = new CmsSignedDataGenerator();
      byte[] derEncoded = tstInfo.GetDerEncoded();
      if (request.CertReq)
      {
        signedDataGenerator.AddCertificates(this.x509Certs);
        signedDataGenerator.AddAttributeCertificates(this.x509AttrCerts);
      }
      signedDataGenerator.AddCrls(this.x509Crls);
      signedDataGenerator.AddSignerInfoGenerator(this.signerInfoGenerator);
      return new TimeStampToken(signedDataGenerator.Generate(PkcsObjectIdentifiers.IdCTTstInfo.Id, (CmsProcessable) new CmsProcessableByteArray(derEncoded), true));
    }
    catch (CmsException ex)
    {
      throw new TspException("Error generating time-stamp token", (Exception) ex);
    }
    catch (IOException ex)
    {
      throw new TspException("Exception encoding info", (Exception) ex);
    }
  }

  private static DateTime WithResolution(DateTime dateTime, Resolution resolution)
  {
    switch (resolution)
    {
      case Resolution.R_SECONDS:
        return DateTimeUtilities.WithPrecisionSecond(dateTime);
      case Resolution.R_TENTHS_OF_SECONDS:
        return DateTimeUtilities.WithPrecisionDecisecond(dateTime);
      case Resolution.R_HUNDREDTHS_OF_SECONDS:
        return DateTimeUtilities.WithPrecisionCentisecond(dateTime);
      case Resolution.R_MILLISECONDS:
        return DateTimeUtilities.WithPrecisionMillisecond(dateTime);
      default:
        throw new InvalidOperationException();
    }
  }

  private class TableGen : CmsAttributeTableGenerator
  {
    private readonly SignerInfoGenerator infoGen;
    private readonly EssCertID essCertID;

    public TableGen(SignerInfoGenerator infoGen, EssCertID essCertID)
    {
      this.infoGen = infoGen;
      this.essCertID = essCertID;
    }

    public Org.BouncyCastle.Asn1.Cms.AttributeTable GetAttributes(
      IDictionary<CmsAttributeTableParameter, object> parameters)
    {
      Org.BouncyCastle.Asn1.Cms.AttributeTable attributes = this.infoGen.signedGen.GetAttributes(parameters);
      return attributes[PkcsObjectIdentifiers.IdAASigningCertificate] == null ? attributes.Add(PkcsObjectIdentifiers.IdAASigningCertificate, (Asn1Encodable) new SigningCertificate(this.essCertID)) : attributes;
    }
  }

  private class TableGen2 : CmsAttributeTableGenerator
  {
    private readonly SignerInfoGenerator infoGen;
    private readonly EssCertIDv2 essCertID;

    public TableGen2(SignerInfoGenerator infoGen, EssCertIDv2 essCertID)
    {
      this.infoGen = infoGen;
      this.essCertID = essCertID;
    }

    public Org.BouncyCastle.Asn1.Cms.AttributeTable GetAttributes(
      IDictionary<CmsAttributeTableParameter, object> parameters)
    {
      Org.BouncyCastle.Asn1.Cms.AttributeTable attributes = this.infoGen.signedGen.GetAttributes(parameters);
      return attributes[PkcsObjectIdentifiers.IdAASigningCertificateV2] == null ? attributes.Add(PkcsObjectIdentifiers.IdAASigningCertificateV2, (Asn1Encodable) new SigningCertificateV2(this.essCertID)) : attributes;
    }
  }
}
