using System;
using System.Collections.Generic;
using System.Reflection;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;

namespace buMotion;

[Serializable]
public class AlarmActionSettings : buSerilization
{
	public AlarmWarningActionType WaterCheckAction = AlarmWarningActionType.Pause;

	public AlarmWarningActionType WaterLeakAction = AlarmWarningActionType.SoftAlarm;

	public AlarmWarningActionType PhaseErrorAction = AlarmWarningActionType.HardAlarm;

	public AlarmWarningActionType DoorSwitch = AlarmWarningActionType.Pause;

	public AlarmWarningActionType AirPreasure = AlarmWarningActionType.Pause;

	public AlarmWarningActionType HidroTermic = AlarmWarningActionType.Pause;

	public AlarmWarningActionType XLimitAction = AlarmWarningActionType.HardAlarm;

	public AlarmWarningActionType YLimitAction = AlarmWarningActionType.HardAlarm;

	public AlarmWarningActionType ZLimitAction = AlarmWarningActionType.HardAlarm;

	public AlarmWarningActionType LubricateBlockAction = AlarmWarningActionType.SoftAlarm;

	public AlarmWarningActionType LubricateLevelAction = AlarmWarningActionType.Warning;

	public AlarmWarningActionType ToolNotAvailableAction = AlarmWarningActionType.SoftAlarm;

	public AlarmWarningActionType ToolMissingAction = AlarmWarningActionType.SoftAlarm;

	public AlarmWarningActionType SpindleDriveAction = AlarmWarningActionType.HardAlarm;

	public AlarmWarningActionType SawDriveAction = AlarmWarningActionType.HardAlarm;

	public AlarmWarningActionType SawWarmUp = AlarmWarningActionType.NoAction;

	public AlarmWarningActionType SpindleWarmUp = AlarmWarningActionType.NoAction;

	public AlarmWarningActionType XAxisMaintenance = AlarmWarningActionType.NoAction;

	public AlarmWarningActionType YAxisMaintenance = AlarmWarningActionType.NoAction;

	public AlarmWarningActionType ZAxisMaintenance = AlarmWarningActionType.NoAction;

	public AlarmWarningActionType AAxisMaintenance = AlarmWarningActionType.NoAction;

	public AlarmWarningActionType CAxisMaintenance = AlarmWarningActionType.NoAction;

	public AlarmWarningActionType HidroMotorMaintenance = AlarmWarningActionType.NoAction;

	public AlarmWarningActionType LubricateMaintenance = AlarmWarningActionType.NoAction;

	public AlarmWarningActionType CabinetMaintenance = AlarmWarningActionType.NoAction;

	public AlarmWarningActionType AirMaintenance = AlarmWarningActionType.NoAction;

	public AlarmWarningActionType MachineCleaningMaintenance = AlarmWarningActionType.NoAction;

	public static List<string> Captions;

	[NonSerialized]
	internal static GetString _0007;

	public AlarmActionSettings()
	{
	}

	public AlarmActionSettings(AlarmActionSettings data)
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
		string result = default(string);
		while (4u != 0)
		{
			result = global::_0003._0005(_0007(107389876), XLimitAction.ToString());
			if (0 == 0)
			{
				break;
			}
		}
		return result;
	}

	static AlarmActionSettings()
	{
		Strings.CreateGetStringDelegate(typeof(AlarmActionSettings));
		Captions = new List<string>();
	}
}
