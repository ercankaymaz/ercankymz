// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServerOnNetwork
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
public class ServerOnNetwork : IEncodeable, ICloneable, IJsonEncodeable
{
  private uint m_recordId;
  private string m_serverName;
  private string m_discoveryUrl;
  private StringCollection m_serverCapabilities;

  public ServerOnNetwork() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_recordId = 0U;
    this.m_serverName = (string) null;
    this.m_discoveryUrl = (string) null;
    this.m_serverCapabilities = new StringCollection();
  }

  [DataMember(Name = "RecordId", IsRequired = false, Order = 1)]
  public uint RecordId
  {
    get => this.m_recordId;
    set => this.m_recordId = value;
  }

  [DataMember(Name = "ServerName", IsRequired = false, Order = 2)]
  public string ServerName
  {
    get => this.m_serverName;
    set => this.m_serverName = value;
  }

  [DataMember(Name = "DiscoveryUrl", IsRequired = false, Order = 3)]
  public string DiscoveryUrl
  {
    get => this.m_discoveryUrl;
    set => this.m_discoveryUrl = value;
  }

  [DataMember(Name = "ServerCapabilities", IsRequired = false, Order = 4)]
  public StringCollection ServerCapabilities
  {
    get => this.m_serverCapabilities;
    set
    {
      this.m_serverCapabilities = value;
      if (value != null)
        return;
      this.m_serverCapabilities = new StringCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ServerOnNetwork;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ServerOnNetwork_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ServerOnNetwork_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ServerOnNetwork_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("RecordId", this.RecordId);
    encoder.WriteString("ServerName", this.ServerName);
    encoder.WriteString("DiscoveryUrl", this.DiscoveryUrl);
    encoder.WriteStringArray("ServerCapabilities", (IList<string>) this.ServerCapabilities);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RecordId = decoder.ReadUInt32("RecordId");
    this.ServerName = decoder.ReadString("ServerName");
    this.DiscoveryUrl = decoder.ReadString("DiscoveryUrl");
    this.ServerCapabilities = decoder.ReadStringArray("ServerCapabilities");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ServerOnNetwork serverOnNetwork && Utils.IsEqual((object) this.m_recordId, (object) serverOnNetwork.m_recordId) && Utils.IsEqual((object) this.m_serverName, (object) serverOnNetwork.m_serverName) && Utils.IsEqual((object) this.m_discoveryUrl, (object) serverOnNetwork.m_discoveryUrl) && Utils.IsEqual((object) this.m_serverCapabilities, (object) serverOnNetwork.m_serverCapabilities);
  }

  public virtual object Clone() => (object) (ServerOnNetwork) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ServerOnNetwork serverOnNetwork = (ServerOnNetwork) base.MemberwiseClone();
    serverOnNetwork.m_recordId = (uint) Utils.Clone((object) this.m_recordId);
    serverOnNetwork.m_serverName = (string) Utils.Clone((object) this.m_serverName);
    serverOnNetwork.m_discoveryUrl = (string) Utils.Clone((object) this.m_discoveryUrl);
    serverOnNetwork.m_serverCapabilities = (StringCollection) Utils.Clone((object) this.m_serverCapabilities);
    return (object) serverOnNetwork;
  }
}
