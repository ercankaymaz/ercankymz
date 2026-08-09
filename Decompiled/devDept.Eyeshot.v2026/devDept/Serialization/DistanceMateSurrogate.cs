using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class DistanceMateSurrogate : MateSurrogate
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dzrkn4XJZcShE03JOG_0024Q_003D_003D;

	public double Distance
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzrkn4XJZcShE03JOG_0024Q_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzrkn4XJZcShE03JOG_0024Q_003D_003D = value;
		}
	}

	public DistanceMateSurrogate(Mate obj)
		: base(obj)
	{
	}

	protected override Mate ConvertToObject()
	{
		return new DistanceMate(this);
	}

	protected override void CopyDataFromObject(Mate obj)
	{
		Distance = ((DistanceMate)obj).Distance;
		base.CopyDataFromObject(obj);
	}
}
