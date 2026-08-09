namespace System.ServiceModel.Dispatcher;

public interface IOperationInvoker
{
	object[] AllocateInputs();

	IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state);

	object InvokeEnd(object instance, out object[] outputs, IAsyncResult result);
}
