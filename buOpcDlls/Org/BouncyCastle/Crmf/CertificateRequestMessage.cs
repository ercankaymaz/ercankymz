// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crmf.CertificateRequestMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Crmf;

public class CertificateRequestMessage
{
  public static readonly int popRaVerified = 0;
  public static readonly int popSigningKey = 1;
  public static readonly int popKeyEncipherment = 2;
  public static readonly int popKeyAgreement = 3;
  private readonly CertReqMsg certReqMsg;
  private readonly Controls controls;

  private static CertReqMsg ParseBytes(byte[] encoding)
  {
    return CertReqMsg.GetInstance((object) encoding);
  }

  public CertificateRequestMessage(byte[] encoded)
    : this(CertReqMsg.GetInstance((object) encoded))
  {
  }

  public CertificateRequestMessage(CertReqMsg certReqMsg)
  {
    this.certReqMsg = certReqMsg;
    this.controls = certReqMsg.CertReq.Controls;
  }

  public CertReqMsg ToAsn1Structure() => this.certReqMsg;

  public CertTemplate GetCertTemplate() => this.certReqMsg.CertReq.CertTemplate;

  public bool HasControls => this.controls != null;

  public bool HasControl(DerObjectIdentifier objectIdentifier)
  {
    return this.FindControl(objectIdentifier) != null;
  }

  public IControl GetControl(DerObjectIdentifier type)
  {
    AttributeTypeAndValue control = this.FindControl(type);
    if (control != null)
    {
      if (control.Type.Equals((Asn1Object) CrmfObjectIdentifiers.id_regCtrl_pkiArchiveOptions))
        return (IControl) new PkiArchiveControl(PkiArchiveOptions.GetInstance((object) control.Value));
      if (control.Type.Equals((Asn1Object) CrmfObjectIdentifiers.id_regCtrl_regToken))
        return (IControl) new RegTokenControl(DerUtf8String.GetInstance((object) control.Value));
      if (control.Type.Equals((Asn1Object) CrmfObjectIdentifiers.id_regCtrl_authenticator))
        return (IControl) new AuthenticatorControl(DerUtf8String.GetInstance((object) control.Value));
    }
    return (IControl) null;
  }

  public AttributeTypeAndValue FindControl(DerObjectIdentifier type)
  {
    if (this.controls == null)
      return (AttributeTypeAndValue) null;
    AttributeTypeAndValue[] typeAndValueArray = this.controls.ToAttributeTypeAndValueArray();
    AttributeTypeAndValue control = (AttributeTypeAndValue) null;
    for (int index = 0; index < typeAndValueArray.Length; ++index)
    {
      if (typeAndValueArray[index].Type.Equals((Asn1Object) type))
      {
        control = typeAndValueArray[index];
        break;
      }
    }
    return control;
  }

  public bool HasProofOfPossession => this.certReqMsg.Popo != null;

  public int ProofOfPossession => this.certReqMsg.Popo.Type;

  public bool HasSigningKeyProofOfPossessionWithPkMac
  {
    get
    {
      Org.BouncyCastle.Asn1.Crmf.ProofOfPossession popo = this.certReqMsg.Popo;
      return popo.Type == CertificateRequestMessage.popSigningKey && PopoSigningKey.GetInstance((object) popo.Object).PoposkInput.PublicKeyMac != null;
    }
  }

  public bool IsValidSigningKeyPop(IVerifierFactoryProvider verifierProvider)
  {
    Org.BouncyCastle.Asn1.Crmf.ProofOfPossession popo = this.certReqMsg.Popo;
    if (popo.Type != CertificateRequestMessage.popSigningKey)
      throw new InvalidOperationException("not Signing Key type of proof of possession");
    PopoSigningKey instance = PopoSigningKey.GetInstance((object) popo.Object);
    if (instance.PoposkInput != null && instance.PoposkInput.PublicKeyMac != null)
      throw new InvalidOperationException("verification requires password check");
    return this.VerifySignature(verifierProvider, instance);
  }

  private bool VerifySignature(
    IVerifierFactoryProvider verifierFactoryProvider,
    PopoSigningKey signKey)
  {
    return X509Utilities.VerifySignature(verifierFactoryProvider.CreateVerifierFactory((object) signKey.AlgorithmIdentifier), (Asn1Encodable) signKey.PoposkInput ?? (Asn1Encodable) this.certReqMsg.CertReq, signKey.Signature);
  }

  public byte[] GetEncoded() => this.certReqMsg.GetEncoded();
}
