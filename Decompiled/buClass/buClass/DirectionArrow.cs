using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class DirectionArrow : buSerilization
{
	public bool Visible = true;

	public Color Color = Color.Gold;

	public double Thickness = 1.0;

	public double Angle = 0.0;

	public double PointAngle = 15.0;

	public double Length = 10.0;

	public bool Reverse = false;

	public Pnt3D Point = new Pnt3D();

	public Pnt3D PrePoint = new Pnt3D();

	public string BelongEntityName = "";

	public int BelongEntityIndex = -1;

	public static List<string> Captions = new List<string>();

	public DirectionArrow()
	{
	}

	public DirectionArrow(DirectionArrow arrow)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(arrow, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
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

	public override string ToString()
	{
		return Visible + " , " + Point.ToString() + " , Ang : " + Angle + " , Reverse: " + Reverse;
	}
}
