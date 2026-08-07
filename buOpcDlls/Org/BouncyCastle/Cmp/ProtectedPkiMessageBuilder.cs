// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cmp.ProtectedPkiMessageBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Cmp;

public sealed class ProtectedPkiMessageBuilder
{
  private readonly PkiHeaderBuilder m_hdrBuilder;
  private PkiBody body;
  private readonly List<InfoTypeAndValue> generalInfos = new List<InfoTypeAndValue>();
  private readonly List<X509Certificate> extraCerts = new List<X509Certificate>();

  public ProtectedPkiMessageBuilder(GeneralName sender, GeneralName recipient)
    : this(PkiHeader.CMP_2000, sender, recipient)
  {
  }

  public ProtectedPkiMessageBuilder(int pvno, GeneralName sender, GeneralName recipient)
  {
    this.m_hdrBuilder = new PkiHeaderBuilder(pvno, sender, recipient);
  }

  public ProtectedPkiMessageBuilder SetTransactionId(byte[] tid)
  {
    this.m_hdrBuilder.SetTransactionID(tid);
    return this;
  }

  public ProtectedPkiMessageBuilder SetFreeText(PkiFreeText freeText)
  {
    this.m_hdrBuilder.SetFreeText(freeText);
    return this;
  }

  public ProtectedPkiMessageBuilder AddGeneralInfo(InfoTypeAndValue genInfo)
  {
    this.generalInfos.Add(genInfo);
    return this;
  }

  public ProtectedPkiMessageBuilder SetMessageTime(DateTime time)
  {
    this.m_hdrBuilder.SetMessageTime(new Asn1GeneralizedTime(time));
    return this;
  }

  public ProtectedPkiMessageBuilder SetMessageTime(Asn1GeneralizedTime generalizedTime)
  {
    this.m_hdrBuilder.SetMessageTime(generalizedTime);
    return this;
  }

  public ProtectedPkiMessageBuilder SetRecipKID(byte[] id)
  {
    this.m_hdrBuilder.SetRecipKID(id);
    return this;
  }

  public ProtectedPkiMessageBuilder SetRecipNonce(byte[] nonce)
  {
    this.m_hdrBuilder.SetRecipNonce(nonce);
    return this;
  }

  public ProtectedPkiMessageBuilder SetSenderKID(byte[] id)
  {
    this.m_hdrBuilder.SetSenderKID(id);
    return this;
  }

  public ProtectedPkiMessageBuilder SetSenderNonce(byte[] nonce)
  {
    this.m_hdrBuilder.SetSenderNonce(nonce);
    return this;
  }

  public ProtectedPkiMessageBuilder SetBody(PkiBody body)
  {
    this.body = body;
    return this;
  }

  public ProtectedPkiMessageBuilder AddCmpCertificate(X509Certificate certificate)
  {
    this.extraCerts.Add(certificate);
    return this;
  }

  public ProtectedPkiMessage Build(ISignatureFactory signatureFactory)
  {
    if (this.body == null)
      throw new InvalidOperationException("body must be set before building");
    if (!(signatureFactory.AlgorithmDetails is AlgorithmIdentifier algorithmDetails))
      throw new ArgumentException("AlgorithmDetails is not AlgorithmIdentifier");
    this.FinalizeHeader(algorithmDetails);
    PkiHeader pkiHeader = this.m_hdrBuilder.Build();
    DerBitString signature = X509Utilities.GenerateSignature(signatureFactory, (Asn1Encodable) new DerSequence((Asn1Encodable) pkiHeader, (Asn1Encodable) this.body));
    return this.FinalizeMessage(pkiHeader, signature);
  }

  public ProtectedPkiMessage Build(IMacFactory macFactory)
  {
    if (this.body == null)
      throw new InvalidOperationException("body must be set before building");
    if (!(macFactory.AlgorithmDetails is AlgorithmIdentifier algorithmDetails))
      throw new ArgumentException("AlgorithmDetails is not AlgorithmIdentifier");
    this.FinalizeHeader(algorithmDetails);
    PkiHeader pkiHeader = this.m_hdrBuilder.Build();
    DerBitString mac = X509Utilities.GenerateMac(macFactory, (Asn1Encodable) new DerSequence((Asn1Encodable) pkiHeader, (Asn1Encodable) this.body));
    return this.FinalizeMessage(pkiHeader, mac);
  }

  private void FinalizeHeader(AlgorithmIdentifier algorithmIdentifier)
  {
    this.m_hdrBuilder.SetProtectionAlg(algorithmIdentifier);
    if (this.generalInfos.Count <= 0)
      return;
    this.m_hdrBuilder.SetGeneralInfo(this.generalInfos.ToArray());
  }

  private ProtectedPkiMessage FinalizeMessage(PkiHeader header, DerBitString protection)
  {
    if (this.extraCerts.Count < 1)
      return new ProtectedPkiMessage(new PkiMessage(header, this.body, protection));
    CmpCertificate[] extraCerts = new CmpCertificate[this.extraCerts.Count];
    for (int index = 0; index < extraCerts.Length; ++index)
      extraCerts[index] = new CmpCertificate(this.extraCerts[index].CertificateStructure);
    return new ProtectedPkiMessage(new PkiMessage(header, this.body, protection, extraCerts));
  }
}
