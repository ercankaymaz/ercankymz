using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class AlingmentPoints3D : buSerilization5
{
	public Point3D pntBottomLeft = new Point3D();

	public Point3D pntBottomCenter = new Point3D();

	public Point3D pntBottomRight = new Point3D();

	public Point3D pntMiddleLeft = new Point3D();

	public Point3D pntMiddleCenter = new Point3D();

	public Point3D pntMiddleRight = new Point3D();

	public Point3D pntTopLeft = new Point3D();

	public Point3D pntTopCenter = new Point3D();

	public Point3D pntTopRight = new Point3D();

	public List<Point3D> MovePoints = new List<Point3D>();

	public List<Point3D> TipPoints = new List<Point3D>();

	public List<Point3D> BoxSizePoints = new List<Point3D>();

	public List<Point3D> RotatePoints = new List<Point3D>();

	public AlingmentPoints3D()
	{
	}

	public AlingmentPoints3D(AlingmentPoints3D data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
			FieldInfo[] fields = GetType().GetFields();
			if (fields != null)
			{
				for (int i = 0; i <= fields.Length - 1; i++)
				{
					_ = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		MovePoints.Clear();
		MovePoints = new List<Point3D>();
		for (int j = 0; j <= data.MovePoints.Count - 1; j++)
		{
			MovePoints.Add(buVector5.ToPoint3D(data.MovePoints[j]));
		}
		TipPoints.Clear();
		TipPoints = new List<Point3D>();
		for (int k = 0; k <= data.TipPoints.Count - 1; k++)
		{
			TipPoints.Add(buVector5.ToPoint3D(data.TipPoints[k]));
		}
		BoxSizePoints.Clear();
		BoxSizePoints = new List<Point3D>();
		for (int l = 0; l <= data.BoxSizePoints.Count - 1; l++)
		{
			BoxSizePoints.Add(buVector5.ToPoint3D(data.BoxSizePoints[l]));
		}
		RotatePoints.Clear();
		RotatePoints = new List<Point3D>();
		for (int m = 0; m <= data.RotatePoints.Count - 1; m++)
		{
			RotatePoints.Add(buVector5.ToPoint3D(data.RotatePoints[m]));
		}
	}
}
