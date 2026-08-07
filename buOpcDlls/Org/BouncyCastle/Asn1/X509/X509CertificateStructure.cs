// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.X509CertificateStructure
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class X509CertificateStructure : Asn1Encodable
{
  private readonly TbsCertificateStructure tbsCert;
  private readonly AlgorithmIdentifier sigAlgID;
  private readonly DerBitString sig;

  public static X509CertificateStructure GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return X509CertificateStructure.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static X509CertificateStructure GetInstance(object obj)
  {
    if (obj == null)
      return (X509CertificateStructure) null;
    return obj is X509CertificateStructure certificateStructure ? certificateStructure : new X509CertificateStructure(Asn1Sequence.GetInstance(obj));
  }

  public X509CertificateStructure(
    TbsCertificateStructure tbsCert,
    AlgorithmIdentifier sigAlgID,
    DerBitString sig)
  {
    if (tbsCert == null)
      throw new ArgumentNullException(nameof (tbsCert));
    if (sigAlgID == null)
      throw new ArgumentNullException(nameof (sigAlgID));
    if (sig == null)
      throw new ArgumentNullException(nameof (sig));
    this.tbsCert = tbsCert;
    this.sigAlgID = sigAlgID;
    this.sig = sig;
  }

  private X509CertificateStructure(Asn1Sequence seq)
  {
    this.tbsCert = seq.Count == 3 ? TbsCertificateStructure.GetInstance((object) seq[0]) : throw new ArgumentException("sequence wrong size for a certificate", nameof (seq));
    this.sigAlgID = AlgorithmIdentifier.GetInstance((object) seq[1]);
    this.sig = DerBitString.GetInstance((object) seq[2]);
  }

  public TbsCertificateStructure TbsCertificate => this.tbsCert;

  public int Version => this.tbsCert.Version;

  public DerInteger SerialNumber => this.tbsCert.SerialNumber;

  public X509Name Issuer => this.tbsCert.Issuer;

  public Time StartDate => this.tbsCert.StartDate;

  public Time EndDate => this.tbsCert.EndDate;

  public X509Name Subject => this.tbsCert.Subject;

  public SubjectPublicKeyInfo SubjectPublicKeyInfo => this.tbsCert.SubjectPublicKeyInfo;

  public AlgorithmIdentifier SignatureAlgorithm => this.sigAlgID;

  public DerBitString Signature => this.sig;

  public byte[] GetSignatureOctets() => this.sig.GetOctets();

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence(new Asn1Encodable[3]
    {
      (Asn1Encodable) this.tbsCert,
      (Asn1Encodable) this.sigAlgID,
      (Asn1Encodable) this.sig
    });
  }
}
