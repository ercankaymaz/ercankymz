using System;

namespace ModuleWorks;

[Serializable]
[Flags]
public enum VerificationResult
{
	NoError = 0,
	RapidEdgeCrash = 1,
	EdgeCrash = 2,
	ArborCrash = 4,
	HolderCrash = 8,
	FluteSafetyDistanceCrash = 0x10,
	ShaftSafetyDistanceCrash = 0x20,
	ArborSafetyDistanceCrash = 0x40,
	HolderSafetyDistanceCrash = 0x80
}
