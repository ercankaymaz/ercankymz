using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbBlockUserParameter_UserParameterType
{
	kDistance = 0,
	kArea = 1,
	kVolume = 2,
	kReal = 3,
	kAngle = 4,
	kString = 5
}
