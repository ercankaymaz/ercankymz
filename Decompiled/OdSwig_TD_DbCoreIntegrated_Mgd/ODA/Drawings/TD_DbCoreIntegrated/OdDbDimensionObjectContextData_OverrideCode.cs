using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbDimensionObjectContextData_OverrideCode
{
	eDimtofl = 1,
	eDimsoxd = 2,
	eDimatfit = 4,
	eDimtix = 8,
	eDimtmove = 0x10
}
