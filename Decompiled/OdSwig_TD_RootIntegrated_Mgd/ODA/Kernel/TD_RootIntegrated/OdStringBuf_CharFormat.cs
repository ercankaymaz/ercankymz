using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdStringBuf_CharFormat
{
	CharFormat_Undefined = 0,
	CharFormat_ANSI = 1,
	CharFormat_UTF8 = 2,
	CharFormat_UTF16LE = 3,
	CharFormat_UTF16BE = 4,
	CharFormat_UTF32LE = 5,
	CharFormat_UTF32BE = 6
}
