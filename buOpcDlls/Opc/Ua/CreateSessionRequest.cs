// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CreateSessionRequest
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
public class CreateSessionRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private ApplicationDescription m_clientDescription;
  private string m_serverUri;
  private string m_endpointUrl;
  private string m_sessionName;
  private byte[] m_clientNonce;
  private byte[] m_clientCertificate;
  private double m_requestedSessionTimeout;
  private uint m_maxResponseMessageSize;

  public CreateSessionRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_clientDescription = new ApplicationDescription();
    this.m_serverUri = (string) null;
    this.m_endpointUrl = (string) null;
    this.m_sessionName = (string) null;
    this.m_clientNonce = (byte[]) null;
    this.m_clientCertificate = (byte[]) null;
    this.m_requestedSessionTimeout = 0.0;
    this.m_maxResponseMessageSize = 0U;
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

  [DataMember(Name = "ClientDescription", IsRequired = false, Order = 2)]
  public ApplicationDescription ClientDescription
  {
    get => this.m_clientDescription;
    set
    {
      this.m_clientDescription = value;
      if (value != null)
        return;
      this.m_clientDescription = new ApplicationDescription();
    }
  }

  [DataMember(Name = "ServerUri", IsRequired = false, Order = 3)]
  public string ServerUri
  {
    get => this.m_serverUri;
    set => this.m_serverUri = value;
  }

  [DataMember(Name = "EndpointUrl", IsRequired = false, Order = 4)]
  public string EndpointUrl
  {
    get => this.m_endpointUrl;
    set => this.m_endpointUrl = value;
  }

  [DataMember(Name = "SessionName", IsRequired = false, Order = 5)]
  public string SessionName
  {
    get => this.m_sessionName;
    set => this.m_sessionName = value;
  }

  [DataMember(Name = "ClientNonce", IsRequired = false, Order = 6)]
  public byte[] ClientNonce
  {
    get => this.m_clientNonce;
    set => this.m_clientNonce = value;
  }

  [DataMember(Name = "ClientCertificate", IsRequired = false, Order = 7)]
  public byte[] ClientCertificate
  {
    get => this.m_clientCertificate;
    set => this.m_clientCertificate = value;
  }

  [DataMember(Name = "RequestedSessionTimeout", IsRequired = false, Order = 8)]
  public double RequestedSessionTimeout
  {
    get => this.m_requestedSessionTimeout;
    set => this.m_requestedSessionTimeout = value;
  }

  [DataMember(Name = "MaxResponseMessageSize", IsRequired = false, Order = 9)]
  public uint MaxResponseMessageSize
  {
    get => this.m_maxResponseMessageSize;
    set => this.m_maxResponseMessageSize = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.CreateSessionRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CreateSessionRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CreateSessionRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CreateSessionRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteEncodeable("ClientDescription", (IEncodeable) this.ClientDescription, typeof (ApplicationDescription));
    encoder.WriteString("ServerUri", this.ServerUri);
    encoder.WriteString("EndpointUrl", this.EndpointUrl);
    encoder.WriteString("SessionName", this.SessionName);
    encoder.WriteByteString("ClientNonce", this.ClientNonce);
    encoder.WriteByteString("ClientCertificate", this.ClientCertificate);
    encoder.WriteDouble("RequestedSessionTimeout", this.RequestedSessionTimeout);
    encoder.WriteUInt32("MaxResponseMessageSize", this.MaxResponseMessageSize);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.ClientDescription = (ApplicationDescription) decoder.ReadEncodeable("ClientDescription", typeof (ApplicationDescription));
    this.ServerUri = decoder.ReadString("ServerUri");
    this.EndpointUrl = decoder.ReadString("EndpointUrl");
    this.SessionName = decoder.ReadString("SessionName");
    this.ClientNonce = decoder.ReadByteString("ClientNonce");
    this.ClientCertificate = decoder.ReadByteString("ClientCertificate");
    this.RequestedSessionTimeout = decoder.ReadDouble("RequestedSessionTimeout");
    this.MaxResponseMessageSize = decoder.ReadUInt32("MaxResponseMessageSize");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is CreateSessionRequest createSessionRequest && Utils.IsEqual((object) this.m_requestHeader, (object) createSessionRequest.m_requestHeader) && Utils.IsEqual((object) this.m_clientDescription, (object) createSessionRequest.m_clientDescription) && Utils.IsEqual((object) this.m_serverUri, (object) createSessionRequest.m_serverUri) && Utils.IsEqual((object) this.m_endpointUrl, (object) createSessionRequest.m_endpointUrl) && Utils.IsEqual((object) this.m_sessionName, (object) createSessionRequest.m_sessionName) && Utils.IsEqual((object) this.m_clientNonce, (object) createSessionRequest.m_clientNonce) && Utils.IsEqual((object) this.m_clientCertificate, (object) createSessionRequest.m_clientCertificate) && Utils.IsEqual((object) this.m_requestedSessionTimeout, (object) createSessionRequest.m_requestedSessionTimeout) && Utils.IsEqual((object) this.m_maxResponseMessageSize, (object) createSessionRequest.m_maxResponseMessageSize);
  }

  public virtual object Clone() => (object) (CreateSessionRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    CreateSessionRequest createSessionRequest = (CreateSessionRequest) base.MemberwiseClone();
    createSessionRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    createSessionRequest.m_clientDescription = (ApplicationDescription) Utils.Clone((object) this.m_clientDescription);
    createSessionRequest.m_serverUri = (string) Utils.Clone((object) this.m_serverUri);
    createSessionRequest.m_endpointUrl = (string) Utils.Clone((object) this.m_endpointUrl);
    createSessionRequest.m_sessionName = (string) Utils.Clone((object) this.m_sessionName);
    createSessionRequest.m_clientNonce = (byte[]) Utils.Clone((object) this.m_clientNonce);
    createSessionRequest.m_clientCertificate = (byte[]) Utils.Clone((object) this.m_clientCertificate);
    createSessionRequest.m_requestedSessionTimeout = (double) Utils.Clone((object) this.m_requestedSessionTimeout);
    createSessionRequest.m_maxResponseMessageSize = (uint) Utils.Clone((object) this.m_maxResponseMessageSize);
    return (object) createSessionRequest;
  }
}
