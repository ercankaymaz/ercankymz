// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SessionSecurityDiagnosticsDataType
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
public class SessionSecurityDiagnosticsDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_sessionId;
  private string m_clientUserIdOfSession;
  private StringCollection m_clientUserIdHistory;
  private string m_authenticationMechanism;
  private string m_encoding;
  private string m_transportProtocol;
  private MessageSecurityMode m_securityMode;
  private string m_securityPolicyUri;
  private byte[] m_clientCertificate;

  public SessionSecurityDiagnosticsDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_sessionId = (NodeId) null;
    this.m_clientUserIdOfSession = (string) null;
    this.m_clientUserIdHistory = new StringCollection();
    this.m_authenticationMechanism = (string) null;
    this.m_encoding = (string) null;
    this.m_transportProtocol = (string) null;
    this.m_securityMode = MessageSecurityMode.Invalid;
    this.m_securityPolicyUri = (string) null;
    this.m_clientCertificate = (byte[]) null;
  }

  [DataMember(Name = "SessionId", IsRequired = false, Order = 1)]
  public NodeId SessionId
  {
    get => this.m_sessionId;
    set => this.m_sessionId = value;
  }

  [DataMember(Name = "ClientUserIdOfSession", IsRequired = false, Order = 2)]
  public string ClientUserIdOfSession
  {
    get => this.m_clientUserIdOfSession;
    set => this.m_clientUserIdOfSession = value;
  }

  [DataMember(Name = "ClientUserIdHistory", IsRequired = false, Order = 3)]
  public StringCollection ClientUserIdHistory
  {
    get => this.m_clientUserIdHistory;
    set
    {
      this.m_clientUserIdHistory = value;
      if (value != null)
        return;
      this.m_clientUserIdHistory = new StringCollection();
    }
  }

  [DataMember(Name = "AuthenticationMechanism", IsRequired = false, Order = 4)]
  public string AuthenticationMechanism
  {
    get => this.m_authenticationMechanism;
    set => this.m_authenticationMechanism = value;
  }

  [DataMember(Name = "Encoding", IsRequired = false, Order = 5)]
  public string Encoding
  {
    get => this.m_encoding;
    set => this.m_encoding = value;
  }

  [DataMember(Name = "TransportProtocol", IsRequired = false, Order = 6)]
  public string TransportProtocol
  {
    get => this.m_transportProtocol;
    set => this.m_transportProtocol = value;
  }

  [DataMember(Name = "SecurityMode", IsRequired = false, Order = 7)]
  public MessageSecurityMode SecurityMode
  {
    get => this.m_securityMode;
    set => this.m_securityMode = value;
  }

  [DataMember(Name = "SecurityPolicyUri", IsRequired = false, Order = 8)]
  public string SecurityPolicyUri
  {
    get => this.m_securityPolicyUri;
    set => this.m_securityPolicyUri = value;
  }

  [DataMember(Name = "ClientCertificate", IsRequired = false, Order = 9)]
  public byte[] ClientCertificate
  {
    get => this.m_clientCertificate;
    set => this.m_clientCertificate = value;
  }

  public virtual ExpandedNodeId TypeId
  {
    get => (ExpandedNodeId) DataTypeIds.SessionSecurityDiagnosticsDataType;
  }

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SessionSecurityDiagnosticsDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SessionSecurityDiagnosticsDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SessionSecurityDiagnosticsDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("SessionId", this.SessionId);
    encoder.WriteString("ClientUserIdOfSession", this.ClientUserIdOfSession);
    encoder.WriteStringArray("ClientUserIdHistory", (IList<string>) this.ClientUserIdHistory);
    encoder.WriteString("AuthenticationMechanism", this.AuthenticationMechanism);
    encoder.WriteString("Encoding", this.Encoding);
    encoder.WriteString("TransportProtocol", this.TransportProtocol);
    encoder.WriteEnumerated("SecurityMode", (Enum) this.SecurityMode);
    encoder.WriteString("SecurityPolicyUri", this.SecurityPolicyUri);
    encoder.WriteByteString("ClientCertificate", this.ClientCertificate);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.SessionId = decoder.ReadNodeId("SessionId");
    this.ClientUserIdOfSession = decoder.ReadString("ClientUserIdOfSession");
    this.ClientUserIdHistory = decoder.ReadStringArray("ClientUserIdHistory");
    this.AuthenticationMechanism = decoder.ReadString("AuthenticationMechanism");
    this.Encoding = decoder.ReadString("Encoding");
    this.TransportProtocol = decoder.ReadString("TransportProtocol");
    this.SecurityMode = (MessageSecurityMode) decoder.ReadEnumerated("SecurityMode", typeof (MessageSecurityMode));
    this.SecurityPolicyUri = decoder.ReadString("SecurityPolicyUri");
    this.ClientCertificate = decoder.ReadByteString("ClientCertificate");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is SessionSecurityDiagnosticsDataType diagnosticsDataType && Utils.IsEqual((object) this.m_sessionId, (object) diagnosticsDataType.m_sessionId) && Utils.IsEqual((object) this.m_clientUserIdOfSession, (object) diagnosticsDataType.m_clientUserIdOfSession) && Utils.IsEqual((object) this.m_clientUserIdHistory, (object) diagnosticsDataType.m_clientUserIdHistory) && Utils.IsEqual((object) this.m_authenticationMechanism, (object) diagnosticsDataType.m_authenticationMechanism) && Utils.IsEqual((object) this.m_encoding, (object) diagnosticsDataType.m_encoding) && Utils.IsEqual((object) this.m_transportProtocol, (object) diagnosticsDataType.m_transportProtocol) && Utils.IsEqual((object) this.m_securityMode, (object) diagnosticsDataType.m_securityMode) && Utils.IsEqual((object) this.m_securityPolicyUri, (object) diagnosticsDataType.m_securityPolicyUri) && Utils.IsEqual((object) this.m_clientCertificate, (object) diagnosticsDataType.m_clientCertificate);
  }

  public virtual object Clone()
  {
    return (object) (SessionSecurityDiagnosticsDataType) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    SessionSecurityDiagnosticsDataType diagnosticsDataType = (SessionSecurityDiagnosticsDataType) base.MemberwiseClone();
    diagnosticsDataType.m_sessionId = (NodeId) Utils.Clone((object) this.m_sessionId);
    diagnosticsDataType.m_clientUserIdOfSession = (string) Utils.Clone((object) this.m_clientUserIdOfSession);
    diagnosticsDataType.m_clientUserIdHistory = (StringCollection) Utils.Clone((object) this.m_clientUserIdHistory);
    diagnosticsDataType.m_authenticationMechanism = (string) Utils.Clone((object) this.m_authenticationMechanism);
    diagnosticsDataType.m_encoding = (string) Utils.Clone((object) this.m_encoding);
    diagnosticsDataType.m_transportProtocol = (string) Utils.Clone((object) this.m_transportProtocol);
    diagnosticsDataType.m_securityMode = (MessageSecurityMode) Utils.Clone((object) this.m_securityMode);
    diagnosticsDataType.m_securityPolicyUri = (string) Utils.Clone((object) this.m_securityPolicyUri);
    diagnosticsDataType.m_clientCertificate = (byte[]) Utils.Clone((object) this.m_clientCertificate);
    return (object) diagnosticsDataType;
  }
}
