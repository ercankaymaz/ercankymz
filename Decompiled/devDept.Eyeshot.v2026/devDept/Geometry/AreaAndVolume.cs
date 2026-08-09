using System;
using System.Collections.Generic;
using devDept.Eyeshot.Entities;

namespace devDept.Geometry;

public abstract class AreaAndVolume
{
	protected double m;

	protected double Cx;

	protected double Cy;

	protected double Cz;

	protected double x;

	protected double y;

	protected double z;

	protected double xx;

	protected double yy;

	protected double zz;

	protected double yx;

	protected double zx;

	protected double zy;

	protected Point3D meanPoint;

	public abstract Point3D Centroid { get; }

	protected AreaAndVolume(Point3D refPoint = null)
	{
		if (refPoint != null)
		{
			meanPoint = (Point3D)refPoint.Clone();
		}
		else
		{
			meanPoint = Point3D.Origin;
		}
	}

	protected abstract void AddTriangleContribution(Point3D p1, Point3D p2, Point3D p3);

	public void Add(Mesh mesh)
	{
		IndexTriangle[] triangles = mesh.Triangles;
		foreach (IndexTriangle indexTriangle in triangles)
		{
			AddTriangleContribution(mesh.Vertices[indexTriangle.V1] - meanPoint, mesh.Vertices[indexTriangle.V2] - meanPoint, mesh.Vertices[indexTriangle.V3] - meanPoint);
		}
	}

	public void Add(IList<Mesh> meshes)
	{
		foreach (Mesh mesh in meshes)
		{
			IndexTriangle[] triangles = mesh.Triangles;
			foreach (IndexTriangle indexTriangle in triangles)
			{
				AddTriangleContribution(mesh.Vertices[indexTriangle.V1] - meanPoint, mesh.Vertices[indexTriangle.V2] - meanPoint, mesh.Vertices[indexTriangle.V3] - meanPoint);
			}
		}
	}

	public void Add(IList<Point3D> vList, IList<IndexTriangle> tList)
	{
		foreach (IndexTriangle t in tList)
		{
			AddTriangleContribution(vList[t.V1] - meanPoint, vList[t.V2] - meanPoint, vList[t.V3] - meanPoint);
		}
	}

	public void Add(float[] vList, int[] tList)
	{
		for (int i = 0; i < tList.Length; i += 3)
		{
			Point3D[] array = new Point3D[3];
			for (int j = 0; j < 3; j++)
			{
				int num = 3 * tList[i + j];
				array[j] = new Point3D(vList[num], vList[num + 1], vList[num + 2]);
			}
			AddTriangleContribution(array[0] - meanPoint, array[1] - meanPoint, array[2] - meanPoint);
		}
	}

	protected abstract double GetMass();

	public void GetPrincipalAxes(double volume, Point3D centroid, out Vector3D axisX, out Vector3D axisY, out Vector3D axisZ, out double ix, out double iy, out double iz)
	{
		MomentOfInertia resultsAboutCentroid = GetResultsAboutCentroid(volume, centroid - meanPoint, 1.0 / 120.0);
		double[,] array = new double[3, 3];
		array[0, 0] = resultsAboutCentroid.Ix;
		array[1, 1] = resultsAboutCentroid.Iy;
		array[2, 2] = resultsAboutCentroid.Iz;
		array[0, 1] = (array[1, 0] = 0.0 - resultsAboutCentroid.Iyx);
		array[0, 2] = (array[2, 0] = 0.0 - resultsAboutCentroid.Izx);
		array[1, 2] = (array[2, 1] = 0.0 - resultsAboutCentroid.Izy);
		Utility._0023_003DzQblHGY4s1vkJ(array, out var _0023_003DzAvn2b38_003D, out var _);
		Vector3D vector3D = new Vector3D(array[0, 0], array[1, 0], array[2, 0]);
		Vector3D vector3D2 = new Vector3D(array[0, 1], array[1, 1], array[2, 1]);
		Vector3D vector3D3 = new Vector3D(array[0, 2], array[1, 2], array[2, 2]);
		axisX = new Vector3D(array[0, 0], array[1, 0], array[2, 0]);
		axisY = new Vector3D(array[0, 1], array[1, 1], array[2, 1]);
		axisZ = new Vector3D(array[0, 2], array[1, 2], array[2, 2]);
		ix = _0023_003DzAvn2b38_003D[0];
		iy = _0023_003DzAvn2b38_003D[1];
		iz = _0023_003DzAvn2b38_003D[2];
		if (_0023_003DzAvn2b38_003D[0] >= _0023_003DzAvn2b38_003D[1] && _0023_003DzAvn2b38_003D[0] >= _0023_003DzAvn2b38_003D[2])
		{
			axisZ = vector3D;
			iz = _0023_003DzAvn2b38_003D[0];
			if (_0023_003DzAvn2b38_003D[1] >= _0023_003DzAvn2b38_003D[2])
			{
				axisY = vector3D2;
				iy = _0023_003DzAvn2b38_003D[1];
				axisX = vector3D3;
				ix = _0023_003DzAvn2b38_003D[2];
			}
			else
			{
				axisY = vector3D3;
				iy = _0023_003DzAvn2b38_003D[2];
				axisX = vector3D2;
				ix = _0023_003DzAvn2b38_003D[1];
			}
		}
		else if (_0023_003DzAvn2b38_003D[1] >= _0023_003DzAvn2b38_003D[0] && _0023_003DzAvn2b38_003D[1] >= _0023_003DzAvn2b38_003D[2])
		{
			axisZ = vector3D2;
			iz = _0023_003DzAvn2b38_003D[1];
			if (_0023_003DzAvn2b38_003D[0] >= _0023_003DzAvn2b38_003D[2])
			{
				axisY = vector3D;
				iy = _0023_003DzAvn2b38_003D[0];
				axisX = vector3D3;
				ix = _0023_003DzAvn2b38_003D[2];
			}
			else
			{
				axisY = vector3D3;
				iy = _0023_003DzAvn2b38_003D[2];
				axisX = vector3D;
				ix = _0023_003DzAvn2b38_003D[0];
			}
		}
		else
		{
			axisZ = vector3D3;
			iz = _0023_003DzAvn2b38_003D[2];
			if (_0023_003DzAvn2b38_003D[0] >= _0023_003DzAvn2b38_003D[1])
			{
				axisY = vector3D;
				iy = _0023_003DzAvn2b38_003D[0];
				axisX = vector3D2;
				ix = _0023_003DzAvn2b38_003D[1];
			}
			else
			{
				axisY = vector3D2;
				iy = _0023_003DzAvn2b38_003D[1];
				axisX = vector3D;
				ix = _0023_003DzAvn2b38_003D[0];
			}
		}
		axisZ = Vector3D.Cross(axisX, axisY);
	}

