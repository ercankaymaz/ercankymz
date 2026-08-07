// Decompiled with JetBrains decompiler
// Type: Opc.Ua.X509IdentityToken
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class X509IdentityToken : UserIdentityToken
{
  private byte[] m_certificateData;
  private X509Certificate2 m_certificate;

  public X509IdentityToken() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_certificateData = (byte[]) null;

  [DataMember(Name = "CertificateData", IsRequired = false, Order = 1)]
  public byte[] CertificateData
  {
    get => this.m_certificateData;
    set => this.m_certificateData = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.X509IdentityToken;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.X509IdentityToken_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.X509IdentityToken_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.X509IdentityToken_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteByteString("CertificateData", this.CertificateData);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.CertificateData = decoder.ReadByteString("CertificateData");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is X509IdentityToken x509IdentityToken && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_certificateData, (object) x509IdentityToken.m_certificateData) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (X509IdentityToken) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    X509IdentityToken x509IdentityToken = (X509IdentityToken) base.MemberwiseClone();
    x509IdentityToken.m_certificateData = (byte[]) Utils.Clone((object) this.m_certificateData);
    return (object) x509IdentityToken;
  }

  public X509Certificate2 Certificate
  {
    get
    {
      return this.m_certificate == null && this.m_certificateData != null ? CertificateFactory.Create(this.m_certificateData, true) : this.m_certificate;
    }
    set => this.m_certificate = value;
  }

  public override SignatureData Sign(byte[] dataToSign, string securityPolicyUri)
  {
    X509Certificate2 certificate = this.m_certificate ?? CertificateFactory.Create(this.m_certificateData, true);
    SignatureData signatureData = SecurityPolicies.Sign(certificate, securityPolicyUri, dataToSign);
    this.m_certificateData = certificate.RawData;
    return signatureData;
  }

  public override bool Verify(
    byte[] dataToVerify,
    SignatureData signatureData,
    string securityPolicyUri)
  {
    try
    {
      X509Certificate2 certificate = this.m_certificate ?? CertificateFactory.Create(this.m_certificateData, true);
      int num = SecurityPolicies.Verify(certificate, securityPolicyUri, dataToVerify, signatureData) ? 1 : 0;
      this.m_certificateData = certificate.RawData;
      return num != 0;
    }
    catch (Exception ex)
    {
      throw ServiceResultException.Create(2149580800U /*0x80200000*/, ex, "Could not verify user signature!");
    }
  }
}
