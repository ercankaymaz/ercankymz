using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit;

public class WatermarkComboBox : ComboBox
{
	public static readonly DependencyProperty WatermarkProperty;

	public static readonly DependencyProperty WatermarkTemplateProperty;

	public static readonly DependencyProperty WatermarkBackgroundProperty;

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

	public Brush WatermarkBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(WatermarkBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WatermarkBackgroundProperty, (object)value);
		}
	}

	static WatermarkComboBox()
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		WatermarkProperty = DependencyProperty.Register("Watermark", typeof(object), typeof(WatermarkComboBox), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		WatermarkTemplateProperty = DependencyProperty.Register("WatermarkTemplate", typeof(DataTemplate), typeof(WatermarkComboBox), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		WatermarkBackgroundProperty = DependencyProperty.RegisterAttached("WatermarkBackground", typeof(Brush), typeof(WatermarkComboBox), new PropertyMetadata((object)null));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(WatermarkComboBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(WatermarkComboBox)));
	}
}
