using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Features;
using Microsoft.Windows.Design.Policies;
using Microsoft.Windows.Design.Services;

namespace MS.Internal.Features;

internal class ItemPolicyConnector : IDisposable
{
	internal class ItemPolicyServiceImpl : ItemPolicyService
	{
		private ItemPolicyConnector _server;

		public ItemPolicyConnector Server => _server;

		public override IEnumerable<ItemPolicy> Policies
		{
			get
			{
				if (_server._policies == null)
				{
					yield break;
				}
				foreach (PolicyData data in _server._policies.Values)
				{
					if (data.Validator == null)
					{
						yield return data.Policy;
					}
				}
			}
		}

		public override event EventHandler<PolicyAddedEventArgs> PolicyAdded
		{
			add
			{
				ItemPolicyConnector server = _server;
				server._policyAdded = (EventHandler<PolicyAddedEventArgs>)Delegate.Combine(server._policyAdded, value);
			}
			remove
			{
				ItemPolicyConnector server = _server;
				server._policyAdded = (EventHandler<PolicyAddedEventArgs>)Delegate.Remove(server._policyAdded, value);
			}
		}

		internal ItemPolicyServiceImpl(ItemPolicyConnector server)
		{
			_server = server;
		}
	}

	private class PolicyData
	{
		internal ItemPolicy Policy;

		internal RequirementValidator Validator;
	}

	private FeatureManager _manager;

	private Dictionary<Type, PolicyData> _policies;

	private HashSet<Type> _seenFeatureProviderTypes;

	private EventHandler<PolicyAddedEventArgs> _policyAdded;

	public ItemPolicyConnector(FeatureManager manager)
	{
		_manager = manager;
		ServiceManager services = manager.Context.Services;
		PublishServiceCallback<ItemPolicyService> callback = () => new ItemPolicyServiceImpl(this);
		services.Publish(callback);
		_policies = new Dictionary<Type, PolicyData>();
		manager.FeatureAvailable += OnFeatureAvailable;
	}

	private void AttemptActivatePolicy(ItemPolicy policy)
	{
		if (!_policies.ContainsKey(policy.GetType()))
		{
			PolicyData policyData = new PolicyData();
			policyData.Validator = new RequirementValidator(_manager, policy.GetType());
			policyData.Policy = policy;
			_policies[policy.GetType()] = policyData;
			if (policyData.Validator.MeetsRequirements)
			{
				ActivatePolicy(policyData);
			}
			else
			{
				policyData.Validator.RequirementsChanged += OnPolicyRequirementsChanged;
			}
		}
	}

	private void ActivatePolicy(PolicyData policyData)
	{
		policyData.Validator.RequirementsChanged -= OnPolicyRequirementsChanged;
		policyData.Validator = null;
		policyData.Policy.Activate(_manager.Context);
		if (_policyAdded != null)
		{
			_policyAdded(this, new PolicyAddedEventArgs(policyData.Policy));
		}
	}

	private void Dispose(bool disposing)
	{
		if (!disposing || _policies == null)
		{
			return;
		}
		foreach (PolicyData value in _policies.Values)
		{
			if (value.Validator != null)
			{
				value.Validator.RequirementsChanged -= OnPolicyRequirementsChanged;
			}
			else
			{
				value.Policy.Deactivate();
			}
		}
		_manager.FeatureAvailable -= OnFeatureAvailable;
		_policies = null;
	}

	public void OnExtensionAvailable(Type featureProviderType)
	{
		if (_seenFeatureProviderTypes == null)
		{
			_seenFeatureProviderTypes = new HashSet<Type>();
		}
		if (_seenFeatureProviderTypes.Contains(featureProviderType))
		{
			return;
		}
		_seenFeatureProviderTypes.Add(featureProviderType);
		object[] customAttributes = featureProviderType.GetCustomAttributes(typeof(UsesItemPolicyAttribute), inherit: true);
		for (int i = 0; i < customAttributes.Length; i++)
		{
			UsesItemPolicyAttribute usesItemPolicyAttribute = (UsesItemPolicyAttribute)customAttributes[i];
			Type itemPolicyType = usesItemPolicyAttribute.ItemPolicyType;
			if (typeof(ItemPolicy).IsAssignableFrom(itemPolicyType) && !_policies.ContainsKey(itemPolicyType))
			{
				ConstructorInfo constructor = itemPolicyType.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
				if ((object)constructor != null && constructor.Invoke(null) is ItemPolicy policy)
				{
					AttemptActivatePolicy(policy);
				}
			}
		}
	}

	private void OnFeatureAvailable(object sender, FeatureAvailableEventArgs e)
	{
		OnExtensionAvailable(e.FeatureProviderType);
	}

	private void OnPolicyRequirementsChanged(object sender, EventArgs e)
	{
		RequirementValidator requirementValidator = (RequirementValidator)sender;
		if (requirementValidator.MeetsRequirements)
		{
			PolicyData policyData = _policies[requirementValidator.Type];
			ActivatePolicy(policyData);
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
