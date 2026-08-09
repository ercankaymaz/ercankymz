using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MachiningParamsTiltStrategy
{
	NoTilt,
	RelativeToCuttingDir,
	RelativeAngle,
	FixedAngle,
	ThruBeampoint,
	FromBeampointAway,
	AroundAxis,
	ThruCurve,
	ThruLines,
	FromCurveAway,
	RelativeToImpellerMachLayer,
	PortMachAutoTilt,
	RotaryProjectionAutoTilt,
	RelativeToContactPoint,
	TiltWithFixedAngleToSurfaceNormal,
	TiltedIntoPlane
}
