using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbMPolygon_loopDir
{
	kExterior = 0,
	kInterior = 1,
	kAnnotation = 2
}
