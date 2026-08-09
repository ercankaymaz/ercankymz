using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbFiler_FilerType
{
	kFileFiler = 0,
	kCopyFiler = 1,
	kUndoFiler = 2,
	kBagFiler = 3,
	kIdXlateFiler = 4,
	kPageFiler = 5,
	kDeepCloneFiler = 6,
	kIdFiler = 7,
	kPurgeFiler = 8,
	kWblockCloneFiler = 9
}
