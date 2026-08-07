// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RegisterServer2Request
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
public class RegisterServer2Request : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private RegisteredServer m_server;
  private ExtensionObjectCollection m_discoveryConfiguration;

  public RegisterServer2Request() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_server = new RegisteredServer();
    this.m_discoveryConfiguration = new ExtensionObjectCollection();
  }

  [DataMember(Name = "RequestHeader", IsRequired = false, Order = 1)]
  public RequestHeader RequestHeader
  {
    get => this.m_requestHeader;
    set
    {
      this.m_requestHeader = value;
      if (value != null)
        return;
      this.m_requestHeader = new RequestHeader();
    }
  }

  [DataMember(Name = "Server", IsRequired = false, Order = 2)]
  public RegisteredServer Server
  {
    get => this.m_server;
    set
    {
      this.m_server = value;
      if (value != null)
        return;
      this.m_server = new RegisteredServer();
    }
  }

  [DataMember(Name = "DiscoveryConfiguration", IsRequired = false, Order = 3)]
  public ExtensionObjectCollection DiscoveryConfiguration
  {
    get => this.m_discoveryConfiguration;
    set
    {
      this.m_discoveryConfiguration = value;
      if (value != null)
        return;
      this.m_discoveryConfiguration = new ExtensionObjectCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.RegisterServer2Request;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RegisterServer2Request_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RegisterServer2Request_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RegisterServer2Request_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteEncodeable("Server", (IEncodeable) this.Server, typeof (RegisteredServer));
    encoder.WriteExtensionObjectArray("DiscoveryConfiguration", (IList<ExtensionObject>) this.DiscoveryConfiguration);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.Server = (RegisteredServer) decoder.ReadEncodeable("Server", typeof (RegisteredServer));
    this.DiscoveryConfiguration = decoder.ReadExtensionObjectArray("DiscoveryConfiguration");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is RegisterServer2Request registerServer2Request && Utils.IsEqual((object) this.m_requestHeader, (object) registerServer2Request.m_requestHeader) && Utils.IsEqual((object) this.m_server, (object) registerServer2Request.m_server) && Utils.IsEqual((object) this.m_discoveryConfiguration, (object) registerServer2Request.m_discoveryConfiguration);
  }

  public virtual object Clone() => (object) (RegisterServer2Request) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    RegisterServer2Request registerServer2Request = (RegisterServer2Request) base.MemberwiseClone();
    registerServer2Request.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    registerServer2Request.m_server = (RegisteredServer) Utils.Clone((object) this.m_server);
    registerServer2Request.m_discoveryConfiguration = (ExtensionObjectCollection) Utils.Clone((object) this.m_discoveryConfiguration);
    return (object) registerServer2Request;
  }
}
