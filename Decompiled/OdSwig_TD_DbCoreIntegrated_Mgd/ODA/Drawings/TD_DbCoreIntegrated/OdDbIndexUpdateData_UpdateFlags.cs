using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbIndexUpdateData_UpdateFlags
{
	kModified = 1,
	kDeleted = 2,
	kProcessed = 4,
	kUnknownKey = 8
}
