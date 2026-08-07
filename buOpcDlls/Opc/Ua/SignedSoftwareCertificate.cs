// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SignedSoftwareCertificate
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class SignedSoftwareCertificate : IEncodeable, ICloneable, IJsonEncodeable
{
  private byte[] m_certificateData;
  private byte[] m_signature;

  public SignedSoftwareCertificate() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_certificateData = (byte[]) null;
    this.m_signature = (byte[]) null;
  }

  [DataMember(Name = "CertificateData", IsRequired = false, Order = 1)]
  public byte[] CertificateData
  {
    get => this.m_certificateData;
    set => this.m_certificateData = value;
  }

  [DataMember(Name = "Signature", IsRequired = false, Order = 2)]
  public byte[] Signature
  {
    get => this.m_signature;
    set => this.m_signature = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.SignedSoftwareCertificate;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SignedSoftwareCertificate_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SignedSoftwareCertificate_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SignedSoftwareCertificate_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteByteString("CertificateData", this.CertificateData);
    encoder.WriteByteString("Signature", this.Signature);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.CertificateData = decoder.ReadByteString("CertificateData");
    this.Signature = decoder.ReadByteString("Signature");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is SignedSoftwareCertificate softwareCertificate && Utils.IsEqual((object) this.m_certificateData, (object) softwareCertificate.m_certificateData) && Utils.IsEqual((object) this.m_signature, (object) softwareCertificate.m_signature);
  }

  public virtual object Clone() => (object) (SignedSoftwareCertificate) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    SignedSoftwareCertificate softwareCertificate = (SignedSoftwareCertificate) base.MemberwiseClone();
    softwareCertificate.m_certificateData = (byte[]) Utils.Clone((object) this.m_certificateData);
    softwareCertificate.m_signature = (byte[]) Utils.Clone((object) this.m_signature);
    return (object) softwareCertificate;
  }
}
