using System.Reflection;

namespace buClass.Apps;

public class jewelScale : buSerilization
{
	public double ConstantX = 20.0;

	public double ConstantY = 160.0;

	public jewelScaleMehod Method = jewelScaleMehod.Constant;

	public jewelScale()
	{
	}

	public jewelScale(jewelScale data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
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
		return "X: " + ConstantX + "  -  Y: " + ConstantY + "  -  Method: " + Method;
	}
}
