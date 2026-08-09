using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbGeoVerticalCoordinateSystem_Type
{
	kTypeUnknown = 0,
	kTypeEllipsoidal = 1,
	kTypeGeoidModelDerived = 2
}
