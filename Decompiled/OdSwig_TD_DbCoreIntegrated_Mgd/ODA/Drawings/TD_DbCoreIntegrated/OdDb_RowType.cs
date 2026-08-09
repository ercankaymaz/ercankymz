using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_RowType
{
	kUnknownRow = 0,
	kDataRow = 1,
	kTitleRow = 2,
	kHeaderRow = 4
}
