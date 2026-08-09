using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MachiningAreaRoughingParamsDepthStepMode
{
	DsmConstantDepthStep,
	DsmNumberOfSlices,
	DsmNumberOfSlicesWithConstantVolume,
	DsmSpiralAngle
}
