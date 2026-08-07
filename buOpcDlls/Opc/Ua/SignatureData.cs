// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SignatureData
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
public class SignatureData : IEncodeable, ICloneable, IJsonEncodeable
{
  private string m_algorithm;
  private byte[] m_signature;

  public SignatureData() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_algorithm = (string) null;
    this.m_signature = (byte[]) null;
  }

  [DataMember(Name = "Algorithm", IsRequired = false, Order = 1)]
  public string Algorithm
  {
    get => this.m_algorithm;
    set => this.m_algorithm = value;
  }

  [DataMember(Name = "Signature", IsRequired = false, Order = 2)]
  public byte[] Signature
  {
    get => this.m_signature;
    set => this.m_signature = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.SignatureData;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SignatureData_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SignatureData_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SignatureData_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("Algorithm", this.Algorithm);
    encoder.WriteByteString("Signature", this.Signature);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Algorithm = decoder.ReadString("Algorithm");
    this.Signature = decoder.ReadByteString("Signature");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is SignatureData signatureData && Utils.IsEqual((object) this.m_algorithm, (object) signatureData.m_algorithm) && Utils.IsEqual((object) this.m_signature, (object) signatureData.m_signature);
  }

  public virtual object Clone() => (object) (SignatureData) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    SignatureData signatureData = (SignatureData) base.MemberwiseClone();
    signatureData.m_algorithm = (string) Utils.Clone((object) this.m_algorithm);
    signatureData.m_signature = (byte[]) Utils.Clone((object) this.m_signature);
    return (object) signatureData;
  }
}
