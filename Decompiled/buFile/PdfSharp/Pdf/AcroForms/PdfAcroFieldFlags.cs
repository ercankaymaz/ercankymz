using System;

namespace PdfSharp.Pdf.AcroForms;

[Flags]
public enum PdfAcroFieldFlags
{
	ReadOnly = 1,
	Required = 2,
	NoExport = 4,
	Pushbutton = 0x10000,
	Radio = 0x8000,
	NoToggleToOff = 0x4000,
	Multiline = 0x1000,
	Password = 0x2000,
	FileSelect = 0x100000,
	DoNotSpellCheckTextField = 0x400000,
	DoNotScroll = 0x800000,
	Combo = 0x20000,
	Edit = 0x40000,
	Sort = 0x80000,
	MultiSelect = 0x200000,
	DoNotSpellCheckChoiseField = 0x400000
}
