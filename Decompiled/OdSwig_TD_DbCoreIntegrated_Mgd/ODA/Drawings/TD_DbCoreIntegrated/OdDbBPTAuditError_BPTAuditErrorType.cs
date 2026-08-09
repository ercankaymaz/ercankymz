using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbBPTAuditError_BPTAuditErrorType
{
	empty = 0,
	noMatchingRow = 1,
	invalidCell = 2,
	notInValueSet = 3,
	nonConstAttDef = 4,
	invalidUnmatchedValue = 5,
	duplicateRows = 6,
	exprExternRef = 7,
	cellEvalError = 8
}
