using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MachiningAreaRestFinishingParamsType
{
	RfBasedOnTool,
	RfBasedOnStock,
	RfBasedOnToolLength,
	RfBasedOnToolDiameterPlusLength
}
