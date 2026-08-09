using System;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PrimitiveTypeCollectionEditor : TypeEditor<PrimitiveTypeCollectionControl>
{
	protected override void SetValueDependencyProperty()
	{
		base.ValueProperty = PrimitiveTypeCollectionControl.ItemsSourceProperty;
	}

	protected override PrimitiveTypeCollectionControl CreateEditor()
	{
		return new PropertyGridEditorPrimitiveTypeCollectionControl();
	}

	protected override void ResolveValueBinding(PropertyItem propertyItem)
	{
		Type propertyType = propertyItem.PropertyType;
		base.Editor.ItemsSourceType = propertyType;
		if (propertyType.BaseType == typeof(Array))
		{
			base.Editor.ItemType = propertyType.GetElementType();
		}
		else
		{
			Type[] genericArguments = propertyType.GetGenericArguments();
			if (genericArguments.Length != 0)
			{
				base.Editor.ItemType = genericArguments[0];
			}
		}
		base.ResolveValueBinding(propertyItem);
	}
}
