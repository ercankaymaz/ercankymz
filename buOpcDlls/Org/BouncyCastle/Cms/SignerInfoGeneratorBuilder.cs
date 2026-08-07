// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.SignerInfoGeneratorBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.X509;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class SignerInfoGeneratorBuilder
{
  private bool directSignature;
  private CmsAttributeTableGenerator signedGen;
  private CmsAttributeTableGenerator unsignedGen;

  public SignerInfoGeneratorBuilder SetDirectSignature(bool hasNoSignedAttributes)
  {
    this.directSignature = hasNoSignedAttributes;
    return this;
  }

  public SignerInfoGeneratorBuilder WithSignedAttributeGenerator(
    CmsAttributeTableGenerator signedGen)
  {
    this.signedGen = signedGen;
    return this;
  }

  public SignerInfoGeneratorBuilder WithUnsignedAttributeGenerator(
    CmsAttributeTableGenerator unsignedGen)
  {
    this.unsignedGen = unsignedGen;
    return this;
  }

  public SignerInfoGenerator Build(ISignatureFactory contentSigner, X509Certificate certificate)
  {
    SignerIdentifier sigId = new SignerIdentifier(new IssuerAndSerialNumber(certificate.IssuerDN, new DerInteger(certificate.SerialNumber)));
    SignerInfoGenerator generator = this.CreateGenerator(contentSigner, sigId);
    generator.SetAssociatedCertificate(certificate);
    return generator;
  }

  public SignerInfoGenerator Build(ISignatureFactory signerFactory, byte[] subjectKeyIdentifier)
  {
    SignerIdentifier sigId = new SignerIdentifier((Asn1OctetString) new DerOctetString(subjectKeyIdentifier));
    return this.CreateGenerator(signerFactory, sigId);
  }

  private SignerInfoGenerator CreateGenerator(
    ISignatureFactory contentSigner,
    SignerIdentifier sigId)
  {
    if (this.directSignature)
      return new SignerInfoGenerator(sigId, contentSigner, true);
    if (this.signedGen == null && this.unsignedGen == null)
      return new SignerInfoGenerator(sigId, contentSigner);
    if (this.signedGen == null)
      this.signedGen = (CmsAttributeTableGenerator) new DefaultSignedAttributeTableGenerator();
    return new SignerInfoGenerator(sigId, contentSigner, this.signedGen, this.unsignedGen);
  }
}
