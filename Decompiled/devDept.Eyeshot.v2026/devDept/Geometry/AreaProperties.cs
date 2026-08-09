using System.Collections.Generic;

namespace devDept.Geometry;

public class AreaProperties : AreaAndVolume
{
	public double Area => m;

	public override Point3D Centroid
	{
		get
		{
			if (m != 0.0)
			{
				double num = 1.0 / (6.0 * m);
				return new Point3D(Cx * num, Cy * num, Cz * num) + meanPoint;
			}
			return null;
		}
	}

	public AreaProperties(Point3D refPoint = null)
		: base(refPoint)
	{
	}

	protected override double GetMass()
	{
		return Area;
	}

	public void Add(IList<Point3D> vList)
	{
		for (int i = 0; i < vList.Count - 1; i++)
		{
			_0023_003DzN0mGQl5K3Qbe(vList[i] - meanPoint, vList[i + 1] - meanPoint);
		}
	}

	private void _0023_003DzN0mGQl5K3Qbe(Point3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003DzjdeMMkk_003D)
	{
		double num = _0023_003DzFj_0024IqDQ_003D.X;
		double num2 = _0023_003DzFj_0024IqDQ_003D.Y;
		double num3 = _0023_003DzjdeMMkk_003D.X;
		double num4 = _0023_003DzjdeMMkk_003D.Y;
		double num5 = 0.0;
		double num6 = num * (num4 - num5) + num3 * (num5 - num2) + 0.0 * (num2 - num4);
		m += num6 / 2.0;
		double num7 = _0023_003DzFj_0024IqDQ_003D.X;
		double num8 = _0023_003DzFj_0024IqDQ_003D.Y;
		double num9 = _0023_003DzFj_0024IqDQ_003D.Z;
		double num10 = _0023_003DzjdeMMkk_003D.X;
		double num11 = _0023_003DzjdeMMkk_003D.Y;
		double num12 = _0023_003DzjdeMMkk_003D.Z;
		double num13 = num7 + num10;
		Cx += num6 * num13;
		double num14 = num8 + num11;
		Cy += num6 * num14;
		double num15 = num9 + num12;
		Cz += num6 * num15;
		x += num6 * (num7 + num10);
		y += num6 * (num8 + num11);
		z += num6 * (num9 + num12);
		xx += num6 * (num7 * num7 + num7 * num10 + num10 * num10);
		yy += num6 * (num8 * num8 + num8 * num11 + num11 * num11);
		zz += num6 * (num9 * num9 + num9 * num12 + num12 * num12);
		yx += num6 * (num7 * num11 + 2.0 * num7 * num8 + 2.0 * num10 * num11 + num10 * num8);
		zx += num6 * (num7 * num12 + 2.0 * num7 * num9 + 2.0 * num10 * num12 + num10 * num9);
		zy += num6 * (num8 * num12 + 2.0 * num8 * num9 + 2.0 * num11 * num12 + num11 * num9);
	}

	protected override void AddTriangleContribution(Point3D p1, Point3D p2, Point3D p3)
	{
		double num = Utility.TriangleArea(p1, p2, p3);
		m += num;
		double num2 = p1.X;
		double num3 = p1.Y;
		double num4 = p1.Z;
		double num5 = p2.X;
		double num6 = p2.Y;
		double num7 = p2.Z;
		double num8 = p3.X;
		double num9 = p3.Y;
		double num10 = p3.Z;
		double num11 = num2 + num5 + num8;
		Cx += 2.0 * num * num11;
		double num12 = num3 + num6 + num9;
		Cy += 2.0 * num * num12;
		double num13 = num4 + num7 + num10;
		Cz += 2.0 * num * num13;
		x += 2.0 * num * (num2 + num5 + num8);
		y += 2.0 * num * (num3 + num6 + num9);
		z += 2.0 * num * (num4 + num7 + num10);
		xx += num * (num2 * num2 + num5 * num5 + num8 * num8 + num11 * num11);
		yy += num * (num3 * num3 + num6 * num6 + num9 * num9 + num12 * num12);
		zz += num * (num4 * num4 + num7 * num7 + num10 * num10 + num13 * num13);
		yx += 2.0 * num * (num3 * num2 + num6 * num5 + num9 * num8 + num12 * num11);
		zx += 2.0 * num * (num4 * num2 + num7 * num5 + num10 * num8 + num13 * num11);
		zy += 2.0 * num * (num4 * num3 + num7 * num6 + num10 * num9 + num13 * num12);
	}

	public void GetResults(double a, Point3D C, out double X, out double Y, out double Z, out double XX, out double YY, out double ZZ, out double XY, out double ZX, out double YZ, out MomentOfInertia world, out MomentOfInertia centroid)
	{
		double num = 1.0 / 6.0;
		X = x * num + m * meanPoint.X;
		Y = y * num + m * meanPoint.Y;
		Z = z * num + m * meanPoint.Z;
		num = 1.0 / 12.0;
		XX = xx * num + 2.0 * m * (meanPoint.X * C.X) - m * (meanPoint.X * meanPoint.X);
		YY = yy * num + 2.0 * m * (meanPoint.Y * C.Y) - m * (meanPoint.Y * meanPoint.Y);
		ZZ = zz * num + 2.0 * m * (meanPoint.Z * C.Z) - m * (meanPoint.Z * meanPoint.Z);
		XY = yx * num / 2.0 + m * (meanPoint.X * C.Y + meanPoint.Y * C.X) - m * (meanPoint.X * meanPoint.Y);
		ZX = zx * num / 2.0 + m * (meanPoint.X * C.Z + meanPoint.Z * C.X) - m * (meanPoint.X * meanPoint.Z);
		YZ = zy * num / 2.0 + m * (meanPoint.Z * C.Y + meanPoint.Y * C.Z) - m * (meanPoint.Z * meanPoint.Y);
		world = GetResultAboutPoint(m, C - meanPoint, Point3D.Origin - meanPoint, num);
		centroid = GetResultAboutPoint(m, C - meanPoint, C - meanPoint, num);
	}
}
