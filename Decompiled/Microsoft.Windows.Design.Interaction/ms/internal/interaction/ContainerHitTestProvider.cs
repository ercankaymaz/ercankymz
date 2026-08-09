using System.Windows;
using System.Windows.Media;
using MS.Internal.Transforms;

namespace MS.Internal.Interaction;

internal class ContainerHitTestProvider : HitTestProvider
{
	public override PointHitTestResult HitTestPoint(VisualHitTestArgs args)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		Rect childLayoutBounds = args.ChildLayoutBounds;
		if (((Rect)(ref childLayoutBounds)).Contains(args.ChildPoint))
		{
			return new PointHitTestResult(args.ChildVisual, args.ChildPoint);
		}
		return null;
	}

	public override GeometryHitTestResult HitTestGeometry(VisualHitTestArgs args)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		Transform transformToAncestor = TransformUtil.GetTransformToAncestor((DependencyObject)(object)args.ChildVisual, args.SourceAncestor);
		Rect val = ((GeneralTransform)transformToAncestor).TransformBounds(args.ChildLayoutBounds);
		Rect bounds = args.SourceHitGeometry.Bounds;
		if (!args.SourceHitGeometry.FillContains((Geometry)new RectangleGeometry(val)))
		{
			if (!((Rect)(ref val)).Contains(bounds))
			{
				if (!((Rect)(ref bounds)).IntersectsWith(val))
				{
					return new GeometryHitTestResult(args.ChildVisual, (IntersectionDetail)1);
				}
				return new GeometryHitTestResult(args.ChildVisual, (IntersectionDetail)4);
			}
			return new GeometryHitTestResult(args.ChildVisual, (IntersectionDetail)3);
		}
		return new GeometryHitTestResult(args.ChildVisual, (IntersectionDetail)2);
	}
}
