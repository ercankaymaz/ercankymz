using System;

namespace UglyToad.PdfPig.AcroForms.Fields;

[Flags]
public enum AcroTextFieldFlags : uint
{
	ReadOnly = 1u,
	Required = 2u,
	NoExport = 4u,
	Multiline = 0x1000u,
	Password = 0x2000u,
	FileSelect = 0x100000u,
	DoNotSpellCheck = 0x400000u,
	DoNotScroll = 0x800000u,
	Comb = 0x1000000u,
	RichText = 0x2000000u
}
