using System;

namespace ModuleWorks;

[Serializable]
public enum TesselationErrorCode
{
	NoError,
	PrimaryFail,
	SecondaryFail,
	BothFail
}
