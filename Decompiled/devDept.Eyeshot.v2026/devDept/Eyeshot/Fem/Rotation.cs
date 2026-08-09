using System;
using devDept.Serialization;

namespace devDept.Eyeshot.Fem;

[Serializable]
internal class Rotation
{
	private double[,] matrix;

	public double[,] Matrix
	{
		get
		{
			return matrix;
		}
		set
		{
			matrix = value;
		}
	}

	protected internal Rotation(double[,] matrix)
	{
		Matrix = matrix;
	}

	public virtual FemRotationSurrogate ConvertToSurrogate()
	{
		return new FemRotationSurrogate(this);
	}
}
