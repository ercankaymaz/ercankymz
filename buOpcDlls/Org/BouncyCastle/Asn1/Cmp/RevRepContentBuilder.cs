// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.RevRepContentBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class RevRepContentBuilder
{
  private readonly Asn1EncodableVector m_status = new Asn1EncodableVector();
  private readonly Asn1EncodableVector m_revCerts = new Asn1EncodableVector();
  private readonly Asn1EncodableVector m_crls = new Asn1EncodableVector();

  public virtual RevRepContentBuilder Add(PkiStatusInfo status)
  {
    this.m_status.Add((Asn1Encodable) status);
    return this;
  }

  public virtual RevRepContentBuilder Add(PkiStatusInfo status, CertId certId)
  {
    if (this.m_status.Count != this.m_revCerts.Count)
      throw new InvalidOperationException("status and revCerts sequence must be in common order");
    this.m_status.Add((Asn1Encodable) status);
    this.m_revCerts.Add((Asn1Encodable) certId);
    return this;
  }

  public virtual RevRepContentBuilder AddCrl(CertificateList crl)
  {
    this.m_crls.Add((Asn1Encodable) crl);
    return this;
  }

  public virtual RevRepContent Build()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(3);
    elementVector.Add((Asn1Encodable) new DerSequence(this.m_status));
    if (this.m_revCerts.Count != 0)
      elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 0, (Asn1Encodable) new DerSequence(this.m_revCerts)));
    if (this.m_crls.Count != 0)
      elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 1, (Asn1Encodable) new DerSequence(this.m_crls)));
    return RevRepContent.GetInstance((object) new DerSequence(elementVector));
  }
}
