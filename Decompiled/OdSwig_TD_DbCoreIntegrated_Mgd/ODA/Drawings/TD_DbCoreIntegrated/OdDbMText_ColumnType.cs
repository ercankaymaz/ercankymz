using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbMText_ColumnType
{
	kNoColumns = 0,
	kStaticColumns = 1,
	kDynamicColumns = 2
}
