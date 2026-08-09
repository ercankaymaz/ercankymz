using System;
using MS.Internal;

namespace Microsoft.Windows.Design;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class RequiresContextItemAttribute : RequirementAttribute
{
	private class RequireContextItemSubscription : RequirementSubscription
	{
		private EditingContext _context;

		private Type _contextItemType;

		internal RequireContextItemSubscription(EditingContext context, RequiresContextItemAttribute requirement)
			: base(requirement)
		{
			_context = context;
			_contextItemType = requirement.ContextItemType;
		}

		private void OnContextItemChanged(ContextItem item)
		{
			OnRequirementChanged();
		}

		protected override void Subscribe()
		{
			_context.Items.Subscribe(_contextItemType, OnContextItemChanged);
		}

		protected override void Unsubscribe()
		{
			_context.Items.Unsubscribe(_contextItemType, OnContextItemChanged);
		}
	}

	private Type _contextItemType;

	public Type ContextItemType => _contextItemType;

	public override object TypeId => new EqualityArray(typeof(RequiresContextItemAttribute), _contextItemType);

	public RequiresContextItemAttribute(Type contextItemType)
	{
		if ((object)contextItemType == null)
		{
			throw new ArgumentNullException("contextItemType");
		}
		_contextItemType = contextItemType;
	}

	public override RequirementSubscription CreateSubscription(EditingContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		return new RequireContextItemSubscription(context, this);
	}

	public override bool MeetsRequirement(EditingContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		return context.Items.Contains(ContextItemType);
	}
}
