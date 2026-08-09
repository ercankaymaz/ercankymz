using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum LastExitType
{
	BackToRapidPlane,
	UseRapidDistance,
	UseFeedDistance,
	BackToClearanceThroughTubeCenter,
	Direct,
	BackToIncrementalRapidPlane,
	GenericRetract,
	LastType
}
