using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class SizeObject : buSerilization
{
	public double Width;

	public double Height;

	public double Depth;

	public SizeObject()
	{
	}

	public SizeObject(double width, double height, double depth)
	{
		Width = width;
		Height = height;
		Depth = depth;
	}

	public SizeObject(SizeObject size)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(size, ref CopiedClass);
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
		return "W: " + Width + " - H: " + Height + " - D: " + Depth;
	}
}
