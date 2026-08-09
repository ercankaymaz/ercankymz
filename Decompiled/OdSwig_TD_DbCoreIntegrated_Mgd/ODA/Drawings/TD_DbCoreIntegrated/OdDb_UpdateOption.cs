using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_UpdateOption
{
	kUpdateOptionNone = 0,
	kUpdateOptionSkipFormat = 0x20000,
	kUpdateOptionUpdateRowHeight = 0x40000,
	kUpdateOptionUpdateColumnWidth = 0x80000,
	kUpdateOptionAllowSourceUpdate = 0x100000,
	kUpdateOptionForceFullSourceUpdate = 0x200000,
	kUpdateOptionOverwriteContentModifiedAfterUpdate = 0x400000,
	kUpdateOptionOverwriteFormatModifiedAfterUpdate = 0x800000,
	kUpdateOptionForPreview = 0x1000000,
	kUpdateOptionIncludeXrefs = 0x2000000,
	kUpdateOptionSkipFormatAfterFirstUpdate = 0x4000000
}
