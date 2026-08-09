using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_CellProperty
{
	kCellPropInvalid = 0,
	kCellPropDataType = 1,
	kCellPropDataFormat = 2,
	kCellPropRotation = 4,
	kCellPropScale = 8,
	kCellPropAlignment = 0x10,
	kCellPropContentColor = 0x20,
	kCellPropTextStyle = 0x40,
	kCellPropTextHeight = 0x80,
	kCellPropAutoScale = 0x100,
	kCellPropBackgroundColor = 0x200,
	kCellPropMarginLeft = 0x400,
	kCellPropMarginTop = 0x800,
	kCellPropMarginRight = 0x1000,
	kCellPropMarginBottom = 0x2000,
	kCellPropContentLayout = 0x4000,
	kCellPropMergeAll = 0x8000,
	kCellPropFlowDirBtoT = 0x10000,
	kCellPropMarginHorzSpacing = 0x20000,
	kCellPropMarginVertSpacing = 0x40000,
	kCellPropDataTypeAndFormat = 3,
	kCellPropContent = 0x1EF,
	kCellPropBitProperties = 0x18100,
	kCellPropAll = 0x7FFFF
}
