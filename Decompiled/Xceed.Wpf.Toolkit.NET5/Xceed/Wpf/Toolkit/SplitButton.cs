using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_ActionButton", Type = typeof(Button))]
public class SplitButton : DropDownButton
{
	private const string PART_ActionButton = "PART_ActionButton";

	public static readonly DependencyProperty DropDownTooltipProperty;

	public object DropDownTooltip
	{
		get
		{
			return ((DependencyObject)this).GetValue(DropDownTooltipProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropDownTooltipProperty, value);
		}
	}

	static SplitButton()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		DropDownTooltipProperty = DependencyProperty.Register("DropDownTooltip", typeof(object), typeof(SplitButton), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnDropDownTooltipChanged)));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(SplitButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(SplitButton)));
	}

	private static void OnDropDownTooltipChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is SplitButton splitButton)
		{
			splitButton.OnDropDownTooltipChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnDropDownTooltipChanged(object oldValue, object newValue)
	{
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		base.Button = GetTemplateChild("PART_ActionButton") as Button;
	}
}
