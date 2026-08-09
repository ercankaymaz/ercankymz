using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbField_State
{
	kInitialized = 1,
	kCompiled = 2,
	kModified = 4,
	kEvaluated = 8,
	kHasCache = 0x10,
	kHasFormattedString = 0x20
}
