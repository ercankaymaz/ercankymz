using System;

namespace Xbim.Ifc4;

internal class Vector : IVectorOrDirection
{
	public int Dim
	{
		get
		{
			return Orientation.Dim;
		}
		set
		{
			Orientation.Dim = value;
		}
	}

	public double[] DirectionRatios
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public Direction Orientation { get; set; }

	public double Magnitude { get; set; }

	public Vector(Direction direction, double v)
	{
		Orientation = direction;
		Magnitude = v;
	}
}
