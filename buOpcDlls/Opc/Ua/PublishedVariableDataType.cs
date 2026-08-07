// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PublishedVariableDataType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class PublishedVariableDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_publishedVariable;
  private uint m_attributeId;
  private double m_samplingIntervalHint;
  private uint m_deadbandType;
  private double m_deadbandValue;
  private string m_indexRange;
  private Variant m_substituteValue;
  private QualifiedNameCollection m_metaDataProperties;

  public PublishedVariableDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_publishedVariable = (NodeId) null;
    this.m_attributeId = 0U;
    this.m_samplingIntervalHint = 0.0;
    this.m_deadbandType = 0U;
    this.m_deadbandValue = 0.0;
    this.m_indexRange = (string) null;
    this.m_substituteValue = Variant.Null;
    this.m_metaDataProperties = new QualifiedNameCollection();
  }

  [DataMember(Name = "PublishedVariable", IsRequired = false, Order = 1)]
  public NodeId PublishedVariable
  {
    get => this.m_publishedVariable;
    set => this.m_publishedVariable = value;
  }

  [DataMember(Name = "AttributeId", IsRequired = false, Order = 2)]
  public uint AttributeId
  {
    get => this.m_attributeId;
    set => this.m_attributeId = value;
  }

  [DataMember(Name = "SamplingIntervalHint", IsRequired = false, Order = 3)]
  public double SamplingIntervalHint
  {
    get => this.m_samplingIntervalHint;
    set => this.m_samplingIntervalHint = value;
  }

  [DataMember(Name = "DeadbandType", IsRequired = false, Order = 4)]
  public uint DeadbandType
  {
    get => this.m_deadbandType;
    set => this.m_deadbandType = value;
  }

  [DataMember(Name = "DeadbandValue", IsRequired = false, Order = 5)]
  public double DeadbandValue
  {
    get => this.m_deadbandValue;
    set => this.m_deadbandValue = value;
  }

  [DataMember(Name = "IndexRange", IsRequired = false, Order = 6)]
  public string IndexRange
  {
    get => this.m_indexRange;
    set => this.m_indexRange = value;
  }

  [DataMember(Name = "SubstituteValue", IsRequired = false, Order = 7)]
  public Variant SubstituteValue
  {
    get => this.m_substituteValue;
    set => this.m_substituteValue = value;
  }

  [DataMember(Name = "MetaDataProperties", IsRequired = false, Order = 8)]
  public QualifiedNameCollection MetaDataProperties
  {
    get => this.m_metaDataProperties;
    set
    {
      this.m_metaDataProperties = value;
      if (value != null)
        return;
      this.m_metaDataProperties = new QualifiedNameCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.PublishedVariableDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PublishedVariableDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PublishedVariableDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PublishedVariableDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("PublishedVariable", this.PublishedVariable);
    encoder.WriteUInt32("AttributeId", this.AttributeId);
    encoder.WriteDouble("SamplingIntervalHint", this.SamplingIntervalHint);
    encoder.WriteUInt32("DeadbandType", this.DeadbandType);
    encoder.WriteDouble("DeadbandValue", this.DeadbandValue);
    encoder.WriteString("IndexRange", this.IndexRange);
    encoder.WriteVariant("SubstituteValue", this.SubstituteValue);
    encoder.WriteQualifiedNameArray("MetaDataProperties", (IList<QualifiedName>) this.MetaDataProperties);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.PublishedVariable = decoder.ReadNodeId("PublishedVariable");
    this.AttributeId = decoder.ReadUInt32("AttributeId");
    this.SamplingIntervalHint = decoder.ReadDouble("SamplingIntervalHint");
    this.DeadbandType = decoder.ReadUInt32("DeadbandType");
    this.DeadbandValue = decoder.ReadDouble("DeadbandValue");
    this.IndexRange = decoder.ReadString("IndexRange");
    this.SubstituteValue = decoder.ReadVariant("SubstituteValue");
    this.MetaDataProperties = decoder.ReadQualifiedNameArray("MetaDataProperties");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is PublishedVariableDataType variableDataType && Utils.IsEqual((object) this.m_publishedVariable, (object) variableDataType.m_publishedVariable) && Utils.IsEqual((object) this.m_attributeId, (object) variableDataType.m_attributeId) && Utils.IsEqual((object) this.m_samplingIntervalHint, (object) variableDataType.m_samplingIntervalHint) && Utils.IsEqual((object) this.m_deadbandType, (object) variableDataType.m_deadbandType) && Utils.IsEqual((object) this.m_deadbandValue, (object) variableDataType.m_deadbandValue) && Utils.IsEqual((object) this.m_indexRange, (object) variableDataType.m_indexRange) && Utils.IsEqual((object) this.m_substituteValue, (object) variableDataType.m_substituteValue) && Utils.IsEqual((object) this.m_metaDataProperties, (object) variableDataType.m_metaDataProperties);
  }

  public virtual object Clone() => (object) (PublishedVariableDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    PublishedVariableDataType variableDataType = (PublishedVariableDataType) base.MemberwiseClone();
    variableDataType.m_publishedVariable = (NodeId) Utils.Clone((object) this.m_publishedVariable);
    variableDataType.m_attributeId = (uint) Utils.Clone((object) this.m_attributeId);
    variableDataType.m_samplingIntervalHint = (double) Utils.Clone((object) this.m_samplingIntervalHint);
    variableDataType.m_deadbandType = (uint) Utils.Clone((object) this.m_deadbandType);
    variableDataType.m_deadbandValue = (double) Utils.Clone((object) this.m_deadbandValue);
    variableDataType.m_indexRange = (string) Utils.Clone((object) this.m_indexRange);
    variableDataType.m_substituteValue = (Variant) Utils.Clone((object) this.m_substituteValue);
    variableDataType.m_metaDataProperties = (QualifiedNameCollection) Utils.Clone((object) this.m_metaDataProperties);
    return (object) variableDataType;
  }
}
