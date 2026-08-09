using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_TableCopyOption
{
	kTableCopyOptionNone = 0,
	kTableCopyOptionExpandOrContractTable = 1,
	kTableCopyOptionSkipContent = 2,
	kTableCopyOptionSkipValue = 4,
	kTableCopyOptionSkipField = 8,
	kTableCopyOptionSkipFormula = 0x10,
	kTableCopyOptionSkipBlock = 0x20,
	kTableCopyOptionSkipDataLink = 0x40,
	kTableCopyOptionSkipLabelCell = 0x80,
	kTableCopyOptionSkipDataCell = 0x100,
	kTableCopyOptionSkipFormat = 0x200,
	kTableCopyOptionSkipCellStyle = 0x400,
	kTableCopyOptionConvertFormatToOverrides = 0x800,
	kTableCopyOptionSkipCellState = 0x1000,
	kTableCopyOptionSkipContentFormat = 0x2000,
	kTableCopyOptionSkipDissimilarContentFormat = 0x4000,
	kTableCopyOptionSkipGeometry = 0x8000,
	kTableCopyOptionSkipMerges = 0x10000,
	kTableCopyOptionFillTarget = 0x20000,
	kTableCopyOptionOverwriteReadOnlyContent = 0x40000,
	kTableCopyOptionOverwriteReadOnlyFormat = 0x80000,
	kTableCopyOptionOverwriteContentModifiedAfterUpdate = 0x100000,
	kTableCopyOptionOverwriteFormatModifiedAfterUpdate = 0x200000,
	kTableCopyOptionOnlyContentModifiedAfterUpdate = 0x400000,
	kTableCopyOptionOnlyFormatModifiedAfterUpdate = 0x800000,
	kTableCopyOptionRowHeight = 0x1000000,
	kTableCopyOptionColumnWidth = 0x2000000,
	kTableCopyOptionFullCellState = 0x4000000,
	kTableCopyOptionForRountrip = 0x8000000,
	kTableCopyOptionConvertFieldToValue = 0x10000000,
	kTableCopyOptionSkipFieldTranslation = 0x20000000
}
