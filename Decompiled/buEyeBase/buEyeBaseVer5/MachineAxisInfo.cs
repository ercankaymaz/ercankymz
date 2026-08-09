using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class MachineAxisInfo : buSerilization5
{
	public string AxisName = "X";

	public double MaxSpeed = 3000.0;

	public double Acceleration = 10000.0;

	public double Deceleration = 10000.0;

	public double Jerk = 4000.0;

	public string AxisExplanation = "";

	public MachineAxisInfo()
	{
	}

	public MachineAxisInfo(MachineAxisInfo data)
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

	public static string AxisToString(MachineAxisInfo AxisInfo)
	{
		return buLangTranslate.preDef.Axes + " " + AxisInfo.AxisName + " - " + buLangTranslate.preDef.Speed + " " + AxisInfo.MaxSpeed + " - " + buLangTranslate.preDef.Acceleration + " " + AxisInfo.Acceleration + " - " + buLangTranslate.preDef.Deceleration + " " + AxisInfo.Deceleration + " - " + buLangTranslate.preDef.Jerk + " " + AxisInfo.Jerk + " - " + buLangTranslate.preDef.Explanation + " " + AxisInfo.AxisExplanation;
	}

	public override string ToString()
	{
		return AxisName + " - Speed: " + MaxSpeed.ToString("f3") + " - Acc: " + Acceleration.ToString("f3") + " - Dec: " + Deceleration.ToString("f3") + " - Jerk: " + Jerk.ToString("f3") + " - Exp:" + AxisExplanation;
	}
}
