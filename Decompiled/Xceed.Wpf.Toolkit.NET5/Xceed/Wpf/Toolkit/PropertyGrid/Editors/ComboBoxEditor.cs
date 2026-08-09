using System.Collections;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public abstract class ComboBoxEditor : TypeEditor<ComboBox>
{
	protected override void SetValueDependencyProperty()
	{
		base.ValueProperty = Selector.SelectedItemProperty;
	}

	protected override ComboBox CreateEditor()
	{
		return new PropertyGridEditorComboBox();
	}

	protected override void ResolveValueBinding(PropertyItem propertyItem)
	{
		SetItemsSource(propertyItem);
		base.ResolveValueBinding(propertyItem);
	}

	protected abstract IEnumerable CreateItemsSource(PropertyItem propertyItem);

	private void SetItemsSource(PropertyItem propertyItem)
	{
		base.Editor.ItemsSource = CreateItemsSource(propertyItem);
	}
}
