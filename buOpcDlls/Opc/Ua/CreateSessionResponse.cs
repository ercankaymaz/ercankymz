// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CreateSessionResponse
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
public class CreateSessionResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
  private ResponseHeader m_responseHeader;
  private NodeId m_sessionId;
  private NodeId m_authenticationToken;
  private double m_revisedSessionTimeout;
  private byte[] m_serverNonce;
  private byte[] m_serverCertificate;
  private EndpointDescriptionCollection m_serverEndpoints;
  private SignedSoftwareCertificateCollection m_serverSoftwareCertificates;
  private SignatureData m_serverSignature;
  private uint m_maxRequestMessageSize;

  public CreateSessionResponse() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_responseHeader = new ResponseHeader();
    this.m_sessionId = (NodeId) null;
    this.m_authenticationToken = (NodeId) null;
    this.m_revisedSessionTimeout = 0.0;
    this.m_serverNonce = (byte[]) null;
    this.m_serverCertificate = (byte[]) null;
    this.m_serverEndpoints = new EndpointDescriptionCollection();
    this.m_serverSoftwareCertificates = new SignedSoftwareCertificateCollection();
    this.m_serverSignature = new SignatureData();
    this.m_maxRequestMessageSize = 0U;
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

  [DataMember(Name = "SessionId", IsRequired = false, Order = 2)]
  public NodeId SessionId
  {
    get => this.m_sessionId;
    set => this.m_sessionId = value;
  }

  [DataMember(Name = "AuthenticationToken", IsRequired = false, Order = 3)]
  public NodeId AuthenticationToken
  {
    get => this.m_authenticationToken;
    set => this.m_authenticationToken = value;
  }

  [DataMember(Name = "RevisedSessionTimeout", IsRequired = false, Order = 4)]
  public double RevisedSessionTimeout
  {
    get => this.m_revisedSessionTimeout;
    set => this.m_revisedSessionTimeout = value;
  }

  [DataMember(Name = "ServerNonce", IsRequired = false, Order = 5)]
  public byte[] ServerNonce
  {
    get => this.m_serverNonce;
    set => this.m_serverNonce = value;
  }

  [DataMember(Name = "ServerCertificate", IsRequired = false, Order = 6)]
  public byte[] ServerCertificate
  {
    get => this.m_serverCertificate;
    set => this.m_serverCertificate = value;
  }

  [DataMember(Name = "ServerEndpoints", IsRequired = false, Order = 7)]
  public EndpointDescriptionCollection ServerEndpoints
  {
    get => this.m_serverEndpoints;
    set
    {
      this.m_serverEndpoints = value;
      if (value != null)
        return;
      this.m_serverEndpoints = new EndpointDescriptionCollection();
    }
  }

  [DataMember(Name = "ServerSoftwareCertificates", IsRequired = false, Order = 8)]
  public SignedSoftwareCertificateCollection ServerSoftwareCertificates
  {
    get => this.m_serverSoftwareCertificates;
    set
    {
      this.m_serverSoftwareCertificates = value;
      if (value != null)
        return;
      this.m_serverSoftwareCertificates = new SignedSoftwareCertificateCollection();
    }
  }

  [DataMember(Name = "ServerSignature", IsRequired = false, Order = 9)]
  public SignatureData ServerSignature
  {
    get => this.m_serverSignature;
    set
    {
      this.m_serverSignature = value;
      if (value != null)
        return;
      this.m_serverSignature = new SignatureData();
    }
  }

  [DataMember(Name = "MaxRequestMessageSize", IsRequired = false, Order = 10)]
  public uint MaxRequestMessageSize
  {
    get => this.m_maxRequestMessageSize;
    set => this.m_maxRequestMessageSize = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.CreateSessionResponse;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CreateSessionResponse_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CreateSessionResponse_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.CreateSessionResponse_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("ResponseHeader", (IEncodeable) this.ResponseHeader, typeof (ResponseHeader));
    encoder.WriteNodeId("SessionId", this.SessionId);
    encoder.WriteNodeId("AuthenticationToken", this.AuthenticationToken);
    encoder.WriteDouble("RevisedSessionTimeout", this.RevisedSessionTimeout);
    encoder.WriteByteString("ServerNonce", this.ServerNonce);
    encoder.WriteByteString("ServerCertificate", this.ServerCertificate);
    encoder.WriteEncodeableArray("ServerEndpoints", (IList<IEncodeable>) this.ServerEndpoints.ToArray(), typeof (EndpointDescription));
    encoder.WriteEncodeableArray("ServerSoftwareCertificates", (IList<IEncodeable>) this.ServerSoftwareCertificates.ToArray(), typeof (SignedSoftwareCertificate));
    encoder.WriteEncodeable("ServerSignature", (IEncodeable) this.ServerSignature, typeof (SignatureData));
    encoder.WriteUInt32("MaxRequestMessageSize", this.MaxRequestMessageSize);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ResponseHeader = (ResponseHeader) decoder.ReadEncodeable("ResponseHeader", typeof (ResponseHeader));
    this.SessionId = decoder.ReadNodeId("SessionId");
    this.AuthenticationToken = decoder.ReadNodeId("AuthenticationToken");
    this.RevisedSessionTimeout = decoder.ReadDouble("RevisedSessionTimeout");
    this.ServerNonce = decoder.ReadByteString("ServerNonce");
    this.ServerCertificate = decoder.ReadByteString("ServerCertificate");
    this.ServerEndpoints = (EndpointDescriptionCollection) (EndpointDescription[]) decoder.ReadEncodeableArray("ServerEndpoints", typeof (EndpointDescription));
    this.ServerSoftwareCertificates = (SignedSoftwareCertificateCollection) (SignedSoftwareCertificate[]) decoder.ReadEncodeableArray("ServerSoftwareCertificates", typeof (SignedSoftwareCertificate));
    this.ServerSignature = (SignatureData) decoder.ReadEncodeable("ServerSignature", typeof (SignatureData));
    this.MaxRequestMessageSize = decoder.ReadUInt32("MaxRequestMessageSize");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is CreateSessionResponse createSessionResponse && Utils.IsEqual((object) this.m_responseHeader, (object) createSessionResponse.m_responseHeader) && Utils.IsEqual((object) this.m_sessionId, (object) createSessionResponse.m_sessionId) && Utils.IsEqual((object) this.m_authenticationToken, (object) createSessionResponse.m_authenticationToken) && Utils.IsEqual((object) this.m_revisedSessionTimeout, (object) createSessionResponse.m_revisedSessionTimeout) && Utils.IsEqual((object) this.m_serverNonce, (object) createSessionResponse.m_serverNonce) && Utils.IsEqual((object) this.m_serverCertificate, (object) createSessionResponse.m_serverCertificate) && Utils.IsEqual((object) this.m_serverEndpoints, (object) createSessionResponse.m_serverEndpoints) && Utils.IsEqual((object) this.m_serverSoftwareCertificates, (object) createSessionResponse.m_serverSoftwareCertificates) && Utils.IsEqual((object) this.m_serverSignature, (object) createSessionResponse.m_serverSignature) && Utils.IsEqual((object) this.m_maxRequestMessageSize, (object) createSessionResponse.m_maxRequestMessageSize);
  }

  public virtual object Clone() => (object) (CreateSessionResponse) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    CreateSessionResponse createSessionResponse = (CreateSessionResponse) base.MemberwiseClone();
    createSessionResponse.m_responseHeader = (ResponseHeader) Utils.Clone((object) this.m_responseHeader);
    createSessionResponse.m_sessionId = (NodeId) Utils.Clone((object) this.m_sessionId);
    createSessionResponse.m_authenticationToken = (NodeId) Utils.Clone((object) this.m_authenticationToken);
    createSessionResponse.m_revisedSessionTimeout = (double) Utils.Clone((object) this.m_revisedSessionTimeout);
    createSessionResponse.m_serverNonce = (byte[]) Utils.Clone((object) this.m_serverNonce);
    createSessionResponse.m_serverCertificate = (byte[]) Utils.Clone((object) this.m_serverCertificate);
    createSessionResponse.m_serverEndpoints = (EndpointDescriptionCollection) Utils.Clone((object) this.m_serverEndpoints);
    createSessionResponse.m_serverSoftwareCertificates = (SignedSoftwareCertificateCollection) Utils.Clone((object) this.m_serverSoftwareCertificates);
    createSessionResponse.m_serverSignature = (SignatureData) Utils.Clone((object) this.m_serverSignature);
    createSessionResponse.m_maxRequestMessageSize = (uint) Utils.Clone((object) this.m_maxRequestMessageSize);
    return (object) createSessionResponse;
  }
}
