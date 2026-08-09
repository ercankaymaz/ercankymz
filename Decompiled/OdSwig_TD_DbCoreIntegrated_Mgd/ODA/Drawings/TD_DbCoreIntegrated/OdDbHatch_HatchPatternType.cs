using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbHatch_HatchPatternType
{
	kUserDefined = 0,
	kPreDefined = 1,
	kCustomDefined = 2
}
