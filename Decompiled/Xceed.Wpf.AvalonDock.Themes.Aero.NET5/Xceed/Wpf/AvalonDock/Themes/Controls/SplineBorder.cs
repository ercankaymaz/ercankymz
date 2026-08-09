using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Xceed.Wpf.AvalonDock.Themes.Controls;

public class SplineBorder : Control
{
	public static readonly DependencyProperty ThicknessProperty = DependencyProperty.Register("Thickness", typeof(double), typeof(SplineBorder), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(SplineBorder), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register("Stroke", typeof(Brush), typeof(SplineBorder), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty BottomBorderMarginProperty = DependencyProperty.Register("BottomBorderMargin", typeof(double), typeof(SplineBorder), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AffectsRender));

	public double Thickness
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ThicknessProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThicknessProperty, (object)value);
		}
	}

	public Brush Fill
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(FillProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FillProperty, (object)value);
		}
	}

	public Brush Stroke
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(StrokeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StrokeProperty, (object)value);
		}
	}

	public double BottomBorderMargin
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(BottomBorderMarginProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BottomBorderMarginProperty, (object)value);
		}
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		PathGeometry pathGeometry = new PathGeometry();
		PathFigure pathFigure = new PathFigure
		{
			IsFilled = true,
			IsClosed = true
		};
		pathFigure.StartPoint = new Point(base.ActualWidth, 0.0);
		QuadraticBezierSegment value = new QuadraticBezierSegment
		{
			Point1 = new Point(base.ActualWidth * 2.0 / 3.0, 0.0),
			Point2 = new Point(base.ActualWidth / 2.0, base.ActualHeight / 2.0),
			IsStroked = false
		};
		pathFigure.Segments.Add(value);
		QuadraticBezierSegment value2 = new QuadraticBezierSegment
		{
			Point1 = new Point(base.ActualWidth / 3.0, base.ActualHeight),
			Point2 = new Point(0.0, base.ActualHeight),
			IsStroked = false
		};
		pathFigure.Segments.Add(value2);
		pathFigure.Segments.Add(new LineSegment
		{
			Point = new Point(base.ActualWidth, base.ActualHeight),
			IsStroked = false
		});
		pathGeometry.Figures.Add(pathFigure);
		drawingContext.DrawGeometry(Fill, null, pathGeometry);
		PathGeometry pathGeometry2 = new PathGeometry();
		PathFigure pathFigure2 = new PathFigure
		{
			IsFilled = false,
			IsClosed = false
		};
		pathFigure2.StartPoint = new Point(base.ActualWidth, Thickness / 2.0);
		QuadraticBezierSegment value3 = new QuadraticBezierSegment
		{
			Point1 = new Point(base.ActualWidth * 2.0 / 3.0, 0.0),
			Point2 = new Point(base.ActualWidth / 2.0, base.ActualHeight / 2.0)
		};
		pathFigure2.Segments.Add(value3);
		QuadraticBezierSegment value4 = new QuadraticBezierSegment
		{
			Point1 = new Point(base.ActualWidth / 3.0, base.ActualHeight),
			Point2 = new Point(0.0, base.ActualHeight - BottomBorderMargin)
		};
		pathFigure2.Segments.Add(value4);
		pathGeometry2.Figures.Add(pathFigure2);
		drawingContext.DrawGeometry(null, new Pen(Stroke, Thickness), pathGeometry2);
		base.OnRender(drawingContext);
	}
}
