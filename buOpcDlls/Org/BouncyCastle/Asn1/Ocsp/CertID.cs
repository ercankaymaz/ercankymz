// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Ocsp.CertID
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Ocsp;

public class CertID : Asn1Encodable
{
  private readonly AlgorithmIdentifier hashAlgorithm;
  private readonly Asn1OctetString issuerNameHash;
  private readonly Asn1OctetString issuerKeyHash;
  private readonly DerInteger serialNumber;

  public static CertID GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return CertID.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static CertID GetInstance(object obj)
  {
    if (obj == null)
      return (CertID) null;
    return obj is CertID certId ? certId : new CertID(Asn1Sequence.GetInstance(obj));
  }

  public CertID(
    AlgorithmIdentifier hashAlgorithm,
    Asn1OctetString issuerNameHash,
    Asn1OctetString issuerKeyHash,
    DerInteger serialNumber)
  {
    this.hashAlgorithm = hashAlgorithm;
    this.issuerNameHash = issuerNameHash;
    this.issuerKeyHash = issuerKeyHash;
    this.serialNumber = serialNumber;
  }

  private CertID(Asn1Sequence seq)
  {
    this.hashAlgorithm = seq.Count == 4 ? AlgorithmIdentifier.GetInstance((object) seq[0]) : throw new ArgumentException("Wrong number of elements in sequence", nameof (seq));
    this.issuerNameHash = Asn1OctetString.GetInstance((object) seq[1]);
    this.issuerKeyHash = Asn1OctetString.GetInstance((object) seq[2]);
    this.serialNumber = DerInteger.GetInstance((object) seq[3]);
  }

  public AlgorithmIdentifier HashAlgorithm => this.hashAlgorithm;

  public Asn1OctetString IssuerNameHash => this.issuerNameHash;

  public Asn1OctetString IssuerKeyHash => this.issuerKeyHash;

  public DerInteger SerialNumber => this.serialNumber;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence(new Asn1Encodable[4]
    {
      (Asn1Encodable) this.hashAlgorithm,
      (Asn1Encodable) this.issuerNameHash,
      (Asn1Encodable) this.issuerKeyHash,
      (Asn1Encodable) this.serialNumber
    });
  }
}
