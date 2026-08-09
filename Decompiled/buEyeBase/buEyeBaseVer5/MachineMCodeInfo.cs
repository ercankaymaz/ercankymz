using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class MachineMCodeInfo : buSerilization5
{
	public string MCode = "M6";

	public string ExtraCode = "";

	public double TimeAsSec = 1.0;

	public string MCodeExplanation = "";

	public MachineMCodeInfo()
	{
	}

	public MachineMCodeInfo(MachineMCodeInfo data)
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

	public static string MCodeToString(MachineMCodeInfo MCodeInfo)
	{
		return "M " + buLangTranslate.preDef.Code + " " + MCodeInfo.MCode + " - " + buLangTranslate.preDef.Time + " " + MCodeInfo.TimeAsSec + " - " + buLangTranslate.preDef.Extra + " " + MCodeInfo.ExtraCode + " - " + buLangTranslate.preDef.Explanation + " " + MCodeInfo.MCodeExplanation;
	}

	public override string ToString()
	{
		return MCode + " - TimeAsSec: " + TimeAsSec.ToString("f3") + " - ExtraCode: " + ExtraCode;
	}
}
