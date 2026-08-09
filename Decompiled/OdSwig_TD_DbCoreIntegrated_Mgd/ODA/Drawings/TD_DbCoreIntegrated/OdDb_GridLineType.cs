using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_GridLineType
{
	kInvalidGridLine = 0,
	kHorzTop = 1,
	kHorzInside = 2,
	kHorzBottom = 4,
	kVertLeft = 8,
	kVertInside = 0x10,
	kVertRight = 0x20,
	kHorzGridLineTypes = 7,
	kVertGridLineTypes = 0x38,
	kOuterGridLineTypes = 0x2D,
	kInnerGridLineTypes = 0x12,
	kAllGridLineTypes = 0x3F
}
