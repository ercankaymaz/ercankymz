using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class PipeBendSettings : buSerilization5
{
	public bool ShowOperationInfo = false;

	public string pathFromFile = "C:\\";

	public LengthUnit UnitLength = LengthUnit.mm;

	public SpeedUnit UnitSpeed = SpeedUnit.mmPerSec;

	public PipeBendSettings()
	{
	}

	public PipeBendSettings(PipeBendSettings data)
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
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
