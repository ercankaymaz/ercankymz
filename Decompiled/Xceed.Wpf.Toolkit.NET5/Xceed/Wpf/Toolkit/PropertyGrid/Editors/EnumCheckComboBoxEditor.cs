using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Data;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class EnumCheckComboBoxEditor : TypeEditor<CheckComboBox>
{
	protected override void SetValueDependencyProperty()
	{
		base.ValueProperty = Selector.SelectedValueProperty;
	}

	protected override CheckComboBox CreateEditor()
	{
		return new PropertyGridEditorEnumCheckComboBox();
	}

	protected override void ResolveValueBinding(PropertyItem propertyItem)
	{
		SetItemsSource(propertyItem);
		base.ResolveValueBinding(propertyItem);
	}

	private void SetItemsSource(PropertyItem propertyItem)
	{
		base.Editor.ItemsSource = CreateItemsSource(propertyItem);
	}

	protected IEnumerable CreateItemsSource(PropertyItem propertyItem)
	{
		return GetValues(propertyItem.PropertyType);
	}

	protected override IValueConverter CreateValueConverter()
	{
		return new SourceComboBoxEditorMultiStringConverter();
	}

	private static object[] GetValues(Type enumType)
	{
		List<object> list = new List<object>();
		if (enumType != null)
		{
			foreach (FieldInfo item in from x in enumType.GetFields()
				where x.IsLiteral
				select x)
			{
				object[] customAttributes = item.GetCustomAttributes(typeof(BrowsableAttribute), inherit: false);
				if (customAttributes.Length != 1 || ((BrowsableAttribute)customAttributes[0]).Browsable)
				{
					list.Add(item.GetValue(enumType));
				}
			}
		}
		return list.ToArray();
	}
}
