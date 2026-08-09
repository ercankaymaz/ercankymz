using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbGeoData_ScaleEstimationMethod
{
	kScaleEstMethodUnity = 1,
	kScaleEstMethodUserDefined = 2,
	kScaleEstMethodReferencePoint = 3,
	kScaleEstMethodPrismoidal = 4
}
