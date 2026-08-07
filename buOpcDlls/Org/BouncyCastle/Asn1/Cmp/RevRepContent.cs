// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.RevRepContent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class RevRepContent : Asn1Encodable
{
  private readonly Asn1Sequence m_status;
  private readonly Asn1Sequence m_revCerts;
  private readonly Asn1Sequence m_crls;

  public static RevRepContent GetInstance(object obj)
  {
    if (obj == null)
      return (RevRepContent) null;
    return obj is RevRepContent revRepContent ? revRepContent : new RevRepContent(Asn1Sequence.GetInstance(obj));
  }

  public static RevRepContent GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return RevRepContent.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private RevRepContent(Asn1Sequence seq)
  {
    this.m_status = Asn1Sequence.GetInstance((object) seq[0]);
    for (int index = 1; index < seq.Count; ++index)
    {
      Asn1TaggedObject instance = Asn1TaggedObject.GetInstance((object) seq[index]);
      if (instance.HasContextTag(0))
        this.m_revCerts = Asn1Sequence.GetInstance(instance, true);
      else if (instance.HasContextTag(1))
        this.m_crls = Asn1Sequence.GetInstance(instance, true);
    }
  }

  public virtual PkiStatusInfo[] GetStatus()
  {
    return this.m_status.MapElements<PkiStatusInfo>(new Func<Asn1Encodable, PkiStatusInfo>(PkiStatusInfo.GetInstance));
  }

  public virtual CertId[] GetRevCerts()
  {
    return this.m_revCerts?.MapElements<CertId>(new Func<Asn1Encodable, CertId>(CertId.GetInstance));
  }

  public virtual CertificateList[] GetCrls()
  {
    return this.m_crls?.MapElements<CertificateList>(new Func<Asn1Encodable, CertificateList>(CertificateList.GetInstance));
  }

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.m_status);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.m_revCerts);
    elementVector.AddOptionalTagged(true, 1, (Asn1Encodable) this.m_crls);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
