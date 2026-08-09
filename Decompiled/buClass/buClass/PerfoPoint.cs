using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class PerfoPoint : buSerilization
{
	public double X = 0.0;

	public double Width = 0.0;

	public double Height = 0.0;

	public PerfoPoint()
	{
	}

	public PerfoPoint(double x, double width, double height)
	{
		X = x;
		Width = width;
		Height = height;
	}

	public PerfoPoint(PerfoPoint lengths)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(lengths, ref CopiedClass);
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
		return "X: " + X + " - Width: " + Width + " - Height: " + Height;
	}
}
