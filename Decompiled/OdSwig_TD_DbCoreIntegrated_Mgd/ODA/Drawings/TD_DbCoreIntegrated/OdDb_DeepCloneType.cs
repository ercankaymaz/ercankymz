using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_DeepCloneType
{
	kDcCopy = 0,
	kDcExplode = 1,
	kDcBlock = 2,
	kDcXrefBind = 3,
	kDcSymTableMerge = 4,
	kDcInsert = 6,
	kDcWblock = 7,
	kDcObjects = 8,
	kDcXrefInsert = 9,
	kDcInsertCopy = 0xA,
	kDcWblkObjects = 0xB
}
