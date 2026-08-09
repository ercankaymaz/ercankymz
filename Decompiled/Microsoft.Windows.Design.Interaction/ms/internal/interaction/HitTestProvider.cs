using System.Windows.Media;

namespace MS.Internal.Interaction;

internal class HitTestProvider
{
	public virtual PointHitTestResult HitTestPoint(VisualHitTestArgs args)
	{
		return null;
	}

	public virtual GeometryHitTestResult HitTestGeometry(VisualHitTestArgs args)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		return new GeometryHitTestResult(args.ChildVisual, (IntersectionDetail)0);
	}
}
