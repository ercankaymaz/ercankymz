using System.Windows;

namespace Xceed.Wpf.Toolkit;

public class WatermarkTextBox : AutoSelectTextBox
{
	public static readonly DependencyProperty KeepWatermarkOnGotFocusProperty;

	public static readonly DependencyProperty WatermarkProperty;

	public static readonly DependencyProperty WatermarkTemplateProperty;

	public bool KeepWatermarkOnGotFocus
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(KeepWatermarkOnGotFocusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(KeepWatermarkOnGotFocusProperty, (object)value);
		}
	}

	public object Watermark
	{
		get
		{
			return ((DependencyObject)this).GetValue(WatermarkProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WatermarkProperty, value);
		}
	}

	public DataTemplate WatermarkTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(WatermarkTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WatermarkTemplateProperty, (object)value);
		}
	}

	static WatermarkTextBox()
	{
		KeepWatermarkOnGotFocusProperty = DependencyProperty.Register("KeepWatermarkOnGotFocus", typeof(bool), typeof(WatermarkTextBox), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));
		WatermarkProperty = DependencyProperty.Register("Watermark", typeof(object), typeof(WatermarkTextBox), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		WatermarkTemplateProperty = DependencyProperty.Register("WatermarkTemplate", typeof(DataTemplate), typeof(WatermarkTextBox), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(WatermarkTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(WatermarkTextBox)));
	}
}
