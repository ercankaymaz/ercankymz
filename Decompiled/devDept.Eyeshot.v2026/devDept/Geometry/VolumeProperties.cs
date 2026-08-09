namespace devDept.Geometry;

public class VolumeProperties : AreaAndVolume
{
	public double Volume => m / 6.0;

	public override Point3D Centroid
	{
		get
		{
			if (m != 0.0)
			{
				double num = 1.0 / (4.0 * m);
				return new Point3D(Cx * num, Cy * num, Cz * num) + meanPoint;
			}
			return null;
		}
	}

	public VolumeProperties(Point3D refPoint = null)
		: base(refPoint)
	{
	}

	protected override double GetMass()
	{
		return Volume;
	}

	protected override void AddTriangleContribution(Point3D p1, Point3D p2, Point3D p3)
	{
		double num = p1.X;
		double num2 = p1.Y;
		double num3 = p1.Z;
		double num4 = p2.X;
		double num5 = p2.Y;
		double num6 = p2.Z;
		double num7 = p3.X;
		double num8 = p3.Y;
		double num9 = p3.Z;
		double num10 = num * num5 * num9 + num2 * num6 * num7 + num4 * num8 * num3 - (num7 * num5 * num3 + num4 * num2 * num9 + num8 * num6 * num);
		m += num10;
		double num11 = num + num4 + num7;
		Cx += num10 * num11;
		double num12 = num2 + num5 + num8;
		Cy += num10 * num12;
		double num13 = num3 + num6 + num9;
		Cz += num10 * num13;
		x += num10 * (num + num4 + num7);
		y += num10 * (num2 + num5 + num8);
		z += num10 * (num3 + num6 + num9);
		xx += num10 * (num * num + num4 * num4 + num7 * num7 + num11 * num11);
		yy += num10 * (num2 * num2 + num5 * num5 + num8 * num8 + num12 * num12);
		zz += num10 * (num3 * num3 + num6 * num6 + num9 * num9 + num13 * num13);
		yx += num10 * (num2 * num + num5 * num4 + num8 * num7 + num12 * num11);
		zx += num10 * (num3 * num + num6 * num4 + num9 * num7 + num13 * num11);
		zy += num10 * (num3 * num2 + num6 * num5 + num9 * num8 + num13 * num12);
	}

	public void GetResults(double m, Point3D C, out double X, out double Y, out double Z, out double XX, out double YY, out double ZZ, out double XY, out double ZX, out double YZ, out MomentOfInertia world, out MomentOfInertia centroid)
	{
		double num = 1.0 / 24.0;
		X = x * num + m * meanPoint.X;
		Y = y * num + m * meanPoint.Y;
		Z = z * num + m * meanPoint.Z;
		num = 1.0 / 120.0;
		XX = xx * num + 2.0 * m * (meanPoint.X * C.X) - m * (meanPoint.X * meanPoint.X);
		YY = yy * num + 2.0 * m * (meanPoint.Y * C.Y) - m * (meanPoint.Y * meanPoint.Y);
		ZZ = zz * num + 2.0 * m * (meanPoint.Z * C.Z) - m * (meanPoint.Z * meanPoint.Z);
		XY = yx * num + m * (meanPoint.X * C.Y + meanPoint.Y * C.X) - m * (meanPoint.X * meanPoint.Y);
		ZX = zx * num + m * (meanPoint.X * C.Z + meanPoint.Z * C.X) - m * (meanPoint.X * meanPoint.Z);
		YZ = zy * num + m * (meanPoint.Z * C.Y + meanPoint.Y * C.Z) - m * (meanPoint.Z * meanPoint.Y);
		world = GetResultAboutPoint(m, C - meanPoint, Point3D.Origin - meanPoint, num);
		centroid = GetResultAboutPoint(m, C - meanPoint, C - meanPoint, num);
	}
}
