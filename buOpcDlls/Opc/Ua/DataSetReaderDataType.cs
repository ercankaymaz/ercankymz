// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataSetReaderDataType
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
public class DataSetReaderDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private string m_name;
  private bool m_enabled;
  private Variant m_publisherId;
  private ushort m_writerGroupId;
  private ushort m_dataSetWriterId;
  private DataSetMetaDataType m_dataSetMetaData;
  private uint m_dataSetFieldContentMask;
  private double m_messageReceiveTimeout;
  private uint m_keyFrameCount;
  private string m_headerLayoutUri;
  private MessageSecurityMode m_securityMode;
  private string m_securityGroupId;
  private EndpointDescriptionCollection m_securityKeyServices;
  private KeyValuePairCollection m_dataSetReaderProperties;
  private ExtensionObject m_transportSettings;
  private ExtensionObject m_messageSettings;
  private ExtensionObject m_subscribedDataSet;

  public DataSetReaderDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_name = (string) null;
    this.m_enabled = true;
    this.m_publisherId = Variant.Null;
    this.m_writerGroupId = (ushort) 0;
    this.m_dataSetWriterId = (ushort) 0;
    this.m_dataSetMetaData = new DataSetMetaDataType();
    this.m_dataSetFieldContentMask = 0U;
    this.m_messageReceiveTimeout = 0.0;
    this.m_keyFrameCount = 0U;
    this.m_headerLayoutUri = (string) null;
    this.m_securityMode = MessageSecurityMode.Invalid;
    this.m_securityGroupId = (string) null;
    this.m_securityKeyServices = new EndpointDescriptionCollection();
    this.m_dataSetReaderProperties = new KeyValuePairCollection();
    this.m_transportSettings = (ExtensionObject) null;
    this.m_messageSettings = (ExtensionObject) null;
    this.m_subscribedDataSet = (ExtensionObject) null;
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

  [DataMember(Name = "PublisherId", IsRequired = false, Order = 3)]
  public Variant PublisherId
  {
    get => this.m_publisherId;
    set => this.m_publisherId = value;
  }

  [DataMember(Name = "WriterGroupId", IsRequired = false, Order = 4)]
  public ushort WriterGroupId
  {
    get => this.m_writerGroupId;
    set => this.m_writerGroupId = value;
  }

  [DataMember(Name = "DataSetWriterId", IsRequired = false, Order = 5)]
  public ushort DataSetWriterId
  {
    get => this.m_dataSetWriterId;
    set => this.m_dataSetWriterId = value;
  }

  [DataMember(Name = "DataSetMetaData", IsRequired = false, Order = 6)]
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

  [DataMember(Name = "DataSetFieldContentMask", IsRequired = false, Order = 7)]
  public uint DataSetFieldContentMask
  {
    get => this.m_dataSetFieldContentMask;
    set => this.m_dataSetFieldContentMask = value;
  }

  [DataMember(Name = "MessageReceiveTimeout", IsRequired = false, Order = 8)]
  public double MessageReceiveTimeout
  {
    get => this.m_messageReceiveTimeout;
    set => this.m_messageReceiveTimeout = value;
  }

  [DataMember(Name = "KeyFrameCount", IsRequired = false, Order = 9)]
  public uint KeyFrameCount
  {
    get => this.m_keyFrameCount;
    set => this.m_keyFrameCount = value;
  }

  [DataMember(Name = "HeaderLayoutUri", IsRequired = false, Order = 10)]
  public string HeaderLayoutUri
  {
    get => this.m_headerLayoutUri;
    set => this.m_headerLayoutUri = value;
  }

  [DataMember(Name = "SecurityMode", IsRequired = false, Order = 11)]
  public MessageSecurityMode SecurityMode
  {
    get => this.m_securityMode;
    set => this.m_securityMode = value;
  }

  [DataMember(Name = "SecurityGroupId", IsRequired = false, Order = 12)]
  public string SecurityGroupId
  {
    get => this.m_securityGroupId;
    set => this.m_securityGroupId = value;
  }

  [DataMember(Name = "SecurityKeyServices", IsRequired = false, Order = 13)]
  public EndpointDescriptionCollection SecurityKeyServices
  {
    get => this.m_securityKeyServices;
    set
    {
      this.m_securityKeyServices = value;
      if (value != null)
        return;
      this.m_securityKeyServices = new EndpointDescriptionCollection();
    }
  }

  [DataMember(Name = "DataSetReaderProperties", IsRequired = false, Order = 14)]
  public KeyValuePairCollection DataSetReaderProperties
  {
    get => this.m_dataSetReaderProperties;
    set
    {
      this.m_dataSetReaderProperties = value;
      if (value != null)
        return;
      this.m_dataSetReaderProperties = new KeyValuePairCollection();
    }
  }

  [DataMember(Name = "TransportSettings", IsRequired = false, Order = 15)]
  public ExtensionObject TransportSettings
  {
    get => this.m_transportSettings;
    set => this.m_transportSettings = value;
  }

  [DataMember(Name = "MessageSettings", IsRequired = false, Order = 16 /*0x10*/)]
  public ExtensionObject MessageSettings
  {
    get => this.m_messageSettings;
    set => this.m_messageSettings = value;
  }

  [DataMember(Name = "SubscribedDataSet", IsRequired = false, Order = 17)]
  public ExtensionObject SubscribedDataSet
  {
    get => this.m_subscribedDataSet;
    set => this.m_subscribedDataSet = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.DataSetReaderDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataSetReaderDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataSetReaderDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataSetReaderDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("Name", this.Name);
    encoder.WriteBoolean("Enabled", this.Enabled);
    encoder.WriteVariant("PublisherId", this.PublisherId);
    encoder.WriteUInt16("WriterGroupId", this.WriterGroupId);
    encoder.WriteUInt16("DataSetWriterId", this.DataSetWriterId);
    encoder.WriteEncodeable("DataSetMetaData", (IEncodeable) this.DataSetMetaData, typeof (DataSetMetaDataType));
    encoder.WriteUInt32("DataSetFieldContentMask", this.DataSetFieldContentMask);
    encoder.WriteDouble("MessageReceiveTimeout", this.MessageReceiveTimeout);
    encoder.WriteUInt32("KeyFrameCount", this.KeyFrameCount);
    encoder.WriteString("HeaderLayoutUri", this.HeaderLayoutUri);
    encoder.WriteEnumerated("SecurityMode", (Enum) this.SecurityMode);
    encoder.WriteString("SecurityGroupId", this.SecurityGroupId);
    encoder.WriteEncodeableArray("SecurityKeyServices", (IList<IEncodeable>) this.SecurityKeyServices.ToArray(), typeof (EndpointDescription));
    encoder.WriteEncodeableArray("DataSetReaderProperties", (IList<IEncodeable>) this.DataSetReaderProperties.ToArray(), typeof (KeyValuePair));
    encoder.WriteExtensionObject("TransportSettings", this.TransportSettings);
    encoder.WriteExtensionObject("MessageSettings", this.MessageSettings);
    encoder.WriteExtensionObject("SubscribedDataSet", this.SubscribedDataSet);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Name = decoder.ReadString("Name");
    this.Enabled = decoder.ReadBoolean("Enabled");
    this.PublisherId = decoder.ReadVariant("PublisherId");
    this.WriterGroupId = decoder.ReadUInt16("WriterGroupId");
    this.DataSetWriterId = decoder.ReadUInt16("DataSetWriterId");
    this.DataSetMetaData = (DataSetMetaDataType) decoder.ReadEncodeable("DataSetMetaData", typeof (DataSetMetaDataType));
    this.DataSetFieldContentMask = decoder.ReadUInt32("DataSetFieldContentMask");
    this.MessageReceiveTimeout = decoder.ReadDouble("MessageReceiveTimeout");
    this.KeyFrameCount = decoder.ReadUInt32("KeyFrameCount");
    this.HeaderLayoutUri = decoder.ReadString("HeaderLayoutUri");
    this.SecurityMode = (MessageSecurityMode) decoder.ReadEnumerated("SecurityMode", typeof (MessageSecurityMode));
    this.SecurityGroupId = decoder.ReadString("SecurityGroupId");
    this.SecurityKeyServices = (EndpointDescriptionCollection) (EndpointDescription[]) decoder.ReadEncodeableArray("SecurityKeyServices", typeof (EndpointDescription));
    this.DataSetReaderProperties = (KeyValuePairCollection) (KeyValuePair[]) decoder.ReadEncodeableArray("DataSetReaderProperties", typeof (KeyValuePair));
    this.TransportSettings = decoder.ReadExtensionObject("TransportSettings");
    this.MessageSettings = decoder.ReadExtensionObject("MessageSettings");
    this.SubscribedDataSet = decoder.ReadExtensionObject("SubscribedDataSet");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is DataSetReaderDataType setReaderDataType && Utils.IsEqual((object) this.m_name, (object) setReaderDataType.m_name) && Utils.IsEqual((object) this.m_enabled, (object) setReaderDataType.m_enabled) && Utils.IsEqual((object) this.m_publisherId, (object) setReaderDataType.m_publisherId) && Utils.IsEqual((object) this.m_writerGroupId, (object) setReaderDataType.m_writerGroupId) && Utils.IsEqual((object) this.m_dataSetWriterId, (object) setReaderDataType.m_dataSetWriterId) && Utils.IsEqual((object) this.m_dataSetMetaData, (object) setReaderDataType.m_dataSetMetaData) && Utils.IsEqual((object) this.m_dataSetFieldContentMask, (object) setReaderDataType.m_dataSetFieldContentMask) && Utils.IsEqual((object) this.m_messageReceiveTimeout, (object) setReaderDataType.m_messageReceiveTimeout) && Utils.IsEqual((object) this.m_keyFrameCount, (object) setReaderDataType.m_keyFrameCount) && Utils.IsEqual((object) this.m_headerLayoutUri, (object) setReaderDataType.m_headerLayoutUri) && Utils.IsEqual((object) this.m_securityMode, (object) setReaderDataType.m_securityMode) && Utils.IsEqual((object) this.m_securityGroupId, (object) setReaderDataType.m_securityGroupId) && Utils.IsEqual((object) this.m_securityKeyServices, (object) setReaderDataType.m_securityKeyServices) && Utils.IsEqual((object) this.m_dataSetReaderProperties, (object) setReaderDataType.m_dataSetReaderProperties) && Utils.IsEqual((object) this.m_transportSettings, (object) setReaderDataType.m_transportSettings) && Utils.IsEqual((object) this.m_messageSettings, (object) setReaderDataType.m_messageSettings) && Utils.IsEqual((object) this.m_subscribedDataSet, (object) setReaderDataType.m_subscribedDataSet);
  }

  public virtual object Clone() => (object) (DataSetReaderDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DataSetReaderDataType setReaderDataType = (DataSetReaderDataType) base.MemberwiseClone();
    setReaderDataType.m_name = (string) Utils.Clone((object) this.m_name);
    setReaderDataType.m_enabled = (bool) Utils.Clone((object) this.m_enabled);
    setReaderDataType.m_publisherId = (Variant) Utils.Clone((object) this.m_publisherId);
    setReaderDataType.m_writerGroupId = (ushort) Utils.Clone((object) this.m_writerGroupId);
    setReaderDataType.m_dataSetWriterId = (ushort) Utils.Clone((object) this.m_dataSetWriterId);
    setReaderDataType.m_dataSetMetaData = (DataSetMetaDataType) Utils.Clone((object) this.m_dataSetMetaData);
    setReaderDataType.m_dataSetFieldContentMask = (uint) Utils.Clone((object) this.m_dataSetFieldContentMask);
    setReaderDataType.m_messageReceiveTimeout = (double) Utils.Clone((object) this.m_messageReceiveTimeout);
    setReaderDataType.m_keyFrameCount = (uint) Utils.Clone((object) this.m_keyFrameCount);
    setReaderDataType.m_headerLayoutUri = (string) Utils.Clone((object) this.m_headerLayoutUri);
    setReaderDataType.m_securityMode = (MessageSecurityMode) Utils.Clone((object) this.m_securityMode);
    setReaderDataType.m_securityGroupId = (string) Utils.Clone((object) this.m_securityGroupId);
    setReaderDataType.m_securityKeyServices = (EndpointDescriptionCollection) Utils.Clone((object) this.m_securityKeyServices);
    setReaderDataType.m_dataSetReaderProperties = (KeyValuePairCollection) Utils.Clone((object) this.m_dataSetReaderProperties);
    setReaderDataType.m_transportSettings = (ExtensionObject) Utils.Clone((object) this.m_transportSettings);
    setReaderDataType.m_messageSettings = (ExtensionObject) Utils.Clone((object) this.m_messageSettings);
    setReaderDataType.m_subscribedDataSet = (ExtensionObject) Utils.Clone((object) this.m_subscribedDataSet);
    return (object) setReaderDataType;
  }
}
