using System;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class PointNormal : Point3D
{
	public double Nx;

	public double Ny;

	public double Nz;

	public Vector3D Normal
	{
		get
		{
			return new Vector3D(Nx, Ny, Nz);
		}
		set
		{
			Nx = value.X;
			Ny = value.Y;
			Nz = value.Z;
		}
	}

	public PointNormal(double x, double y, double z)
		: base(x, y, z)
	{
		Nx = (Ny = (Nz = 0.0));
	}

	public PointNormal(double x, double y, double z, double nx, double ny, double nz)
		: base(x, y, z)
	{
		Nx = nx;
		Ny = ny;
		Nz = nz;
	}

	protected PointNormal(PointNormal another)
		: base(another)
	{
		Nx = another.Nx;
		Ny = another.Ny;
		Nz = another.Nz;
	}

	public override object Clone()
	{
		return new PointNormal(this);
	}

	public override void TransformBy(Transformation xform)
	{
		base.TransformBy(xform);
		Transformation matrixForNormals = Utility.GetMatrixForNormals(xform);
		Utility._0023_003Dze5abBKgivGEU(matrixForNormals, matrixForNormals.HasScaling, ref Nx, ref Ny, ref Nz);
	}

	public override Point2DSurrogate ConvertToSurrogate()
	{
		return new PointNormalSurrogate(this);
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659080), base.ToString(), Nx, Ny, Nz);
	}

	protected bool Equals(PointNormal other)
	{
		if (Equals((Point3D)other) && Utility.Compare(other.Nx, Nx) == 0 && Utility.Compare(other.Ny, Ny) == 0)
		{
			return Utility.Compare(other.Nz, Nz) == 0;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (this == obj)
		{
			return true;
		}
		if (obj.GetType() != GetType())
		{
			return false;
		}
		return Equals((PointNormal)obj);
	}

	public override int GetHashCode()
	{
		return (((((base.GetHashCode() * 397) ^ Nx.GetHashCode()) * 397) ^ Ny.GetHashCode()) * 397) ^ Nz.GetHashCode();
	}
}
