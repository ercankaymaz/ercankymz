using System;

namespace buMotion;

[Serializable]
public enum AlarmWarningActionType
{
	Warning,
	SoftAlarm,
	HardAlarm,
	Information,
	NoAction,
	Pause
}
