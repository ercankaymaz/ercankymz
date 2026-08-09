using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdValue_FormatOption
{
	kFormatOptionNone = 0,
	kForEditing = 1,
	kForExpression = 2,
	kUseMaximumPrecision = 4,
	kIgnoreMtextFormat = 8
}
