// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.KeyRecRepContent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class KeyRecRepContent : Asn1Encodable
{
  private readonly PkiStatusInfo m_status;
  private readonly CmpCertificate m_newSigCert;
  private readonly Asn1Sequence m_caCerts;
  private readonly Asn1Sequence m_keyPairHist;

  public static KeyRecRepContent GetInstance(object obj)
  {
    if (obj == null)
      return (KeyRecRepContent) null;
    return obj is KeyRecRepContent keyRecRepContent ? keyRecRepContent : new KeyRecRepContent(Asn1Sequence.GetInstance(obj));
  }

  public static KeyRecRepContent GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return KeyRecRepContent.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private KeyRecRepContent(Asn1Sequence seq)
  {
    this.m_status = PkiStatusInfo.GetInstance((object) seq[0]);
    for (int index = 1; index < seq.Count; ++index)
    {
      Asn1TaggedObject instance = Asn1TaggedObject.GetInstance((object) seq[index]);
      switch (instance.TagNo)
      {
        case 0:
          this.m_newSigCert = CmpCertificate.GetInstance((object) instance.GetObject());
          break;
        case 1:
          this.m_caCerts = Asn1Sequence.GetInstance((object) instance.GetObject());
          break;
        case 2:
          this.m_keyPairHist = Asn1Sequence.GetInstance((object) instance.GetObject());
          break;
        default:
          throw new ArgumentException("unknown tag number: " + instance.TagNo.ToString(), nameof (seq));
      }
    }
  }

  public virtual PkiStatusInfo Status => this.m_status;

  public virtual CmpCertificate NewSigCert => this.m_newSigCert;

  public virtual CmpCertificate[] GetCACerts()
  {
    return this.m_caCerts?.MapElements<CmpCertificate>(new Func<Asn1Encodable, CmpCertificate>(CmpCertificate.GetInstance));
  }

  public virtual CertifiedKeyPair[] GetKeyPairHist()
  {
    return this.m_keyPairHist?.MapElements<CertifiedKeyPair>(new Func<Asn1Encodable, CertifiedKeyPair>(CertifiedKeyPair.GetInstance));
  }

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.m_status);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.m_newSigCert);
    elementVector.AddOptionalTagged(true, 1, (Asn1Encodable) this.m_caCerts);
    elementVector.AddOptionalTagged(true, 2, (Asn1Encodable) this.m_keyPairHist);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
