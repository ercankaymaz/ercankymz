using System;

namespace ModuleWorks;

[Serializable]
public enum ToolPathLinkType
{
	Approach,
	LeadIn,
	ConnectionNotClearanceArea,
	ConnectionClearanceArea,
	LeadOut,
	Retract,
	NotALink
}
