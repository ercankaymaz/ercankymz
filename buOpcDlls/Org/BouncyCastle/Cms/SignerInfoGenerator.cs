// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.SignerInfoGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.X509;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class SignerInfoGenerator
{
  internal X509Certificate certificate;
  internal ISignatureFactory contentSigner;
  internal SignerIdentifier sigId;
  internal CmsAttributeTableGenerator signedGen;
  internal CmsAttributeTableGenerator unsignedGen;
  private bool isDirectSignature;

  internal SignerInfoGenerator(SignerIdentifier sigId, ISignatureFactory signerFactory)
    : this(sigId, signerFactory, false)
  {
  }

  internal SignerInfoGenerator(
    SignerIdentifier sigId,
    ISignatureFactory signerFactory,
    bool isDirectSignature)
  {
    this.sigId = sigId;
    this.contentSigner = signerFactory;
    this.isDirectSignature = isDirectSignature;
    if (this.isDirectSignature)
    {
      this.signedGen = (CmsAttributeTableGenerator) null;
      this.unsignedGen = (CmsAttributeTableGenerator) null;
    }
    else
    {
      this.signedGen = (CmsAttributeTableGenerator) new DefaultSignedAttributeTableGenerator();
      this.unsignedGen = (CmsAttributeTableGenerator) null;
    }
  }

  internal SignerInfoGenerator(
    SignerIdentifier sigId,
    ISignatureFactory contentSigner,
    CmsAttributeTableGenerator signedGen,
    CmsAttributeTableGenerator unsignedGen)
  {
    this.sigId = sigId;
    this.contentSigner = contentSigner;
    this.signedGen = signedGen;
    this.unsignedGen = unsignedGen;
    this.isDirectSignature = false;
  }

  internal void SetAssociatedCertificate(X509Certificate certificate)
  {
    this.certificate = certificate;
  }

  public SignerInfoGeneratorBuilder NewBuilder()
  {
    SignerInfoGeneratorBuilder generatorBuilder = new SignerInfoGeneratorBuilder();
    generatorBuilder.WithSignedAttributeGenerator(this.signedGen);
    generatorBuilder.WithUnsignedAttributeGenerator(this.unsignedGen);
    generatorBuilder.SetDirectSignature(this.isDirectSignature);
    return generatorBuilder;
  }
}
