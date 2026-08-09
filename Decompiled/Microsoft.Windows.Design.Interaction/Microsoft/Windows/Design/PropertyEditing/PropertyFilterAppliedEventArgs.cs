using System;

namespace Microsoft.Windows.Design.PropertyEditing;

public class PropertyFilterAppliedEventArgs : EventArgs
{
	private PropertyFilter _filter;

	public PropertyFilter Filter => _filter;

	public PropertyFilterAppliedEventArgs(PropertyFilter filter)
	{
		_filter = filter;
	}
}
