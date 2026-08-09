using System;
using System.Collections.Generic;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class Rectangle2D : buSerilization5
{
	public Point3D StartPoint = new Point3D();

	public double Width = 0.0;

	public double Height = 0.0;

	public Rectangle2D()
	{
	}

	public Rectangle2D(Rectangle2D data)
	{
		StartPoint = new Point3D(data.StartPoint.X, data.StartPoint.Y, data.StartPoint.Z);
		Width = data.Width;
		Height = data.Height;
	}

	public Rectangle2D(Point3D startPoint, double width, double height)
	{
		StartPoint = buVector5.ToPoint3D(startPoint);
		Width = width;
		Height = height;
	}

	public Rectangle2D(double width, double height)
	{
		StartPoint = new Point3D();
		Width = width;
		Height = height;
	}

	public static void Rectangle3DToVertices(Rectangle2D rect, ref List<Point3D> Vertices)
	{
		Vertices = new List<Point3D>();
		Vertices.Add(new Point3D(rect.StartPoint.X, rect.StartPoint.Y));
		Vertices.Add(new Point3D(rect.StartPoint.X + rect.Width, rect.StartPoint.Y));
		Vertices.Add(new Point3D(rect.StartPoint.X + rect.Width, rect.StartPoint.Y + rect.Height));
		Vertices.Add(new Point3D(rect.StartPoint.X, rect.StartPoint.Y + rect.Height));
		Vertices.Add(new Point3D(rect.StartPoint.X, rect.StartPoint.Y));
	}

	public static void Rectangle3DToVertices(Point3D CornerPoint, double dX, double dY, ref List<Point3D> Vertices)
	{
		Vertices = new List<Point3D>();
		Vertices.Add(new Point3D(CornerPoint.X, CornerPoint.Y));
		Vertices.Add(new Point3D(CornerPoint.X + dX, CornerPoint.Y));
		Vertices.Add(new Point3D(CornerPoint.X + dX, CornerPoint.Y + dY));
		Vertices.Add(new Point3D(CornerPoint.X, CornerPoint.Y + dY));
		Vertices.Add(new Point3D(CornerPoint.X, CornerPoint.Y));
	}

	public static void Rectangle2DCenter(Rectangle2D rect, ref Point3D Center)
	{
		Center = new Point3D(rect.StartPoint.X + rect.Width / 2.0, rect.StartPoint.Y + rect.Height / 2.0);
	}

	public static Rectangle2D Copy(Rectangle2D P)
	{
		return new Rectangle2D(P.StartPoint, P.Width, P.Height);
	}

	public static Rectangle2D[] Copy(Rectangle2D[] pts)
	{
		Rectangle2D[] array = new Rectangle2D[pts.Length];
		for (int i = 0; i < pts.Length; i++)
		{
			array[i] = Copy(pts[i]);
		}
		return array;
	}

	public static List<Rectangle2D> Copy(List<Rectangle2D> pts)
	{
		List<Rectangle2D> list = new List<Rectangle2D>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public static void Copy(List<Rectangle2D> pts, ref List<Rectangle2D> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(Copy(pts[i]));
		}
	}

	public override string ToString()
	{
		return StartPoint.ToString() + " - W: " + Width + " - H: " + Height;
	}
}
