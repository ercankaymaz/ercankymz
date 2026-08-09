using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.Primitives;

public abstract class ShapeBase : Shape
{
	private Pen _pen;

	internal bool IsPenEmptyOrUndefined
	{
		get
		{
			double strokeThickness = base.StrokeThickness;
			if (base.Stroke != null && !DoubleHelper.IsNaN(strokeThickness))
			{
				return DoubleHelper.AreVirtuallyEqual(0.0, strokeThickness);
			}
			return true;
		}
	}

	protected abstract override Geometry DefiningGeometry { get; }

	static ShapeBase()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		Shape.StrokeDashArrayProperty.OverrideMetadata(typeof(ShapeBase), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnStrokeChanged)));
		Shape.StrokeDashCapProperty.OverrideMetadata(typeof(ShapeBase), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnStrokeChanged)));
		Shape.StrokeDashOffsetProperty.OverrideMetadata(typeof(ShapeBase), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnStrokeChanged)));
		Shape.StrokeEndLineCapProperty.OverrideMetadata(typeof(ShapeBase), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnStrokeChanged)));
		Shape.StrokeLineJoinProperty.OverrideMetadata(typeof(ShapeBase), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnStrokeChanged)));
		Shape.StrokeMiterLimitProperty.OverrideMetadata(typeof(ShapeBase), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnStrokeChanged)));
		Shape.StrokeProperty.OverrideMetadata(typeof(ShapeBase), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnStrokeChanged)));
		Shape.StrokeStartLineCapProperty.OverrideMetadata(typeof(ShapeBase), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnStrokeChanged)));
		Shape.StrokeThicknessProperty.OverrideMetadata(typeof(ShapeBase), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnStrokeChanged)));
	}

	internal virtual Rect GetDefiningGeometryBounds()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return DefiningGeometry.Bounds;
	}

	internal virtual Size GetNaturalSize()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		Rect renderBounds = DefiningGeometry.GetRenderBounds(GetPen());
		return new Size(Math.Max(((Rect)(ref renderBounds)).Right, 0.0), Math.Max(((Rect)(ref renderBounds)).Bottom, 0.0));
	}

	internal Pen GetPen()
	{
		if (IsPenEmptyOrUndefined)
		{
			return null;
		}
		if (_pen == null)
		{
			_pen = MakePen();
		}
		return _pen;
	}

	internal double GetStrokeThickness()
	{
		if (IsPenEmptyOrUndefined)
		{
			return 0.0;
		}
		return Math.Abs(base.StrokeThickness);
	}

	internal bool IsSizeEmptyOrUndefined(Size size)
	{
		if (!DoubleHelper.IsNaN(((Size)(ref size)).Width) && !DoubleHelper.IsNaN(((Size)(ref size)).Height))
		{
			return ((Size)(ref size)).IsEmpty;
		}
		return true;
	}

	private static void OnStrokeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ShapeBase)(object)d)._pen = null;
	}

	private Pen MakePen()
	{
		Pen pen = new Pen();
		pen.Brush = base.Stroke;
		pen.DashCap = base.StrokeDashCap;
		if (base.StrokeDashArray != null || base.StrokeDashOffset != 0.0)
		{
			pen.DashStyle = new DashStyle(base.StrokeDashArray, base.StrokeDashOffset);
		}
		pen.EndLineCap = base.StrokeEndLineCap;
		pen.LineJoin = base.StrokeLineJoin;
		pen.MiterLimit = base.StrokeMiterLimit;
		pen.StartLineCap = base.StrokeStartLineCap;
		pen.Thickness = Math.Abs(base.StrokeThickness);
		return pen;
	}
}
