using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Eyeshot.Control.Labels;

public class TangentLabel : StackedLabel
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static Bitmap _0023_003DzkQLiFbXzRyCees_0024lDg_003D_003D = _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzbZ9bvVMMB5rX();

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

	public TangentLabel(SketchCurve curve)
		: base(Icon, curve)
	{
	}

	public override void UpdateAnchorPoint(Transformation accumulatedTransformation = null)
	{
		((TangentConstraint)_0023_003Dz6pzz0jpYcSyePZtY2g_003D_003D()).GetTangentParameters(out var s, out var _);
		base.AnchorPoint = _0023_003DzFQoJmsjWPpodV7yemw_003D_003D.PointAt(s);
		if (accumulatedTransformation != null)
		{
			base.AnchorPoint.TransformBy(accumulatedTransformation);
		}
	}
}
