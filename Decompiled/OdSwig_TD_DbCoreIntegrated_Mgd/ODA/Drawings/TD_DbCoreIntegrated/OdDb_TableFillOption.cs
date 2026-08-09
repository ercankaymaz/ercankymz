using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_TableFillOption
{
	kTableFillOptionNone = 0,
	kTableFillOptionRow = 1,
	kTableFillOptionReverse = 2,
	kTableFillOptionGenerateSeries = 4,
	kTableFillOptionCopyContent = 8,
	kTableFillOptionCopyFormat = 0x10,
	kTableFillOptionOverwriteReadOnlyContent = 0x20,
	kTableFillOptionOverwriteReadOnlyFormat = 0x40
}
