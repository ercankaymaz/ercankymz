using System;
using buClass;

namespace buMotion;

[Serializable]
public class preBoolVars : buSerilization
{
	public bool ParWriting = false;

	public bool Start = false;

	public bool Stop = false;

	public bool Pause = false;

	public bool Warning = false;

	public bool Alarm = false;

	public bool Saw = false;

	public bool Spindle = false;

	public int AlarmCountPre = 0;

	public int AlarmListCountPre = 0;

	public int WarningCountPre = 0;

	public int WarningListCountPre = 0;
}
