using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Claims;
using System.ServiceModel;

namespace System.IdentityModel.Policy;

internal class DefaultEvaluationContext : EvaluationContext
{
	private List<ClaimSet> _claimSets;

	private Dictionary<string, object> _properties;

	private int _generation;

	private ReadOnlyCollection<ClaimSet> _readOnlyClaimSets;

	public override int Generation => _generation;

	public override ReadOnlyCollection<ClaimSet> ClaimSets
	{
		get
		{
			if (_claimSets == null)
			{
				return EmptyReadOnlyCollection<ClaimSet>.Instance;
			}
			if (_readOnlyClaimSets == null)
			{
				_readOnlyClaimSets = new ReadOnlyCollection<ClaimSet>(_claimSets);
			}
			return _readOnlyClaimSets;
		}
	}

	public override IDictionary<string, object> Properties => _properties;

	public DateTime ExpirationTime { get; private set; } = SecurityUtils.MaxUtcDateTime;

	public DefaultEvaluationContext()
	{
		_properties = new Dictionary<string, object>();
		_generation = 0;
	}

	public override void AddClaimSet(IAuthorizationPolicy policy, ClaimSet claimSet)
	{
		if (claimSet == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("claimSet");
		}
		if (_claimSets == null)
		{
			_claimSets = new List<ClaimSet>();
		}
		_claimSets.Add(claimSet);
		_generation++;
	}

	public override void RecordExpirationTime(DateTime expirationTime)
	{
		if (ExpirationTime > expirationTime)
		{
			ExpirationTime = expirationTime;
		}
	}
}
