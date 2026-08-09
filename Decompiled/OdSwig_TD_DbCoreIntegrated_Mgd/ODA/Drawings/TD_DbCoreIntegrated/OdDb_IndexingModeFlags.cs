using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_IndexingModeFlags
{
	kNoIndexing = 0,
	kUpdateBlockIndexOnSave = 1,
	kUseBlockChangeIterator = 2,
	kUseAll = 3
}
