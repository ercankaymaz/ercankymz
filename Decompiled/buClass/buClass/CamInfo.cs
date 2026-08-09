using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class CamInfo : buSerilization
{
	public double TotalLength = 0.0;

	public double TotalProcessLength = 0.0;

	public double AirMoveLength = 0.0;

	public double TotalSecond = 0.0;

	public double ProcessSecond = 0.0;

	public double AirMoveSecond = 0.0;

	public double StartSecond = 0.0;

	public double EndSecond = 0.0;

	public string ProcessMinute = "";

	public string AllProcessTime = "";

	public double TotalOperationTimeSec = 0.0;

	public double TotalOperationDistance = 0.0;

	public double TotalOperationG1Distance = 0.0;

	public double TotalOperationG0Distance = 0.0;

	public static List<string> Captions = new List<string>();

	public CamInfo()
	{
	}

	public CamInfo(CamInfo info)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(info, ref CopiedClass);
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
		return "Tot Len: " + TotalLength.ToString("f3") + " , Sec: " + ProcessSecond;
	}
}
