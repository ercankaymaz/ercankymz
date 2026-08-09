using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace System.ServiceModel;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true)]
public sealed class DeliveryRequirementsAttribute : Attribute, IContractBehavior
{
	private QueuedDeliveryRequirementsMode queuedDeliveryRequirements;

	public QueuedDeliveryRequirementsMode QueuedDeliveryRequirements
	{
		get
		{
			return queuedDeliveryRequirements;
		}
		set
		{
			if (QueuedDeliveryRequirementsModeHelper.IsDefined(value))
			{
				queuedDeliveryRequirements = value;
				return;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
		}
	}

	public bool RequireOrderedDelivery { get; set; }

	void IContractBehavior.Validate(ContractDescription description, ServiceEndpoint endpoint)
	{
		if (description == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("description");
		}
		if (endpoint == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("endpoint");
		}
		ValidateEndpoint(endpoint);
	}

	void IContractBehavior.AddBindingParameters(ContractDescription description, ServiceEndpoint endpoint, BindingParameterCollection parameters)
	{
	}

	void IContractBehavior.ApplyClientBehavior(ContractDescription description, ServiceEndpoint endpoint, ClientRuntime proxy)
	{
	}

	void IContractBehavior.ApplyDispatchBehavior(ContractDescription description, ServiceEndpoint endpoint, DispatchRuntime dispatch)
	{
	}

	private void ValidateEndpoint(ServiceEndpoint endpoint)
	{
		string name = endpoint.Contract.ContractType.Name;
		EnsureQueuedDeliveryRequirements(name, endpoint.Binding);
		EnsureOrderedDeliveryRequirements(name, endpoint.Binding);
	}

	private void EnsureQueuedDeliveryRequirements(string name, Binding binding)
	{
		if (QueuedDeliveryRequirements == QueuedDeliveryRequirementsMode.Required || QueuedDeliveryRequirements == QueuedDeliveryRequirementsMode.NotAllowed)
		{
			IBindingDeliveryCapabilities property = binding.GetProperty<IBindingDeliveryCapabilities>(new BindingParameterCollection());
			if (property == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SinceTheBindingForDoesnTSupportIBindingCapabilities2_1, name)));
			}
			bool queuedDelivery = property.QueuedDelivery;
			if (QueuedDeliveryRequirements == QueuedDeliveryRequirementsMode.Required && !queuedDelivery)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.BindingRequirementsAttributeRequiresQueuedDelivery1, name)));
			}
			if (QueuedDeliveryRequirements == QueuedDeliveryRequirementsMode.NotAllowed && queuedDelivery)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.BindingRequirementsAttributeDisallowsQueuedDelivery1, name)));
			}
		}
	}

	private void EnsureOrderedDeliveryRequirements(string name, Binding binding)
	{
		if (RequireOrderedDelivery)
		{
			IBindingDeliveryCapabilities property = binding.GetProperty<IBindingDeliveryCapabilities>(new BindingParameterCollection());
			if (property == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SinceTheBindingForDoesnTSupportIBindingCapabilities1_1, name)));
			}
			if (!property.AssuresOrderedDelivery)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.TheBindingForDoesnTSupportOrderedDelivery1, name)));
			}
		}
	}
}
