using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbLeader_AnnoType
{
	kMText = 0,
	kFcf = 1,
	kBlockRef = 2,
	kNoAnno = 3
}
