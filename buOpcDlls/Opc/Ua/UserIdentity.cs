// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UserIdentity
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class UserIdentity : IUserIdentity
{
  private UserIdentityToken m_token;
  private string m_displayName;
  private UserTokenType m_tokenType;
  private XmlQualifiedName m_issuedTokenType;
  private NodeIdCollection m_grantedRoleIds;

  public UserIdentity() => this.Initialize((UserIdentityToken) new AnonymousIdentityToken());

  public UserIdentity(string username, string password)
  {
    this.Initialize((UserIdentityToken) new UserNameIdentityToken()
    {
      UserName = username,
      DecryptedPassword = password
    });
  }

  public UserIdentity(IssuedIdentityToken issuedToken)
  {
    this.Initialize((UserIdentityToken) issuedToken);
  }

  public UserIdentity(CertificateIdentifier certificateId)
  {
    X509Certificate2 certificate = certificateId != null ? certificateId.Find().Result : throw new ArgumentNullException(nameof (certificateId));
    if (certificate == null)
      return;
    this.Initialize(certificate);
  }

  public UserIdentity(X509Certificate2 certificate)
  {
    if (certificate == null)
      throw new ArgumentNullException(nameof (certificate));
    this.Initialize(certificate);
  }

  public UserIdentity(UserIdentityToken token) => this.Initialize(token);

  [OnDeserializing]
  private void Initialize(StreamingContext context)
  {
    this.Initialize((UserIdentityToken) new AnonymousIdentityToken());
  }

  [DataMember(Name = "PolicyId", IsRequired = false, Order = 10)]
  public string PolicyId
  {
    get => this.m_token.PolicyId;
    set => this.m_token.PolicyId = value;
  }

  public string DisplayName => this.m_displayName;

  [DataMember(Name = "TokenType", IsRequired = true, Order = 20)]
  public UserTokenType TokenType
  {
    get => this.m_tokenType;
    private set => this.m_tokenType = value;
  }

  [DataMember(Name = "IssuedTokenType", IsRequired = false, Order = 30)]
  public XmlQualifiedName IssuedTokenType
  {
    get => this.m_issuedTokenType;
    private set => this.m_issuedTokenType = value;
  }

  public bool SupportsSignatures => false;

  public NodeIdCollection GrantedRoleIds
  {
    get => this.m_grantedRoleIds;
    set => this.m_grantedRoleIds = value;
  }

  public UserIdentityToken GetIdentityToken()
  {
    return this.m_token == null ? (UserIdentityToken) new AnonymousIdentityToken() : this.m_token;
  }

  private void Initialize(UserIdentityToken token)
  {
    if (token == null)
      throw new ArgumentNullException(nameof (token));
    this.m_grantedRoleIds = new NodeIdCollection();
    this.m_token = token;
    if (token is UserNameIdentityToken nameIdentityToken)
    {
      this.m_tokenType = UserTokenType.UserName;
      this.m_issuedTokenType = (XmlQualifiedName) null;
      this.m_displayName = nameIdentityToken.UserName;
    }
    else if (token is X509IdentityToken x509IdentityToken)
    {
      this.m_tokenType = UserTokenType.Certificate;
      this.m_issuedTokenType = (XmlQualifiedName) null;
      if (x509IdentityToken.Certificate != null)
        this.m_displayName = x509IdentityToken.Certificate.Subject;
      else
        this.m_displayName = CertificateFactory.Create(x509IdentityToken.CertificateData, true).Subject;
    }
    else if (token is IssuedIdentityToken issuedIdentityToken)
    {
      if (issuedIdentityToken.IssuedTokenType != Opc.Ua.IssuedTokenType.JWT)
        throw new NotSupportedException("Only JWT Issued Tokens are supported!");
      if (issuedIdentityToken.DecryptedTokenData == null || issuedIdentityToken.DecryptedTokenData.Length == 0)
        throw new ArgumentException("JSON Web Token has no data associated with it.", nameof (token));
      this.m_tokenType = UserTokenType.IssuedToken;
      this.m_issuedTokenType = new XmlQualifiedName("", "http://opcfoundation.org/UA/UserToken#JWT");
      this.m_displayName = "JWT";
    }
    else
    {
      if (!(token is AnonymousIdentityToken))
        throw new ArgumentException("Unrecognized UA user identity token type.", nameof (token));
      this.m_tokenType = UserTokenType.Anonymous;
      this.m_issuedTokenType = (XmlQualifiedName) null;
      this.m_displayName = "Anonymous";
    }
  }

  private void Initialize(X509Certificate2 certificate)
  {
    this.Initialize((UserIdentityToken) new X509IdentityToken()
    {
      CertificateData = certificate.RawData,
      Certificate = certificate
    });
  }
}
