// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Ess.EssCertIDv2
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Ess;

public class EssCertIDv2 : Asn1Encodable
{
  private readonly AlgorithmIdentifier hashAlgorithm;
  private readonly byte[] certHash;
  private readonly IssuerSerial issuerSerial;
  private static readonly AlgorithmIdentifier DefaultAlgID = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha256);

  public static EssCertIDv2 GetInstance(object obj)
  {
    if (obj == null)
      return (EssCertIDv2) null;
    return obj is EssCertIDv2 essCertIdv2 ? essCertIdv2 : new EssCertIDv2(Asn1Sequence.GetInstance(obj));
  }

  private EssCertIDv2(Asn1Sequence seq)
  {
    if (seq.Count > 3)
      throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    int num = 0;
    this.hashAlgorithm = !(seq[0] is Asn1OctetString) ? AlgorithmIdentifier.GetInstance((object) seq[num++].ToAsn1Object()) : EssCertIDv2.DefaultAlgID;
    Asn1Sequence asn1Sequence = seq;
    int index1 = num;
    int index2 = index1 + 1;
    this.certHash = Asn1OctetString.GetInstance((object) asn1Sequence[index1].ToAsn1Object()).GetOctets();
    if (seq.Count <= index2)
      return;
    this.issuerSerial = IssuerSerial.GetInstance((object) Asn1Sequence.GetInstance((object) seq[index2].ToAsn1Object()));
  }

  public EssCertIDv2(byte[] certHash)
    : this((AlgorithmIdentifier) null, certHash, (IssuerSerial) null)
  {
  }

  public EssCertIDv2(AlgorithmIdentifier algId, byte[] certHash)
    : this(algId, certHash, (IssuerSerial) null)
  {
  }

  public EssCertIDv2(byte[] certHash, IssuerSerial issuerSerial)
    : this((AlgorithmIdentifier) null, certHash, issuerSerial)
  {
  }

  public EssCertIDv2(AlgorithmIdentifier algId, byte[] certHash, IssuerSerial issuerSerial)
  {
    this.hashAlgorithm = algId != null ? algId : EssCertIDv2.DefaultAlgID;
    this.certHash = certHash;
    this.issuerSerial = issuerSerial;
  }

  public AlgorithmIdentifier HashAlgorithm => this.hashAlgorithm;

  public byte[] GetCertHash() => Arrays.Clone(this.certHash);

  public IssuerSerial IssuerSerial => this.issuerSerial;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(3);
    if (!this.hashAlgorithm.Equals((object) EssCertIDv2.DefaultAlgID))
      elementVector.Add((Asn1Encodable) this.hashAlgorithm);
    elementVector.Add((Asn1Encodable) new DerOctetString(this.certHash).ToAsn1Object());
    elementVector.AddOptional((Asn1Encodable) this.issuerSerial);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
