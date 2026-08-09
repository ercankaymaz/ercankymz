using System.ComponentModel;
using System.Diagnostics;
using devDept.Geometry;

namespace devDept.Eyeshot;

public abstract class ClippingPlaneBase
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzd0xzEtI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Plane _0023_003DznksI_0024l2L21KB = Plane.XY;

	[Description("Plane normal.")]
	public Vector3D Normal
	{
		get
		{
			return Plane.AxisZ;
		}
		set
		{
			value.Normalize();
			Plane = new Plane((value * Distance).AsPoint, value);
		}
	}

	[Description("Plane distance from the origin.")]
	public double Distance
	{
		get
		{
			return 0.0 - Plane.Equation.D;
		}
		set
		{
			Plane = new Plane((Plane.AxisZ * value).AsPoint, Plane.AxisZ);
		}
	}

	public Plane Plane
	{
		get
		{
			return _0023_003DznksI_0024l2L21KB;
		}
		set
		{
			_0023_003DznksI_0024l2L21KB = value;
		}
	}

	[Description("Clipping plane status.")]
	public bool Active
	{
		get
		{
			return _0023_003Dzd0xzEtI_003D;
		}
		set
		{
			_0023_003Dzd0xzEtI_003D = value;
		}
	}

	protected ClippingPlaneBase()
	{
	}

	protected ClippingPlaneBase(Vector3D normal, double distance, bool active)
	{
		Plane = new Plane(new Point3D((normal * distance).ToArray()), normal);
		_0023_003Dzd0xzEtI_003D = active;
	}

	protected ClippingPlaneBase(Plane plane, bool active)
	{
		Plane = plane;
		Active = active;
	}

	public double[] Coefficients()
	{
		return new double[4]
		{
			0.0 - Normal.X,
			0.0 - Normal.Y,
			0.0 - Normal.Z,
			Distance
		};
	}
}
