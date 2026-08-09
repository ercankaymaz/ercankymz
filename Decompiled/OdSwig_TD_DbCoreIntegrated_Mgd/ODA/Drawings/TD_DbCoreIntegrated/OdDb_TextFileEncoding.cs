using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_TextFileEncoding
{
	kTextFileEncodingDefault = 0,
	kTextFileEncodingANSI = 1,
	kTextFileEncodingUTF8 = 0xB,
	kTextFileEncodingUTF16 = 0x15,
	kTextFileEncodingUTF16LE = 0x16,
	kTextFileEncodingUTF16BE = 0x17,
	kTextFileEncodingUTF32 = 0x1F,
	kTextFileEncodingUTF32LE = 0x20,
	kTextFileEncodingUTF32BE = 0x21
}
