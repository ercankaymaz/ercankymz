// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataSetMetaDataType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DataSetMetaDataType : DataTypeSchemaHeader
{
  private string m_name;
  private LocalizedText m_description;
  private FieldMetaDataCollection m_fields;
  private Uuid m_dataSetClassId;
  private ConfigurationVersionDataType m_configurationVersion;

  public DataSetMetaDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_name = (string) null;
    this.m_description = (LocalizedText) null;
    this.m_fields = new FieldMetaDataCollection();
    this.m_dataSetClassId = Uuid.Empty;
    this.m_configurationVersion = new ConfigurationVersionDataType();
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

  [DataMember(Name = "Fields", IsRequired = false, Order = 3)]
  public FieldMetaDataCollection Fields
  {
    get => this.m_fields;
    set
    {
      this.m_fields = value;
      if (value != null)
        return;
      this.m_fields = new FieldMetaDataCollection();
    }
  }

  [DataMember(Name = "DataSetClassId", IsRequired = false, Order = 4)]
  public Uuid DataSetClassId
  {
    get => this.m_dataSetClassId;
    set => this.m_dataSetClassId = value;
  }

  [DataMember(Name = "ConfigurationVersion", IsRequired = false, Order = 5)]
  public ConfigurationVersionDataType ConfigurationVersion
  {
    get => this.m_configurationVersion;
    set
    {
      this.m_configurationVersion = value;
      if (value != null)
        return;
      this.m_configurationVersion = new ConfigurationVersionDataType();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.DataSetMetaDataType;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataSetMetaDataType_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataSetMetaDataType_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataSetMetaDataType_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("Name", this.Name);
    encoder.WriteLocalizedText("Description", this.Description);
    encoder.WriteEncodeableArray("Fields", (IList<IEncodeable>) this.Fields.ToArray(), typeof (FieldMetaData));
    encoder.WriteGuid("DataSetClassId", this.DataSetClassId);
    encoder.WriteEncodeable("ConfigurationVersion", (IEncodeable) this.ConfigurationVersion, typeof (ConfigurationVersionDataType));
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Name = decoder.ReadString("Name");
    this.Description = decoder.ReadLocalizedText("Description");
    this.Fields = (FieldMetaDataCollection) (FieldMetaData[]) decoder.ReadEncodeableArray("Fields", typeof (FieldMetaData));
    this.DataSetClassId = decoder.ReadGuid("DataSetClassId");
    this.ConfigurationVersion = (ConfigurationVersionDataType) decoder.ReadEncodeable("ConfigurationVersion", typeof (ConfigurationVersionDataType));
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is DataSetMetaDataType dataSetMetaDataType && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_name, (object) dataSetMetaDataType.m_name) && Utils.IsEqual((object) this.m_description, (object) dataSetMetaDataType.m_description) && Utils.IsEqual((object) this.m_fields, (object) dataSetMetaDataType.m_fields) && Utils.IsEqual((object) this.m_dataSetClassId, (object) dataSetMetaDataType.m_dataSetClassId) && Utils.IsEqual((object) this.m_configurationVersion, (object) dataSetMetaDataType.m_configurationVersion) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (DataSetMetaDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DataSetMetaDataType dataSetMetaDataType = (DataSetMetaDataType) base.MemberwiseClone();
    dataSetMetaDataType.m_name = (string) Utils.Clone((object) this.m_name);
    dataSetMetaDataType.m_description = (LocalizedText) Utils.Clone((object) this.m_description);
    dataSetMetaDataType.m_fields = (FieldMetaDataCollection) Utils.Clone((object) this.m_fields);
    dataSetMetaDataType.m_dataSetClassId = (Uuid) Utils.Clone((object) this.m_dataSetClassId);
    dataSetMetaDataType.m_configurationVersion = (ConfigurationVersionDataType) Utils.Clone((object) this.m_configurationVersion);
    return (object) dataSetMetaDataType;
  }
}
