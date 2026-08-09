using System;
using MS.Internal;

namespace Microsoft.Windows.Design;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class RequiresServiceAttribute : RequirementAttribute
{
	private class RequireServiceSubscription : RequirementSubscription
	{
		private EditingContext _context;

		private Type _serviceType;

		internal RequireServiceSubscription(EditingContext context, RequiresServiceAttribute requirement)
			: base(requirement)
		{
			_context = context;
			_serviceType = requirement.ServiceType;
		}

		private void OnServiceAvailable(Type serviceType, object serviceInstance)
		{
			OnRequirementChanged();
		}

		protected override void Subscribe()
		{
			_context.Services.Subscribe(_serviceType, OnServiceAvailable);
		}

		protected override void Unsubscribe()
		{
			_context.Services.Unsubscribe(_serviceType, OnServiceAvailable);
		}
	}

	private Type _serviceType;

	public Type ServiceType => _serviceType;

	public override object TypeId => new EqualityArray(typeof(RequiresServiceAttribute), _serviceType);

	public RequiresServiceAttribute(Type serviceType)
	{
		if ((object)serviceType == null)
		{
			throw new ArgumentNullException("serviceType");
		}
		_serviceType = serviceType;
	}

	public override RequirementSubscription CreateSubscription(EditingContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		return new RequireServiceSubscription(context, this);
	}

	public override bool MeetsRequirement(EditingContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		return context.Services.Contains(ServiceType);
	}
}
