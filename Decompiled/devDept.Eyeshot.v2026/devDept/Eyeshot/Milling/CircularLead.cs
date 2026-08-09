using System;
using System.Diagnostics;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public class CircularLead : Lead
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Plane _0023_003DznksI_0024l2L21KB;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly double _0023_003Dzrs3b507aH5yJ;

	public CircularLead(double radius)
	{
		_0023_003DznksI_0024l2L21KB = Plane.XY;
		_0023_003DznksI_0024l2L21KB.Translate(0.0, radius);
		_0023_003Dzrs3b507aH5yJ = radius;
		BuildAsLollipop(radius, 0.0);
	}

	public override void Init(double tolerance, bool leadIn)
	{
		Toolpath.CircularMotion circularMotion = ((!leadIn) ? new Toolpath.CircularMotion(_0023_003DznksI_0024l2L21KB, _0023_003Dzrs3b507aH5yJ, new Interval(4.71238898038469, Math.PI * 2.0), motionType.G03, 0.0, 0.0, string.Empty)
		{
			Approach = approachType.Lead
		} : new Toolpath.CircularMotion(_0023_003DznksI_0024l2L21KB, _0023_003Dzrs3b507aH5yJ, new Interval(Math.PI, 4.71238898038469), motionType.G03, 0.0, 0.0, string.Empty)
		{
			Approach = approachType.Lead
		});
		Motions = new Toolpath.Motion[1] { circularMotion };
		base.Init(tolerance, leadIn);
	}
}
