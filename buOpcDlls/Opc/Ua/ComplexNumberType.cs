// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ComplexNumberType
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
public class ComplexNumberType : IEncodeable, ICloneable, IJsonEncodeable
{
  private float m_real;
  private float m_imaginary;

  public ComplexNumberType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_real = 0.0f;
    this.m_imaginary = 0.0f;
  }

  [DataMember(Name = "Real", IsRequired = false, Order = 1)]
  public float Real
  {
    get => this.m_real;
    set => this.m_real = value;
  }

  [DataMember(Name = "Imaginary", IsRequired = false, Order = 2)]
  public float Imaginary
  {
    get => this.m_imaginary;
    set => this.m_imaginary = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ComplexNumberType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ComplexNumberType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ComplexNumberType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ComplexNumberType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteFloat("Real", this.Real);
    encoder.WriteFloat("Imaginary", this.Imaginary);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Real = decoder.ReadFloat("Real");
    this.Imaginary = decoder.ReadFloat("Imaginary");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ComplexNumberType complexNumberType && Utils.IsEqual((object) this.m_real, (object) complexNumberType.m_real) && Utils.IsEqual((object) this.m_imaginary, (object) complexNumberType.m_imaginary);
  }

  public virtual object Clone() => (object) (ComplexNumberType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ComplexNumberType complexNumberType = (ComplexNumberType) base.MemberwiseClone();
    complexNumberType.m_real = (float) Utils.Clone((object) this.m_real);
    complexNumberType.m_imaginary = (float) Utils.Clone((object) this.m_imaginary);
    return (object) complexNumberType;
  }
}
