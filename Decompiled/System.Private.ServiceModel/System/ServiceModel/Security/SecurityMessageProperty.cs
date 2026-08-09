using System.Collections.ObjectModel;
using System.IdentityModel.Policy;
using System.ServiceModel.Channels;
using System.ServiceModel.Security.Tokens;

namespace System.ServiceModel.Security;

public class SecurityMessageProperty : IMessageProperty, IDisposable
{
	private Collection<SupportingTokenSpecification> _outgoingSupportingTokens;

	private Collection<SupportingTokenSpecification> _incomingSupportingTokens;

	private SecurityTokenSpecification _transportToken;

	private SecurityTokenSpecification _protectionToken;

	private SecurityTokenSpecification _initiatorToken;

	private SecurityTokenSpecification _recipientToken;

	private ServiceSecurityContext _securityContext;

	private string _senderIdPrefix = "_";

	private bool _disposed;

	public ServiceSecurityContext ServiceSecurityContext
	{
		get
		{
			ThrowIfDisposed();
			return _securityContext;
		}
		set
		{
			ThrowIfDisposed();
			_securityContext = value;
		}
	}

	public ReadOnlyCollection<IAuthorizationPolicy> ExternalAuthorizationPolicies { get; set; }

	public SecurityTokenSpecification ProtectionToken
	{
		get
		{
			ThrowIfDisposed();
			return _protectionToken;
		}
		set
		{
			ThrowIfDisposed();
			_protectionToken = value;
		}
	}

	public SecurityTokenSpecification InitiatorToken
	{
		get
		{
			ThrowIfDisposed();
			return _initiatorToken;
		}
		set
		{
			ThrowIfDisposed();
			_initiatorToken = value;
		}
	}

	public SecurityTokenSpecification RecipientToken
	{
		get
		{
			ThrowIfDisposed();
			return _recipientToken;
		}
		set
		{
			ThrowIfDisposed();
			_recipientToken = value;
		}
	}

	public SecurityTokenSpecification TransportToken
	{
		get
		{
			ThrowIfDisposed();
			return _transportToken;
		}
		set
		{
			ThrowIfDisposed();
			_transportToken = value;
		}
	}

	public string SenderIdPrefix
	{
		get
		{
			return _senderIdPrefix;
		}
		set
		{
			XmlHelper.ValidateIdPrefix(value);
			_senderIdPrefix = value;
		}
	}

	public bool HasIncomingSupportingTokens
	{
		get
		{
			ThrowIfDisposed();
			if (_incomingSupportingTokens != null)
			{
				return _incomingSupportingTokens.Count > 0;
			}
			return false;
		}
	}

	public Collection<SupportingTokenSpecification> IncomingSupportingTokens
	{
		get
		{
			ThrowIfDisposed();
			if (_incomingSupportingTokens == null)
			{
				_incomingSupportingTokens = new Collection<SupportingTokenSpecification>();
			}
			return _incomingSupportingTokens;
		}
	}

	public Collection<SupportingTokenSpecification> OutgoingSupportingTokens
	{
		get
		{
			if (_outgoingSupportingTokens == null)
			{
				_outgoingSupportingTokens = new Collection<SupportingTokenSpecification>();
			}
			return _outgoingSupportingTokens;
		}
	}

	internal bool HasOutgoingSupportingTokens
	{
		get
		{
			if (_outgoingSupportingTokens != null)
			{
				return _outgoingSupportingTokens.Count > 0;
			}
			return false;
		}
	}

	public SecurityMessageProperty()
	{
		_securityContext = ServiceSecurityContext.Anonymous;
	}

	public IMessageProperty CreateCopy()
	{
		ThrowIfDisposed();
		SecurityMessageProperty securityMessageProperty = new SecurityMessageProperty();
		if (HasOutgoingSupportingTokens)
		{
			for (int i = 0; i < _outgoingSupportingTokens.Count; i++)
			{
				securityMessageProperty.OutgoingSupportingTokens.Add(_outgoingSupportingTokens[i]);
			}
		}
		if (HasIncomingSupportingTokens)
		{
			for (int j = 0; j < _incomingSupportingTokens.Count; j++)
			{
				securityMessageProperty.IncomingSupportingTokens.Add(_incomingSupportingTokens[j]);
			}
		}
		securityMessageProperty._securityContext = _securityContext;
		securityMessageProperty.ExternalAuthorizationPolicies = ExternalAuthorizationPolicies;
		securityMessageProperty._senderIdPrefix = _senderIdPrefix;
		securityMessageProperty._protectionToken = _protectionToken;
		securityMessageProperty._initiatorToken = _initiatorToken;
		securityMessageProperty._recipientToken = _recipientToken;
		securityMessageProperty._transportToken = _transportToken;
		return securityMessageProperty;
	}

