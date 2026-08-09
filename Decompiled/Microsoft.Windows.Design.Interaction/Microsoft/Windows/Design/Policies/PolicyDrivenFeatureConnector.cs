using System;
using System.Collections.Generic;
using MS.Internal.Features;
using Microsoft.Windows.Design.Features;
using Microsoft.Windows.Design.Model;
using Microsoft.Windows.Design.Services;

namespace Microsoft.Windows.Design.Policies;

public abstract class PolicyDrivenFeatureConnector<TFeatureProviderType> : FeatureConnector<TFeatureProviderType> where TFeatureProviderType : FeatureProvider
{
	protected sealed class ItemFeatureProvider
	{
		private ModelItem _item;

		private TFeatureProviderType _featureProvider;

		public ModelItem Item => _item;

		public TFeatureProviderType FeatureProvider => _featureProvider;

		internal ItemFeatureProvider(ModelItem item, TFeatureProviderType featureProvider)
		{
			_item = item;
			_featureProvider = featureProvider;
		}
	}

	private class PolicyNode
	{
		private PolicyNode _next;

		private ItemPolicy _policy;

		internal bool HasMultiple => _next != null;

		internal PolicyNode(ItemPolicy policy, PolicyNode next)
		{
			_policy = policy;
			_next = next;
		}

		internal bool Contains(ItemPolicy policy)
		{
			for (PolicyNode policyNode = this; policyNode != null; policyNode = policyNode._next)
			{
				if (policyNode._policy == policy)
				{
					return true;
				}
			}
			return false;
		}

		internal static bool Remove(ref PolicyNode root, ItemPolicy policy)
		{
			PolicyNode policyNode = null;
			for (PolicyNode policyNode2 = root; policyNode2 != null; policyNode2 = policyNode2._next)
			{
				if (policyNode2._policy == policy)
				{
					if (policyNode != null)
					{
						policyNode._next = policyNode2._next;
						return true;
					}
					root = policyNode2._next;
					return true;
				}
				policyNode = policyNode2;
			}
			return false;
		}
	}

	private class ProviderData
	{
		internal TFeatureProviderType Provider;

		internal PolicyNode AssociatedPolicies;

		internal bool IsValid;
	}

	private ItemPolicyConnector _policyServer;

	private ItemPolicyService _policyService;

	private Dictionary<ModelItem, List<ProviderData>> _featureProviders;

	private Dictionary<ModelItem, List<ProviderData>> _removes;

	private Dictionary<ModelItem, List<ProviderData>> _adds;

	protected IEnumerable<ItemFeatureProvider> FeatureProviders
	{
		get
		{
			foreach (KeyValuePair<ModelItem, List<ProviderData>> kv in _featureProviders)
			{
				KeyValuePair<ModelItem, List<ProviderData>> keyValuePair = kv;
				foreach (ProviderData data in keyValuePair.Value)
				{
					if (data.IsValid)
					{
						KeyValuePair<ModelItem, List<ProviderData>> keyValuePair2 = kv;
						yield return new ItemFeatureProvider(keyValuePair2.Key, data.Provider);
					}
				}
			}
		}
	}

	protected PolicyDrivenFeatureConnector(FeatureManager manager)
		: base(manager)
	{
		_featureProviders = new Dictionary<ModelItem, List<ProviderData>>();
		_policyService = base.Context.Services.GetService<ItemPolicyService>();
		if (_policyService == null)
		{
			_policyServer = new ItemPolicyConnector(manager);
			_policyService = base.Context.Services.GetService<ItemPolicyService>();
		}
		else
		{
			ItemPolicyConnector.ItemPolicyServiceImpl itemPolicyServiceImpl = (ItemPolicyConnector.ItemPolicyServiceImpl)_policyService;
			_policyServer = itemPolicyServiceImpl.Server;
		}
		Predicate<Type> match = delegate(Type featureProviderType)
		{
			_policyServer.OnExtensionAvailable(featureProviderType);
			return false;
		};
		foreach (TFeatureProviderType item in base.Manager.CreateFeatureProviders(typeof(TFeatureProviderType), match))
		{
			_ = item;
		}
		_policyService.PolicyAdded += OnPolicyAdded;
		foreach (ItemPolicy policy in _policyService.Policies)
		{
			OnPolicyItemsChanged(this, new PolicyItemsChangedEventArgs(policy, policy.PolicyItems, null));
			policy.PolicyItemsChanged += OnPolicyItemsChanged;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _policyServer != null)
		{
			_policyServer.Dispose();
		}
		base.Dispose(disposing);
	}

