using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class SizeObject2D : buSerilization
{
	public double Width;

	public double Height;

	public SizeObject2D()
	{
	}

	public SizeObject2D(double width, double height)
	{
		Width = width;
		Height = height;
	}

	public SizeObject2D(SizeObject2D size)
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
		return "W: " + Width + " - H: " + Height;
	}
}
