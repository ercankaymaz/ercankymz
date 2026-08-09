using System.Runtime;
using System.ServiceModel.Channels;
using System.ServiceModel.Diagnostics;

namespace System.ServiceModel.Dispatcher;

public class InstanceBehavior
{
	private IInstanceProvider _provider;

	internal IInstanceContextProvider InstanceContextProvider { get; }

	internal InstanceBehavior(DispatchRuntime dispatch, ImmutableDispatchRuntime immutableRuntime)
	{
		_provider = dispatch.InstanceProvider;
		InstanceContextProvider = dispatch.InstanceContextProvider;
	}

	internal void AfterReply(ref MessageRpc rpc, ErrorBehavior error)
	{
		InstanceContext instanceContext = rpc.InstanceContext;
		if (instanceContext == null)
		{
			return;
		}
		try
		{
			instanceContext.UnbindRpc(ref rpc);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			error.HandleError(ex);
		}
	}

	internal void EnsureInstanceContext(ref MessageRpc rpc)
	{
		if (rpc.InstanceContext == null)
		{
			throw new ArgumentNullException("rpc.InstanceContext");
		}
		rpc.OperationContext.SetInstanceContext(rpc.InstanceContext);
		rpc.InstanceContext.Behavior = this;
		if (rpc.InstanceContext.State == CommunicationState.Created)
		{
			lock (rpc.InstanceContext.ThisLock)
			{
				if (rpc.InstanceContext.State == CommunicationState.Created)
				{
					rpc.InstanceContext.Open(rpc.Channel.CloseTimeout);
				}
			}
		}
		rpc.InstanceContext.BindRpc(ref rpc);
	}

	internal object GetInstance(InstanceContext instanceContext)
	{
		if (_provider == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxNoDefaultConstructor));
		}
		return _provider.GetInstance(instanceContext);
	}

	internal object GetInstance(InstanceContext instanceContext, Message request)
	{
		if (_provider == null)
		{
			throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxNoDefaultConstructor), request);
		}
		return _provider.GetInstance(instanceContext, request);
	}

	internal void EnsureServiceInstance(ref MessageRpc rpc)
	{
		if (WcfEventSource.Instance.GetServiceInstanceStartIsEnabled())
		{
			WcfEventSource.Instance.GetServiceInstanceStart(rpc.EventTraceActivity);
		}
		rpc.Instance = rpc.InstanceContext.GetServiceInstance(rpc.Request);
		if (WcfEventSource.Instance.GetServiceInstanceStopIsEnabled())
		{
			WcfEventSource.Instance.GetServiceInstanceStop(rpc.EventTraceActivity);
		}
	}
}
