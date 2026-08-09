using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Xceed.Wpf.AvalonDock.Controls;

public class LayoutGridResizerControl : Thumb
{
	public static readonly DependencyProperty BackgroundWhileDraggingProperty;

	public static readonly DependencyProperty OpacityWhileDraggingProperty;

	public Brush BackgroundWhileDragging
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(BackgroundWhileDraggingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BackgroundWhileDraggingProperty, (object)value);
		}
	}

	public double OpacityWhileDragging
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(OpacityWhileDraggingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OpacityWhileDraggingProperty, (object)value);
		}
	}

	static LayoutGridResizerControl()
	{
		BackgroundWhileDraggingProperty = DependencyProperty.Register("BackgroundWhileDragging", typeof(Brush), typeof(LayoutGridResizerControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Black));
		OpacityWhileDraggingProperty = DependencyProperty.Register("OpacityWhileDragging", typeof(double), typeof(LayoutGridResizerControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.5));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(LayoutGridResizerControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(LayoutGridResizerControl)));
		FrameworkElement.HorizontalAlignmentProperty.OverrideMetadata(typeof(LayoutGridResizerControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)HorizontalAlignment.Stretch, FrameworkPropertyMetadataOptions.AffectsParentMeasure));
		FrameworkElement.VerticalAlignmentProperty.OverrideMetadata(typeof(LayoutGridResizerControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)VerticalAlignment.Stretch, FrameworkPropertyMetadataOptions.AffectsParentMeasure));
		Control.BackgroundProperty.OverrideMetadata(typeof(LayoutGridResizerControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Transparent));
		UIElement.IsHitTestVisibleProperty.OverrideMetadata(typeof(LayoutGridResizerControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, (PropertyChangedCallback)null));
	}
}
