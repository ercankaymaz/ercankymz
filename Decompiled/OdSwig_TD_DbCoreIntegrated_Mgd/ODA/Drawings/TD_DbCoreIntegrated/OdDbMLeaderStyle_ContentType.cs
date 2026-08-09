using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbMLeaderStyle_ContentType
{
	kNoneContent = 0,
	kBlockContent = 1,
	kMTextContent = 2,
	kToleranceContent = 3
}
