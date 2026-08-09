using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class UpDownEditor<TEditor, TType> : TypeEditor<TEditor> where TEditor : UpDownBase<TType>, new()
{
	protected override void SetValueDependencyProperty()
	{
		base.ValueProperty = UpDownBase<TType>.ValueProperty;
	}

	internal void SetMinMaxFromRangeAttribute(PropertyDescriptor propertyDescriptor, TypeConverter converter)
	{
		if (propertyDescriptor != null)
		{
			RangeAttribute attribute = PropertyGridUtilities.GetAttribute<RangeAttribute>(propertyDescriptor);
			if (attribute != null)
			{
				base.Editor.Maximum = (TType)converter.ConvertFrom(attribute.Maximum.ToString());
				base.Editor.Minimum = (TType)converter.ConvertFrom(attribute.Minimum.ToString());
			}
		}
	}
}
