// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UserTokenPolicy
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
public class UserTokenPolicy : IEncodeable, ICloneable, IJsonEncodeable, IFormattable
{
  private string m_policyId;
  private UserTokenType m_tokenType;
  private string m_issuedTokenType;
  private string m_issuerEndpointUrl;
  private string m_securityPolicyUri;

  public UserTokenPolicy() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_policyId = (string) null;
    this.m_tokenType = UserTokenType.Anonymous;
    this.m_issuedTokenType = (string) null;
    this.m_issuerEndpointUrl = (string) null;
    this.m_securityPolicyUri = (string) null;
  }

  [DataMember(Name = "PolicyId", IsRequired = false, Order = 1)]
  public string PolicyId
  {
    get => this.m_policyId;
    set => this.m_policyId = value;
  }

  [DataMember(Name = "TokenType", IsRequired = false, Order = 2)]
  public UserTokenType TokenType
  {
    get => this.m_tokenType;
    set => this.m_tokenType = value;
  }

  [DataMember(Name = "IssuedTokenType", IsRequired = false, Order = 3)]
  public string IssuedTokenType
  {
    get => this.m_issuedTokenType;
    set => this.m_issuedTokenType = value;
  }

  [DataMember(Name = "IssuerEndpointUrl", IsRequired = false, Order = 4)]
  public string IssuerEndpointUrl
  {
    get => this.m_issuerEndpointUrl;
    set => this.m_issuerEndpointUrl = value;
  }

  [DataMember(Name = "SecurityPolicyUri", IsRequired = false, Order = 5)]
  public string SecurityPolicyUri
  {
    get => this.m_securityPolicyUri;
    set => this.m_securityPolicyUri = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.UserTokenPolicy;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UserTokenPolicy_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UserTokenPolicy_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UserTokenPolicy_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("PolicyId", this.PolicyId);
    encoder.WriteEnumerated("TokenType", (Enum) this.TokenType);
    encoder.WriteString("IssuedTokenType", this.IssuedTokenType);
    encoder.WriteString("IssuerEndpointUrl", this.IssuerEndpointUrl);
    encoder.WriteString("SecurityPolicyUri", this.SecurityPolicyUri);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.PolicyId = decoder.ReadString("PolicyId");
    this.TokenType = (UserTokenType) decoder.ReadEnumerated("TokenType", typeof (UserTokenType));
    this.IssuedTokenType = decoder.ReadString("IssuedTokenType");
    this.IssuerEndpointUrl = decoder.ReadString("IssuerEndpointUrl");
    this.SecurityPolicyUri = decoder.ReadString("SecurityPolicyUri");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is UserTokenPolicy userTokenPolicy && Utils.IsEqual((object) this.m_policyId, (object) userTokenPolicy.m_policyId) && Utils.IsEqual((object) this.m_tokenType, (object) userTokenPolicy.m_tokenType) && Utils.IsEqual((object) this.m_issuedTokenType, (object) userTokenPolicy.m_issuedTokenType) && Utils.IsEqual((object) this.m_issuerEndpointUrl, (object) userTokenPolicy.m_issuerEndpointUrl) && Utils.IsEqual((object) this.m_securityPolicyUri, (object) userTokenPolicy.m_securityPolicyUri);
  }

  public virtual object Clone() => (object) (UserTokenPolicy) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    UserTokenPolicy userTokenPolicy = (UserTokenPolicy) base.MemberwiseClone();
    userTokenPolicy.m_policyId = (string) Utils.Clone((object) this.m_policyId);
    userTokenPolicy.m_tokenType = (UserTokenType) Utils.Clone((object) this.m_tokenType);
    userTokenPolicy.m_issuedTokenType = (string) Utils.Clone((object) this.m_issuedTokenType);
    userTokenPolicy.m_issuerEndpointUrl = (string) Utils.Clone((object) this.m_issuerEndpointUrl);
    userTokenPolicy.m_securityPolicyUri = (string) Utils.Clone((object) this.m_securityPolicyUri);
    return (object) userTokenPolicy;
  }

  public UserTokenPolicy(UserTokenType tokenType)
  {
    this.Initialize();
    this.m_tokenType = tokenType;
  }

  public override string ToString() => this.m_tokenType.ToString();

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format != null)
      throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
    return string.Format(formatProvider, "{0}", (object) this.ToString());
  }
}
