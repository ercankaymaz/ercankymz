using System;

namespace buClass;

[Serializable]
public enum CamTiltStrategy
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
	RelativeToContactPoint
}
