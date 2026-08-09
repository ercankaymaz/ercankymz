using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ReadSurfaceVars : buSerilization
{
	public double CValue = 0.0;

	public double ReadValue = 0.0;

	public double XValue = 0.0;

	public double YValue = 0.0;

	public ReadSurfaceVars()
	{
	}

	public ReadSurfaceVars(ReadSurfaceVars data)
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
		return "X: " + XValue.ToString("f5") + " , Y: " + YValue.ToString("f5") + " , C: " + CValue.ToString("f5") + " , Read: " + ReadValue.ToString("f5");
	}
}
