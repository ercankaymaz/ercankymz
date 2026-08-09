using System.Windows;
using System.Windows.Data;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class NumericUpDownEditor<TEditor, TType> : UpDownEditor<TEditor, TType> where TEditor : UpDownBase<TType>, new()
{
	protected override void SetControlProperties(PropertyItem propertyItem)
	{
		base.SetControlProperties(propertyItem);
		Binding binding = new Binding("IsInvalid");
		binding.Source = base.Editor;
		binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
		binding.Mode = BindingMode.TwoWay;
		BindingOperations.SetBinding((DependencyObject)(object)propertyItem, PropertyItem.IsInvalidProperty, binding);
	}
}
