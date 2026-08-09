using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class PipeBendData : buSerilization5
{
	public double Diameter = 40.0;

	public double Length = 1000.0;

	public PipeBendData()
	{
	}

	public PipeBendData(PipeBendData data)
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
		return "Diameter: " + Diameter + " - Length: " + Length;
	}
}
