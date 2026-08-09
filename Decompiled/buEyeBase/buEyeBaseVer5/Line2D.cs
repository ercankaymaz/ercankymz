using System;
using System.Collections.Generic;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class Line2D : buSerilization5
{
	public Point3D StartPoint = new Point3D();

	public Point3D EndPoint = new Point3D();

	public Line2D()
	{
	}

	public Line2D(Line2D data)
	{
		StartPoint = new Point3D(data.StartPoint.X, data.StartPoint.Y, data.StartPoint.Z);
		EndPoint = new Point3D(data.EndPoint.X, data.EndPoint.Y, data.EndPoint.Z);
	}

	public Line2D(Point3D startPoint, Point3D endPoint)
	{
		StartPoint = buVector5.ToPoint3D(startPoint);
		EndPoint = buVector5.ToPoint3D(endPoint);
	}

	public Line2D(Point3D startPoint, double dX, double dY)
	{
		StartPoint = buVector5.ToPoint3D(startPoint);
		EndPoint = new Point3D(startPoint.X + dX, startPoint.Y + dY, startPoint.Z);
	}

	public Line2D(double dX, double dY)
	{
		StartPoint = new Point3D();
		EndPoint = new Point3D(dX, dY);
	}

	public static void Line2DToVertices(Line2D line, ref List<Point3D> Vertices)
	{
		Vertices = new List<Point3D>();
		Vertices.Add(new Point3D(line.StartPoint.X, line.StartPoint.Y));
		Vertices.Add(new Point3D(line.EndPoint.X, line.EndPoint.Y));
	}

	public static Line2D Copy(Line2D P)
	{
		return new Line2D(P.StartPoint, P.EndPoint);
	}

	public static Line2D[] Copy(Line2D[] pts)
	{
		Line2D[] array = new Line2D[pts.Length];
		for (int i = 0; i < pts.Length; i++)
		{
			array[i] = Copy(pts[i]);
		}
		return array;
	}

	public static List<Line2D> Copy(List<Line2D> pts)
	{
		List<Line2D> list = new List<Line2D>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public static void Copy(List<Line2D> pts, ref List<Line2D> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(Copy(pts[i]));
		}
	}

	public override string ToString()
	{
		return StartPoint.ToString() + " -  " + EndPoint.ToString();
	}
}
