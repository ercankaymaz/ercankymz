using System;
using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

[CLSCompliant(false)]
public class PropertyGridEditorULongUpDown : ULongUpDown
{
	static PropertyGridEditorULongUpDown()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorULongUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorULongUpDown)));
	}
}
