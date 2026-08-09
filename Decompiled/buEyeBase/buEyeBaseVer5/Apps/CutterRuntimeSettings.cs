using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class CutterRuntimeSettings : buSerilization
{
	public int SimStep = 1;

	public double ManuelSheetWidth = 1000.0;

	public double ManuelSheetHeight = 500.0;

	public CutterRuntimeSettings()
	{
	}

	public CutterRuntimeSettings(CutterRuntimeSettings data)
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

	public static void Copy(CutterRuntimeSettings Source, ref CutterRuntimeSettings Target)
	{
		Target = new CutterRuntimeSettings(Source);
	}

	public override string ToString()
	{
		return "";
	}
}
