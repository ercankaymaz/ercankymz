using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[Flags]
[ComVisible(true)]
public enum LimitAlarmStates
{
	Inactive = 0,
	HighHigh = 1,
	High = 2,
	Low = 4,
	LowLow = 8
}
