// Decompiled with JetBrains decompiler
// Type: Opc.Ua.StructureField
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
public class StructureField : IEncodeable, ICloneable, IJsonEncodeable
{
  private string m_name;
  private LocalizedText m_description;
  private NodeId m_dataType;
  private int m_valueRank;
  private UInt32Collection m_arrayDimensions;
  private uint m_maxStringLength;
  private bool m_isOptional;

  public StructureField() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_name = (string) null;
    this.m_description = (LocalizedText) null;
    this.m_dataType = (NodeId) null;
    this.m_valueRank = 0;
    this.m_arrayDimensions = new UInt32Collection();
    this.m_maxStringLength = 0U;
    this.m_isOptional = false;
  }

  [DataMember(Name = "Name", IsRequired = false, Order = 1)]
  public string Name
  {
    get => this.m_name;
    set => this.m_name = value;
  }

  [DataMember(Name = "Description", IsRequired = false, Order = 2)]
  public LocalizedText Description
  {
    get => this.m_description;
    set => this.m_description = value;
  }

  [DataMember(Name = "DataType", IsRequired = false, Order = 3)]
  public NodeId DataType
  {
    get => this.m_dataType;
    set => this.m_dataType = value;
  }

  [DataMember(Name = "ValueRank", IsRequired = false, Order = 4)]
  public int ValueRank
  {
    get => this.m_valueRank;
    set => this.m_valueRank = value;
  }

  [DataMember(Name = "ArrayDimensions", IsRequired = false, Order = 5)]
  public UInt32Collection ArrayDimensions
  {
    get => this.m_arrayDimensions;
    set
    {
      this.m_arrayDimensions = value;
      if (value != null)
        return;
      this.m_arrayDimensions = new UInt32Collection();
    }
  }

  [DataMember(Name = "MaxStringLength", IsRequired = false, Order = 6)]
  public uint MaxStringLength
  {
    get => this.m_maxStringLength;
    set => this.m_maxStringLength = value;
  }

  [DataMember(Name = "IsOptional", IsRequired = false, Order = 7)]
  public bool IsOptional
  {
    get => this.m_isOptional;
    set => this.m_isOptional = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.StructureField;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.StructureField_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.StructureField_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.StructureField_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("Name", this.Name);
    encoder.WriteLocalizedText("Description", this.Description);
    encoder.WriteNodeId("DataType", this.DataType);
    encoder.WriteInt32("ValueRank", this.ValueRank);
    encoder.WriteUInt32Array("ArrayDimensions", (IList<uint>) this.ArrayDimensions);
    encoder.WriteUInt32("MaxStringLength", this.MaxStringLength);
    encoder.WriteBoolean("IsOptional", this.IsOptional);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Name = decoder.ReadString("Name");
    this.Description = decoder.ReadLocalizedText("Description");
    this.DataType = decoder.ReadNodeId("DataType");
    this.ValueRank = decoder.ReadInt32("ValueRank");
    this.ArrayDimensions = decoder.ReadUInt32Array("ArrayDimensions");
    this.MaxStringLength = decoder.ReadUInt32("MaxStringLength");
    this.IsOptional = decoder.ReadBoolean("IsOptional");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is StructureField structureField && Utils.IsEqual((object) this.m_name, (object) structureField.m_name) && Utils.IsEqual((object) this.m_description, (object) structureField.m_description) && Utils.IsEqual((object) this.m_dataType, (object) structureField.m_dataType) && Utils.IsEqual((object) this.m_valueRank, (object) structureField.m_valueRank) && Utils.IsEqual((object) this.m_arrayDimensions, (object) structureField.m_arrayDimensions) && Utils.IsEqual((object) this.m_maxStringLength, (object) structureField.m_maxStringLength) && Utils.IsEqual((object) this.m_isOptional, (object) structureField.m_isOptional);
  }

  public virtual object Clone() => (object) (StructureField) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    StructureField structureField = (StructureField) base.MemberwiseClone();
    structureField.m_name = (string) Utils.Clone((object) this.m_name);
    structureField.m_description = (LocalizedText) Utils.Clone((object) this.m_description);
    structureField.m_dataType = (NodeId) Utils.Clone((object) this.m_dataType);
    structureField.m_valueRank = (int) Utils.Clone((object) this.m_valueRank);
    structureField.m_arrayDimensions = (UInt32Collection) Utils.Clone((object) this.m_arrayDimensions);
    structureField.m_maxStringLength = (uint) Utils.Clone((object) this.m_maxStringLength);
    structureField.m_isOptional = (bool) Utils.Clone((object) this.m_isOptional);
    return (object) structureField;
  }
}
