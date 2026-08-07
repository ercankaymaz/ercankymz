// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataSetWriterDataType
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
public class DataSetWriterDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private string m_name;
  private bool m_enabled;
  private ushort m_dataSetWriterId;
  private uint m_dataSetFieldContentMask;
  private uint m_keyFrameCount;
  private string m_dataSetName;
  private KeyValuePairCollection m_dataSetWriterProperties;
  private ExtensionObject m_transportSettings;
  private ExtensionObject m_messageSettings;

  public DataSetWriterDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_name = (string) null;
    this.m_enabled = true;
    this.m_dataSetWriterId = (ushort) 0;
    this.m_dataSetFieldContentMask = 0U;
    this.m_keyFrameCount = 0U;
    this.m_dataSetName = (string) null;
    this.m_dataSetWriterProperties = new KeyValuePairCollection();
    this.m_transportSettings = (ExtensionObject) null;
    this.m_messageSettings = (ExtensionObject) null;
  }

  [DataMember(Name = "Name", IsRequired = false, Order = 1)]
  public string Name
  {
    get => this.m_name;
    set => this.m_name = value;
  }

  [DataMember(Name = "Enabled", IsRequired = false, Order = 2)]
  public bool Enabled
  {
    get => this.m_enabled;
    set => this.m_enabled = value;
  }

  [DataMember(Name = "DataSetWriterId", IsRequired = false, Order = 3)]
  public ushort DataSetWriterId
  {
    get => this.m_dataSetWriterId;
    set => this.m_dataSetWriterId = value;
  }

  [DataMember(Name = "DataSetFieldContentMask", IsRequired = false, Order = 4)]
  public uint DataSetFieldContentMask
  {
    get => this.m_dataSetFieldContentMask;
    set => this.m_dataSetFieldContentMask = value;
  }

  [DataMember(Name = "KeyFrameCount", IsRequired = false, Order = 5)]
  public uint KeyFrameCount
  {
    get => this.m_keyFrameCount;
    set => this.m_keyFrameCount = value;
  }

  [DataMember(Name = "DataSetName", IsRequired = false, Order = 6)]
  public string DataSetName
  {
    get => this.m_dataSetName;
    set => this.m_dataSetName = value;
  }

  [DataMember(Name = "DataSetWriterProperties", IsRequired = false, Order = 7)]
  public KeyValuePairCollection DataSetWriterProperties
  {
    get => this.m_dataSetWriterProperties;
    set
    {
      this.m_dataSetWriterProperties = value;
      if (value != null)
        return;
      this.m_dataSetWriterProperties = new KeyValuePairCollection();
    }
  }

  [DataMember(Name = "TransportSettings", IsRequired = false, Order = 8)]
  public ExtensionObject TransportSettings
  {
    get => this.m_transportSettings;
    set => this.m_transportSettings = value;
  }

  [DataMember(Name = "MessageSettings", IsRequired = false, Order = 9)]
  public ExtensionObject MessageSettings
  {
    get => this.m_messageSettings;
    set => this.m_messageSettings = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.DataSetWriterDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataSetWriterDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataSetWriterDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataSetWriterDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("Name", this.Name);
    encoder.WriteBoolean("Enabled", this.Enabled);
    encoder.WriteUInt16("DataSetWriterId", this.DataSetWriterId);
    encoder.WriteUInt32("DataSetFieldContentMask", this.DataSetFieldContentMask);
    encoder.WriteUInt32("KeyFrameCount", this.KeyFrameCount);
    encoder.WriteString("DataSetName", this.DataSetName);
    encoder.WriteEncodeableArray("DataSetWriterProperties", (IList<IEncodeable>) this.DataSetWriterProperties.ToArray(), typeof (KeyValuePair));
    encoder.WriteExtensionObject("TransportSettings", this.TransportSettings);
    encoder.WriteExtensionObject("MessageSettings", this.MessageSettings);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Name = decoder.ReadString("Name");
    this.Enabled = decoder.ReadBoolean("Enabled");
    this.DataSetWriterId = decoder.ReadUInt16("DataSetWriterId");
    this.DataSetFieldContentMask = decoder.ReadUInt32("DataSetFieldContentMask");
    this.KeyFrameCount = decoder.ReadUInt32("KeyFrameCount");
    this.DataSetName = decoder.ReadString("DataSetName");
    this.DataSetWriterProperties = (KeyValuePairCollection) (KeyValuePair[]) decoder.ReadEncodeableArray("DataSetWriterProperties", typeof (KeyValuePair));
    this.TransportSettings = decoder.ReadExtensionObject("TransportSettings");
    this.MessageSettings = decoder.ReadExtensionObject("MessageSettings");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is DataSetWriterDataType setWriterDataType && Utils.IsEqual((object) this.m_name, (object) setWriterDataType.m_name) && Utils.IsEqual((object) this.m_enabled, (object) setWriterDataType.m_enabled) && Utils.IsEqual((object) this.m_dataSetWriterId, (object) setWriterDataType.m_dataSetWriterId) && Utils.IsEqual((object) this.m_dataSetFieldContentMask, (object) setWriterDataType.m_dataSetFieldContentMask) && Utils.IsEqual((object) this.m_keyFrameCount, (object) setWriterDataType.m_keyFrameCount) && Utils.IsEqual((object) this.m_dataSetName, (object) setWriterDataType.m_dataSetName) && Utils.IsEqual((object) this.m_dataSetWriterProperties, (object) setWriterDataType.m_dataSetWriterProperties) && Utils.IsEqual((object) this.m_transportSettings, (object) setWriterDataType.m_transportSettings) && Utils.IsEqual((object) this.m_messageSettings, (object) setWriterDataType.m_messageSettings);
  }

  public virtual object Clone() => (object) (DataSetWriterDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DataSetWriterDataType setWriterDataType = (DataSetWriterDataType) base.MemberwiseClone();
    setWriterDataType.m_name = (string) Utils.Clone((object) this.m_name);
    setWriterDataType.m_enabled = (bool) Utils.Clone((object) this.m_enabled);
    setWriterDataType.m_dataSetWriterId = (ushort) Utils.Clone((object) this.m_dataSetWriterId);
    setWriterDataType.m_dataSetFieldContentMask = (uint) Utils.Clone((object) this.m_dataSetFieldContentMask);
    setWriterDataType.m_keyFrameCount = (uint) Utils.Clone((object) this.m_keyFrameCount);
    setWriterDataType.m_dataSetName = (string) Utils.Clone((object) this.m_dataSetName);
    setWriterDataType.m_dataSetWriterProperties = (KeyValuePairCollection) Utils.Clone((object) this.m_dataSetWriterProperties);
    setWriterDataType.m_transportSettings = (ExtensionObject) Utils.Clone((object) this.m_transportSettings);
    setWriterDataType.m_messageSettings = (ExtensionObject) Utils.Clone((object) this.m_messageSettings);
    return (object) setWriterDataType;
  }
}
