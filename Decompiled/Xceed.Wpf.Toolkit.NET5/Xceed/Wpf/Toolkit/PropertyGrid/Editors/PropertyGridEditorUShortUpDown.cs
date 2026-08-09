using System;
using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

[CLSCompliant(false)]
public class PropertyGridEditorUShortUpDown : UShortUpDown
{
	static PropertyGridEditorUShortUpDown()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorUShortUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorUShortUpDown)));
	}
}
