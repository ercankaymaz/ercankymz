using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

public abstract class EditorDefinitionBase : PropertyDefinitionBase
{
	internal EditorDefinitionBase()
	{
	}

	internal FrameworkElement GenerateEditingElementInternal(PropertyItemBase propertyItem)
	{
		return GenerateEditingElement(propertyItem);
	}

	protected virtual FrameworkElement GenerateEditingElement(PropertyItemBase propertyItem)
	{
		return null;
	}

	internal void UpdateProperty(FrameworkElement element, DependencyProperty elementProp, DependencyProperty definitionProperty)
	{
		object value = ((DependencyObject)this).GetValue(definitionProperty);
		object obj = ((DependencyObject)this).ReadLocalValue(definitionProperty);
		object value2 = ((DependencyObject)element).GetValue(elementProp);
		bool flag = false;
		if (obj != DependencyProperty.UnsetValue)
		{
			if (value2 != null && value != null)
			{
				flag = ((value2.GetType().IsValueType && value.GetType().IsValueType) ? value2.Equals(value) : (value == ((DependencyObject)element).GetValue(elementProp)));
			}
			if (!flag)
			{
				((DependencyObject)element).SetValue(elementProp, value);
			}
			else
			{
				((DependencyObject)element).ClearValue(elementProp);
			}
		}
	}
}
