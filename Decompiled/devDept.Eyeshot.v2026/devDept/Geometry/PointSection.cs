using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace devDept.Geometry;

public class PointSection : Point3D
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dzm7Lenv5FW9QvpdCr41tbjm0_003D;

	public double plotValue
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzm7Lenv5FW9QvpdCr41tbjm0_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzm7Lenv5FW9QvpdCr41tbjm0_003D = value;
		}
	}

	public PointSection(double x, double y, double z, double plotValue)
		: base(x, y, z)
	{
		this.plotValue = plotValue;
	}

	public PointSection(PointSection another)
		: base(another.X, another.Y, another.Z)
	{
		plotValue = another.plotValue;
	}

	public override object Clone()
	{
		return new PointSection(this);
	}
}