	protected MomentOfInertia GetResultsAboutWorld(double m, double r)
	{
		double num = xx * r;
		double num2 = yy * r;
		double num3 = zz * r;
		MomentOfInertia result = default(MomentOfInertia);
		result.Ix = num2 + num3;
		result.Iy = num3 + num;
		result.Iz = num + num2;
		result.Rx = Math.Sqrt(result.Ix / m);
		result.Ry = Math.Sqrt(result.Iy / m);
		result.Rz = Math.Sqrt(result.Iz / m);
		return result;
	}

	protected MomentOfInertia GetResultsAboutCentroid(double m, Point3D C, double r)
	{
		double num = xx * r - m * C.X * C.X;
		double num2 = yy * r - m * C.Y * C.Y;
		double num3 = zz * r - m * C.Z * C.Z;
		MomentOfInertia result = default(MomentOfInertia);
		result.Iyx = yx * r - m * C.Y * C.X;
		result.Izx = zx * r - m * C.Z * C.X;
		result.Izy = zy * r - m * C.Z * C.Y;
		result.Ix = num2 + num3;
		result.Iy = num3 + num;
		result.Iz = num + num2;
		result.Rx = Math.Sqrt(result.Ix / m);
		result.Ry = Math.Sqrt(result.Iy / m);
		result.Rz = Math.Sqrt(result.Iz / m);
		return result;
	}

	protected MomentOfInertia GetResultAboutPoint(double m, Point3D C, Point3D P, double r)
	{
		double num = xx * r + m * (P.X * P.X) - 2.0 * m * (P.X * C.X);
		double num2 = yy * r + m * (P.Y * P.Y) - 2.0 * m * (P.Y * C.Y);
		double num3 = zz * r + m * (P.Z * P.Z) - 2.0 * m * (P.Z * C.Z);
		MomentOfInertia result = default(MomentOfInertia);
		result.Iyx = yx * r - m * (P.X * C.Y + P.Y * C.X) - m * (P.X * P.Y);
		result.Izx = zx * r - m * (P.X * C.Z + P.Z * C.X) - m * (P.X * P.Z);
		result.Izy = zy * r - m * (P.Z * C.Y + P.Y * C.Z) - m * (P.Z * P.Y);
		result.Ix = num2 + num3;
		result.Iy = num + num3;
		result.Iz = num + num2;
		result.Rx = Math.Sqrt(result.Ix / m);
		result.Ry = Math.Sqrt(result.Iy / m);
		result.Rz = Math.Sqrt(result.Iz / m);
		return result;
	}

	internal static Point3D _0023_003Dz2_00247Z08V0cR3eZU8MKTsyQao_003D(IList<Mesh> _0023_003DzIIuKCj1NK1q5)
	{
		Point3D origin = Point3D.Origin;
		int _0023_003Dzfsn580w_003D = 0;
		foreach (Mesh item in _0023_003DzIIuKCj1NK1q5)
		{
			_0023_003DzPJNpNF4_003D(item.Vertices, origin, ref _0023_003Dzfsn580w_003D);
		}
		return origin / _0023_003Dzfsn580w_003D;
	}

	public static Point3D ComputeGeometricCenter(Point3D[] vertices)
	{
		Point3D origin = Point3D.Origin;
		int _0023_003Dzfsn580w_003D = 0;
		_0023_003DzPJNpNF4_003D(vertices, origin, ref _0023_003Dzfsn580w_003D);
		return origin / _0023_003Dzfsn580w_003D;
	}

	private static void _0023_003DzPJNpNF4_003D(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Point3D _0023_003DzbUvT9Pc_003D, ref int _0023_003Dzfsn580w_003D)
	{
		foreach (Point3D point3D in _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
		{
			_0023_003DzbUvT9Pc_003D.X += point3D.X;
			_0023_003DzbUvT9Pc_003D.Y += point3D.Y;
			_0023_003DzbUvT9Pc_003D.Z += point3D.Z;
			_0023_003Dzfsn580w_003D++;
		}
	}
}
