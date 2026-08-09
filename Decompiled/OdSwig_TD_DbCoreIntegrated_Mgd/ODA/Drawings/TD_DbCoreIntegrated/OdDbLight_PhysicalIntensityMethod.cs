using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbLight_PhysicalIntensityMethod
{
	kPeakIntensity = 0,
	kFlux = 1,
	kIlluminance = 2
}
