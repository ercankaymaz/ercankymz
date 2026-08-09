using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCountertopPocketData : buSerilization5
{
	public bool Enable = false;

	public double PocketDistance = 200.0;

	public double PocketWidth = 200.0;

	public double PocketHeight = 100.0;

	public marbleCountertopPocketData()
	{
	}

	public marbleCountertopPocketData(marbleCountertopPocketData data)
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
		return "Pocket : " + Enable + " , Dis : " + PocketDistance + " , Width: " + PocketWidth + " , Height: " + PocketHeight;
	}
}
