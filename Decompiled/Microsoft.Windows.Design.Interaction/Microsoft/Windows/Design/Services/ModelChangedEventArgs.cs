using System;
using System.Collections.Generic;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Services;

public abstract class ModelChangedEventArgs : EventArgs
{
	public abstract IEnumerable<ModelItem> ItemsAdded { get; }

	public abstract IEnumerable<ModelItem> ItemsRemoved { get; }

	public abstract IEnumerable<ModelProperty> PropertiesChanged { get; }

	public abstract IEnumerable<string> PropertyNamesChanged { get; }
}
