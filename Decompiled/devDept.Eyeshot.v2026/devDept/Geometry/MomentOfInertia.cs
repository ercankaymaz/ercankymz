namespace devDept.Geometry;

public struct MomentOfInertia
{
	public double Ix;

	public double Iy;

	public double Iz;

	public double Iyx;

	public double Izy;

	public double Izx;

	public double Rx;

	public double Ry;

	public double Rz;

	public static MomentOfInertia operator +(MomentOfInertia a, MomentOfInertia b)
	{
		return new MomentOfInertia
		{
			Ix = a.Ix + b.Ix,
			Iy = a.Iy + b.Iy,
			Iz = a.Iz + b.Iz,
			Rx = a.Rx + b.Rx,
			Ry = a.Ry + b.Ry,
			Rz = a.Rz + b.Rz
		};
	}
}
