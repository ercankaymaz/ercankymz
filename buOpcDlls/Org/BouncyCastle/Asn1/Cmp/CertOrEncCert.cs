// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.CertOrEncCert
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Crmf;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class CertOrEncCert : Asn1Encodable, IAsn1Choice
{
  private readonly CmpCertificate m_certificate;
  private readonly EncryptedKey m_encryptedCert;

  public static CertOrEncCert GetInstance(object obj)
  {
    if (obj == null)
      return (CertOrEncCert) null;
    return obj is CertOrEncCert certOrEncCert ? certOrEncCert : new CertOrEncCert(Asn1TaggedObject.GetInstance(obj));
  }

  public static CertOrEncCert GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return Asn1Utilities.GetInstanceFromChoice<CertOrEncCert>(taggedObject, declaredExplicit, new Func<object, CertOrEncCert>(CertOrEncCert.GetInstance));
  }

  private CertOrEncCert(Asn1TaggedObject taggedObject)
  {
    if (taggedObject.TagNo == 0)
      this.m_certificate = CmpCertificate.GetInstance((object) taggedObject.GetObject());
    else
      this.m_encryptedCert = taggedObject.TagNo == 1 ? EncryptedKey.GetInstance((object) taggedObject.GetObject()) : throw new ArgumentException("unknown tag: " + taggedObject.TagNo.ToString(), nameof (taggedObject));
  }

  public CertOrEncCert(CmpCertificate certificate)
  {
    this.m_certificate = certificate ?? throw new ArgumentNullException(nameof (certificate));
  }

  public CertOrEncCert(EncryptedValue encryptedValue)
  {
    this.m_encryptedCert = new EncryptedKey(encryptedValue ?? throw new ArgumentNullException(nameof (encryptedValue)));
  }

  public CertOrEncCert(EncryptedKey encryptedKey)
  {
    this.m_encryptedCert = encryptedKey ?? throw new ArgumentNullException(nameof (encryptedKey));
  }

  public virtual CmpCertificate Certificate => this.m_certificate;

  public virtual EncryptedKey EncryptedCert => this.m_encryptedCert;

  public override Asn1Object ToAsn1Object()
  {
    if (this.m_certificate != null)
      return (Asn1Object) new DerTaggedObject(true, 0, (Asn1Encodable) this.m_certificate);
    return this.m_encryptedCert != null ? (Asn1Object) new DerTaggedObject(true, 1, (Asn1Encodable) this.m_encryptedCert) : throw new InvalidOperationException();
  }
}
