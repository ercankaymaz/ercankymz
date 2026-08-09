using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_RotationAngle
{
	kDegreesUnknown = -1,
	kDegrees000 = 0,
	kDegrees090 = 1,
	kDegrees180 = 2,
	kDegrees270 = 3
}
