using System;

namespace Microsoft.Windows.Design.PropertyEditing;

[AttributeUsage(AttributeTargets.Property)]
[CLSCompliant(false)]
public sealed class PropertyOrderAttribute : Attribute
{
	private PropertyOrder _order;

	public PropertyOrder Order => _order;

	public PropertyOrderAttribute(PropertyOrder order)
	{
		if (order == null)
		{
			throw new ArgumentNullException("order");
		}
		_order = order;
	}
}
