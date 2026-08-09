using System;
using devDept.Geometry;

namespace devDept.Eyeshot;

[Serializable]
internal sealed class Region3D
{
	public Point3D min;

	public Point3D max;

	public Region3D()
	{
		min = new Point3D();
		max = new Point3D();
	}

	public Region3D(Point3D _0023_003Dzolujj1eesFy7, Point3D _0023_003DzD4iGfzJhcPzu)
	{
		min = new Point3D(_0023_003Dzolujj1eesFy7.X, _0023_003Dzolujj1eesFy7.Y, _0023_003Dzolujj1eesFy7.Z);
		max = new Point3D(_0023_003DzD4iGfzJhcPzu.X, _0023_003DzD4iGfzJhcPzu.Y, _0023_003DzD4iGfzJhcPzu.Z);
	}
}
