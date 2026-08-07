// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.CertificateList
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class CertificateList : Asn1Encodable
{
  private readonly TbsCertificateList tbsCertList;
  private readonly AlgorithmIdentifier sigAlgID;
  private readonly DerBitString sig;

  public static CertificateList GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return CertificateList.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static CertificateList GetInstance(object obj)
  {
    if (obj == null)
      return (CertificateList) null;
    return obj is CertificateList certificateList ? certificateList : new CertificateList(Asn1Sequence.GetInstance(obj));
  }

  private CertificateList(Asn1Sequence seq)
  {
    this.tbsCertList = seq.Count == 3 ? TbsCertificateList.GetInstance((object) seq[0]) : throw new ArgumentException("sequence wrong size for CertificateList", nameof (seq));
    this.sigAlgID = AlgorithmIdentifier.GetInstance((object) seq[1]);
    this.sig = DerBitString.GetInstance((object) seq[2]);
  }

  public TbsCertificateList TbsCertList => this.tbsCertList;

  public CrlEntry[] GetRevokedCertificates() => this.tbsCertList.GetRevokedCertificates();

  public IEnumerable<CrlEntry> GetRevokedCertificateEnumeration()
  {
    return this.tbsCertList.GetRevokedCertificateEnumeration();
  }

  public AlgorithmIdentifier SignatureAlgorithm => this.sigAlgID;

  public DerBitString Signature => this.sig;

  public byte[] GetSignatureOctets() => this.sig.GetOctets();

  public int Version => this.tbsCertList.Version;

  public X509Name Issuer => this.tbsCertList.Issuer;

  public Time ThisUpdate => this.tbsCertList.ThisUpdate;

  public Time NextUpdate => this.tbsCertList.NextUpdate;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence(new Asn1Encodable[3]
    {
      (Asn1Encodable) this.tbsCertList,
      (Asn1Encodable) this.sigAlgID,
      (Asn1Encodable) this.sig
    });
  }
}
