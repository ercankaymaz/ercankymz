using System;

namespace buClass;

[Serializable]
public class TempVariables : buSerilization
{
	public bool AlarmPre = false;

	public bool RunPre = false;

	public int alarmCountPre = 0;

	public int ActiveToolTypePre = -1;
}
