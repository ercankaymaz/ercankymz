using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_GridProperty
{
	kGridPropInvalid = 0,
	kGridPropLineStyle = 1,
	kGridPropLineWeight = 2,
	kGridPropLinetype = 4,
	kGridPropColor = 8,
	kGridPropVisibility = 0x10,
	kGridPropDoubleLineSpacing = 0x20,
	kGridPropAll = 0x3F
}
