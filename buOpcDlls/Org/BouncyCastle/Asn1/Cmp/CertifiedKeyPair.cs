// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.CertifiedKeyPair
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Crmf;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class CertifiedKeyPair : Asn1Encodable
{
  private readonly CertOrEncCert m_certOrEncCert;
  private readonly EncryptedKey m_privateKey;
  private readonly PkiPublicationInfo m_publicationInfo;

  public static CertifiedKeyPair GetInstance(object obj)
  {
    if (obj == null)
      return (CertifiedKeyPair) null;
    return obj is CertifiedKeyPair certifiedKeyPair ? certifiedKeyPair : new CertifiedKeyPair(Asn1Sequence.GetInstance(obj));
  }

  public static CertifiedKeyPair GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return CertifiedKeyPair.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private CertifiedKeyPair(Asn1Sequence seq)
  {
    this.m_certOrEncCert = CertOrEncCert.GetInstance((object) seq[0]);
    if (seq.Count < 2)
      return;
    if (seq.Count == 2)
    {
      Asn1TaggedObject instance = Asn1TaggedObject.GetInstance((object) seq[1]);
      if (instance.TagNo == 0)
        this.m_privateKey = EncryptedKey.GetInstance((object) instance.GetObject());
      else
        this.m_publicationInfo = PkiPublicationInfo.GetInstance((object) instance.GetObject());
    }
    else
    {
      this.m_privateKey = EncryptedKey.GetInstance((object) Asn1TaggedObject.GetInstance((object) seq[1]).GetObject());
      this.m_publicationInfo = PkiPublicationInfo.GetInstance((object) Asn1TaggedObject.GetInstance((object) seq[2]).GetObject());
    }
  }

  public CertifiedKeyPair(CertOrEncCert certOrEncCert)
    : this(certOrEncCert, (EncryptedKey) null, (PkiPublicationInfo) null)
  {
  }

  public CertifiedKeyPair(
    CertOrEncCert certOrEncCert,
    EncryptedValue privateKey,
    PkiPublicationInfo publicationInfo)
    : this(certOrEncCert, privateKey == null ? (EncryptedKey) null : new EncryptedKey(privateKey), publicationInfo)
  {
  }

  public CertifiedKeyPair(
    CertOrEncCert certOrEncCert,
    EncryptedKey privateKey,
    PkiPublicationInfo publicationInfo)
  {
    this.m_certOrEncCert = certOrEncCert != null ? certOrEncCert : throw new ArgumentNullException(nameof (certOrEncCert));
    this.m_privateKey = privateKey;
    this.m_publicationInfo = publicationInfo;
  }

  public virtual CertOrEncCert CertOrEncCert => this.m_certOrEncCert;

  public virtual EncryptedKey PrivateKey => this.m_privateKey;

  public virtual PkiPublicationInfo PublicationInfo => this.m_publicationInfo;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.m_certOrEncCert);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.m_privateKey);
    elementVector.AddOptionalTagged(true, 1, (Asn1Encodable) this.m_publicationInfo);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
