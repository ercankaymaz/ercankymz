using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbGeoData_TypeOfCoordinates
{
	kCoordTypUnknown = 0,
	kCoordTypLocal = 1,
	kCoordTypGrid = 2,
	kCoordTypGeographic = 3
}
