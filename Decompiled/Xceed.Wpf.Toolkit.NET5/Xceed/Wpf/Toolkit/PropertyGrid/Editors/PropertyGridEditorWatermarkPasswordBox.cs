using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PropertyGridEditorWatermarkPasswordBox : WatermarkPasswordBox
{
	static PropertyGridEditorWatermarkPasswordBox()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorWatermarkPasswordBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorWatermarkPasswordBox)));
	}
}
