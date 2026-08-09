using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdValue_ParseOption
{
	kParseOptionNone = 0,
	kSetDefaultFormat = 1,
	kPreserveMtextFormat = 2,
	kConvertTextToValue = 4,
	kChangeDataType = 8,
	kParseTextForFieldCode = 0x10
}
