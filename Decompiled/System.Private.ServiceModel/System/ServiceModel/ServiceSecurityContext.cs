using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Security.Principal;
using System.ServiceModel.Security;

namespace System.ServiceModel;

public class ServiceSecurityContext
{
	private static ServiceSecurityContext s_anonymous;

	private AuthorizationContext _authorizationContext;

	private IIdentity _primaryIdentity;

	private Claim _identityClaim;

	public static ServiceSecurityContext Anonymous
	{
		get
		{
			if (s_anonymous == null)
			{
				s_anonymous = new ServiceSecurityContext(EmptyReadOnlyCollection<IAuthorizationPolicy>.Instance);
			}
			return s_anonymous;
		}
	}

	public bool IsAnonymous
	{
		get
		{
			if (this != Anonymous)
			{
				return IdentityClaim == null;
			}
			return true;
		}
	}

	internal Claim IdentityClaim
	{
		get
		{
			if (_identityClaim == null)
			{
				_identityClaim = SecurityUtils.GetPrimaryIdentityClaim(AuthorizationContext);
			}
			return _identityClaim;
		}
	}

	public IIdentity PrimaryIdentity
	{
		get
		{
			if (_primaryIdentity == null)
			{
				IIdentity identity = null;
				IList<IIdentity> identities = GetIdentities();
				if (identities != null && identities.Count == 1)
				{
					identity = identities[0];
				}
				_primaryIdentity = identity ?? SecurityUtils.AnonymousIdentity;
			}
			return _primaryIdentity;
		}
	}

	public ReadOnlyCollection<IAuthorizationPolicy> AuthorizationPolicies { get; set; }

	public AuthorizationContext AuthorizationContext
	{
		get
		{
			if (_authorizationContext == null)
			{
				_authorizationContext = AuthorizationContext.CreateDefaultAuthorizationContext(AuthorizationPolicies);
			}
			return _authorizationContext;
		}
	}

	public ServiceSecurityContext(ReadOnlyCollection<IAuthorizationPolicy> authorizationPolicies)
	{
		_authorizationContext = null;
		AuthorizationPolicies = authorizationPolicies ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("authorizationPolicies");
	}

	public ServiceSecurityContext(AuthorizationContext authorizationContext)
		: this(authorizationContext, EmptyReadOnlyCollection<IAuthorizationPolicy>.Instance)
	{
	}

	public ServiceSecurityContext(AuthorizationContext authorizationContext, ReadOnlyCollection<IAuthorizationPolicy> authorizationPolicies)
	{
		_authorizationContext = authorizationContext ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("authorizationContext");
		AuthorizationPolicies = authorizationPolicies ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("authorizationPolicies");
	}

	private IList<IIdentity> GetIdentities()
	{
		AuthorizationContext authorizationContext = AuthorizationContext;
		if (authorizationContext != null && authorizationContext.Properties.TryGetValue("Identities", out var value))
		{
			return value as IList<IIdentity>;
		}
		return null;
	}
}
