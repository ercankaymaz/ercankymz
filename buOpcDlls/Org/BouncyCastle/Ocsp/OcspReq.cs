// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Ocsp.OcspReq
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Ocsp;

public class OcspReq : X509ExtensionBase
{
  private OcspRequest req;

  public OcspReq(OcspRequest req) => this.req = req;

  public OcspReq(byte[] req)
    : this(new Asn1InputStream(req))
  {
  }

  public OcspReq(Stream inStr)
    : this(new Asn1InputStream(inStr))
  {
  }

  private OcspReq(Asn1InputStream aIn)
  {
    try
    {
      this.req = OcspRequest.GetInstance((object) aIn.ReadObject());
    }
    catch (ArgumentException ex)
    {
      throw new IOException("malformed request: " + ex.Message);
    }
    catch (InvalidCastException ex)
    {
      throw new IOException("malformed request: " + ex.Message);
    }
  }

  public byte[] GetTbsRequest()
  {
    try
    {
      return this.req.TbsRequest.GetEncoded();
    }
    catch (IOException ex)
    {
      throw new OcspException("problem encoding tbsRequest", (Exception) ex);
    }
  }

  public int Version => this.req.TbsRequest.Version.IntValueExact + 1;

  public GeneralName RequestorName
  {
    get => GeneralName.GetInstance((object) this.req.TbsRequest.RequestorName);
  }

  public Req[] GetRequestList()
  {
    Asn1Sequence requestList1 = this.req.TbsRequest.RequestList;
    Req[] requestList2 = new Req[requestList1.Count];
    for (int index = 0; index != requestList2.Length; ++index)
      requestList2[index] = new Req(Request.GetInstance((object) requestList1[index]));
    return requestList2;
  }

  public X509Extensions RequestExtensions
  {
    get => X509Extensions.GetInstance((object) this.req.TbsRequest.RequestExtensions);
  }

  protected override X509Extensions GetX509Extensions() => this.RequestExtensions;

  public string SignatureAlgOid
  {
    get
    {
      return !this.IsSigned ? (string) null : this.req.OptionalSignature.SignatureAlgorithm.Algorithm.Id;
    }
  }

  public byte[] GetSignature()
  {
    return !this.IsSigned ? (byte[]) null : this.req.OptionalSignature.GetSignatureOctets();
  }

  private List<X509Certificate> GetCertList()
  {
    List<X509Certificate> certList = new List<X509Certificate>();
    Asn1Sequence certs = this.req.OptionalSignature.Certs;
    if (certs != null)
    {
      foreach (object obj in certs)
      {
        X509CertificateStructure instance = X509CertificateStructure.GetInstance(obj);
        if (instance != null)
          certList.Add(new X509Certificate(instance));
      }
    }
    return certList;
  }

  public X509Certificate[] GetCerts()
  {
    return !this.IsSigned ? (X509Certificate[]) null : this.GetCertList().ToArray();
  }

  public IStore<X509Certificate> GetCertificates()
  {
    return !this.IsSigned ? (IStore<X509Certificate>) null : CollectionUtilities.CreateStore<X509Certificate>((IEnumerable<X509Certificate>) this.GetCertList());
  }

  public bool IsSigned => this.req.OptionalSignature != null;

  public bool Verify(AsymmetricKeyParameter publicKey)
  {
    if (!this.IsSigned)
      throw new OcspException("attempt to Verify signature on unsigned object");
    try
    {
      ISigner signer = SignerUtilities.GetSigner(this.SignatureAlgOid);
      signer.Init(false, (ICipherParameters) publicKey);
      byte[] encoded = this.req.TbsRequest.GetEncoded();
      signer.BlockUpdate(encoded, 0, encoded.Length);
      return signer.VerifySignature(this.GetSignature());
    }
    catch (Exception ex)
    {
      throw new OcspException("exception processing sig: " + ex?.ToString(), ex);
    }
  }

  public byte[] GetEncoded() => this.req.GetEncoded();
}
