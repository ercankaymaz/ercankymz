using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PropertyGridEditorPrimitiveTypeCollectionControl : PrimitiveTypeCollectionControl
{
	static PropertyGridEditorPrimitiveTypeCollectionControl()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorPrimitiveTypeCollectionControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorPrimitiveTypeCollectionControl)));
	}
}
