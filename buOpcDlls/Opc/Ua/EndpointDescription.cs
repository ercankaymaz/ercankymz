// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EndpointDescription
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class EndpointDescription : IEncodeable, ICloneable, IJsonEncodeable
{
  private Uri m_proxyUrl;
  private string m_endpointUrl;
  private ApplicationDescription m_server;
  private byte[] m_serverCertificate;
  private MessageSecurityMode m_securityMode;
  private string m_securityPolicyUri;
  private UserTokenPolicyCollection m_userIdentityTokens;
  private string m_transportProfileUri;
  private byte m_securityLevel;

  public EndpointDescription(string url)
  {
    this.Initialize();
    UriBuilder uriBuilder = new UriBuilder(url);
    if (uriBuilder.Scheme.StartsWith("http", StringComparison.Ordinal) && !uriBuilder.Path.EndsWith("/discovery"))
      uriBuilder.Path += "/discovery";
    this.Server.DiscoveryUrls.Add(uriBuilder.ToString());
    this.EndpointUrl = url;
    this.Server.ApplicationUri = url;
    this.Server.ApplicationName = (LocalizedText) url;
    this.SecurityMode = MessageSecurityMode.None;
    this.SecurityPolicyUri = "http://opcfoundation.org/UA/SecurityPolicy#None";
  }

  public BinaryEncodingSupport EncodingSupport
  {
    get
    {
      if (!string.IsNullOrEmpty(this.EndpointUrl) && this.EndpointUrl.StartsWith("opc.tcp"))
        return BinaryEncodingSupport.Required;
      this.TransportProfileUri = Profiles.NormalizeUri(this.TransportProfileUri);
      return this.TransportProfileUri == "http://opcfoundation.org/UA-Profile/Transport/https-uabinary" ? BinaryEncodingSupport.Required : BinaryEncodingSupport.None;
    }
  }

  public Uri ProxyUrl
  {
    get => this.m_proxyUrl;
    set => this.m_proxyUrl = value;
  }

  public UserTokenPolicy FindUserTokenPolicy(string policyId)
  {
    foreach (UserTokenPolicy userIdentityToken in (List<UserTokenPolicy>) this.m_userIdentityTokens)
    {
      if (userIdentityToken.PolicyId == policyId)
        return userIdentityToken;
    }
    return (UserTokenPolicy) null;
  }

  public UserTokenPolicy FindUserTokenPolicy(
    UserTokenType tokenType,
    XmlQualifiedName issuedTokenType)
  {
    return issuedTokenType == (XmlQualifiedName) null ? this.FindUserTokenPolicy(tokenType, (string) null) : this.FindUserTokenPolicy(tokenType, issuedTokenType.Namespace);
  }

  public UserTokenPolicy FindUserTokenPolicy(UserTokenType tokenType, string issuedTokenType)
  {
    string str = issuedTokenType;
    foreach (UserTokenPolicy userIdentityToken in (List<UserTokenPolicy>) this.m_userIdentityTokens)
    {
      if (tokenType == userIdentityToken.TokenType && !(str != userIdentityToken.IssuedTokenType))
        return userIdentityToken;
    }
    return (UserTokenPolicy) null;
  }

  public EndpointDescription() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_endpointUrl = (string) null;
    this.m_server = new ApplicationDescription();
    this.m_serverCertificate = (byte[]) null;
    this.m_securityMode = MessageSecurityMode.Invalid;
    this.m_securityPolicyUri = (string) null;
    this.m_userIdentityTokens = new UserTokenPolicyCollection();
    this.m_transportProfileUri = (string) null;
    this.m_securityLevel = (byte) 0;
  }

  [DataMember(Name = "EndpointUrl", IsRequired = false, Order = 1)]
  public string EndpointUrl
  {
    get => this.m_endpointUrl;
    set => this.m_endpointUrl = value;
  }

  [DataMember(Name = "Server", IsRequired = false, Order = 2)]
  public ApplicationDescription Server
  {
    get => this.m_server;
    set
    {
      this.m_server = value;
      if (value != null)
        return;
      this.m_server = new ApplicationDescription();
    }
  }

  [DataMember(Name = "ServerCertificate", IsRequired = false, Order = 3)]
  public byte[] ServerCertificate
  {
    get => this.m_serverCertificate;
    set => this.m_serverCertificate = value;
  }

  [DataMember(Name = "SecurityMode", IsRequired = false, Order = 4)]
  public MessageSecurityMode SecurityMode
  {
    get => this.m_securityMode;
    set => this.m_securityMode = value;
  }

  [DataMember(Name = "SecurityPolicyUri", IsRequired = false, Order = 5)]
  public string SecurityPolicyUri
  {
    get => this.m_securityPolicyUri;
    set => this.m_securityPolicyUri = value;
  }

  [DataMember(Name = "UserIdentityTokens", IsRequired = false, Order = 6)]
  public UserTokenPolicyCollection UserIdentityTokens
  {
    get => this.m_userIdentityTokens;
    set
    {
      this.m_userIdentityTokens = value;
      if (value != null)
        return;
      this.m_userIdentityTokens = new UserTokenPolicyCollection();
    }
  }

  [DataMember(Name = "TransportProfileUri", IsRequired = false, Order = 7)]
  public string TransportProfileUri
  {
    get => this.m_transportProfileUri;
    set => this.m_transportProfileUri = value;
  }

  [DataMember(Name = "SecurityLevel", IsRequired = false, Order = 8)]
  public byte SecurityLevel
  {
    get => this.m_securityLevel;
    set => this.m_securityLevel = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.EndpointDescription;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EndpointDescription_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EndpointDescription_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EndpointDescription_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("EndpointUrl", this.EndpointUrl);
    encoder.WriteEncodeable("Server", (IEncodeable) this.Server, typeof (ApplicationDescription));
    encoder.WriteByteString("ServerCertificate", this.ServerCertificate);
    encoder.WriteEnumerated("SecurityMode", (Enum) this.SecurityMode);
    encoder.WriteString("SecurityPolicyUri", this.SecurityPolicyUri);
    encoder.WriteEncodeableArray("UserIdentityTokens", (IList<IEncodeable>) this.UserIdentityTokens.ToArray(), typeof (UserTokenPolicy));
    encoder.WriteString("TransportProfileUri", this.TransportProfileUri);
    encoder.WriteByte("SecurityLevel", this.SecurityLevel);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.EndpointUrl = decoder.ReadString("EndpointUrl");
    this.Server = (ApplicationDescription) decoder.ReadEncodeable("Server", typeof (ApplicationDescription));
    this.ServerCertificate = decoder.ReadByteString("ServerCertificate");
    this.SecurityMode = (MessageSecurityMode) decoder.ReadEnumerated("SecurityMode", typeof (MessageSecurityMode));
    this.SecurityPolicyUri = decoder.ReadString("SecurityPolicyUri");
    this.UserIdentityTokens = (UserTokenPolicyCollection) (UserTokenPolicy[]) decoder.ReadEncodeableArray("UserIdentityTokens", typeof (UserTokenPolicy));
    this.TransportProfileUri = decoder.ReadString("TransportProfileUri");
    this.SecurityLevel = decoder.ReadByte("SecurityLevel");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is EndpointDescription endpointDescription && Utils.IsEqual((object) this.m_endpointUrl, (object) endpointDescription.m_endpointUrl) && Utils.IsEqual((object) this.m_server, (object) endpointDescription.m_server) && Utils.IsEqual((object) this.m_serverCertificate, (object) endpointDescription.m_serverCertificate) && Utils.IsEqual((object) this.m_securityMode, (object) endpointDescription.m_securityMode) && Utils.IsEqual((object) this.m_securityPolicyUri, (object) endpointDescription.m_securityPolicyUri) && Utils.IsEqual((object) this.m_userIdentityTokens, (object) endpointDescription.m_userIdentityTokens) && Utils.IsEqual((object) this.m_transportProfileUri, (object) endpointDescription.m_transportProfileUri) && Utils.IsEqual((object) this.m_securityLevel, (object) endpointDescription.m_securityLevel);
  }

  public virtual object Clone() => (object) (EndpointDescription) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EndpointDescription endpointDescription = (EndpointDescription) base.MemberwiseClone();
    endpointDescription.m_endpointUrl = (string) Utils.Clone((object) this.m_endpointUrl);
    endpointDescription.m_server = (ApplicationDescription) Utils.Clone((object) this.m_server);
    endpointDescription.m_serverCertificate = (byte[]) Utils.Clone((object) this.m_serverCertificate);
    endpointDescription.m_securityMode = (MessageSecurityMode) Utils.Clone((object) this.m_securityMode);
    endpointDescription.m_securityPolicyUri = (string) Utils.Clone((object) this.m_securityPolicyUri);
    endpointDescription.m_userIdentityTokens = (UserTokenPolicyCollection) Utils.Clone((object) this.m_userIdentityTokens);
    endpointDescription.m_transportProfileUri = (string) Utils.Clone((object) this.m_transportProfileUri);
    endpointDescription.m_securityLevel = (byte) Utils.Clone((object) this.m_securityLevel);
    return (object) endpointDescription;
  }
}
