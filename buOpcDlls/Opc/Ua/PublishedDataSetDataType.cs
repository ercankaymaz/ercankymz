// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PublishedDataSetDataType
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
public class PublishedDataSetDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private string m_name;
  private StringCollection m_dataSetFolder;
  private DataSetMetaDataType m_dataSetMetaData;
  private KeyValuePairCollection m_extensionFields;
  private ExtensionObject m_dataSetSource;

  public PublishedDataSetDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_name = (string) null;
    this.m_dataSetFolder = new StringCollection();
    this.m_dataSetMetaData = new DataSetMetaDataType();
    this.m_extensionFields = new KeyValuePairCollection();
    this.m_dataSetSource = (ExtensionObject) null;
  }

  [DataMember(Name = "Name", IsRequired = false, Order = 1)]
  public string Name
  {
    get => this.m_name;
    set => this.m_name = value;
  }

  [DataMember(Name = "DataSetFolder", IsRequired = false, Order = 2)]
  public StringCollection DataSetFolder
  {
    get => this.m_dataSetFolder;
    set
    {
      this.m_dataSetFolder = value;
      if (value != null)
        return;
      this.m_dataSetFolder = new StringCollection();
    }
  }

  [DataMember(Name = "DataSetMetaData", IsRequired = false, Order = 3)]
  public DataSetMetaDataType DataSetMetaData
  {
    get => this.m_dataSetMetaData;
    set
    {
      this.m_dataSetMetaData = value;
      if (value != null)
        return;
      this.m_dataSetMetaData = new DataSetMetaDataType();
    }
  }

  [DataMember(Name = "ExtensionFields", IsRequired = false, Order = 4)]
  public KeyValuePairCollection ExtensionFields
  {
    get => this.m_extensionFields;
    set
    {
      this.m_extensionFields = value;
      if (value != null)
        return;
      this.m_extensionFields = new KeyValuePairCollection();
    }
  }

  [DataMember(Name = "DataSetSource", IsRequired = false, Order = 5)]
  public ExtensionObject DataSetSource
  {
    get => this.m_dataSetSource;
    set => this.m_dataSetSource = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.PublishedDataSetDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PublishedDataSetDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PublishedDataSetDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PublishedDataSetDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("Name", this.Name);
    encoder.WriteStringArray("DataSetFolder", (IList<string>) this.DataSetFolder);
    encoder.WriteEncodeable("DataSetMetaData", (IEncodeable) this.DataSetMetaData, typeof (DataSetMetaDataType));
    encoder.WriteEncodeableArray("ExtensionFields", (IList<IEncodeable>) this.ExtensionFields.ToArray(), typeof (KeyValuePair));
    encoder.WriteExtensionObject("DataSetSource", this.DataSetSource);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Name = decoder.ReadString("Name");
    this.DataSetFolder = decoder.ReadStringArray("DataSetFolder");
    this.DataSetMetaData = (DataSetMetaDataType) decoder.ReadEncodeable("DataSetMetaData", typeof (DataSetMetaDataType));
    this.ExtensionFields = (KeyValuePairCollection) (KeyValuePair[]) decoder.ReadEncodeableArray("ExtensionFields", typeof (KeyValuePair));
    this.DataSetSource = decoder.ReadExtensionObject("DataSetSource");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is PublishedDataSetDataType publishedDataSetDataType && Utils.IsEqual((object) this.m_name, (object) publishedDataSetDataType.m_name) && Utils.IsEqual((object) this.m_dataSetFolder, (object) publishedDataSetDataType.m_dataSetFolder) && Utils.IsEqual((object) this.m_dataSetMetaData, (object) publishedDataSetDataType.m_dataSetMetaData) && Utils.IsEqual((object) this.m_extensionFields, (object) publishedDataSetDataType.m_extensionFields) && Utils.IsEqual((object) this.m_dataSetSource, (object) publishedDataSetDataType.m_dataSetSource);
  }

  public virtual object Clone() => (object) (PublishedDataSetDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    PublishedDataSetDataType publishedDataSetDataType = (PublishedDataSetDataType) base.MemberwiseClone();
    publishedDataSetDataType.m_name = (string) Utils.Clone((object) this.m_name);
    publishedDataSetDataType.m_dataSetFolder = (StringCollection) Utils.Clone((object) this.m_dataSetFolder);
    publishedDataSetDataType.m_dataSetMetaData = (DataSetMetaDataType) Utils.Clone((object) this.m_dataSetMetaData);
    publishedDataSetDataType.m_extensionFields = (KeyValuePairCollection) Utils.Clone((object) this.m_extensionFields);
    publishedDataSetDataType.m_dataSetSource = (ExtensionObject) Utils.Clone((object) this.m_dataSetSource);
    return (object) publishedDataSetDataType;
  }
}
