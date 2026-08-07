// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PubSubConfigurationDataType
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
public class PubSubConfigurationDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private PublishedDataSetDataTypeCollection m_publishedDataSets;
  private PubSubConnectionDataTypeCollection m_connections;
  private bool m_enabled;

  public PubSubConfigurationDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_publishedDataSets = new PublishedDataSetDataTypeCollection();
    this.m_connections = new PubSubConnectionDataTypeCollection();
    this.m_enabled = true;
  }

  [DataMember(Name = "PublishedDataSets", IsRequired = false, Order = 1)]
  public PublishedDataSetDataTypeCollection PublishedDataSets
  {
    get => this.m_publishedDataSets;
    set
    {
      this.m_publishedDataSets = value;
      if (value != null)
        return;
      this.m_publishedDataSets = new PublishedDataSetDataTypeCollection();
    }
  }

  [DataMember(Name = "Connections", IsRequired = false, Order = 2)]
  public PubSubConnectionDataTypeCollection Connections
  {
    get => this.m_connections;
    set
    {
      this.m_connections = value;
      if (value != null)
        return;
      this.m_connections = new PubSubConnectionDataTypeCollection();
    }
  }

  [DataMember(Name = "Enabled", IsRequired = false, Order = 3)]
  public bool Enabled
  {
    get => this.m_enabled;
    set => this.m_enabled = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.PubSubConfigurationDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PubSubConfigurationDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PubSubConfigurationDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PubSubConfigurationDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeableArray("PublishedDataSets", (IList<IEncodeable>) this.PublishedDataSets.ToArray(), typeof (PublishedDataSetDataType));
    encoder.WriteEncodeableArray("Connections", (IList<IEncodeable>) this.Connections.ToArray(), typeof (PubSubConnectionDataType));
    encoder.WriteBoolean("Enabled", this.Enabled);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.PublishedDataSets = (PublishedDataSetDataTypeCollection) (PublishedDataSetDataType[]) decoder.ReadEncodeableArray("PublishedDataSets", typeof (PublishedDataSetDataType));
    this.Connections = (PubSubConnectionDataTypeCollection) (PubSubConnectionDataType[]) decoder.ReadEncodeableArray("Connections", typeof (PubSubConnectionDataType));
    this.Enabled = decoder.ReadBoolean("Enabled");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is PubSubConfigurationDataType configurationDataType && Utils.IsEqual((object) this.m_publishedDataSets, (object) configurationDataType.m_publishedDataSets) && Utils.IsEqual((object) this.m_connections, (object) configurationDataType.m_connections) && Utils.IsEqual((object) this.m_enabled, (object) configurationDataType.m_enabled);
  }

  public virtual object Clone() => (object) (PubSubConfigurationDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    PubSubConfigurationDataType configurationDataType = (PubSubConfigurationDataType) base.MemberwiseClone();
    configurationDataType.m_publishedDataSets = (PublishedDataSetDataTypeCollection) Utils.Clone((object) this.m_publishedDataSets);
    configurationDataType.m_connections = (PubSubConnectionDataTypeCollection) Utils.Clone((object) this.m_connections);
    configurationDataType.m_enabled = (bool) Utils.Clone((object) this.m_enabled);
    return (object) configurationDataType;
  }
}
