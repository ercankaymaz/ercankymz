using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class AngleMateSurrogate : MateSurrogate
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzCwX4mA970fxgnASt2Q_003D_003D;

	public double Angle
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzCwX4mA970fxgnASt2Q_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzCwX4mA970fxgnASt2Q_003D_003D = value;
		}
	}

	public AngleMateSurrogate(Mate obj)
		: base(obj)
	{
	}

	protected override Mate ConvertToObject()
	{
		return new AngleMate(this);
	}

	protected override void CopyDataFromObject(Mate obj)
	{
		Angle = ((AngleMate)obj).Angle;
		base.CopyDataFromObject(obj);
	}
}
