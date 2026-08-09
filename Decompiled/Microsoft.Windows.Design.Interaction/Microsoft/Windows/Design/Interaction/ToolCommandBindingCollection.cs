using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Windows.Design.Interaction;

public class ToolCommandBindingCollection : Collection<ToolCommandBinding>
{
	public void AddRange(ICollection<ToolCommandBinding> bindings)
	{
		if (bindings == null)
		{
			throw new ArgumentNullException("bindings");
		}
		foreach (ToolCommandBinding binding in bindings)
		{
			Add(binding);
		}
	}

	protected override void InsertItem(int index, ToolCommandBinding item)
	{
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		base.InsertItem(index, item);
	}

	protected override void SetItem(int index, ToolCommandBinding item)
	{
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		base.SetItem(index, item);
	}
}
