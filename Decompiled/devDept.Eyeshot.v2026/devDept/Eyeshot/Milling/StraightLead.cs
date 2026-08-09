using System.Diagnostics;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public class StraightLead : Lead
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly double _0023_003Dz3bgAkHE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly bool _0023_003Dzpg2v1bCBDRJr;

	public StraightLead(double length, bool perp = true)
	{
		_0023_003Dz3bgAkHE_003D = length;
		_0023_003Dzpg2v1bCBDRJr = perp;
	}

	public override void Init(double tolerance, bool leadIn)
	{
		Point3D first = Point3D.Origin;
		Point3D second = (_0023_003Dzpg2v1bCBDRJr ? new Point3D(0.0, _0023_003Dz3bgAkHE_003D) : new Point3D(leadIn ? (0.0 - _0023_003Dz3bgAkHE_003D) : _0023_003Dz3bgAkHE_003D, 0.0));
		if (leadIn)
		{
			Utility.Swap(ref first, ref second);
		}
		Motions = new Toolpath.Motion[1]
		{
			new Toolpath.LinearMotion(first, second, motionType.G01, 0.0, 0.0, string.Empty)
			{
				Approach = approachType.Lead
			}
		};
		base.Init(tolerance, leadIn);
	}
}
