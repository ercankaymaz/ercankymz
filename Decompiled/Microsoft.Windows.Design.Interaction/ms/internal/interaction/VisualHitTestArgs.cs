using System;
using System.Windows;
using System.Windows.Media;
using MS.Internal.Transforms;

namespace MS.Internal.Interaction;

internal class VisualHitTestArgs
{
	private Visual _sourceAncestor;

	private Visual _child;

	private HitTestParameters _hitTestParameters;

	private Point? _childPoint;

	public Visual ChildVisual => _child;

	public Visual SourceAncestor => _sourceAncestor;

	public Point ChildPoint
	{
		get
		{
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			if (!_childPoint.HasValue)
			{
				HitTestParameters hitTestParameters = _hitTestParameters;
				PointHitTestParameters val = (PointHitTestParameters)(object)((hitTestParameters is PointHitTestParameters) ? hitTestParameters : null);
				if (val != null)
				{
					Transform val2 = TransformUtil.SafeInvert(TransformUtil.GetSelectionFrameTransformToParentVisual((DependencyObject)(object)_child, _sourceAncestor));
					_childPoint = ((GeneralTransform)val2).Transform(val.HitPoint);
				}
			}
			return _childPoint.Value;
		}
	}

	public HitTestParameters HitTestParameters => _hitTestParameters;

	public Rect ChildLayoutBounds
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			Rect selectionFrameBounds = ElementUtilities.GetSelectionFrameBounds((DependencyObject)(object)_child);
			return new Rect(default(Point), ((Rect)(ref selectionFrameBounds)).Size);
		}
	}

	public Geometry SourceHitGeometry
	{
		get
		{
			HitTestParameters hitTestParameters = _hitTestParameters;
			GeometryHitTestParameters val = (GeometryHitTestParameters)(object)((hitTestParameters is GeometryHitTestParameters) ? hitTestParameters : null);
			if (val != null)
			{
				return val.HitGeometry;
			}
			return null;
		}
	}

	public VisualHitTestArgs(Visual sourceAncestor, Visual child, Point parentPoint)
		: this(sourceAncestor, child, (HitTestParameters)new PointHitTestParameters(parentPoint))
	{
	}//IL_0003: Unknown result type (might be due to invalid IL or missing references)
	//IL_0004: Unknown result type (might be due to invalid IL or missing references)
	//IL_000e: Expected O, but got Unknown


	public VisualHitTestArgs(Visual sourceAncestor, Visual child, HitTestParameters parameters)
	{
		if (sourceAncestor == null)
		{
			throw new ArgumentNullException("sourceAncestor");
		}
		if (child == null)
		{
			throw new ArgumentNullException("child");
		}
		_sourceAncestor = sourceAncestor;
		_child = child;
		_hitTestParameters = parameters;
	}

	internal void UpdateChild(DependencyObject child)
	{
		_child = (Visual)(object)((child is Visual) ? child : null);
		_childPoint = null;
	}
}
