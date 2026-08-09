using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_Page_Format
{
	kA4 = 0,
	kA3 = 1,
	kP11x17 = 2,
	kA5 = 3,
	kB4JIS = 4,
	kB5JIS = 5,
	kExecutive = 6,
	kLegal = 7,
	kLetter = 8,
	kTabloid = 9,
	kB4ISO = 0xA,
	kB5ISO = 0xB,
	kCustom = 0xC,
	kLastFormat = 0xD
}
