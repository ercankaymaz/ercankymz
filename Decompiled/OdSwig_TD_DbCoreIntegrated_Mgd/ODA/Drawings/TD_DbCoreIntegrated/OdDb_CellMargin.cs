using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_CellMargin
{
	kCellMarginTop = 1,
	kCellMarginLeft = 2,
	kCellMarginBottom = 4,
	kCellMarginRight = 8,
	kCellMarginHorzSpacing = 0x10,
	kCellMarginVertSpacing = 0x20
}
