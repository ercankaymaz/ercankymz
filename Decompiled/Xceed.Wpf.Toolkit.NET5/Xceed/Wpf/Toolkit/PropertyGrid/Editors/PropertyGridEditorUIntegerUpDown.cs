using System;
using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

[CLSCompliant(false)]
public class PropertyGridEditorUIntegerUpDown : UIntegerUpDown
{
	static PropertyGridEditorUIntegerUpDown()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorUIntegerUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorUIntegerUpDown)));
	}
}
