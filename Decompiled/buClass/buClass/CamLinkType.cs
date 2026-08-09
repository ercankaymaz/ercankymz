using System;

namespace buClass;

[Serializable]
public enum CamLinkType
{
	Approach,
	LeadIn,
	ConnectionNotClearanceArea,
	ConnectionClearanceArea,
	LeadOut,
	Retract,
	NotALink
}
