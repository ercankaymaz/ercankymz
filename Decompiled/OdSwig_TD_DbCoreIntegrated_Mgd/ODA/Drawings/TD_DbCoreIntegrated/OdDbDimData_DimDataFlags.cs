using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbDimData_DimDataFlags
{
	kDimEditable = 1,
	kDimInvisible = 2,
	kDimFocal = 4,
	kDimHideIfValueIsZero = 8,
	kDimEmptyData = 0x10,
	kDimResultantLength = 0x20,
	kDimDeltaLength = 0x40,
	kDimResultantAngle = 0x80,
	kDimDeltaAngle = 0x100,
	kDimRadius = 0x200,
	kDimCustomValue = 0x400,
	kDimConstrained = 0x800,
	kDimCustomString = 0x1000
}
