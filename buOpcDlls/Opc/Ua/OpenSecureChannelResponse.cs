// Decompiled with JetBrains decompiler
// Type: Opc.Ua.OpenSecureChannelResponse
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
public class OpenSecureChannelResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
  private ResponseHeader m_responseHeader;
  private uint m_serverProtocolVersion;
  private ChannelSecurityToken m_securityToken;
  private byte[] m_serverNonce;

  public OpenSecureChannelResponse() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_responseHeader = new ResponseHeader();
    this.m_serverProtocolVersion = 0U;
    this.m_securityToken = new ChannelSecurityToken();
    this.m_serverNonce = (byte[]) null;
  }

  [DataMember(Name = "ResponseHeader", IsRequired = false, Order = 1)]
  public ResponseHeader ResponseHeader
  {
    get => this.m_responseHeader;
    set
    {
      this.m_responseHeader = value;
      if (value != null)
        return;
      this.m_responseHeader = new ResponseHeader();
    }
  }

  [DataMember(Name = "ServerProtocolVersion", IsRequired = false, Order = 2)]
  public uint ServerProtocolVersion
  {
    get => this.m_serverProtocolVersion;
    set => this.m_serverProtocolVersion = value;
  }

  [DataMember(Name = "SecurityToken", IsRequired = false, Order = 3)]
  public ChannelSecurityToken SecurityToken
  {
    get => this.m_securityToken;
    set
    {
      this.m_securityToken = value;
      if (value != null)
        return;
      this.m_securityToken = new ChannelSecurityToken();
    }
  }

  [DataMember(Name = "ServerNonce", IsRequired = false, Order = 4)]
  public byte[] ServerNonce
  {
    get => this.m_serverNonce;
    set => this.m_serverNonce = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.OpenSecureChannelResponse;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.OpenSecureChannelResponse_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.OpenSecureChannelResponse_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.OpenSecureChannelResponse_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("ResponseHeader", (IEncodeable) this.ResponseHeader, typeof (ResponseHeader));
    encoder.WriteUInt32("ServerProtocolVersion", this.ServerProtocolVersion);
    encoder.WriteEncodeable("SecurityToken", (IEncodeable) this.SecurityToken, typeof (ChannelSecurityToken));
    encoder.WriteByteString("ServerNonce", this.ServerNonce);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ResponseHeader = (ResponseHeader) decoder.ReadEncodeable("ResponseHeader", typeof (ResponseHeader));
    this.ServerProtocolVersion = decoder.ReadUInt32("ServerProtocolVersion");
    this.SecurityToken = (ChannelSecurityToken) decoder.ReadEncodeable("SecurityToken", typeof (ChannelSecurityToken));
    this.ServerNonce = decoder.ReadByteString("ServerNonce");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is OpenSecureChannelResponse secureChannelResponse && Utils.IsEqual((object) this.m_responseHeader, (object) secureChannelResponse.m_responseHeader) && Utils.IsEqual((object) this.m_serverProtocolVersion, (object) secureChannelResponse.m_serverProtocolVersion) && Utils.IsEqual((object) this.m_securityToken, (object) secureChannelResponse.m_securityToken) && Utils.IsEqual((object) this.m_serverNonce, (object) secureChannelResponse.m_serverNonce);
  }

  public virtual object Clone() => (object) (OpenSecureChannelResponse) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    OpenSecureChannelResponse secureChannelResponse = (OpenSecureChannelResponse) base.MemberwiseClone();
    secureChannelResponse.m_responseHeader = (ResponseHeader) Utils.Clone((object) this.m_responseHeader);
    secureChannelResponse.m_serverProtocolVersion = (uint) Utils.Clone((object) this.m_serverProtocolVersion);
    secureChannelResponse.m_securityToken = (ChannelSecurityToken) Utils.Clone((object) this.m_securityToken);
    secureChannelResponse.m_serverNonce = (byte[]) Utils.Clone((object) this.m_serverNonce);
    return (object) secureChannelResponse;
  }
}
