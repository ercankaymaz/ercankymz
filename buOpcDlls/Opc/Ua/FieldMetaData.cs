// Decompiled with JetBrains decompiler
// Type: Opc.Ua.FieldMetaData
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
public class FieldMetaData : IEncodeable, ICloneable, IJsonEncodeable
{
  private string m_name;
  private LocalizedText m_description;
  private ushort m_fieldFlags;
  private byte m_builtInType;
  private NodeId m_dataType;
  private int m_valueRank;
  private UInt32Collection m_arrayDimensions;
  private uint m_maxStringLength;
  private Uuid m_dataSetFieldId;
  private KeyValuePairCollection m_properties;

  public FieldMetaData() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_name = (string) null;
    this.m_description = (LocalizedText) null;
    this.m_fieldFlags = (ushort) 0;
    this.m_builtInType = (byte) 0;
    this.m_dataType = (NodeId) null;
    this.m_valueRank = 0;
    this.m_arrayDimensions = new UInt32Collection();
    this.m_maxStringLength = 0U;
    this.m_dataSetFieldId = Uuid.Empty;
    this.m_properties = new KeyValuePairCollection();
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

  [DataMember(Name = "FieldFlags", IsRequired = false, Order = 3)]
  public ushort FieldFlags
  {
    get => this.m_fieldFlags;
    set => this.m_fieldFlags = value;
  }

  [DataMember(Name = "BuiltInType", IsRequired = false, Order = 4)]
  public byte BuiltInType
  {
    get => this.m_builtInType;
    set => this.m_builtInType = value;
  }

  [DataMember(Name = "DataType", IsRequired = false, Order = 5)]
  public NodeId DataType
  {
    get => this.m_dataType;
    set => this.m_dataType = value;
  }

  [DataMember(Name = "ValueRank", IsRequired = false, Order = 6)]
  public int ValueRank
  {
    get => this.m_valueRank;
    set => this.m_valueRank = value;
  }

  [DataMember(Name = "ArrayDimensions", IsRequired = false, Order = 7)]
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

  [DataMember(Name = "MaxStringLength", IsRequired = false, Order = 8)]
  public uint MaxStringLength
  {
    get => this.m_maxStringLength;
    set => this.m_maxStringLength = value;
  }

  [DataMember(Name = "DataSetFieldId", IsRequired = false, Order = 9)]
  public Uuid DataSetFieldId
  {
    get => this.m_dataSetFieldId;
    set => this.m_dataSetFieldId = value;
  }

  [DataMember(Name = "Properties", IsRequired = false, Order = 10)]
  public KeyValuePairCollection Properties
  {
    get => this.m_properties;
    set
    {
      this.m_properties = value;
      if (value != null)
        return;
      this.m_properties = new KeyValuePairCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.FieldMetaData;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.FieldMetaData_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.FieldMetaData_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.FieldMetaData_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("Name", this.Name);
    encoder.WriteLocalizedText("Description", this.Description);
    encoder.WriteUInt16("FieldFlags", this.FieldFlags);
    encoder.WriteByte("BuiltInType", this.BuiltInType);
    encoder.WriteNodeId("DataType", this.DataType);
    encoder.WriteInt32("ValueRank", this.ValueRank);
    encoder.WriteUInt32Array("ArrayDimensions", (IList<uint>) this.ArrayDimensions);
    encoder.WriteUInt32("MaxStringLength", this.MaxStringLength);
    encoder.WriteGuid("DataSetFieldId", this.DataSetFieldId);
    encoder.WriteEncodeableArray("Properties", (IList<IEncodeable>) this.Properties.ToArray(), typeof (KeyValuePair));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Name = decoder.ReadString("Name");
    this.Description = decoder.ReadLocalizedText("Description");
    this.FieldFlags = decoder.ReadUInt16("FieldFlags");
    this.BuiltInType = decoder.ReadByte("BuiltInType");
    this.DataType = decoder.ReadNodeId("DataType");
    this.ValueRank = decoder.ReadInt32("ValueRank");
    this.ArrayDimensions = decoder.ReadUInt32Array("ArrayDimensions");
    this.MaxStringLength = decoder.ReadUInt32("MaxStringLength");
    this.DataSetFieldId = decoder.ReadGuid("DataSetFieldId");
    this.Properties = (KeyValuePairCollection) (KeyValuePair[]) decoder.ReadEncodeableArray("Properties", typeof (KeyValuePair));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is FieldMetaData fieldMetaData && Utils.IsEqual((object) this.m_name, (object) fieldMetaData.m_name) && Utils.IsEqual((object) this.m_description, (object) fieldMetaData.m_description) && Utils.IsEqual((object) this.m_fieldFlags, (object) fieldMetaData.m_fieldFlags) && Utils.IsEqual((object) this.m_builtInType, (object) fieldMetaData.m_builtInType) && Utils.IsEqual((object) this.m_dataType, (object) fieldMetaData.m_dataType) && Utils.IsEqual((object) this.m_valueRank, (object) fieldMetaData.m_valueRank) && Utils.IsEqual((object) this.m_arrayDimensions, (object) fieldMetaData.m_arrayDimensions) && Utils.IsEqual((object) this.m_maxStringLength, (object) fieldMetaData.m_maxStringLength) && Utils.IsEqual((object) this.m_dataSetFieldId, (object) fieldMetaData.m_dataSetFieldId) && Utils.IsEqual((object) this.m_properties, (object) fieldMetaData.m_properties);
  }

  public virtual object Clone() => (object) (FieldMetaData) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    FieldMetaData fieldMetaData = (FieldMetaData) base.MemberwiseClone();
    fieldMetaData.m_name = (string) Utils.Clone((object) this.m_name);
    fieldMetaData.m_description = (LocalizedText) Utils.Clone((object) this.m_description);
    fieldMetaData.m_fieldFlags = (ushort) Utils.Clone((object) this.m_fieldFlags);
    fieldMetaData.m_builtInType = (byte) Utils.Clone((object) this.m_builtInType);
    fieldMetaData.m_dataType = (NodeId) Utils.Clone((object) this.m_dataType);
    fieldMetaData.m_valueRank = (int) Utils.Clone((object) this.m_valueRank);
    fieldMetaData.m_arrayDimensions = (UInt32Collection) Utils.Clone((object) this.m_arrayDimensions);
    fieldMetaData.m_maxStringLength = (uint) Utils.Clone((object) this.m_maxStringLength);
    fieldMetaData.m_dataSetFieldId = (Uuid) Utils.Clone((object) this.m_dataSetFieldId);
    fieldMetaData.m_properties = (KeyValuePairCollection) Utils.Clone((object) this.m_properties);
    return (object) fieldMetaData;
  }
}
