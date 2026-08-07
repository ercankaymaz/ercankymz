// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crmf.CertificateRequestMessageBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Crmf;

public class CertificateRequestMessageBuilder
{
  private readonly BigInteger _certReqId;
  private X509ExtensionsGenerator _extGenerator;
  private CertTemplateBuilder _templateBuilder;
  private IList<IControl> m_controls = (IList<IControl>) new List<IControl>();
  private ISignatureFactory _popSigner;
  private PKMacBuilder _pkMacBuilder;
  private char[] _password;
  private GeneralName _sender;
  private int _popoType = 2;
  private PopoPrivKey _popoPrivKey;
  private Asn1Null _popRaVerified;
  private PKMacValue _agreeMac;

  public CertificateRequestMessageBuilder(BigInteger certReqId)
  {
    this._certReqId = certReqId;
    this._extGenerator = new X509ExtensionsGenerator();
    this._templateBuilder = new CertTemplateBuilder();
  }

  public CertificateRequestMessageBuilder SetPublicKey(SubjectPublicKeyInfo publicKeyInfo)
  {
    if (publicKeyInfo != null)
      this._templateBuilder.SetPublicKey(publicKeyInfo);
    return this;
  }

  public CertificateRequestMessageBuilder SetIssuer(X509Name issuer)
  {
    if (issuer != null)
      this._templateBuilder.SetIssuer(issuer);
    return this;
  }

  public CertificateRequestMessageBuilder SetSubject(X509Name subject)
  {
    if (subject != null)
      this._templateBuilder.SetSubject(subject);
    return this;
  }

  public CertificateRequestMessageBuilder SetSerialNumber(BigInteger serialNumber)
  {
    if (serialNumber != null)
      this._templateBuilder.SetSerialNumber(new DerInteger(serialNumber));
    return this;
  }

  public CertificateRequestMessageBuilder SetValidity(DateTime? notBefore, DateTime? notAfter)
  {
    this._templateBuilder.SetValidity(new OptionalValidity(CertificateRequestMessageBuilder.CreateTime(notBefore), CertificateRequestMessageBuilder.CreateTime(notAfter)));
    return this;
  }

  public CertificateRequestMessageBuilder AddExtension(
    DerObjectIdentifier oid,
    bool critical,
    Asn1Encodable value)
  {
    this._extGenerator.AddExtension(oid, critical, value);
    return this;
  }

  public CertificateRequestMessageBuilder AddExtension(
    DerObjectIdentifier oid,
    bool critical,
    byte[] value)
  {
    this._extGenerator.AddExtension(oid, critical, value);
    return this;
  }

  public CertificateRequestMessageBuilder AddControl(IControl control)
  {
    this.m_controls.Add(control);
    return this;
  }

  public CertificateRequestMessageBuilder SetProofOfPossessionSignKeySigner(
    ISignatureFactory popoSignatureFactory)
  {
    if (this._popoPrivKey != null || this._popRaVerified != null || this._agreeMac != null)
      throw new InvalidOperationException("only one proof of possession is allowed.");
    this._popSigner = popoSignatureFactory;
    return this;
  }

  public CertificateRequestMessageBuilder SetProofOfPossessionSubsequentMessage(
    SubsequentMessage msg)
  {
    if (this._popoPrivKey != null || this._popRaVerified != null || this._agreeMac != null)
      throw new InvalidOperationException("only one proof of possession is allowed.");
    this._popoType = 2;
    this._popoPrivKey = new PopoPrivKey(msg);
    return this;
  }

  public CertificateRequestMessageBuilder SetProofOfPossessionSubsequentMessage(
    int type,
    SubsequentMessage msg)
  {
    if (this._popoPrivKey != null || this._popRaVerified != null || this._agreeMac != null)
      throw new InvalidOperationException("only one proof of possession is allowed.");
    this._popoType = type == 2 || type == 3 ? type : throw new ArgumentException("type must be ProofOfPossession.TYPE_KEY_ENCIPHERMENT || ProofOfPossession.TYPE_KEY_AGREEMENT");
    this._popoPrivKey = new PopoPrivKey(msg);
    return this;
  }

