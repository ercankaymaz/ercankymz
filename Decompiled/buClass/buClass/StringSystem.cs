using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class StringSystem : buSerilization
{
	public static string strSystemRuntimeVar = "sysRun.";

	public static string strSystemSettingsVar = "sysSet.";

	public static string strCNCRuntimeVar = "CncRunMaster.";

	public static string strCNCSettingsVar = "CncSetMaster.";

	public static string strAppRuntimeVar = "appRun.";

	public static string strAppSettingsVar = "appSet.";

	public static string strKinematicVar = "Kinematic.";

	public static List<string> Captions = new List<string>();

	public StringSystem()
	{
	}

	public StringSystem(StringSystem data)
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
		return "strSystemRuntimeVar : " + strSystemRuntimeVar.ToString();
	}
}
