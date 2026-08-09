using System;

namespace Microsoft.Windows.Design;

public abstract class ContextItem
{
	public abstract Type ItemType { get; }

	protected virtual void OnItemChanged(EditingContext context, ContextItem previousItem)
	{
	}

	internal void InvokeOnItemChanged(EditingContext context, ContextItem previousItem)
	{
		OnItemChanged(context, previousItem);
	}
}
