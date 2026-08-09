using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit.Core;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

public sealed class Pie : ShapeBase
{
	private enum CacheBits
	{
		IsUpdatingEndAngle = 1,
		IsUpdatingMode = 2,
		IsUpdatingSlice = 4,
		IsUpdatingStartAngle = 8,
		IsUpdatingSweepDirection = 0x10
	}

	public static readonly DependencyProperty EndAngleProperty;

	public static readonly DependencyProperty ModeProperty;

	public static readonly DependencyProperty SliceProperty;

	public static readonly DependencyProperty StartAngleProperty;

	public static readonly DependencyProperty SweepDirectionProperty;

	private Rect _rect = Rect.Empty;

	private BitVector32 _cacheBits = new BitVector32(0);

	public double EndAngle
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(EndAngleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EndAngleProperty, (object)value);
		}
	}

	public PieMode Mode
	{
		get
		{
			return (PieMode)((DependencyObject)this).GetValue(ModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ModeProperty, (object)value);
		}
	}

	public double Slice
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(SliceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SliceProperty, (object)value);
		}
	}

	public double StartAngle
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(StartAngleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StartAngleProperty, (object)value);
		}
	}

	public SweepDirection SweepDirection
	{
		get
		{
			return (SweepDirection)((DependencyObject)this).GetValue(SweepDirectionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SweepDirectionProperty, (object)value);
		}
	}

	public override Transform GeometryTransform => Transform.Identity;

	public override Geometry RenderedGeometry => DefiningGeometry;

	protected override Geometry DefiningGeometry
	{
		get
		{
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			double slice = Slice;
			if (((Rect)(ref _rect)).IsEmpty || slice <= 0.0)
			{
				return Geometry.Empty;
			}
			if (slice >= 1.0)
			{
				return new EllipseGeometry(_rect);
			}
			double num = ((SweepDirection == SweepDirection.Clockwise) ? 1.0 : (-1.0));
			double startAngle = StartAngle;
			Point point = EllipseHelper.PointOfRadialIntersection(_rect, startAngle);
			Point point2 = EllipseHelper.PointOfRadialIntersection(_rect, startAngle + num * slice * 360.0);
			PathSegmentCollection pathSegmentCollection = new PathSegmentCollection();
			pathSegmentCollection.Add(new LineSegment(point, isStroked: true));
			ArcSegment arcSegment = new ArcSegment();
			arcSegment.Point = point2;
			arcSegment.Size = new Size(((Rect)(ref _rect)).Width / 2.0, ((Rect)(ref _rect)).Height / 2.0);
			arcSegment.IsLargeArc = slice > 0.5;
			arcSegment.SweepDirection = SweepDirection;
			pathSegmentCollection.Add(arcSegment);
			return new PathGeometry(new PathFigureCollection
			{
				new PathFigure(RectHelper.Center(_rect), pathSegmentCollection, closed: true)
			});
		}
	}

	private bool IsUpdatingEndAngle
	{
		get
		{
			return _cacheBits[1];
		}
		set
		{
			_cacheBits[1] = value;
		}
	}

	private bool IsUpdatingMode
	{
		get
		{
			return _cacheBits[2];
		}
		set
		{
			_cacheBits[2] = value;
		}
	}

	private bool IsUpdatingSlice
	{
		get
		{
			return _cacheBits[4];
		}
		set
		{
			_cacheBits[4] = value;
		}
	}

	private bool IsUpdatingStartAngle
	{
		get
		{
			return _cacheBits[8];
		}
		set
		{
			_cacheBits[8] = value;
		}
	}

	private bool IsUpdatingSweepDirection
	{
		get
		{
			return _cacheBits[16];
		}
		set
		{
			_cacheBits[16] = value;
		}
	}

	static Pie()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0049: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00d6: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_0171: Expected O, but got Unknown
		EndAngleProperty = DependencyProperty.Register("EndAngle", typeof(double), typeof(Pie), (PropertyMetadata)(object)new FrameworkPropertyMetadata(360.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnEndAngleChanged), new CoerceValueCallback(CoerceEndAngleValue)));
		ModeProperty = DependencyProperty.Register("Mode", typeof(PieMode), typeof(Pie), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)PieMode.Manual, new PropertyChangedCallback(OnModeChanged)));
		SliceProperty = DependencyProperty.Register("Slice", typeof(double), typeof(Pie), (PropertyMetadata)(object)new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnSliceChanged), new CoerceValueCallback(CoerceSliceValue)), new ValidateValueCallback(ValidateSlice));
		StartAngleProperty = DependencyProperty.Register("StartAngle", typeof(double), typeof(Pie), (PropertyMetadata)(object)new FrameworkPropertyMetadata(360.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnStartAngleChanged)));
		SweepDirectionProperty = DependencyProperty.Register("SweepDirection", typeof(SweepDirection), typeof(Pie), (PropertyMetadata)(object)new FrameworkPropertyMetadata(SweepDirection.Clockwise, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OnSweepDirectionChanged), new CoerceValueCallback(CoerceSweepDirectionValue)));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(Pie), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(Pie)));
		Shape.StretchProperty.OverrideMetadata(typeof(Pie), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Stretch.Fill));
		Shape.StrokeLineJoinProperty.OverrideMetadata(typeof(Pie), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)PenLineJoin.Round));
	}

	private static void OnEndAngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Pie)(object)d).OnEndAngleChanged(e);
	}

	private void OnEndAngleChanged(DependencyPropertyChangedEventArgs e)
	{
		if (IsUpdatingEndAngle)
		{
			return;
		}
		if (!IsUpdatingStartAngle && !IsUpdatingSlice && !IsUpdatingSweepDirection && Mode == PieMode.Slice)
		{
			throw new InvalidOperationException(ErrorMessages.GetMessage("EndAngleCannotBeSetDirectlyInSlice"));
		}
		IsUpdatingEndAngle = true;
		try
		{
			if (Mode == PieMode.EndAngle)
			{
				((DependencyObject)this).CoerceValue(SweepDirectionProperty);
			}
			((DependencyObject)this).CoerceValue(SliceProperty);
		}
		finally
		{
			IsUpdatingEndAngle = false;
		}
	}

	private static object CoerceEndAngleValue(DependencyObject d, object value)
	{
		Pie pie = (Pie)(object)d;
		if (pie.IsUpdatingSlice || pie.IsUpdatingSweepDirection || (pie.IsUpdatingStartAngle && pie.Mode == PieMode.Slice))
		{
			double num = pie.StartAngle + ((pie.SweepDirection == SweepDirection.Clockwise) ? 1.0 : (-1.0)) * pie.Slice * 360.0;
			if (!DoubleHelper.AreVirtuallyEqual((double)value, num))
			{
				value = num;
			}
		}
		return value;
	}

	private static void OnModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Pie)(object)d).OnModeChanged(e);
	}

	private void OnModeChanged(DependencyPropertyChangedEventArgs e)
	{
		if (IsUpdatingMode)
		{
			return;
		}
		IsUpdatingMode = true;
		try
		{
			if (Mode == PieMode.EndAngle)
			{
				((DependencyObject)this).CoerceValue(SweepDirectionProperty);
			}
		}
		finally
		{
			IsUpdatingMode = false;
		}
	}

	private static void OnSliceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Pie)(object)d).OnSliceChanged(e);
	}

	private void OnSliceChanged(DependencyPropertyChangedEventArgs e)
	{
		if (IsUpdatingSlice)
		{
			return;
		}
		if (!IsUpdatingStartAngle && !IsUpdatingEndAngle && !IsUpdatingSweepDirection && Mode == PieMode.EndAngle)
		{
			throw new InvalidOperationException(ErrorMessages.GetMessage("SliceCannotBeSetDirectlyInEndAngle"));
		}
		IsUpdatingSlice = true;
		try
		{
			if (!IsUpdatingStartAngle && !IsUpdatingEndAngle && (Mode != PieMode.Manual || !IsUpdatingSweepDirection))
			{
				((DependencyObject)this).CoerceValue(EndAngleProperty);
			}
		}
		finally
		{
			IsUpdatingSlice = false;
		}
	}

	private static object CoerceSliceValue(DependencyObject d, object value)
	{
		Pie pie = (Pie)(object)d;
		if (pie.IsUpdatingEndAngle || pie.IsUpdatingStartAngle || pie.IsUpdatingSweepDirection)
		{
			double num = Math.Max(-360.0, Math.Min(360.0, pie.EndAngle - pie.StartAngle)) / ((pie.SweepDirection == SweepDirection.Clockwise) ? 360.0 : (-360.0));
			double num2 = (DoubleHelper.AreVirtuallyEqual(num, 0.0) ? 0.0 : ((num < 0.0) ? (num + 1.0) : num));
			if (!DoubleHelper.AreVirtuallyEqual((double)value, num2))
			{
				value = num2;
			}
		}
		return value;
	}

	private static bool ValidateSlice(object value)
	{
		double num = (double)value;
		if (num < 0.0 || num > 1.0 || DoubleHelper.IsNaN(num))
		{
			throw new ArgumentException(ErrorMessages.GetMessage("SliceOOR"));
		}
		return true;
	}

	private static void OnStartAngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Pie)(object)d).OnStartAngleChanged(e);
	}

	private void OnStartAngleChanged(DependencyPropertyChangedEventArgs e)
	{
		if (IsUpdatingStartAngle)
		{
			return;
		}
		IsUpdatingStartAngle = true;
		try
		{
			switch (Mode)
			{
			case PieMode.Manual:
				((DependencyObject)this).CoerceValue(SliceProperty);
				break;
			case PieMode.EndAngle:
				((DependencyObject)this).CoerceValue(SweepDirectionProperty);
				((DependencyObject)this).CoerceValue(SliceProperty);
				break;
			case PieMode.Slice:
				((DependencyObject)this).CoerceValue(EndAngleProperty);
				break;
			}
		}
		finally
		{
			IsUpdatingStartAngle = false;
		}
	}

	private static void OnSweepDirectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Pie)(object)d).OnSweepDirectionChanged(e);
	}

	private void OnSweepDirectionChanged(DependencyPropertyChangedEventArgs e)
	{
		if (IsUpdatingSweepDirection)
		{
			return;
		}
		IsUpdatingSweepDirection = true;
		try
		{
			if (Mode == PieMode.Slice)
			{
				((DependencyObject)this).CoerceValue(EndAngleProperty);
			}
			else
			{
				((DependencyObject)this).CoerceValue(SliceProperty);
			}
		}
		finally
		{
			IsUpdatingSweepDirection = false;
		}
	}

	private static object CoerceSweepDirectionValue(DependencyObject d, object value)
	{
		Pie pie = (Pie)(object)d;
		if (pie.IsUpdatingEndAngle || pie.IsUpdatingStartAngle || pie.IsUpdatingMode)
		{
			value = ((!DoubleHelper.AreVirtuallyEqual(pie.StartAngle, pie.EndAngle)) ? ((object)((!(pie.EndAngle < pie.StartAngle)) ? SweepDirection.Clockwise : SweepDirection.Counterclockwise)) : ((object)pie.SweepDirection));
		}
		return value;
	}

	internal override Size GetNaturalSize()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		double strokeThickness = GetStrokeThickness();
		return new Size(strokeThickness, strokeThickness);
	}

	internal override Rect GetDefiningGeometryBounds()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return _rect;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		double strokeThickness = GetStrokeThickness();
		double num = strokeThickness / 2.0;
		_rect = new Rect(num, num, Math.Max(0.0, ((Size)(ref finalSize)).Width - strokeThickness), Math.Max(0.0, ((Size)(ref finalSize)).Height - strokeThickness));
		switch (base.Stretch)
		{
		case Stretch.None:
		{
			ref Rect rect = ref _rect;
			double width = (((Rect)(ref _rect)).Height = 0.0);
			((Rect)(ref rect)).Width = width;
			break;
		}
		case Stretch.Uniform:
			if (((Rect)(ref _rect)).Width > ((Rect)(ref _rect)).Height)
			{
				((Rect)(ref _rect)).Width = ((Rect)(ref _rect)).Height;
			}
			else
			{
				((Rect)(ref _rect)).Height = ((Rect)(ref _rect)).Width;
			}
			break;
		case Stretch.UniformToFill:
			if (((Rect)(ref _rect)).Width < ((Rect)(ref _rect)).Height)
			{
				((Rect)(ref _rect)).Width = ((Rect)(ref _rect)).Height;
			}
			else
			{
				((Rect)(ref _rect)).Height = ((Rect)(ref _rect)).Width;
			}
			break;
		}
		return finalSize;
	}

	protected override Size MeasureOverride(Size constraint)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		if (base.Stretch == Stretch.UniformToFill)
		{
			double width = ((Size)(ref constraint)).Width;
			double height = ((Size)(ref constraint)).Height;
			if (double.IsInfinity(width) && double.IsInfinity(height))
			{
				return GetNaturalSize();
			}
			width = ((!double.IsInfinity(width) && !double.IsInfinity(height)) ? Math.Max(width, height) : Math.Min(width, height));
			return new Size(width, width);
		}
		return GetNaturalSize();
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		if (!((Rect)(ref _rect)).IsEmpty)
		{
			Pen pen = GetPen();
			drawingContext.DrawGeometry(base.Fill, pen, RenderedGeometry);
		}
	}
}
