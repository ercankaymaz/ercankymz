using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class DeviceAlarmWarningInfo : buSerilization
{
	public int AlarmNo = 0;

	public bool isAlarm = false;

	public bool isWarning = false;

	public string AlarmName = "";

	public string AlarmDecstription = "";

	public DeviceAlarmWarningInfo()
	{
	}

	public DeviceAlarmWarningInfo(DeviceAlarmWarningInfo data)
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
		return "No: " + AlarmNo + " , Name = " + AlarmName;
	}
}
