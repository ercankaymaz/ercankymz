using System;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Services;

public abstract class ModelResource
{
	public abstract ModelItem ModelItem { get; }

	public abstract event EventHandler Changed;
}
