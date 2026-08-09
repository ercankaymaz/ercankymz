using System;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class RegenResolutionData : buSerilization5
{
	public double Radius = 10.0;

	public double RegenRatio = 0.01;

	public RegenResolutionData()
	{
	}

	public RegenResolutionData(RegenResolutionData data)
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
		return "Radius: " + Radius + " , RegenRatio: " + RegenRatio;
	}
}
