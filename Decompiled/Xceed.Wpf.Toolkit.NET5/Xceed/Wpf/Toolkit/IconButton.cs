using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit;

public class IconButton : Button
{
	public static readonly DependencyProperty IconProperty;

	public static readonly DependencyProperty IconLocationProperty;

	public static readonly DependencyProperty MouseOverBackgroundProperty;

	public static readonly DependencyProperty MouseOverBorderBrushProperty;

	public static readonly DependencyProperty MouseOverForegroundProperty;

	public static readonly DependencyProperty MousePressedBackgroundProperty;

	public static readonly DependencyProperty MousePressedBorderBrushProperty;

	public static readonly DependencyProperty MousePressedForegroundProperty;

	public Image Icon
	{
		get
		{
			return (Image)((DependencyObject)this).GetValue(IconProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IconProperty, (object)value);
		}
	}

	public Location IconLocation
	{
		get
		{
			return (Location)((DependencyObject)this).GetValue(IconLocationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IconLocationProperty, (object)value);
		}
	}

	public Brush MouseOverBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(MouseOverBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MouseOverBackgroundProperty, (object)value);
		}
	}

	public Brush MouseOverBorderBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(MouseOverBorderBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MouseOverBorderBrushProperty, (object)value);
		}
	}

	public Brush MouseOverForeground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(MouseOverForegroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MouseOverForegroundProperty, (object)value);
		}
	}

	public Brush MousePressedBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(MousePressedBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MousePressedBackgroundProperty, (object)value);
		}
	}

	public Brush MousePressedBorderBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(MousePressedBorderBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MousePressedBorderBrushProperty, (object)value);
		}
	}

	public Brush MousePressedForeground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(MousePressedForegroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MousePressedForegroundProperty, (object)value);
		}
	}

	static IconButton()
	{
		IconProperty = DependencyProperty.Register("Icon", typeof(Image), typeof(IconButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null));
		IconLocationProperty = DependencyProperty.Register("IconLocation", typeof(Location), typeof(IconButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Location.Left));
		MouseOverBackgroundProperty = DependencyProperty.Register("MouseOverBackground", typeof(Brush), typeof(IconButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null));
		MouseOverBorderBrushProperty = DependencyProperty.Register("MouseOverBorderBrush", typeof(Brush), typeof(IconButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null));
		MouseOverForegroundProperty = DependencyProperty.Register("MouseOverForeground", typeof(Brush), typeof(IconButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null));
		MousePressedBackgroundProperty = DependencyProperty.Register("MousePressedBackground", typeof(Brush), typeof(IconButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null));
		MousePressedBorderBrushProperty = DependencyProperty.Register("MousePressedBorderBrush", typeof(Brush), typeof(IconButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null));
		MousePressedForegroundProperty = DependencyProperty.Register("MousePressedForeground", typeof(Brush), typeof(IconButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(IconButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(IconButton)));
	}
}
