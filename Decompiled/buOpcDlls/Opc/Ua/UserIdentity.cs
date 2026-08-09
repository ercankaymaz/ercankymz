using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

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

	[DataMember(Name = "PolicyId", IsRequired = false, Order = 10)]
	public string PolicyId
	{
		get
		{
			return m_token.PolicyId;
		}
		set
		{
			m_token.PolicyId = value;
		}
	}

	public string DisplayName => m_displayName;

	[DataMember(Name = "TokenType", IsRequired = true, Order = 20)]
	public UserTokenType TokenType
	{
		get
		{
			return m_tokenType;
		}
		private set
		{
			m_tokenType = value;
		}
	}

	[DataMember(Name = "IssuedTokenType", IsRequired = false, Order = 30)]
	public XmlQualifiedName IssuedTokenType
	{
		get
		{
			return m_issuedTokenType;
		}
		private set
		{
			m_issuedTokenType = value;
		}
	}

	public bool SupportsSignatures => false;

	public NodeIdCollection GrantedRoleIds
	{
		get
		{
			return m_grantedRoleIds;
		}
		set
		{
			m_grantedRoleIds = value;
		}
	}

	public UserIdentity()
	{
		AnonymousIdentityToken token = new AnonymousIdentityToken();
		Initialize(token);
	}

	public UserIdentity(string username, string password)
	{
		Initialize(new UserNameIdentityToken
		{
			UserName = username,
			DecryptedPassword = password
		});
	}

	public UserIdentity(IssuedIdentityToken issuedToken)
	{
		Initialize(issuedToken);
	}

	public UserIdentity(CertificateIdentifier certificateId)
	{
		if (certificateId == null)
		{
			throw new ArgumentNullException("certificateId");
		}
		X509Certificate2 result = certificateId.Find().Result;
		if (result != null)
		{
			Initialize(result);
		}
	}

	public UserIdentity(X509Certificate2 certificate)
	{
		if (certificate == null)
		{
			throw new ArgumentNullException("certificate");
		}
		Initialize(certificate);
	}

	public UserIdentity(UserIdentityToken token)
	{
		Initialize(token);
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		Initialize(new AnonymousIdentityToken());
	}

	public UserIdentityToken GetIdentityToken()
	{
		if (m_token == null)
		{
			return new AnonymousIdentityToken();
		}
		return m_token;
	}

	private void Initialize(UserIdentityToken token)
	{
		if (token == null)
		{
			throw new ArgumentNullException("token");
		}
		m_grantedRoleIds = new NodeIdCollection();
		m_token = token;
		if (token is UserNameIdentityToken userNameIdentityToken)
		{
			m_tokenType = UserTokenType.UserName;
			m_issuedTokenType = null;
			m_displayName = userNameIdentityToken.UserName;
		}
		else if (token is X509IdentityToken x509IdentityToken)
		{
			m_tokenType = UserTokenType.Certificate;
			m_issuedTokenType = null;
			if (x509IdentityToken.Certificate != null)
			{
				m_displayName = x509IdentityToken.Certificate.Subject;
				return;
			}
			X509Certificate2 x509Certificate = CertificateFactory.Create(x509IdentityToken.CertificateData, useCache: true);
			m_displayName = x509Certificate.Subject;
		}
		else if (token is IssuedIdentityToken issuedIdentityToken)
		{
			if (issuedIdentityToken.IssuedTokenType != Opc.Ua.IssuedTokenType.JWT)
			{
				throw new NotSupportedException("Only JWT Issued Tokens are supported!");
			}
			if (issuedIdentityToken.DecryptedTokenData == null || issuedIdentityToken.DecryptedTokenData.Length == 0)
			{
				throw new ArgumentException("JSON Web Token has no data associated with it.", "token");
			}
			m_tokenType = UserTokenType.IssuedToken;
			m_issuedTokenType = new XmlQualifiedName("", "http://opcfoundation.org/UA/UserToken#JWT");
			m_displayName = "JWT";
		}
		else
		{
			if (!(token is AnonymousIdentityToken))
			{
				throw new ArgumentException("Unrecognized UA user identity token type.", "token");
			}
			m_tokenType = UserTokenType.Anonymous;
			m_issuedTokenType = null;
			m_displayName = "Anonymous";
		}
	}

	private void Initialize(X509Certificate2 certificate)
	{
		X509IdentityToken x509IdentityToken = new X509IdentityToken();
		x509IdentityToken.CertificateData = certificate.RawData;
		x509IdentityToken.Certificate = certificate;
		Initialize(x509IdentityToken);
	}
}
