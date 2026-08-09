using System;
using System.Reflection;

namespace buEyeBaseVer5;

[Serializable]
public class camRuntime5 : buSerilization5
{
	public int CamID = 0;

	public double SimG1DevideLength = 1.0;

	public double SimG0DevideLength = 10.0;

	public camRuntime5()
	{
	}

	public camRuntime5(camRuntime5 offset)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(offset, ref CopiedClass);
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
		return "ID: " + CamID;
	}
}
