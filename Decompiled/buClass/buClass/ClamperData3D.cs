using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class ClamperData3D : buSerilization
{
	public double Width = 100.0;

	public double TipPointHeight = 120.0;

	public double ConstantPointHeight = 120.0;

	public double TipPointThickness = 30.0;

	public double ConstantPointThickness = 60.0;

	public double BottomThickness = 20.0;

	public ClamperData3D()
	{
	}

	public ClamperData3D(ClamperData3D data)
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
}