  public CertificateRequestMessageBuilder SetProofOfPossessionAgreeMac(PKMacValue macValue)
  {
    if (this._popSigner != null || this._popRaVerified != null || this._popoPrivKey != null)
      throw new InvalidOperationException("only one proof of possession allowed");
    this._agreeMac = macValue;
    return this;
  }

  public CertificateRequestMessageBuilder SetProofOfPossessionRaVerified()
  {
    if (this._popSigner != null || this._popoPrivKey != null)
      throw new InvalidOperationException("only one proof of possession allowed");
    this._popRaVerified = (Asn1Null) DerNull.Instance;
    return this;
  }

  [Obsolete("Use 'SetAuthInfoPKMacBuilder' instead")]
  public CertificateRequestMessageBuilder SetAuthInfoPKMAC(
    PKMacBuilder pkmacFactory,
    char[] password)
  {
    return this.SetAuthInfoPKMacBuilder(pkmacFactory, password);
  }

  public CertificateRequestMessageBuilder SetAuthInfoPKMacBuilder(
    PKMacBuilder pkmacFactory,
    char[] password)
  {
    this._pkMacBuilder = pkmacFactory;
    this._password = password;
    return this;
  }

  public CertificateRequestMessageBuilder SetAuthInfoSender(X509Name sender)
  {
    return this.SetAuthInfoSender(new GeneralName(sender));
  }

  public CertificateRequestMessageBuilder SetAuthInfoSender(GeneralName sender)
  {
    this._sender = sender;
    return this;
  }

  public CertificateRequestMessage Build()
  {
    Asn1EncodableVector elementVector1 = new Asn1EncodableVector((Asn1Encodable) new DerInteger(this._certReqId));
    if (!this._extGenerator.IsEmpty)
      this._templateBuilder.SetExtensions(this._extGenerator.Generate());
    elementVector1.Add((Asn1Encodable) this._templateBuilder.Build());
    if (this.m_controls.Count > 0)
    {
      Asn1EncodableVector elementVector2 = new Asn1EncodableVector(this.m_controls.Count);
      foreach (IControl control in (IEnumerable<IControl>) this.m_controls)
        elementVector2.Add((Asn1Encodable) new AttributeTypeAndValue(control.Type, control.Value));
      elementVector1.Add((Asn1Encodable) new DerSequence(elementVector2));
    }
    CertRequest instance = CertRequest.GetInstance((object) new DerSequence(elementVector1));
    Asn1EncodableVector elementVector3 = new Asn1EncodableVector((Asn1Encodable) instance);
    if (this._popSigner != null)
    {
      CertTemplate certTemplate = instance.CertTemplate;
      if (certTemplate.Subject != null && certTemplate.PublicKey != null)
      {
        ProofOfPossessionSigningKeyBuilder signingKeyBuilder = new ProofOfPossessionSigningKeyBuilder(instance);
        elementVector3.Add((Asn1Encodable) new ProofOfPossession(signingKeyBuilder.Build(this._popSigner)));
      }
      else
      {
        ProofOfPossessionSigningKeyBuilder signingKeyBuilder = new ProofOfPossessionSigningKeyBuilder(instance.CertTemplate.PublicKey);
        if (this._sender != null)
          signingKeyBuilder.SetSender(this._sender);
        else
          signingKeyBuilder.SetPublicKeyMac(this._pkMacBuilder, this._password);
        elementVector3.Add((Asn1Encodable) new ProofOfPossession(signingKeyBuilder.Build(this._popSigner)));
      }
    }
    else if (this._popoPrivKey != null)
      elementVector3.Add((Asn1Encodable) new ProofOfPossession(this._popoType, this._popoPrivKey));
    else if (this._agreeMac != null)
      elementVector3.Add((Asn1Encodable) new ProofOfPossession(3, new PopoPrivKey(this._agreeMac)));
    else if (this._popRaVerified != null)
      elementVector3.Add((Asn1Encodable) new ProofOfPossession());
    return new CertificateRequestMessage(CertReqMsg.GetInstance((object) new DerSequence(elementVector3)));
  }

  private static Time CreateTime(DateTime? dateTime)
  {
    return dateTime.HasValue ? new Time(dateTime.Value) : (Time) null;
  }
}
