using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace System.ServiceModel.Description;

public interface IOperationBehavior
{
	void Validate(OperationDescription operationDescription);

	void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation);

	void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation);

	void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters);
}
