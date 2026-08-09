using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Windows.Design.Features;

namespace Microsoft.Windows.Design;

public sealed class RequirementValidator
{
	private FeatureManager _featureManager;

	private Type _type;

	private IEnumerable<RequirementAttribute> _requirements;

	private EventHandler _requirementsChanged;

	private IEnumerable<RequirementSubscription> _subscriptions;

	private static object _syncLock = new object();

	private static Dictionary<Type, IEnumerable<RequirementAttribute>> _requirementCache;

	public bool MeetsRequirements
	{
		get
		{
			int num = 0;
			int num2 = 0;
			foreach (RequirementAttribute requirement in Requirements)
			{
				if (!requirement.MeetsRequirement(_featureManager.Context))
				{
					if (requirement.AllRequired)
					{
						return false;
					}
					num2++;
				}
				if (!requirement.AllRequired)
				{
					num++;
				}
			}
			if (num2 > 0)
			{
				Type[] array = new Type[num];
				bool[] array2 = new bool[num];
				num = 0;
				foreach (RequirementAttribute requirement2 in Requirements)
				{
					if (requirement2.AllRequired)
					{
						continue;
					}
					Type type = requirement2.GetType();
					int num3 = -1;
					for (int i = 0; i < num; i++)
					{
						if ((object)array[i] == type)
						{
							num3 = i;
							break;
						}
					}
					if (num3 == -1)
					{
						array[num] = type;
						num3 = num;
						num++;
					}
					if (!array2[num3])
					{
						array2[num3] = requirement2.MeetsRequirement(_featureManager.Context);
					}
				}
				for (int j = 0; j < num; j++)
				{
					if (!array2[j])
					{
						return false;
					}
				}
			}
			return true;
		}
	}

	public IEnumerable<RequirementAttribute> PendingRequirements
	{
		get
		{
			foreach (RequirementAttribute r in Requirements)
			{
				if (!r.MeetsRequirement(_featureManager.Context))
				{
					yield return r;
				}
			}
		}
	}

	public IEnumerable<RequirementAttribute> Requirements
	{
		get
		{
			if (_requirements == null)
			{
				lock (_syncLock)
				{
					if (_requirementCache == null)
					{
						_requirementCache = new Dictionary<Type, IEnumerable<RequirementAttribute>>();
					}
					if (!_requirementCache.TryGetValue(_type, out _requirements))
					{
						object[] customAttributes = _type.GetCustomAttributes(typeof(RequirementAttribute), inherit: true);
						RequirementAttribute[] array = new RequirementAttribute[customAttributes.Length];
						Array.Copy(customAttributes, array, customAttributes.Length);
						_requirements = array;
						_requirementCache[_type] = _requirements;
					}
				}
			}
			return _requirements;
		}
	}

	public Type Type => _type;

	public event EventHandler RequirementsChanged
	{
		add
		{
			if (value != null)
			{
				bool flag = _requirementsChanged == null;
				_requirementsChanged = (EventHandler)Delegate.Combine(_requirementsChanged, value);
				if (flag)
				{
					SubscribeRequirements();
				}
			}
		}
		remove
		{
			bool flag = _requirementsChanged != null;
			_requirementsChanged = (EventHandler)Delegate.Remove(_requirementsChanged, value);
			if (_requirementsChanged == null && flag)
			{
				UnsubscribeRequirements();
			}
		}
	}

	public RequirementValidator(FeatureManager featureManager, Type type)
	{
		if (featureManager == null)
		{
			throw new ArgumentNullException("featureManager");
		}
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		_featureManager = featureManager;
		_type = type;
	}

	private void OnRequirementChanged(object sender, EventArgs e)
	{
		if (_requirementsChanged != null)
		{
			_requirementsChanged(this, EventArgs.Empty);
		}
	}

	private void SubscribeRequirements()
	{
		List<RequirementSubscription> list = new List<RequirementSubscription>();
		foreach (RequirementAttribute requirement in Requirements)
		{
			RequirementSubscription requirementSubscription = requirement.CreateSubscription(_featureManager.Context);
			requirementSubscription.RequirementChanged += OnRequirementChanged;
			list.Add(requirementSubscription);
		}
		_subscriptions = list;
	}

	[Conditional("DEBUG")]
	internal static void Trace(string format, params object[] args)
	{
	}

	private void UnsubscribeRequirements()
	{
		if (_subscriptions == null)
		{
			return;
		}
		foreach (RequirementSubscription subscription in _subscriptions)
		{
			subscription.RequirementChanged -= OnRequirementChanged;
		}
		_subscriptions = null;
	}
}
