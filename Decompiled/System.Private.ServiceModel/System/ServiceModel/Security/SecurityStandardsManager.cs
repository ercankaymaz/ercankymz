using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security.Tokens;
using System.Xml;

namespace System.ServiceModel.Security;

internal class SecurityStandardsManager
{
	private static SecurityStandardsManager s_instance;

	private readonly SecurityTokenSerializer _tokenSerializer;

	private WSSecurityTokenSerializer _wsSecurityTokenSerializer;

	public static SecurityStandardsManager DefaultInstance
	{
		get
		{
			if (s_instance == null)
			{
				s_instance = new SecurityStandardsManager();
			}
			return s_instance;
		}
	}

	public SecurityVersion SecurityVersion
	{
		get
		{
			if (MessageSecurityVersion != null)
			{
				return MessageSecurityVersion.SecurityVersion;
			}
			return null;
		}
	}

	public MessageSecurityVersion MessageSecurityVersion { get; }

	internal SecurityTokenSerializer SecurityTokenSerializer => _tokenSerializer;

	internal WSUtilitySpecificationVersion WSUtilitySpecificationVersion { get; }

	internal SignatureTargetIdManager IdManager { get; }

	internal SecureConversationDriver SecureConversationDriver { get; }

	internal TrustDriver TrustDriver { get; }

	private WSSecurityTokenSerializer WSSecurityTokenSerializer
	{
		get
		{
			if (_wsSecurityTokenSerializer == null)
			{
				WSSecurityTokenSerializer wSSecurityTokenSerializer = _tokenSerializer as WSSecurityTokenSerializer;
				if (wSSecurityTokenSerializer == null)
				{
					wSSecurityTokenSerializer = new WSSecurityTokenSerializer(SecurityVersion);
				}
				_wsSecurityTokenSerializer = wSSecurityTokenSerializer;
			}
			return _wsSecurityTokenSerializer;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SecurityStandardsManager()
		: this(WSSecurityTokenSerializer.DefaultInstance)
	{
	}

	public SecurityStandardsManager(SecurityTokenSerializer tokenSerializer)
		: this(MessageSecurityVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11, tokenSerializer)
	{
	}

	public SecurityStandardsManager(MessageSecurityVersion messageSecurityVersion, SecurityTokenSerializer tokenSerializer)
	{
		MessageSecurityVersion = messageSecurityVersion ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("messageSecurityVersion"));
		_tokenSerializer = tokenSerializer ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokenSerializer");
		if (messageSecurityVersion.SecureConversationVersion == SecureConversationVersion.WSSecureConversation13)
		{
			SecureConversationDriver = new WSSecureConversationDec2005.DriverDec2005();
		}
		else
		{
			SecureConversationDriver = new WSSecureConversationFeb2005.DriverFeb2005();
		}
		if (SecurityVersion == SecurityVersion.WSSecurity10 || SecurityVersion == SecurityVersion.WSSecurity11)
		{
			IdManager = WSSecurityJan2004.IdManager.Instance;
			WSUtilitySpecificationVersion = WSUtilitySpecificationVersion.Default;
			TrustDriver = null;
			if (messageSecurityVersion.MessageSecurityTokenVersion.TrustVersion == TrustVersion.WSTrust13)
			{
				TrustDriver = new WSTrustDec2005.DriverDec2005(this);
			}
			else
			{
				TrustDriver = new WSTrustFeb2005.DriverFeb2005(this);
			}
			return;
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("messageSecurityVersion", System.SR.MessageSecurityVersionOutOfRange));
	}

	internal bool TryCreateKeyIdentifierClauseFromTokenXml(XmlElement element, SecurityTokenReferenceStyle tokenReferenceStyle, out SecurityKeyIdentifierClause securityKeyIdentifierClause)
	{
		return WSSecurityTokenSerializer.TryCreateKeyIdentifierClauseFromTokenXml(element, tokenReferenceStyle, out securityKeyIdentifierClause);
	}

	internal SecurityKeyIdentifierClause CreateKeyIdentifierClauseFromTokenXml(XmlElement element, SecurityTokenReferenceStyle tokenReferenceStyle)
	{
		return WSSecurityTokenSerializer.CreateKeyIdentifierClauseFromTokenXml(element, tokenReferenceStyle);
	}

	internal SendSecurityHeader CreateSendSecurityHeader(Message message, string actor, bool mustUnderstand, bool relay, SecurityAlgorithmSuite algorithmSuite, MessageDirection direction)
	{
		return SecurityVersion.CreateSendSecurityHeader(message, actor, mustUnderstand, relay, this, algorithmSuite, direction);
	}

	internal ReceiveSecurityHeader TryCreateReceiveSecurityHeader(Message message, string actor, SecurityAlgorithmSuite algorithmSuite, MessageDirection direction)
	{
		return SecurityVersion.TryCreateReceiveSecurityHeader(message, actor, this, algorithmSuite, direction);
	}

	internal bool DoesMessageContainSecurityHeader(Message message)
	{
		return SecurityVersion.DoesMessageContainSecurityHeader(message);
	}
}