	public static SecurityMessageProperty GetOrCreate(Message message)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("message");
		}
		SecurityMessageProperty securityMessageProperty = null;
		if (message.Properties != null)
		{
			securityMessageProperty = message.Properties.Security;
		}
		if (securityMessageProperty == null)
		{
			securityMessageProperty = new SecurityMessageProperty();
			message.Properties.Security = securityMessageProperty;
		}
		return securityMessageProperty;
	}

	private void AddAuthorizationPolicies(SecurityTokenSpecification spec, Collection<IAuthorizationPolicy> policies)
	{
		if (spec != null && spec.SecurityTokenPolicies != null && spec.SecurityTokenPolicies.Count > 0)
		{
			for (int i = 0; i < spec.SecurityTokenPolicies.Count; i++)
			{
				policies.Add(spec.SecurityTokenPolicies[i]);
			}
		}
	}

	internal ReadOnlyCollection<IAuthorizationPolicy> GetInitiatorTokenAuthorizationPolicies()
	{
		return GetInitiatorTokenAuthorizationPolicies(includeTransportToken: true);
	}

	internal ReadOnlyCollection<IAuthorizationPolicy> GetInitiatorTokenAuthorizationPolicies(bool includeTransportToken)
	{
		return GetInitiatorTokenAuthorizationPolicies(includeTransportToken, null);
	}

	internal ReadOnlyCollection<IAuthorizationPolicy> GetInitiatorTokenAuthorizationPolicies(bool includeTransportToken, SecurityContextSecurityToken supportingSessionTokenToExclude)
	{
		if (!HasIncomingSupportingTokens)
		{
			if (_transportToken != null && _initiatorToken == null && _protectionToken == null)
			{
				if (includeTransportToken && _transportToken.SecurityTokenPolicies != null)
				{
					return _transportToken.SecurityTokenPolicies;
				}
				return EmptyReadOnlyCollection<IAuthorizationPolicy>.Instance;
			}
			if (_transportToken == null && _initiatorToken != null && _protectionToken == null)
			{
				return _initiatorToken.SecurityTokenPolicies ?? EmptyReadOnlyCollection<IAuthorizationPolicy>.Instance;
			}
			if (_transportToken == null && _initiatorToken == null && _protectionToken != null)
			{
				return _protectionToken.SecurityTokenPolicies ?? EmptyReadOnlyCollection<IAuthorizationPolicy>.Instance;
			}
		}
		Collection<IAuthorizationPolicy> collection = new Collection<IAuthorizationPolicy>();
		if (includeTransportToken)
		{
			AddAuthorizationPolicies(_transportToken, collection);
		}
		AddAuthorizationPolicies(_initiatorToken, collection);
		AddAuthorizationPolicies(_protectionToken, collection);
		if (HasIncomingSupportingTokens)
		{
			for (int i = 0; i < _incomingSupportingTokens.Count; i++)
			{
				if (supportingSessionTokenToExclude == null || !(_incomingSupportingTokens[i].SecurityToken is SecurityContextSecurityToken securityContextSecurityToken) || !(securityContextSecurityToken.ContextId == supportingSessionTokenToExclude.ContextId))
				{
					SecurityTokenAttachmentMode securityTokenAttachmentMode = _incomingSupportingTokens[i].SecurityTokenAttachmentMode;
					if (securityTokenAttachmentMode == SecurityTokenAttachmentMode.Endorsing || securityTokenAttachmentMode == SecurityTokenAttachmentMode.Signed || securityTokenAttachmentMode == SecurityTokenAttachmentMode.SignedEncrypted || securityTokenAttachmentMode == SecurityTokenAttachmentMode.SignedEndorsing)
					{
						AddAuthorizationPolicies(_incomingSupportingTokens[i], collection);
					}
				}
			}
		}
		return new ReadOnlyCollection<IAuthorizationPolicy>(collection);
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_disposed = true;
		}
	}

	private void ThrowIfDisposed()
	{
		if (_disposed)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ObjectDisposedException(GetType().FullName));
		}
	}
}
