// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Ocsp.OcspReqGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.IO;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Security.Certificates;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Ocsp;

public class OcspReqGenerator
{
  private List<OcspReqGenerator.RequestObject> list = new List<OcspReqGenerator.RequestObject>();
  private GeneralName requestorName;
  private X509Extensions requestExtensions;

  public void AddRequest(CertificateID certId)
  {
    this.list.Add(new OcspReqGenerator.RequestObject(certId, (X509Extensions) null));
  }

  public void AddRequest(CertificateID certId, X509Extensions singleRequestExtensions)
  {
    this.list.Add(new OcspReqGenerator.RequestObject(certId, singleRequestExtensions));
  }

  public void SetRequestorName(X509Name requestorName)
  {
    try
    {
      this.requestorName = new GeneralName(4, (Asn1Encodable) requestorName);
    }
    catch (Exception ex)
    {
      throw new ArgumentException("cannot encode principal", ex);
    }
  }

  public void SetRequestorName(GeneralName requestorName) => this.requestorName = requestorName;

  public void SetRequestExtensions(X509Extensions requestExtensions)
  {
    this.requestExtensions = requestExtensions;
  }

  private OcspReq GenerateRequest(
    DerObjectIdentifier signingAlgorithm,
    AsymmetricKeyParameter privateKey,
    X509Certificate[] chain,
    SecureRandom random)
  {
    Asn1EncodableVector elementVector1 = new Asn1EncodableVector(this.list.Count);
    foreach (OcspReqGenerator.RequestObject requestObject in this.list)
    {
      try
      {
        elementVector1.Add((Asn1Encodable) requestObject.ToRequest());
      }
      catch (Exception ex)
      {
        throw new OcspException("exception creating Request", ex);
      }
    }
    TbsRequest tbsRequest = new TbsRequest(this.requestorName, (Asn1Sequence) new DerSequence(elementVector1), this.requestExtensions);
    Org.BouncyCastle.Asn1.Ocsp.Signature optionalSignature = (Org.BouncyCastle.Asn1.Ocsp.Signature) null;
    if (signingAlgorithm != null)
    {
      if (this.requestorName == null)
        throw new OcspException("requestorName must be specified if request is signed.");
      ISigner signer;
      try
      {
        signer = SignerUtilities.InitSigner(signingAlgorithm, true, privateKey, random);
      }
      catch (Exception ex)
      {
        throw new OcspException("exception creating signature: " + ex?.ToString(), ex);
      }
      DerBitString signatureValue;
      try
      {
        tbsRequest.EncodeTo((Stream) new SignerSink(signer), "DER");
        signatureValue = new DerBitString(signer.GenerateSignature());
      }
      catch (Exception ex)
      {
        throw new OcspException("exception processing TBSRequest: " + ex?.ToString(), ex);
      }
      AlgorithmIdentifier signatureAlgorithm = new AlgorithmIdentifier(signingAlgorithm, (Asn1Encodable) DerNull.Instance);
      Asn1Sequence certs = (Asn1Sequence) null;
      if (!Arrays.IsNullOrEmpty((object[]) chain))
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
        certs = (Asn1Sequence) new DerSequence(elementVector2);
      }
      optionalSignature = new Org.BouncyCastle.Asn1.Ocsp.Signature(signatureAlgorithm, signatureValue, certs);
    }
    return new OcspReq(new OcspRequest(tbsRequest, optionalSignature));
  }

  public OcspReq Generate()
  {
    return this.GenerateRequest((DerObjectIdentifier) null, (AsymmetricKeyParameter) null, (X509Certificate[]) null, (SecureRandom) null);
  }

  public OcspReq Generate(
    string signingAlgorithm,
    AsymmetricKeyParameter privateKey,
    X509Certificate[] chain)
  {
    return this.Generate(signingAlgorithm, privateKey, chain, (SecureRandom) null);
  }

  public OcspReq Generate(
    string signingAlgorithm,
    AsymmetricKeyParameter privateKey,
    X509Certificate[] chain,
    SecureRandom random)
  {
    if (signingAlgorithm == null)
      throw new ArgumentException("no signing algorithm specified");
    try
    {
      return this.GenerateRequest(OcspUtilities.GetAlgorithmOid(signingAlgorithm), privateKey, chain, random);
    }
    catch (ArgumentException ex)
    {
      throw new ArgumentException("unknown signing algorithm specified: " + signingAlgorithm);
    }
  }

  public IEnumerable<string> SignatureAlgNames => OcspUtilities.AlgNames;

  private class RequestObject
  {
    internal CertificateID certId;
    internal X509Extensions extensions;

    public RequestObject(CertificateID certId, X509Extensions extensions)
    {
      this.certId = certId;
      this.extensions = extensions;
    }

    public Request ToRequest() => new Request(this.certId.ToAsn1Object(), this.extensions);
  }
}
