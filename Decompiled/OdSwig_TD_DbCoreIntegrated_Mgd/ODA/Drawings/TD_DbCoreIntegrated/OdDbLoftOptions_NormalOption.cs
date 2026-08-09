using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbLoftOptions_NormalOption
{
	kNoNormal = 0,
	kFirstNormal = 1,
	kLastNormal = 2,
	kEndsNormal = 3,
	kAllNormal = 4,
	kUseDraftAngles = 5
}
