using System;
using System.Collections;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class ItemsSourceAttributeEditor : TypeEditor<ComboBox>
{
	private readonly ItemsSourceAttribute _attribute;

	public ItemsSourceAttributeEditor(ItemsSourceAttribute attribute)
	{
		_attribute = attribute;
	}

	protected override void SetValueDependencyProperty()
	{
		base.ValueProperty = Selector.SelectedValueProperty;
	}

	protected override ComboBox CreateEditor()
	{
		return new PropertyGridEditorComboBox();
	}

	protected override void ResolveValueBinding(PropertyItem propertyItem)
	{
		SetItemsSource();
		base.ResolveValueBinding(propertyItem);
	}

	protected override void SetControlProperties(PropertyItem propertyItem)
	{
		base.Editor.DisplayMemberPath = "DisplayName";
		base.Editor.SelectedValuePath = "Value";
		if (propertyItem != null)
		{
			base.Editor.IsEnabled = !propertyItem.IsReadOnly;
		}
	}

	private void SetItemsSource()
	{
		base.Editor.ItemsSource = CreateItemsSource();
	}

	private IEnumerable CreateItemsSource()
	{
		return (Activator.CreateInstance(_attribute.Type) as IItemsSource).GetValues();
	}
}
