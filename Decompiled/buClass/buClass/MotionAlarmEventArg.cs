using System.Collections.Generic;

namespace buClass;

public class MotionAlarmEventArg
{
	public List<CodesysAlarm> AlarmList = new List<CodesysAlarm>();

	public int AlarmCount = 0;

	public MotionAlarmEventArg()
	{
	}

	public MotionAlarmEventArg(List<CodesysAlarm> alarmList, int count)
	{
		AlarmCount = count;
		AlarmList.Clear();
		for (int i = 0; i <= alarmList.Count - 1; i++)
		{
			AlarmList.Add(new CodesysAlarm(alarmList[i]));
		}
	}

	public override string ToString()
	{
		return "Count =  " + AlarmCount;
	}
}