	private void OnPolicyAdded(object sender, PolicyAddedEventArgs e)
	{
		OnPolicyItemsChanged(this, new PolicyItemsChangedEventArgs(e.Policy, e.Policy.PolicyItems, null));
		e.Policy.PolicyItemsChanged += OnPolicyItemsChanged;
	}

	private void OnPolicyItemsChanged(object sender, PolicyItemsChangedEventArgs e)
	{
		Dictionary<ModelItem, List<ProviderData>> dictionary = _removes;
		Dictionary<ModelItem, List<ProviderData>> dictionary2 = _adds;
		_removes = (_adds = null);
		if (dictionary == null)
		{
			dictionary = new Dictionary<ModelItem, List<ProviderData>>();
		}
		else
		{
			dictionary.Clear();
		}
		if (dictionary2 == null)
		{
			dictionary2 = new Dictionary<ModelItem, List<ProviderData>>();
		}
		else
		{
			dictionary2.Clear();
		}
		foreach (ModelItem item in e.ItemsRemoved)
		{
			if (!_featureProviders.TryGetValue(item, out var value))
			{
				value = new List<ProviderData>();
			}
			bool flag = false;
			foreach (ProviderData item2 in value)
			{
				if (PolicyNode.Remove(ref item2.AssociatedPolicies, e.Policy))
				{
					flag = true;
				}
			}
			if (flag)
			{
				dictionary[item] = value;
			}
		}
		foreach (ModelItem item3 in e.ItemsAdded)
		{
			if (!_featureProviders.TryGetValue(item3, out var value2))
			{
				value2 = new List<ProviderData>();
			}
			bool flag2 = false;
			foreach (TFeatureProviderType item4 in CreateFeatureProviders(item3, e.Policy, value2))
			{
				ProviderData providerData = new ProviderData();
				providerData.Provider = item4;
				providerData.AssociatedPolicies = new PolicyNode(e.Policy, providerData.AssociatedPolicies);
				providerData.IsValid = IsValidProvider(item4);
				value2.Add(providerData);
				flag2 = true;
			}
			if (flag2)
			{
				dictionary2[item3] = value2;
			}
		}
		List<TFeatureProviderType> list = null;
		foreach (KeyValuePair<ModelItem, List<ProviderData>> item5 in dictionary)
		{
			ModelItem key = item5.Key;
			list?.Clear();
			for (int i = 0; i < item5.Value.Count; i++)
			{
				ProviderData providerData2 = item5.Value[i];
				if (providerData2.AssociatedPolicies != null)
				{
					continue;
				}
				if (providerData2.IsValid)
				{
					if (list == null)
					{
						list = new List<TFeatureProviderType>();
					}
					list.Add(providerData2.Provider);
				}
				item5.Value.RemoveAt(i);
				i--;
			}
			if (item5.Value.Count == 0)
			{
				_featureProviders.Remove(key);
			}
			if (list != null && list.Count > 0)
			{
				FeatureProvidersRemoved(key, list);
			}
		}
		foreach (KeyValuePair<ModelItem, List<ProviderData>> item6 in dictionary2)
		{
			ModelItem key2 = item6.Key;
			list?.Clear();
			for (int j = 0; j < item6.Value.Count; j++)
			{
				ProviderData providerData3 = item6.Value[j];
				if (providerData3.AssociatedPolicies != null && !providerData3.AssociatedPolicies.HasMultiple && providerData3.AssociatedPolicies.Contains(e.Policy) && providerData3.IsValid)
				{
					if (list == null)
					{
						list = new List<TFeatureProviderType>();
					}
					list.Add(providerData3.Provider);
				}
			}
			_featureProviders[key2] = item6.Value;
			if (list != null && list.Count > 0)
			{
				FeatureProvidersAdded(key2, list);
			}
		}
		dictionary.Clear();
		dictionary2.Clear();
		_removes = dictionary;
		_adds = dictionary2;
	}

