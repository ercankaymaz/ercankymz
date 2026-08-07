// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RegisteredServer
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
public class RegisteredServer : IEncodeable, ICloneable, IJsonEncodeable
{
  private string m_serverUri;
  private string m_productUri;
  private LocalizedTextCollection m_serverNames;
  private ApplicationType m_serverType;
  private string m_gatewayServerUri;
  private StringCollection m_discoveryUrls;
  private string m_semaphoreFilePath;
  private bool m_isOnline;

  public RegisteredServer() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_serverUri = (string) null;
    this.m_productUri = (string) null;
    this.m_serverNames = new LocalizedTextCollection();
    this.m_serverType = ApplicationType.Server;
    this.m_gatewayServerUri = (string) null;
    this.m_discoveryUrls = new StringCollection();
    this.m_semaphoreFilePath = (string) null;
    this.m_isOnline = true;
  }

  [DataMember(Name = "ServerUri", IsRequired = false, Order = 1)]
  public string ServerUri
  {
    get => this.m_serverUri;
    set => this.m_serverUri = value;
  }

  [DataMember(Name = "ProductUri", IsRequired = false, Order = 2)]
  public string ProductUri
  {
    get => this.m_productUri;
    set => this.m_productUri = value;
  }

  [DataMember(Name = "ServerNames", IsRequired = false, Order = 3)]
  public LocalizedTextCollection ServerNames
  {
    get => this.m_serverNames;
    set
    {
      this.m_serverNames = value;
      if (value != null)
        return;
      this.m_serverNames = new LocalizedTextCollection();
    }
  }

  [DataMember(Name = "ServerType", IsRequired = false, Order = 4)]
  public ApplicationType ServerType
  {
    get => this.m_serverType;
    set => this.m_serverType = value;
  }

  [DataMember(Name = "GatewayServerUri", IsRequired = false, Order = 5)]
  public string GatewayServerUri
  {
    get => this.m_gatewayServerUri;
    set => this.m_gatewayServerUri = value;
  }

  [DataMember(Name = "DiscoveryUrls", IsRequired = false, Order = 6)]
  public StringCollection DiscoveryUrls
  {
    get => this.m_discoveryUrls;
    set
    {
      this.m_discoveryUrls = value;
      if (value != null)
        return;
      this.m_discoveryUrls = new StringCollection();
    }
  }

  [DataMember(Name = "SemaphoreFilePath", IsRequired = false, Order = 7)]
  public string SemaphoreFilePath
  {
    get => this.m_semaphoreFilePath;
    set => this.m_semaphoreFilePath = value;
  }

  [DataMember(Name = "IsOnline", IsRequired = false, Order = 8)]
  public bool IsOnline
  {
    get => this.m_isOnline;
    set => this.m_isOnline = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.RegisteredServer;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RegisteredServer_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RegisteredServer_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RegisteredServer_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("ServerUri", this.ServerUri);
    encoder.WriteString("ProductUri", this.ProductUri);
    encoder.WriteLocalizedTextArray("ServerNames", (IList<LocalizedText>) this.ServerNames);
    encoder.WriteEnumerated("ServerType", (Enum) this.ServerType);
    encoder.WriteString("GatewayServerUri", this.GatewayServerUri);
    encoder.WriteStringArray("DiscoveryUrls", (IList<string>) this.DiscoveryUrls);
    encoder.WriteString("SemaphoreFilePath", this.SemaphoreFilePath);
    encoder.WriteBoolean("IsOnline", this.IsOnline);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ServerUri = decoder.ReadString("ServerUri");
    this.ProductUri = decoder.ReadString("ProductUri");
    this.ServerNames = decoder.ReadLocalizedTextArray("ServerNames");
    this.ServerType = (ApplicationType) decoder.ReadEnumerated("ServerType", typeof (ApplicationType));
    this.GatewayServerUri = decoder.ReadString("GatewayServerUri");
    this.DiscoveryUrls = decoder.ReadStringArray("DiscoveryUrls");
    this.SemaphoreFilePath = decoder.ReadString("SemaphoreFilePath");
    this.IsOnline = decoder.ReadBoolean("IsOnline");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is RegisteredServer registeredServer && Utils.IsEqual((object) this.m_serverUri, (object) registeredServer.m_serverUri) && Utils.IsEqual((object) this.m_productUri, (object) registeredServer.m_productUri) && Utils.IsEqual((object) this.m_serverNames, (object) registeredServer.m_serverNames) && Utils.IsEqual((object) this.m_serverType, (object) registeredServer.m_serverType) && Utils.IsEqual((object) this.m_gatewayServerUri, (object) registeredServer.m_gatewayServerUri) && Utils.IsEqual((object) this.m_discoveryUrls, (object) registeredServer.m_discoveryUrls) && Utils.IsEqual((object) this.m_semaphoreFilePath, (object) registeredServer.m_semaphoreFilePath) && Utils.IsEqual((object) this.m_isOnline, (object) registeredServer.m_isOnline);
  }

  public virtual object Clone() => (object) (RegisteredServer) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    RegisteredServer registeredServer = (RegisteredServer) base.MemberwiseClone();
    registeredServer.m_serverUri = (string) Utils.Clone((object) this.m_serverUri);
    registeredServer.m_productUri = (string) Utils.Clone((object) this.m_productUri);
    registeredServer.m_serverNames = (LocalizedTextCollection) Utils.Clone((object) this.m_serverNames);
    registeredServer.m_serverType = (ApplicationType) Utils.Clone((object) this.m_serverType);
    registeredServer.m_gatewayServerUri = (string) Utils.Clone((object) this.m_gatewayServerUri);
    registeredServer.m_discoveryUrls = (StringCollection) Utils.Clone((object) this.m_discoveryUrls);
    registeredServer.m_semaphoreFilePath = (string) Utils.Clone((object) this.m_semaphoreFilePath);
    registeredServer.m_isOnline = (bool) Utils.Clone((object) this.m_isOnline);
    return (object) registeredServer;
  }
}
