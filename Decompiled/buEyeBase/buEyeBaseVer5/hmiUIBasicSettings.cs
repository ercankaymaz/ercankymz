using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buControls.Controls;
using buCore;

namespace buEyeBaseVer5;

[Serializable]
public class hmiUIBasicSettings : buSerilization5
{
	public buControlDisplay Display = new buControlDisplay();

	public hmiUIBasicPars Parameters = new hmiUIBasicPars();

	public hmiUIBasicSettings()
	{
	}

	public hmiUIBasicSettings(hmiUIBasicSettings data)
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

	public static hmiUIBasicSettings DecodeHMI(List<string> SL, string Title, hmiUIBasicSettings Obj)
	{
		List<string> CalcList = new List<string>();
		buString.ListToSpecificList("<" + Title + ">", "</" + Title + ">", AddStartEndKey: false, SL, ref CalcList);
		buSerilization.DecodeProperty(CalcList, "_Display", SerilizationMode.MultiLine, Obj.Display);
		buSerilization.Decode(CalcList, "", SerilizationMode.MultiLine, Obj.Parameters);
		return Obj;
	}

	public ArrayList ToDefHMI(string Title, int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(new string(' ', Space) + "<" + Title + ">");
		arrayList.Add(new string(' ', Space + 2) + "<buControlDisplayVar>");
		if (Display != null)
		{
			arrayList.AddRange(Display.ToDefAll("_Display", Space + 4, SerilizationMode.MultiLine));
		}
		arrayList.AddRange(Parameters.ToDefAll("", Space + 4, SerilizationMode.MultiLine));
		arrayList.Add(new string(' ', Space + 2) + "</buControlDisplayVar>");
		arrayList.Add(new string(' ', Space) + "</" + Title + ">");
		return arrayList;
	}
}
