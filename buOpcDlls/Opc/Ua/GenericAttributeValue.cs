// Decompiled with JetBrains decompiler
// Type: Opc.Ua.GenericAttributeValue
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
public class GenericAttributeValue : IEncodeable, ICloneable, IJsonEncodeable
{
  private uint m_attributeId;
  private Variant m_value;

  public GenericAttributeValue() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_attributeId = 0U;
    this.m_value = Variant.Null;
  }

  [DataMember(Name = "AttributeId", IsRequired = false, Order = 1)]
  public uint AttributeId
  {
    get => this.m_attributeId;
    set => this.m_attributeId = value;
  }

  [DataMember(Name = "Value", IsRequired = false, Order = 2)]
  public Variant Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.GenericAttributeValue;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.GenericAttributeValue_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.GenericAttributeValue_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.GenericAttributeValue_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("AttributeId", this.AttributeId);
    encoder.WriteVariant("Value", this.Value);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.AttributeId = decoder.ReadUInt32("AttributeId");
    this.Value = decoder.ReadVariant("Value");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is GenericAttributeValue genericAttributeValue && Utils.IsEqual((object) this.m_attributeId, (object) genericAttributeValue.m_attributeId) && Utils.IsEqual((object) this.m_value, (object) genericAttributeValue.m_value);
  }

  public virtual object Clone() => (object) (GenericAttributeValue) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    GenericAttributeValue genericAttributeValue = (GenericAttributeValue) base.MemberwiseClone();
    genericAttributeValue.m_attributeId = (uint) Utils.Clone((object) this.m_attributeId);
    genericAttributeValue.m_value = (Variant) Utils.Clone((object) this.m_value);
    return (object) genericAttributeValue;
  }
}
