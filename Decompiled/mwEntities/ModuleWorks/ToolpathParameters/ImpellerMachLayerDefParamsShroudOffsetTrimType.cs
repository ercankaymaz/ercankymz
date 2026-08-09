using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum ImpellerMachLayerDefParamsShroudOffsetTrimType
{
	SotTrimWhenShroudOffsetTouchHub,
	SotExtendToNextCutEnd,
	SotExtendToTrailingEdge
}
