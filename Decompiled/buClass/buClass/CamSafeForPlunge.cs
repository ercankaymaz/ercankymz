using System;

namespace buClass;

[Serializable]
public enum CamSafeForPlunge
{
	None,
	SafeThenSmallSafe,
	Safe,
	SmallSafe,
	AirThenSafe,
	AirThenSmallSafe,
	Air,
	NotMove
}
