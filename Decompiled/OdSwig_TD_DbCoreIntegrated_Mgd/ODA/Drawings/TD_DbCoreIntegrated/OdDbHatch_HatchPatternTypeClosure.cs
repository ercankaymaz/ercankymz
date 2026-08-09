using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbHatch_HatchPatternTypeClosure
{
	kNoneClosure = 0,
	kSolidClosure = 1,
	kPatternClosure = 2,
	kAnyClosure = 3
}
