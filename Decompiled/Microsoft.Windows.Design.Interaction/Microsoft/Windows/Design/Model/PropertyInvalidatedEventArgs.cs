using System;
using Microsoft.Windows.Design.Metadata;

namespace Microsoft.Windows.Design.Model;

public class PropertyInvalidatedEventArgs : EventArgs
{
	private ModelItem _item;

	private PropertyIdentifier _property;

	public ModelItem Item => _item;

	public PropertyIdentifier InvalidatedProperty => _property;

	public PropertyInvalidatedEventArgs(ModelItem item, PropertyIdentifier property)
	{
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		if (item == null)
		{
			throw new ArgumentNullException("property");
		}
		_item = item;
		_property = property;
	}
}
