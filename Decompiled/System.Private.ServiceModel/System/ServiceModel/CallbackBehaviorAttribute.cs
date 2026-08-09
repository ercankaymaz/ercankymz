using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace System.ServiceModel;

[AttributeUsage(AttributeTargets.Class)]
public sealed class CallbackBehaviorAttribute : Attribute, IEndpointBehavior
{
	private ConcurrencyMode _concurrencyMode;

	private bool _useSynchronizationContext = true;

	public bool AutomaticSessionShutdown { get; set; } = true;

	public ConcurrencyMode ConcurrencyMode
	{
		get
		{
			return _concurrencyMode;
		}
		set
		{
			if (!ConcurrencyModeHelper.IsDefined(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			_concurrencyMode = value;
		}
	}

	public bool UseSynchronizationContext
	{
		get
		{
			return _useSynchronizationContext;
		}
		set
		{
			_useSynchronizationContext = value;
		}
	}

	void IEndpointBehavior.Validate(ServiceEndpoint serviceEndpoint)
	{
	}

	void IEndpointBehavior.AddBindingParameters(ServiceEndpoint serviceEndpoint, BindingParameterCollection parameters)
	{
	}

	void IEndpointBehavior.ApplyClientBehavior(ServiceEndpoint serviceEndpoint, ClientRuntime clientRuntime)
	{
		if (!serviceEndpoint.Contract.IsDuplex())
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxCallbackBehaviorAttributeOnlyOnDuplex, serviceEndpoint.Contract.Name)));
		}
		DispatchRuntime dispatchRuntime = clientRuntime.DispatchRuntime;
		dispatchRuntime.ConcurrencyMode = _concurrencyMode;
		dispatchRuntime.AutomaticInputSessionShutdown = AutomaticSessionShutdown;
		if (!_useSynchronizationContext)
		{
			dispatchRuntime.SynchronizationContext = null;
		}
	}

	void IEndpointBehavior.ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, EndpointDispatcher endpointDispatcher)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFXEndpointBehaviorUsedOnWrongSide, typeof(CallbackBehaviorAttribute).Name)));
	}
}
