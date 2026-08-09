using System;

namespace buClass;

[Serializable]
public enum CamStepDepthMode
{
	ConstantDepthStep,
	NumberOfSlices,
	NumberOfSlicesWithConstantVolume,
	SpiralAngle
}