	protected void UpdateFeatureProviders()
	{
		List<TFeatureProviderType> list = null;
		List<TFeatureProviderType> list2 = null;
		List<ModelItem> list3 = new List<ModelItem>(_featureProviders.Keys);
		foreach (ModelItem item in list3)
		{
			list?.Clear();
			list2?.Clear();
			if (!_featureProviders.TryGetValue(item, out var value) || value == null)
			{
				continue;
			}
			foreach (ProviderData item2 in value)
			{
				bool flag = IsValidProvider(item2.Provider);
				if (flag == item2.IsValid)
				{
					continue;
				}
				item2.IsValid = flag;
				if (flag)
				{
					if (list == null)
					{
						list = new List<TFeatureProviderType>();
					}
					list.Add(item2.Provider);
				}
				else
				{
					if (list2 == null)
					{
						list2 = new List<TFeatureProviderType>();
					}
					list2.Add(item2.Provider);
				}
			}
			if (list2 != null)
			{
				FeatureProvidersRemoved(item, list2);
			}
			if (list != null)
			{
				FeatureProvidersAdded(item, list);
			}
		}
	}

	protected virtual bool IsValidProvider(FeatureProvider featureProvider)
	{
		return true;
	}

	protected abstract void FeatureProvidersAdded(ModelItem item, IEnumerable<TFeatureProviderType> featureProviders);

	protected abstract void FeatureProvidersRemoved(ModelItem item, IEnumerable<TFeatureProviderType> featureProviders);

	private IList<TFeatureProviderType> CreateFeatureProviders(ModelItem item, ItemPolicy policy, List<ProviderData> dataList)
	{
		UsesItemPolicyAttribute requiredPolicy = new UsesItemPolicyAttribute(policy.GetType());
		Predicate<Type> match = delegate(Type featureProviderType)
		{
			foreach (UsesItemPolicyAttribute customAttribute in base.Manager.GetCustomAttributes(featureProviderType, typeof(UsesItemPolicyAttribute)))
			{
				if (customAttribute.Equals(requiredPolicy))
				{
					RequirementValidator requirementValidator = new RequirementValidator(base.Manager, featureProviderType);
					if (requirementValidator.MeetsRequirements)
					{
						if (dataList != null)
						{
							foreach (ProviderData data in dataList)
							{
								if ((object)data.Provider.GetType() == featureProviderType)
								{
									if (data.AssociatedPolicies == null || !data.AssociatedPolicies.Contains(policy))
									{
										data.AssociatedPolicies = new PolicyNode(policy, data.AssociatedPolicies);
									}
									return false;
								}
							}
						}
						return true;
					}
				}
			}
			return false;
		};
		List<TFeatureProviderType> list = new List<TFeatureProviderType>();
		if (!policy.IsSurrogate)
		{
			foreach (TFeatureProviderType item4 in base.Manager.CreateFeatureProviders(typeof(TFeatureProviderType), item, match))
			{
				list.Add(item4);
			}
		}
		else
		{
			foreach (ModelItem surrogateItem in policy.GetSurrogateItems(item))
			{
				foreach (TFeatureProviderType item5 in base.Manager.CreateFeatureProviders(typeof(TFeatureProviderType), surrogateItem, match))
				{
					list.Add(item5);
				}
			}
		}
		return list;
	}
}
