using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_LoftNormalsType
{
	kLoftRuled = 0,
	kLoftSmooth = 1,
	kLoftFirstNormal = 2,
	kLoftLastNormal = 3,
	kLoftEndsNormal = 4,
	kLoftAllNormal = 5,
	kLoftUseDraftAngles = 6
}
