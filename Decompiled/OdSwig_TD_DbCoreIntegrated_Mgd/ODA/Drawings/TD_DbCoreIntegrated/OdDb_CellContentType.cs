using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_CellContentType
{
	kCellContentTypeUnknown = 0,
	kCellContentTypeValue = 1,
	kCellContentTypeField = 2,
	kCellContentTypeBlock = 4
}
