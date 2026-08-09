using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGUID_StringFormat_Enum
{
	Digits = 0,
	Hyphenses = 1,
	Braces = 2,
	Parentheses = 3,
	Extended = 4,
	Base64String = 5
}
