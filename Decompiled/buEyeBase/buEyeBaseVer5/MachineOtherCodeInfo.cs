using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class MachineOtherCodeInfo : buSerilization5
{
	public string OtherCode = "";

	public double TimeAsSec = 1.0;

	public string ExtraCode = "";

	public string OtherCodeExplanation = "";

	public MachineOtherCodeInfo()
	{
	}

	public MachineOtherCodeInfo(MachineOtherCodeInfo data)
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

	public static string OtherCodeToString(MachineOtherCodeInfo OtherCodeInfo)
	{
		return buLangTranslate.preDef.Other + " " + buLangTranslate.preDef.Code + " " + OtherCodeInfo.OtherCode + " - " + buLangTranslate.preDef.Time + " " + OtherCodeInfo.TimeAsSec + " - " + buLangTranslate.preDef.Extra + " " + OtherCodeInfo.ExtraCode + " - " + buLangTranslate.preDef.Explanation + " " + OtherCodeInfo.OtherCodeExplanation;
	}

	public override string ToString()
	{
		return OtherCode + " - TimeAsSec: " + TimeAsSec.ToString("f3") + " - ExtraCode: " + ExtraCode;
	}
}
