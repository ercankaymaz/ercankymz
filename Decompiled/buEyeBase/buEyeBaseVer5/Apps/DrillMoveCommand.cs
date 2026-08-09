using System;

namespace buEyeBaseVer5.Apps;

[Serializable]
public enum DrillMoveCommand
{
	AxisMove = 0,
	SetPiston = 1,
	ResetPiston = 2,
	Finished = 3,
	XAxesGantyOn = 4,
	XAxesGantyOff = 5,
	ResetAll = 6,
	AllClamperDown = 7,
	AllClamperUp = 8,
	Clamper1Down = 9,
	Clamper1Up = 10,
	Clamper2Down = 11,
	Clamper2Up = 12,
	Wait = 13,
	GCode = 14,
	SetPress = 15,
	ResetPress = 16,
	ResetAllPress = 17,
	GCodeList = 18,
	Empty = 99,
	None = 100
}
