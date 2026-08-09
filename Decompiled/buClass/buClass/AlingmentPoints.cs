using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class AlingmentPoints : buSerilization
{
	public Pnt3D pntBottomLeft = new Pnt3D();

	public Pnt3D pntBottomCenter = new Pnt3D();

	public Pnt3D pntBottomRight = new Pnt3D();

	public Pnt3D pntMiddleLeft = new Pnt3D();

	public Pnt3D pntMiddleCenter = new Pnt3D();

	public Pnt3D pntMiddleRight = new Pnt3D();

	public Pnt3D pntTopLeft = new Pnt3D();

	public Pnt3D pntTopCenter = new Pnt3D();

	public Pnt3D pntTopRight = new Pnt3D();

	public List<Pnt3D> MovePoints = new List<Pnt3D>();

	public List<Pnt3D> TipPoints = new List<Pnt3D>();

	public List<Pnt3D> BoxSizePoints = new List<Pnt3D>();

	public List<Pnt3D> RotatePoints = new List<Pnt3D>();

	public AlingmentPoints()
	{
	}

	public AlingmentPoints(AlingmentPoints data)
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
					string name = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		MovePoints.Clear();
		MovePoints = new List<Pnt3D>();
		for (int j = 0; j <= data.MovePoints.Count - 1; j++)
		{
			MovePoints.Add(new Pnt3D(data.MovePoints[j]));
		}
		TipPoints.Clear();
		TipPoints = new List<Pnt3D>();
		for (int k = 0; k <= data.TipPoints.Count - 1; k++)
		{
			TipPoints.Add(new Pnt3D(data.TipPoints[k]));
		}
		BoxSizePoints.Clear();
		BoxSizePoints = new List<Pnt3D>();
		for (int l = 0; l <= data.BoxSizePoints.Count - 1; l++)
		{
			BoxSizePoints.Add(new Pnt3D(data.BoxSizePoints[l]));
		}
		RotatePoints.Clear();
		RotatePoints = new List<Pnt3D>();
		for (int m = 0; m <= data.RotatePoints.Count - 1; m++)
		{
			RotatePoints.Add(new Pnt3D(data.RotatePoints[m]));
		}
	}
}
