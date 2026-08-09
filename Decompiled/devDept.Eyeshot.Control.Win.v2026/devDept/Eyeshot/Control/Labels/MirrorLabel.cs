using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Eyeshot.Control.Labels;

public class MirrorLabel : StackedLabel
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static Bitmap _0023_003DzkQLiFbXzRyCees_0024lDg_003D_003D = _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003Dzt4x8nggMXnt9yD6pCg_003D_003D();

	public static Bitmap Icon
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzkQLiFbXzRyCees_0024lDg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzkQLiFbXzRyCees_0024lDg_003D_003D = value;
		}
	}

	public MirrorLabel(SketchCurve curve)
		: base(Icon, curve)
	{
	}

	public override void UpdateAnchorPoint(Transformation accumulatedTransform = null)
	{
		if (_0023_003DzFQoJmsjWPpodV7yemw_003D_003D != null)
		{
			if (_0023_003DzFQoJmsjWPpodV7yemw_003D_003D is SketchCircle sketchCircle)
			{
				base.AnchorPoint = sketchCircle.Center.Position;
			}
			else if (_0023_003DzFQoJmsjWPpodV7yemw_003D_003D is SketchEllipse sketchEllipse)
			{
				base.AnchorPoint = sketchEllipse.Center.Position;
			}
			else
			{
				base.AnchorPoint = _0023_003DzFQoJmsjWPpodV7yemw_003D_003D.PointAt(0.5);
			}
			if (accumulatedTransform != null)
			{
				base.AnchorPoint.TransformBy(accumulatedTransform);
			}
		}
	}
}
