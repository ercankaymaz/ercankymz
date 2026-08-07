// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.CertificationRequest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class CertificationRequest : Asn1Encodable
{
  protected CertificationRequestInfo reqInfo;
  protected AlgorithmIdentifier sigAlgId;
  protected DerBitString sigBits;

  public static CertificationRequest GetInstance(object obj)
  {
    if (obj == null)
      return (CertificationRequest) null;
    return obj is CertificationRequest ? (CertificationRequest) obj : new CertificationRequest(Asn1Sequence.GetInstance(obj));
  }

  protected CertificationRequest()
  {
  }

  public CertificationRequest(
    CertificationRequestInfo requestInfo,
    AlgorithmIdentifier algorithm,
    DerBitString signature)
  {
    this.reqInfo = requestInfo;
    this.sigAlgId = algorithm;
    this.sigBits = signature;
  }

  internal CertificationRequest(Asn1Sequence seq)
  {
    this.reqInfo = seq.Count == 3 ? CertificationRequestInfo.GetInstance((object) seq[0]) : throw new ArgumentException("Wrong number of elements in sequence", nameof (seq));
    this.sigAlgId = AlgorithmIdentifier.GetInstance((object) seq[1]);
    this.sigBits = DerBitString.GetInstance((object) seq[2]);
  }

  public CertificationRequestInfo GetCertificationRequestInfo() => this.reqInfo;

  public AlgorithmIdentifier SignatureAlgorithm => this.sigAlgId;

  public DerBitString Signature => this.sigBits;

  public byte[] GetSignatureOctets() => this.sigBits.GetOctets();

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence(new Asn1Encodable[3]
    {
      (Asn1Encodable) this.reqInfo,
      (Asn1Encodable) this.sigAlgId,
      (Asn1Encodable) this.sigBits
    });
  }
}
