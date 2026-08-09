using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class TheoBendItem : TheoItem
{
	public double YPos = 0.0;

	public double ModeY1_ = 0.0;

	public double ModeY2_ = 0.0;

	public double Ratio = 0.0;

	public double Angle = 0.0;

	public double Radius = 0.0;

	public double BendAngle = 0.0;

	public double Tool = 0.0;

	public bool NoToolFound = false;

	public List<TheoBendOriginalPosition> OriginalFromCode = new List<TheoBendOriginalPosition>();

	public Pnt3D BendPosition = new Pnt3D();

	public Pnt3D GraphPosition = new Pnt3D();

	public TheoBendItem()
	{
	}

	public TheoBendItem(TheoBendItem data)
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
		OriginalFromCode.Clear();
		for (int j = 0; j <= data.OriginalFromCode.Count - 1; j++)
		{
			OriginalFromCode.Add(new TheoBendOriginalPosition(data.OriginalFromCode[j]));
		}
	}

	public TheoBendItem(double angle, double radius, double bendangle)
	{
		Angle = angle;
		Radius = radius;
		BendAngle = bendangle;
	}

	public override string ToString()
	{
		return "Bend - Angle: " + BendAngle + " - X: " + XPos + " - Rad: " + Radius + " - No Tool: " + NoToolFound;
	}
}
