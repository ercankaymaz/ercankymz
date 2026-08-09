using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class CodesysAxStrings : buSerilization
{
	public string strRuntimeVar = "RunAxis";

	public string strRunExe = "RunAxis.exeAX.";

	public string strRunBool = "RunAxis.BoolAX.";

	public string strSettingsVar = "SetAxis";

	public static List<string> Captions = new List<string>();

	public CodesysAxStrings()
	{
	}

	public CodesysAxStrings(CodesysAxStrings data)
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
		return "Run : " + strRuntimeVar.ToString() + " , Set: " + strSettingsVar.ToString() + " , Exe: " + strRunExe.ToString() + " , Bool: " + strRunBool.ToString();
	}
}
