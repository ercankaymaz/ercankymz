using System;
using System.Collections.Generic;
using System.Reflection;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class SelectionAlingmentPoints : buSerilization5
{
	public List<Point3D> MovePoints = new List<Point3D>();

	public List<Point3D> TipPoints = new List<Point3D>();

	public List<Point3D> BoxSizePoints = new List<Point3D>();

	public List<Point3D> RotatePoints = new List<Point3D>();

	public SelectionAlingmentPoints()
	{
	}

	public SelectionAlingmentPoints(SelectionAlingmentPoints data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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
		buVector5.Copy(data.MovePoints, ref MovePoints);
		TipPoints.Clear();
		TipPoints = new List<Point3D>();
		buVector5.Copy(data.TipPoints, ref TipPoints);
		BoxSizePoints.Clear();
		BoxSizePoints = new List<Point3D>();
		buVector5.Copy(data.BoxSizePoints, ref BoxSizePoints);
		RotatePoints.Clear();
		RotatePoints = new List<Point3D>();
		buVector5.Copy(data.RotatePoints, ref RotatePoints);
	}
}
