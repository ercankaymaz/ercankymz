// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RegisterServerRequest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class RegisterServerRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private RegisteredServer m_server;

  public RegisterServerRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_server = new RegisteredServer();
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

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.RegisterServerRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RegisterServerRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RegisterServerRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RegisterServerRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteEncodeable("Server", (IEncodeable) this.Server, typeof (RegisteredServer));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.Server = (RegisteredServer) decoder.ReadEncodeable("Server", typeof (RegisteredServer));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is RegisterServerRequest registerServerRequest && Utils.IsEqual((object) this.m_requestHeader, (object) registerServerRequest.m_requestHeader) && Utils.IsEqual((object) this.m_server, (object) registerServerRequest.m_server);
  }

  public virtual object Clone() => (object) (RegisterServerRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    RegisterServerRequest registerServerRequest = (RegisterServerRequest) base.MemberwiseClone();
    registerServerRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    registerServerRequest.m_server = (RegisteredServer) Utils.Clone((object) this.m_server);
    return (object) registerServerRequest;
  }
}
