using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbGeoCoordinateSystem_Type
{
	kTypeUnknown = 0,
	kTypeArbitrary = 1,
	kTypeGeographic = 2,
	kTypeProjected = 3
}
