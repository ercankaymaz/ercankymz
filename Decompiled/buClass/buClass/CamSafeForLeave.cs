using System;

namespace buClass;

[Serializable]
public enum CamSafeForLeave
{
	None = 0,
	SmallSafeThenSafe = 1,
	Safe = 2,
	SmallSafe = 3,
	SafeThenAir = 4,
	SmallSafeThenAir = 5,
	Air = 6,
	NotMove = 8
}
