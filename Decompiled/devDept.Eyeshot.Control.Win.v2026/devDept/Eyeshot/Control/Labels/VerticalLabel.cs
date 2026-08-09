using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Eyeshot.Control.Labels;

public class VerticalLabel : StackedLabel
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static Bitmap _0023_003DzkQLiFbXzRyCees_0024lDg_003D_003D = _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzclowSAKcchvX();

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

	public VerticalLabel(SketchCurve curve)
		: base(Icon, curve)
	{
	}
}
