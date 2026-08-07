// Decompiled with JetBrains decompiler
// Type: Opc.Ua.OpenSecureChannelRequest
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
public class OpenSecureChannelRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
  private RequestHeader m_requestHeader;
  private uint m_clientProtocolVersion;
  private SecurityTokenRequestType m_requestType;
  private MessageSecurityMode m_securityMode;
  private byte[] m_clientNonce;
  private uint m_requestedLifetime;

  public OpenSecureChannelRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_requestHeader = new RequestHeader();
    this.m_clientProtocolVersion = 0U;
    this.m_requestType = SecurityTokenRequestType.Issue;
    this.m_securityMode = MessageSecurityMode.Invalid;
    this.m_clientNonce = (byte[]) null;
    this.m_requestedLifetime = 0U;
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

  [DataMember(Name = "ClientProtocolVersion", IsRequired = false, Order = 2)]
  public uint ClientProtocolVersion
  {
    get => this.m_clientProtocolVersion;
    set => this.m_clientProtocolVersion = value;
  }

  [DataMember(Name = "RequestType", IsRequired = false, Order = 3)]
  public SecurityTokenRequestType RequestType
  {
    get => this.m_requestType;
    set => this.m_requestType = value;
  }

  [DataMember(Name = "SecurityMode", IsRequired = false, Order = 4)]
  public MessageSecurityMode SecurityMode
  {
    get => this.m_securityMode;
    set => this.m_securityMode = value;
  }

  [DataMember(Name = "ClientNonce", IsRequired = false, Order = 5)]
  public byte[] ClientNonce
  {
    get => this.m_clientNonce;
    set => this.m_clientNonce = value;
  }

  [DataMember(Name = "RequestedLifetime", IsRequired = false, Order = 6)]
  public uint RequestedLifetime
  {
    get => this.m_requestedLifetime;
    set => this.m_requestedLifetime = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.OpenSecureChannelRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.OpenSecureChannelRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.OpenSecureChannelRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.OpenSecureChannelRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("RequestHeader", (IEncodeable) this.RequestHeader, typeof (RequestHeader));
    encoder.WriteUInt32("ClientProtocolVersion", this.ClientProtocolVersion);
    encoder.WriteEnumerated("RequestType", (Enum) this.RequestType);
    encoder.WriteEnumerated("SecurityMode", (Enum) this.SecurityMode);
    encoder.WriteByteString("ClientNonce", this.ClientNonce);
    encoder.WriteUInt32("RequestedLifetime", this.RequestedLifetime);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RequestHeader = (RequestHeader) decoder.ReadEncodeable("RequestHeader", typeof (RequestHeader));
    this.ClientProtocolVersion = decoder.ReadUInt32("ClientProtocolVersion");
    this.RequestType = (SecurityTokenRequestType) decoder.ReadEnumerated("RequestType", typeof (SecurityTokenRequestType));
    this.SecurityMode = (MessageSecurityMode) decoder.ReadEnumerated("SecurityMode", typeof (MessageSecurityMode));
    this.ClientNonce = decoder.ReadByteString("ClientNonce");
    this.RequestedLifetime = decoder.ReadUInt32("RequestedLifetime");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is OpenSecureChannelRequest secureChannelRequest && Utils.IsEqual((object) this.m_requestHeader, (object) secureChannelRequest.m_requestHeader) && Utils.IsEqual((object) this.m_clientProtocolVersion, (object) secureChannelRequest.m_clientProtocolVersion) && Utils.IsEqual((object) this.m_requestType, (object) secureChannelRequest.m_requestType) && Utils.IsEqual((object) this.m_securityMode, (object) secureChannelRequest.m_securityMode) && Utils.IsEqual((object) this.m_clientNonce, (object) secureChannelRequest.m_clientNonce) && Utils.IsEqual((object) this.m_requestedLifetime, (object) secureChannelRequest.m_requestedLifetime);
  }

  public virtual object Clone() => (object) (OpenSecureChannelRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    OpenSecureChannelRequest secureChannelRequest = (OpenSecureChannelRequest) base.MemberwiseClone();
    secureChannelRequest.m_requestHeader = (RequestHeader) Utils.Clone((object) this.m_requestHeader);
    secureChannelRequest.m_clientProtocolVersion = (uint) Utils.Clone((object) this.m_clientProtocolVersion);
    secureChannelRequest.m_requestType = (SecurityTokenRequestType) Utils.Clone((object) this.m_requestType);
    secureChannelRequest.m_securityMode = (MessageSecurityMode) Utils.Clone((object) this.m_securityMode);
    secureChannelRequest.m_clientNonce = (byte[]) Utils.Clone((object) this.m_clientNonce);
    secureChannelRequest.m_requestedLifetime = (uint) Utils.Clone((object) this.m_requestedLifetime);
    return (object) secureChannelRequest;
  }
}
