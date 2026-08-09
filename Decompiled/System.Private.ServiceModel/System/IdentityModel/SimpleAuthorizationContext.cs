using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Security.Principal;

namespace System.IdentityModel;

internal class SimpleAuthorizationContext : AuthorizationContext
{
	private SecurityUniqueId _id;

	private UnconditionalPolicy _policy;

	private IDictionary<string, object> _properties;

	public override string Id
	{
		get
		{
			if (_id == null)
			{
				_id = SecurityUniqueId.Create();
			}
			return _id.Value;
		}
	}

	public override ReadOnlyCollection<ClaimSet> ClaimSets => _policy.Issuances;

	public override DateTime ExpirationTime => _policy.ExpirationTime;

	public override IDictionary<string, object> Properties => _properties;

	public SimpleAuthorizationContext(IList<IAuthorizationPolicy> authorizationPolicies)
	{
		_policy = (UnconditionalPolicy)authorizationPolicies[0];
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		if (_policy.PrimaryIdentity != null && _policy.PrimaryIdentity != SecurityUtils.AnonymousIdentity)
		{
			dictionary.Add("Identities", new List<IIdentity> { _policy.PrimaryIdentity });
		}
		_properties = dictionary;
	}
}
