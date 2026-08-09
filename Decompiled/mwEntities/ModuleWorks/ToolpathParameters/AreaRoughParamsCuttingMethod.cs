using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum AreaRoughParamsCuttingMethod
{
	CmOneWayAlongRotAxis,
	CmOneWayAlongRevRotAxis,
	CmZigZag,
	CmZigZagClimbOnly
}
