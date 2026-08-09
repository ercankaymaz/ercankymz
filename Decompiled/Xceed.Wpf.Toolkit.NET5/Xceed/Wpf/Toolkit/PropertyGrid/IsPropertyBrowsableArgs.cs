using System.ComponentModel;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

public class IsPropertyBrowsableArgs : PropertyArgs
{
	public bool? IsBrowsable { get; set; }

	public IsPropertyBrowsableArgs(PropertyDescriptor pd)
		: base(pd)
	{
	}
}
