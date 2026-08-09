using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbGeoCoordinateSystem_StatusType
{
	kStatusTypeOutOfDate = 1,
	kStatusTypeUpToDate = 2,
	kStatusTypeUserDefined = 3
}
