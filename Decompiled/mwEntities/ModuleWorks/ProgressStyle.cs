using System;

namespace ModuleWorks;

[Serializable]
[Flags]
public enum ProgressStyle
{
	None = 0,
	NoAbort = 1,
	NoProgress = 2,
	NoTime = 4,
	NoEstimate = 8,
	OnlyInfo = 0xF
}
