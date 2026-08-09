using System;

namespace ModuleWorks;

[Serializable]
public enum ChuckJawsState
{
	[Obsolete("Deprecated since Release 2017.08. Please use ChuckJawsState.Clamped instead.")]
	Calmped = 0,
	Clamped = 0,
	Unclamped = 1
}
