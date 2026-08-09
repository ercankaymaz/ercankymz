using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PropertyGridEditorCollectionControl : CollectionControlButton
{
	static PropertyGridEditorCollectionControl()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorCollectionControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorCollectionControl)));
	}
}
