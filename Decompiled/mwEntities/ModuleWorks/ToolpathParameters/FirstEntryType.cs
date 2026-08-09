using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum FirstEntryType
{
	FromRapidPlane,
	UseRapidDistance,
	UseFeedDistance,
	Direct,
	FromIncrementalRapidPlane,
	GenericApproach,
	LastType
}
