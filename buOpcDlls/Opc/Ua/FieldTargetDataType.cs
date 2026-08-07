// Decompiled with JetBrains decompiler
// Type: Opc.Ua.FieldTargetDataType
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
public class FieldTargetDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private Uuid m_dataSetFieldId;
  private string m_receiverIndexRange;
  private NodeId m_targetNodeId;
  private uint m_attributeId;
  private string m_writeIndexRange;
  private OverrideValueHandling m_overrideValueHandling;
  private Variant m_overrideValue;

  public FieldTargetDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_dataSetFieldId = Uuid.Empty;
    this.m_receiverIndexRange = (string) null;
    this.m_targetNodeId = (NodeId) null;
    this.m_attributeId = 0U;
    this.m_writeIndexRange = (string) null;
    this.m_overrideValueHandling = OverrideValueHandling.Disabled;
    this.m_overrideValue = Variant.Null;
  }

  [DataMember(Name = "DataSetFieldId", IsRequired = false, Order = 1)]
  public Uuid DataSetFieldId
  {
    get => this.m_dataSetFieldId;
    set => this.m_dataSetFieldId = value;
  }

  [DataMember(Name = "ReceiverIndexRange", IsRequired = false, Order = 2)]
  public string ReceiverIndexRange
  {
    get => this.m_receiverIndexRange;
    set => this.m_receiverIndexRange = value;
  }

  [DataMember(Name = "TargetNodeId", IsRequired = false, Order = 3)]
  public NodeId TargetNodeId
  {
    get => this.m_targetNodeId;
    set => this.m_targetNodeId = value;
  }

  [DataMember(Name = "AttributeId", IsRequired = false, Order = 4)]
  public uint AttributeId
  {
    get => this.m_attributeId;
    set => this.m_attributeId = value;
  }

  [DataMember(Name = "WriteIndexRange", IsRequired = false, Order = 5)]
  public string WriteIndexRange
  {
    get => this.m_writeIndexRange;
    set => this.m_writeIndexRange = value;
  }

  [DataMember(Name = "OverrideValueHandling", IsRequired = false, Order = 6)]
  public OverrideValueHandling OverrideValueHandling
  {
    get => this.m_overrideValueHandling;
    set => this.m_overrideValueHandling = value;
  }

  [DataMember(Name = "OverrideValue", IsRequired = false, Order = 7)]
  public Variant OverrideValue
  {
    get => this.m_overrideValue;
    set => this.m_overrideValue = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.FieldTargetDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.FieldTargetDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.FieldTargetDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.FieldTargetDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteGuid("DataSetFieldId", this.DataSetFieldId);
    encoder.WriteString("ReceiverIndexRange", this.ReceiverIndexRange);
    encoder.WriteNodeId("TargetNodeId", this.TargetNodeId);
    encoder.WriteUInt32("AttributeId", this.AttributeId);
    encoder.WriteString("WriteIndexRange", this.WriteIndexRange);
    encoder.WriteEnumerated("OverrideValueHandling", (Enum) this.OverrideValueHandling);
    encoder.WriteVariant("OverrideValue", this.OverrideValue);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.DataSetFieldId = decoder.ReadGuid("DataSetFieldId");
    this.ReceiverIndexRange = decoder.ReadString("ReceiverIndexRange");
    this.TargetNodeId = decoder.ReadNodeId("TargetNodeId");
    this.AttributeId = decoder.ReadUInt32("AttributeId");
    this.WriteIndexRange = decoder.ReadString("WriteIndexRange");
    this.OverrideValueHandling = (OverrideValueHandling) decoder.ReadEnumerated("OverrideValueHandling", typeof (OverrideValueHandling));
    this.OverrideValue = decoder.ReadVariant("OverrideValue");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is FieldTargetDataType fieldTargetDataType && Utils.IsEqual((object) this.m_dataSetFieldId, (object) fieldTargetDataType.m_dataSetFieldId) && Utils.IsEqual((object) this.m_receiverIndexRange, (object) fieldTargetDataType.m_receiverIndexRange) && Utils.IsEqual((object) this.m_targetNodeId, (object) fieldTargetDataType.m_targetNodeId) && Utils.IsEqual((object) this.m_attributeId, (object) fieldTargetDataType.m_attributeId) && Utils.IsEqual((object) this.m_writeIndexRange, (object) fieldTargetDataType.m_writeIndexRange) && Utils.IsEqual((object) this.m_overrideValueHandling, (object) fieldTargetDataType.m_overrideValueHandling) && Utils.IsEqual((object) this.m_overrideValue, (object) fieldTargetDataType.m_overrideValue);
  }

  public virtual object Clone() => (object) (FieldTargetDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    FieldTargetDataType fieldTargetDataType = (FieldTargetDataType) base.MemberwiseClone();
    fieldTargetDataType.m_dataSetFieldId = (Uuid) Utils.Clone((object) this.m_dataSetFieldId);
    fieldTargetDataType.m_receiverIndexRange = (string) Utils.Clone((object) this.m_receiverIndexRange);
    fieldTargetDataType.m_targetNodeId = (NodeId) Utils.Clone((object) this.m_targetNodeId);
    fieldTargetDataType.m_attributeId = (uint) Utils.Clone((object) this.m_attributeId);
    fieldTargetDataType.m_writeIndexRange = (string) Utils.Clone((object) this.m_writeIndexRange);
    fieldTargetDataType.m_overrideValueHandling = (OverrideValueHandling) Utils.Clone((object) this.m_overrideValueHandling);
    fieldTargetDataType.m_overrideValue = (Variant) Utils.Clone((object) this.m_overrideValue);
    return (object) fieldTargetDataType;
  }
}
