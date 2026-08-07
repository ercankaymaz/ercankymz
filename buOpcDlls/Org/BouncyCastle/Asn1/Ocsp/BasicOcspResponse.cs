// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Ocsp.BasicOcspResponse
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Ocsp;

public class BasicOcspResponse : Asn1Encodable
{
  private readonly ResponseData tbsResponseData;
  private readonly AlgorithmIdentifier signatureAlgorithm;
  private readonly DerBitString signature;
  private readonly Asn1Sequence certs;

  public static BasicOcspResponse GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return BasicOcspResponse.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static BasicOcspResponse GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case BasicOcspResponse _:
        return (BasicOcspResponse) obj;
      case Asn1Sequence _:
        return new BasicOcspResponse((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public BasicOcspResponse(
    ResponseData tbsResponseData,
    AlgorithmIdentifier signatureAlgorithm,
    DerBitString signature,
    Asn1Sequence certs)
  {
    this.tbsResponseData = tbsResponseData;
    this.signatureAlgorithm = signatureAlgorithm;
    this.signature = signature;
    this.certs = certs;
  }

  private BasicOcspResponse(Asn1Sequence seq)
  {
    this.tbsResponseData = ResponseData.GetInstance((object) seq[0]);
    this.signatureAlgorithm = AlgorithmIdentifier.GetInstance((object) seq[1]);
    this.signature = (DerBitString) seq[2];
    if (seq.Count <= 3)
      return;
    this.certs = Asn1Sequence.GetInstance((Asn1TaggedObject) seq[3], true);
  }

  public ResponseData TbsResponseData => this.tbsResponseData;

  public AlgorithmIdentifier SignatureAlgorithm => this.signatureAlgorithm;

  public DerBitString Signature => this.signature;

  public byte[] GetSignatureOctets() => this.signature.GetOctets();

  public Asn1Sequence Certs => this.certs;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(new Asn1Encodable[3]
    {
      (Asn1Encodable) this.tbsResponseData,
      (Asn1Encodable) this.signatureAlgorithm,
      (Asn1Encodable) this.signature
    });
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.certs);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
