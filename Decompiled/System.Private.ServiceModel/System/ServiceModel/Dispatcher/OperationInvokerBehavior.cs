using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace System.ServiceModel.Dispatcher;

public class OperationInvokerBehavior : IOperationBehavior
{
	void IOperationBehavior.Validate(OperationDescription description)
	{
	}

	void IOperationBehavior.AddBindingParameters(OperationDescription description, BindingParameterCollection parameters)
	{
	}

	void IOperationBehavior.ApplyDispatchBehavior(OperationDescription description, DispatchOperation dispatch)
	{
		if (dispatch == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("dispatch");
		}
		if (description == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("description");
		}
		if (description.TaskMethod != null)
		{
			dispatch.Invoker = new TaskMethodInvoker(description.TaskMethod, description.TaskTResult);
		}
		else if (description.SyncMethod != null)
		{
			if (description.BeginMethod != null)
			{
				throw new PlatformNotSupportedException();
			}
			dispatch.Invoker = new SyncMethodInvoker(description.SyncMethod);
		}
		else if (description.BeginMethod != null)
		{
			throw new PlatformNotSupportedException();
		}
	}

	void IOperationBehavior.ApplyClientBehavior(OperationDescription description, ClientOperation proxy)
	{
	}
}
