using System;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Services;

public class EventHandlerGeneratedEventArgs : EventArgs
{
	private ModelEvent _modelEvent;

	private string _methodName;

	public ModelEvent ModelEvent => _modelEvent;

	public string MethodName => _methodName;

	public EventHandlerGeneratedEventArgs(ModelEvent modelEvent, string methodName)
	{
		if (modelEvent == null)
		{
			throw new ArgumentNullException("modelEvent");
		}
		if (methodName == null)
		{
			throw new ArgumentNullException("methodName");
		}
		_modelEvent = modelEvent;
		_methodName = methodName;
	}
}
