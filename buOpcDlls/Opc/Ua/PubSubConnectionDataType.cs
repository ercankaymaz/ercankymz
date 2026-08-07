// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PubSubConnectionDataType
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
public class PubSubConnectionDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private string m_name;
  private bool m_enabled;
  private Variant m_publisherId;
  private string m_transportProfileUri;
  private ExtensionObject m_address;
  private KeyValuePairCollection m_connectionProperties;
  private ExtensionObject m_transportSettings;
  private WriterGroupDataTypeCollection m_writerGroups;
  private ReaderGroupDataTypeCollection m_readerGroups;

  public PubSubConnectionDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_name = (string) null;
    this.m_enabled = true;
    this.m_publisherId = Variant.Null;
    this.m_transportProfileUri = (string) null;
    this.m_address = (ExtensionObject) null;
    this.m_connectionProperties = new KeyValuePairCollection();
    this.m_transportSettings = (ExtensionObject) null;
    this.m_writerGroups = new WriterGroupDataTypeCollection();
    this.m_readerGroups = new ReaderGroupDataTypeCollection();
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

  [DataMember(Name = "TransportProfileUri", IsRequired = false, Order = 4)]
  public string TransportProfileUri
  {
    get => this.m_transportProfileUri;
    set => this.m_transportProfileUri = value;
  }

  [DataMember(Name = "Address", IsRequired = false, Order = 5)]
  public ExtensionObject Address
  {
    get => this.m_address;
    set => this.m_address = value;
  }

  [DataMember(Name = "ConnectionProperties", IsRequired = false, Order = 6)]
  public KeyValuePairCollection ConnectionProperties
  {
    get => this.m_connectionProperties;
    set
    {
      this.m_connectionProperties = value;
      if (value != null)
        return;
      this.m_connectionProperties = new KeyValuePairCollection();
    }
  }

  [DataMember(Name = "TransportSettings", IsRequired = false, Order = 7)]
  public ExtensionObject TransportSettings
  {
    get => this.m_transportSettings;
    set => this.m_transportSettings = value;
  }

  [DataMember(Name = "WriterGroups", IsRequired = false, Order = 8)]
  public WriterGroupDataTypeCollection WriterGroups
  {
    get => this.m_writerGroups;
    set
    {
      this.m_writerGroups = value;
      if (value != null)
        return;
      this.m_writerGroups = new WriterGroupDataTypeCollection();
    }
  }

  [DataMember(Name = "ReaderGroups", IsRequired = false, Order = 9)]
  public ReaderGroupDataTypeCollection ReaderGroups
  {
    get => this.m_readerGroups;
    set
    {
      this.m_readerGroups = value;
      if (value != null)
        return;
      this.m_readerGroups = new ReaderGroupDataTypeCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.PubSubConnectionDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PubSubConnectionDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PubSubConnectionDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PubSubConnectionDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("Name", this.Name);
    encoder.WriteBoolean("Enabled", this.Enabled);
    encoder.WriteVariant("PublisherId", this.PublisherId);
    encoder.WriteString("TransportProfileUri", this.TransportProfileUri);
    encoder.WriteExtensionObject("Address", this.Address);
    encoder.WriteEncodeableArray("ConnectionProperties", (IList<IEncodeable>) this.ConnectionProperties.ToArray(), typeof (KeyValuePair));
    encoder.WriteExtensionObject("TransportSettings", this.TransportSettings);
    encoder.WriteEncodeableArray("WriterGroups", (IList<IEncodeable>) this.WriterGroups.ToArray(), typeof (WriterGroupDataType));
    encoder.WriteEncodeableArray("ReaderGroups", (IList<IEncodeable>) this.ReaderGroups.ToArray(), typeof (ReaderGroupDataType));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Name = decoder.ReadString("Name");
    this.Enabled = decoder.ReadBoolean("Enabled");
    this.PublisherId = decoder.ReadVariant("PublisherId");
    this.TransportProfileUri = decoder.ReadString("TransportProfileUri");
    this.Address = decoder.ReadExtensionObject("Address");
    this.ConnectionProperties = (KeyValuePairCollection) (KeyValuePair[]) decoder.ReadEncodeableArray("ConnectionProperties", typeof (KeyValuePair));
    this.TransportSettings = decoder.ReadExtensionObject("TransportSettings");
    this.WriterGroups = (WriterGroupDataTypeCollection) (WriterGroupDataType[]) decoder.ReadEncodeableArray("WriterGroups", typeof (WriterGroupDataType));
    this.ReaderGroups = (ReaderGroupDataTypeCollection) (ReaderGroupDataType[]) decoder.ReadEncodeableArray("ReaderGroups", typeof (ReaderGroupDataType));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is PubSubConnectionDataType connectionDataType && Utils.IsEqual((object) this.m_name, (object) connectionDataType.m_name) && Utils.IsEqual((object) this.m_enabled, (object) connectionDataType.m_enabled) && Utils.IsEqual((object) this.m_publisherId, (object) connectionDataType.m_publisherId) && Utils.IsEqual((object) this.m_transportProfileUri, (object) connectionDataType.m_transportProfileUri) && Utils.IsEqual((object) this.m_address, (object) connectionDataType.m_address) && Utils.IsEqual((object) this.m_connectionProperties, (object) connectionDataType.m_connectionProperties) && Utils.IsEqual((object) this.m_transportSettings, (object) connectionDataType.m_transportSettings) && Utils.IsEqual((object) this.m_writerGroups, (object) connectionDataType.m_writerGroups) && Utils.IsEqual((object) this.m_readerGroups, (object) connectionDataType.m_readerGroups);
  }

  public virtual object Clone() => (object) (PubSubConnectionDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    PubSubConnectionDataType connectionDataType = (PubSubConnectionDataType) base.MemberwiseClone();
    connectionDataType.m_name = (string) Utils.Clone((object) this.m_name);
    connectionDataType.m_enabled = (bool) Utils.Clone((object) this.m_enabled);
    connectionDataType.m_publisherId = (Variant) Utils.Clone((object) this.m_publisherId);
    connectionDataType.m_transportProfileUri = (string) Utils.Clone((object) this.m_transportProfileUri);
    connectionDataType.m_address = (ExtensionObject) Utils.Clone((object) this.m_address);
    connectionDataType.m_connectionProperties = (KeyValuePairCollection) Utils.Clone((object) this.m_connectionProperties);
    connectionDataType.m_transportSettings = (ExtensionObject) Utils.Clone((object) this.m_transportSettings);
    connectionDataType.m_writerGroups = (WriterGroupDataTypeCollection) Utils.Clone((object) this.m_writerGroups);
    connectionDataType.m_readerGroups = (ReaderGroupDataTypeCollection) Utils.Clone((object) this.m_readerGroups);
    return (object) connectionDataType;
  }
}
