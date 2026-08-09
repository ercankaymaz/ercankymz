using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbSweepOptions_AlignOption
{
	kNoAlignment = 0,
	kAlignSweepEntityToPath = 1,
	kTranslateSweepEntityToPath = 2,
	kTranslatePathToSweepEntity = 3
}
