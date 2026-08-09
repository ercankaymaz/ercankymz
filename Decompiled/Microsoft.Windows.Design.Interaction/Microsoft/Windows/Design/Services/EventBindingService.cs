using System;
using System.CodeDom;
using System.Collections.Generic;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Services;

public abstract class EventBindingService
{
	public event EventHandler<EventHandlerGeneratedEventArgs> EventHandlerGenerated;

	public abstract void SetClassName(string className);

	public abstract bool CreateMethod(ModelEvent modelEvent, string methodName);

	public abstract void AppendStatements(ModelEvent modelEvent, string methodName, CodeStatementCollection statements);

	public abstract string CreateUniqueMethodName(ModelEvent modelEvent);

	public abstract bool AllowClassNameForMethodName();

	public abstract IEnumerable<string> GetCompatibleMethods(ModelEvent modelEvent);

	public abstract bool IsExistingMethodName(ModelEvent modelEvent, string methodName);

	public abstract void ValidateMethodName(ModelEvent modelEvent, string methodName);

	public abstract bool RemoveMethod(ModelEvent modelEvent, string methodName);

	public abstract bool ShowMethod(ModelEvent modelEvent, string methodName);

	public abstract IEnumerable<string> GetMethodHandlers(ModelEvent modelEvent);

	public abstract bool AddEventHandler(ModelEvent modelEvent, string methodName);

	public abstract bool RemoveHandle(ModelEvent modelEvent, string methodName);

	public virtual bool RemoveHandlesForName(string elementName)
	{
		return false;
	}

	protected virtual void OnEventHandlerGenerated(ModelEvent modelEvent, string methodName)
	{
		if (this.EventHandlerGenerated != null)
		{
			this.EventHandlerGenerated(this, new EventHandlerGeneratedEventArgs(modelEvent, methodName));
		}
	}
}
