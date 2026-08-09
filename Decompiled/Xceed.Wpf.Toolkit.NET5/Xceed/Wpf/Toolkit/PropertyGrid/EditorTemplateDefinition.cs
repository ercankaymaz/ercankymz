using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

public class EditorTemplateDefinition : EditorDefinitionBase
{
	public static readonly DependencyProperty EditingTemplateProperty = DependencyProperty.Register("EditingTemplate", typeof(DataTemplate), typeof(EditorTemplateDefinition), (PropertyMetadata)(object)new UIPropertyMetadata(null));

	public DataTemplate EditingTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(EditingTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EditingTemplateProperty, (object)value);
		}
	}

	protected sealed override FrameworkElement GenerateEditingElement(PropertyItemBase propertyItem)
	{
		if (EditingTemplate == null)
		{
			return null;
		}
		return EditingTemplate.LoadContent() as FrameworkElement;
	}
}
