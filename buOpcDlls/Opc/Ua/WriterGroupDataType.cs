// Decompiled with JetBrains decompiler
// Type: Opc.Ua.WriterGroupDataType
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
public class WriterGroupDataType : PubSubGroupDataType
{
  private ushort m_writerGroupId;
  private double m_publishingInterval;
  private double m_keepAliveTime;
  private byte m_priority;
  private StringCollection m_localeIds;
  private string m_headerLayoutUri;
  private ExtensionObject m_transportSettings;
  private ExtensionObject m_messageSettings;
  private DataSetWriterDataTypeCollection m_dataSetWriters;

  public WriterGroupDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_writerGroupId = (ushort) 0;
    this.m_publishingInterval = 0.0;
    this.m_keepAliveTime = 0.0;
    this.m_priority = (byte) 0;
    this.m_localeIds = new StringCollection();
    this.m_headerLayoutUri = (string) null;
    this.m_transportSettings = (ExtensionObject) null;
    this.m_messageSettings = (ExtensionObject) null;
    this.m_dataSetWriters = new DataSetWriterDataTypeCollection();
  }

  [DataMember(Name = "WriterGroupId", IsRequired = false, Order = 1)]
  public ushort WriterGroupId
  {
    get => this.m_writerGroupId;
    set => this.m_writerGroupId = value;
  }

  [DataMember(Name = "PublishingInterval", IsRequired = false, Order = 2)]
  public double PublishingInterval
  {
    get => this.m_publishingInterval;
    set => this.m_publishingInterval = value;
  }

  [DataMember(Name = "KeepAliveTime", IsRequired = false, Order = 3)]
  public double KeepAliveTime
  {
    get => this.m_keepAliveTime;
    set => this.m_keepAliveTime = value;
  }

  [DataMember(Name = "Priority", IsRequired = false, Order = 4)]
  public byte Priority
  {
    get => this.m_priority;
    set => this.m_priority = value;
  }

  [DataMember(Name = "LocaleIds", IsRequired = false, Order = 5)]
  public StringCollection LocaleIds
  {
    get => this.m_localeIds;
    set
    {
      this.m_localeIds = value;
      if (value != null)
        return;
      this.m_localeIds = new StringCollection();
    }
  }

  [DataMember(Name = "HeaderLayoutUri", IsRequired = false, Order = 6)]
  public string HeaderLayoutUri
  {
    get => this.m_headerLayoutUri;
    set => this.m_headerLayoutUri = value;
  }

  [DataMember(Name = "TransportSettings", IsRequired = false, Order = 7)]
  public ExtensionObject TransportSettings
  {
    get => this.m_transportSettings;
    set => this.m_transportSettings = value;
  }

  [DataMember(Name = "MessageSettings", IsRequired = false, Order = 8)]
  public ExtensionObject MessageSettings
  {
    get => this.m_messageSettings;
    set => this.m_messageSettings = value;
  }

  [DataMember(Name = "DataSetWriters", IsRequired = false, Order = 9)]
  public DataSetWriterDataTypeCollection DataSetWriters
  {
    get => this.m_dataSetWriters;
    set
    {
      this.m_dataSetWriters = value;
      if (value != null)
        return;
      this.m_dataSetWriters = new DataSetWriterDataTypeCollection();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.WriterGroupDataType;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.WriterGroupDataType_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.WriterGroupDataType_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.WriterGroupDataType_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt16("WriterGroupId", this.WriterGroupId);
    encoder.WriteDouble("PublishingInterval", this.PublishingInterval);
    encoder.WriteDouble("KeepAliveTime", this.KeepAliveTime);
    encoder.WriteByte("Priority", this.Priority);
    encoder.WriteStringArray("LocaleIds", (IList<string>) this.LocaleIds);
    encoder.WriteString("HeaderLayoutUri", this.HeaderLayoutUri);
    encoder.WriteExtensionObject("TransportSettings", this.TransportSettings);
    encoder.WriteExtensionObject("MessageSettings", this.MessageSettings);
    encoder.WriteEncodeableArray("DataSetWriters", (IList<IEncodeable>) this.DataSetWriters.ToArray(), typeof (DataSetWriterDataType));
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.WriterGroupId = decoder.ReadUInt16("WriterGroupId");
    this.PublishingInterval = decoder.ReadDouble("PublishingInterval");
    this.KeepAliveTime = decoder.ReadDouble("KeepAliveTime");
    this.Priority = decoder.ReadByte("Priority");
    this.LocaleIds = decoder.ReadStringArray("LocaleIds");
    this.HeaderLayoutUri = decoder.ReadString("HeaderLayoutUri");
    this.TransportSettings = decoder.ReadExtensionObject("TransportSettings");
    this.MessageSettings = decoder.ReadExtensionObject("MessageSettings");
    this.DataSetWriters = (DataSetWriterDataTypeCollection) (DataSetWriterDataType[]) decoder.ReadEncodeableArray("DataSetWriters", typeof (DataSetWriterDataType));
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is WriterGroupDataType writerGroupDataType && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_writerGroupId, (object) writerGroupDataType.m_writerGroupId) && Utils.IsEqual((object) this.m_publishingInterval, (object) writerGroupDataType.m_publishingInterval) && Utils.IsEqual((object) this.m_keepAliveTime, (object) writerGroupDataType.m_keepAliveTime) && Utils.IsEqual((object) this.m_priority, (object) writerGroupDataType.m_priority) && Utils.IsEqual((object) this.m_localeIds, (object) writerGroupDataType.m_localeIds) && Utils.IsEqual((object) this.m_headerLayoutUri, (object) writerGroupDataType.m_headerLayoutUri) && Utils.IsEqual((object) this.m_transportSettings, (object) writerGroupDataType.m_transportSettings) && Utils.IsEqual((object) this.m_messageSettings, (object) writerGroupDataType.m_messageSettings) && Utils.IsEqual((object) this.m_dataSetWriters, (object) writerGroupDataType.m_dataSetWriters) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (WriterGroupDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    WriterGroupDataType writerGroupDataType = (WriterGroupDataType) base.MemberwiseClone();
    writerGroupDataType.m_writerGroupId = (ushort) Utils.Clone((object) this.m_writerGroupId);
    writerGroupDataType.m_publishingInterval = (double) Utils.Clone((object) this.m_publishingInterval);
    writerGroupDataType.m_keepAliveTime = (double) Utils.Clone((object) this.m_keepAliveTime);
    writerGroupDataType.m_priority = (byte) Utils.Clone((object) this.m_priority);
    writerGroupDataType.m_localeIds = (StringCollection) Utils.Clone((object) this.m_localeIds);
    writerGroupDataType.m_headerLayoutUri = (string) Utils.Clone((object) this.m_headerLayoutUri);
    writerGroupDataType.m_transportSettings = (ExtensionObject) Utils.Clone((object) this.m_transportSettings);
    writerGroupDataType.m_messageSettings = (ExtensionObject) Utils.Clone((object) this.m_messageSettings);
    writerGroupDataType.m_dataSetWriters = (DataSetWriterDataTypeCollection) Utils.Clone((object) this.m_dataSetWriters);
    return (object) writerGroupDataType;
  }
}
