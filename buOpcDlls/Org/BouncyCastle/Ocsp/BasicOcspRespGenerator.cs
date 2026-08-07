// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Ocsp.BasicOcspRespGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Operators;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Security.Certificates;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Ocsp;

public class BasicOcspRespGenerator
{
  private readonly List<BasicOcspRespGenerator.ResponseObject> list = new List<BasicOcspRespGenerator.ResponseObject>();
  private X509Extensions responseExtensions;
  private RespID responderID;

  public BasicOcspRespGenerator(RespID responderID) => this.responderID = responderID;

  public BasicOcspRespGenerator(AsymmetricKeyParameter publicKey)
  {
    this.responderID = new RespID(publicKey);
  }

  public void AddResponse(CertificateID certID, CertificateStatus certStatus)
  {
    this.list.Add(new BasicOcspRespGenerator.ResponseObject(certID, certStatus, DateTime.UtcNow, new DateTime?(), (X509Extensions) null));
  }

  public void AddResponse(
    CertificateID certID,
    CertificateStatus certStatus,
    X509Extensions singleExtensions)
  {
    this.list.Add(new BasicOcspRespGenerator.ResponseObject(certID, certStatus, DateTime.UtcNow, new DateTime?(), singleExtensions));
  }

  public void AddResponse(
    CertificateID certID,
    CertificateStatus certStatus,
    DateTime? nextUpdate,
    X509Extensions singleExtensions)
  {
    this.list.Add(new BasicOcspRespGenerator.ResponseObject(certID, certStatus, DateTime.UtcNow, nextUpdate, singleExtensions));
  }

  public void AddResponse(
    CertificateID certID,
    CertificateStatus certStatus,
    DateTime thisUpdate,
    DateTime? nextUpdate,
    X509Extensions singleExtensions)
  {
    this.list.Add(new BasicOcspRespGenerator.ResponseObject(certID, certStatus, thisUpdate, nextUpdate, singleExtensions));
  }

  public void SetResponseExtensions(X509Extensions responseExtensions)
  {
    this.responseExtensions = responseExtensions;
  }

  private BasicOcspResp GenerateResponse(
    ISignatureFactory signatureFactory,
    X509Certificate[] chain,
    DateTime producedAt)
  {
    DerObjectIdentifier algorithm = ((AlgorithmIdentifier) signatureFactory.AlgorithmDetails).Algorithm;
    Asn1EncodableVector elementVector1 = new Asn1EncodableVector();
    foreach (BasicOcspRespGenerator.ResponseObject responseObject in this.list)
    {
      try
      {
        elementVector1.Add((Asn1Encodable) responseObject.ToResponse());
      }
      catch (Exception ex)
      {
        throw new OcspException("exception creating Request", ex);
      }
    }
    ResponseData tbsResponseData = new ResponseData(this.responderID.ToAsn1Object(), new Asn1GeneralizedTime(producedAt), (Asn1Sequence) new DerSequence(elementVector1), this.responseExtensions);
    DerBitString signature;
    try
    {
      signature = Org.BouncyCastle.X509.X509Utilities.GenerateSignature(signatureFactory, (Asn1Encodable) tbsResponseData);
    }
    catch (Exception ex)
    {
      throw new OcspException("exception processing TBSRequest: " + ex?.ToString(), ex);
    }
    AlgorithmIdentifier sigAlgId = OcspUtilities.GetSigAlgID(algorithm);
    DerSequence certs = (DerSequence) null;
    if (chain != null && chain.Length != 0)
    {
      Asn1EncodableVector elementVector2 = new Asn1EncodableVector(chain.Length);
      try
      {
        for (int index = 0; index != chain.Length; ++index)
          elementVector2.Add((Asn1Encodable) chain[index].CertificateStructure);
      }
      catch (IOException ex)
      {
        throw new OcspException("error processing certs", (Exception) ex);
      }
      catch (CertificateEncodingException ex)
      {
        throw new OcspException("error encoding certs", (Exception) ex);
      }
      certs = new DerSequence(elementVector2);
    }
    return new BasicOcspResp(new BasicOcspResponse(tbsResponseData, sigAlgId, signature, (Asn1Sequence) certs));
  }

  public BasicOcspResp Generate(
    string signingAlgorithm,
    AsymmetricKeyParameter privateKey,
    X509Certificate[] chain,
    DateTime thisUpdate)
  {
    return this.Generate(signingAlgorithm, privateKey, chain, thisUpdate, (SecureRandom) null);
  }

  public BasicOcspResp Generate(
    string signingAlgorithm,
    AsymmetricKeyParameter privateKey,
    X509Certificate[] chain,
    DateTime producedAt,
    SecureRandom random)
  {
    if (signingAlgorithm == null)
      throw new ArgumentException("no signing algorithm specified");
    return this.GenerateResponse((ISignatureFactory) new Asn1SignatureFactory(signingAlgorithm, privateKey, random), chain, producedAt);
  }

  public BasicOcspResp Generate(
    ISignatureFactory signatureCalculatorFactory,
    X509Certificate[] chain,
    DateTime producedAt)
  {
    if (signatureCalculatorFactory == null)
      throw new ArgumentException("no signature calculator specified");
    return this.GenerateResponse(signatureCalculatorFactory, chain, producedAt);
  }

  public IEnumerable<string> SignatureAlgNames => OcspUtilities.AlgNames;

  private class ResponseObject
  {
    internal CertificateID certId;
    internal CertStatus certStatus;
    internal Asn1GeneralizedTime thisUpdate;
    internal Asn1GeneralizedTime nextUpdate;
    internal X509Extensions extensions;

    internal ResponseObject(
      CertificateID certId,
      CertificateStatus certStatus,
      DateTime thisUpdate,
      DateTime? nextUpdate,
      X509Extensions extensions)
    {
      this.certId = certId;
      if (certStatus == null)
        this.certStatus = new CertStatus();
      else if (certStatus is UnknownStatus)
      {
        this.certStatus = new CertStatus(2, (Asn1Encodable) DerNull.Instance);
      }
      else
      {
        RevokedStatus revokedStatus = (RevokedStatus) certStatus;
        CrlReason revocationReason = revokedStatus.HasRevocationReason ? new CrlReason(revokedStatus.RevocationReason) : (CrlReason) null;
        this.certStatus = new CertStatus(new RevokedInfo(new Asn1GeneralizedTime(revokedStatus.RevocationTime), revocationReason));
      }
      this.thisUpdate = (Asn1GeneralizedTime) new DerGeneralizedTime(thisUpdate);
      this.nextUpdate = nextUpdate.HasValue ? (Asn1GeneralizedTime) new DerGeneralizedTime(nextUpdate.Value) : (Asn1GeneralizedTime) null;
      this.extensions = extensions;
    }

    public SingleResponse ToResponse()
    {
      return new SingleResponse(this.certId.ToAsn1Object(), this.certStatus, this.thisUpdate, this.nextUpdate, this.extensions);
    }
  }
}
