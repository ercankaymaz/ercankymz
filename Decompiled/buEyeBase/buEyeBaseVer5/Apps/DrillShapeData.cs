using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillShapeData : buSerilization5
{
	public double Diameter = 0.0;

	public double Depth = 0.0;

	public double Length = 0.0;

	public double Width = 0.0;

	public double Height = 0.0;

	public double Angle = 0.0;

	public int Sides = 0;

	public bool isCenter = true;

	public DrillShapeData()
	{
	}

	public DrillShapeData(double diameter, double depth, double length, double width, double height, double angle, int sides, bool iscenter)
	{
		Angle = angle;
		Depth = depth;
		Diameter = diameter;
		Height = height;
		Length = length;
		Sides = sides;
		Width = width;
		isCenter = iscenter;
	}

	public DrillShapeData(DrillShapeData data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
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

	public override string ToString()
	{
		string text = "";
		if (Depth > 0.0)
		{
			text = text + "Depth: " + Depth.ToString("f2");
		}
		if (Diameter > 0.0)
		{
			text = text + " - Dia: " + Diameter.ToString("f2");
		}
		if (Width > 0.0)
		{
			text = text + " - Width: " + Width.ToString("f2");
		}
		if (Height > 0.0)
		{
			text = text + " - Height: " + Height.ToString("f2");
		}
		if (Length > 0.0)
		{
			text = text + " - Length: " + Length.ToString("f2");
		}
		if (Angle > 0.0)
		{
			text = text + " - Angle: " + Angle.ToString("f2");
		}
		if (Sides > 0)
		{
			text = text + " - Sides: " + Sides.ToString("f2");
		}
		return base.ToString();
	}
}
