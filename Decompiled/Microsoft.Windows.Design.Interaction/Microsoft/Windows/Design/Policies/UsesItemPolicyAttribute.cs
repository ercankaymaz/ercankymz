using System;
using System.Globalization;
using MS.Internal;
using MS.Internal.Properties;
using Microsoft.Windows.Design.Services;

namespace Microsoft.Windows.Design.Policies;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class UsesItemPolicyAttribute : RequirementAttribute
{
	private class RequirePolicySubscription : RequirementSubscription
	{
		private EditingContext _context;

		private Type _policyType;

		private ItemPolicyService _policyService;

		internal RequirePolicySubscription(EditingContext context, UsesItemPolicyAttribute requirement)
			: base(requirement)
		{
			_context = context;
			_policyType = requirement.ItemPolicyType;
		}

		private void OnPolicyAdded(object sender, PolicyAddedEventArgs e)
		{
			if ((object)e.Policy.GetType() == _policyType)
			{
				OnRequirementChanged();
			}
		}

		private void OnPolicyServiceAvailable(ItemPolicyService policyService)
		{
			_context.Services.Unsubscribe<ItemPolicyService>(OnPolicyServiceAvailable);
			_policyService = policyService;
			_policyService.PolicyAdded += OnPolicyAdded;
		}

		protected override void Subscribe()
		{
			_policyService = _context.Services.GetService<ItemPolicyService>();
			if (_policyService != null)
			{
				_policyService.PolicyAdded += OnPolicyAdded;
			}
			else
			{
				_context.Services.Subscribe<ItemPolicyService>(OnPolicyServiceAvailable);
			}
		}

		protected override void Unsubscribe()
		{
			if (_policyService != null)
			{
				_policyService.PolicyAdded -= OnPolicyAdded;
			}
			else
			{
				_context.Services.Unsubscribe<ItemPolicyService>(OnPolicyServiceAvailable);
			}
		}
	}

	private Type _itemPolicyType;

	public override bool AllRequired => false;

	public Type ItemPolicyType => _itemPolicyType;

	public override object TypeId => new MS.Internal.EqualityArray(typeof(UsesItemPolicyAttribute), _itemPolicyType);

	public UsesItemPolicyAttribute(Type itemPolicyType)
	{
		if ((object)itemPolicyType == null)
		{
			throw new ArgumentNullException("itemPolicyType");
		}
		if (itemPolicyType.IsAssignableFrom(typeof(ItemPolicy)))
		{
			throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_ArgIncorrectTypeValue, new object[2]
			{
				"itemPolicyType",
				typeof(ItemPolicy).Name
			}));
		}
		_itemPolicyType = itemPolicyType;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is UsesItemPolicyAttribute usesItemPolicyAttribute))
		{
			return false;
		}
		return (object)usesItemPolicyAttribute.ItemPolicyType == ItemPolicyType;
	}

	public override int GetHashCode()
	{
		return _itemPolicyType.GetHashCode();
	}

	public override RequirementSubscription CreateSubscription(EditingContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		return new RequirePolicySubscription(context, this);
	}

	public override bool MeetsRequirement(EditingContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		ItemPolicyService service = context.Services.GetService<ItemPolicyService>();
		if (service == null)
		{
			return false;
		}
		foreach (ItemPolicy policy in service.Policies)
		{
			if ((object)policy.GetType() == ItemPolicyType)
			{
				return true;
			}
		}
		return false;
	}
}
