using System;
using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

[CLSCompliant(false)]
public class PropertyGridEditorSByteUpDown : SByteUpDown
{
	static PropertyGridEditorSByteUpDown()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGridEditorSByteUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(PropertyGridEditorSByteUpDown)));
	}
}
