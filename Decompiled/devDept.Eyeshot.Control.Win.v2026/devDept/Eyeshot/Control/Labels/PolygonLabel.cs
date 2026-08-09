using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Eyeshot.Control.Labels;

public class PolygonLabel : StackedLabel
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static Bitmap _0023_003DzkQLiFbXzRyCees_0024lDg_003D_003D = _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzMPEs0KmRLlkI9jF1zw_003D_003D();

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

	public PolygonLabel(SketchCurve curve)
		: base(Icon, curve)
	{
	}

	public override void UpdateAnchorPoint(Transformation accumulatedTransform = null)
	{
		if (_0023_003DzFQoJmsjWPpodV7yemw_003D_003D != null)
		{
			base.AnchorPoint = ((PolygonConstraint)_0023_003Dz6pzz0jpYcSyePZtY2g_003D_003D()).Center.Position;
			if (accumulatedTransform != null)
			{
				base.AnchorPoint.TransformBy(accumulatedTransform);
			}
		}
	}
}
