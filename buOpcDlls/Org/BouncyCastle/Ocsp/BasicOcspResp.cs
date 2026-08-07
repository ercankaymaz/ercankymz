// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Ocsp.BasicOcspResp
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

public class BasicOcspResp : X509ExtensionBase
{
  private readonly BasicOcspResponse resp;
  private readonly ResponseData data;

  public BasicOcspResp(BasicOcspResponse resp)
  {
    this.resp = resp;
    this.data = resp.TbsResponseData;
  }

  public byte[] GetTbsResponseData()
  {
    try
    {
      return this.data.GetDerEncoded();
    }
    catch (IOException ex)
    {
      throw new OcspException("problem encoding tbsResponseData", (Exception) ex);
    }
  }

  public int Version => this.data.Version.IntValueExact + 1;

  public RespID ResponderId => new RespID(this.data.ResponderID);

  public DateTime ProducedAt => this.data.ProducedAt.ToDateTime();

  public SingleResp[] Responses
  {
    get
    {
      Asn1Sequence responses1 = this.data.Responses;
      SingleResp[] responses2 = new SingleResp[responses1.Count];
      for (int index = 0; index != responses2.Length; ++index)
        responses2[index] = new SingleResp(SingleResponse.GetInstance((object) responses1[index]));
      return responses2;
    }
  }

  public X509Extensions ResponseExtensions => this.data.ResponseExtensions;

  protected override X509Extensions GetX509Extensions() => this.ResponseExtensions;

  public string SignatureAlgName
  {
    get => OcspUtilities.GetAlgorithmName(this.resp.SignatureAlgorithm.Algorithm);
  }

  public string SignatureAlgOid => this.resp.SignatureAlgorithm.Algorithm.Id;

  public byte[] GetSignature() => this.resp.GetSignatureOctets();

  private List<X509Certificate> GetCertList()
  {
    List<X509Certificate> certList = new List<X509Certificate>();
    Asn1Sequence certs = this.resp.Certs;
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

  public X509Certificate[] GetCerts() => this.GetCertList().ToArray();

  public IStore<X509Certificate> GetCertificates()
  {
    return CollectionUtilities.CreateStore<X509Certificate>((IEnumerable<X509Certificate>) this.GetCertList());
  }

  public bool Verify(AsymmetricKeyParameter publicKey)
  {
    try
    {
      ISigner signer = SignerUtilities.GetSigner(this.SignatureAlgName);
      signer.Init(false, (ICipherParameters) publicKey);
      byte[] derEncoded = this.data.GetDerEncoded();
      signer.BlockUpdate(derEncoded, 0, derEncoded.Length);
      return signer.VerifySignature(this.GetSignature());
    }
    catch (Exception ex)
    {
      throw new OcspException("exception processing sig: " + ex?.ToString(), ex);
    }
  }

  public byte[] GetEncoded() => this.resp.GetEncoded();

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is BasicOcspResp basicOcspResp && this.resp.Equals((object) basicOcspResp.resp);
  }

  public override int GetHashCode() => this.resp.GetHashCode();
}
