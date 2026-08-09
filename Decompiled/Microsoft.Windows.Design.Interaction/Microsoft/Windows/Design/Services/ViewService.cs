using System;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Services;

public abstract class ViewService
{
	public abstract event EventHandler LayoutUpdated;

	public abstract ModelItem GetModel(ViewItem view);
}
