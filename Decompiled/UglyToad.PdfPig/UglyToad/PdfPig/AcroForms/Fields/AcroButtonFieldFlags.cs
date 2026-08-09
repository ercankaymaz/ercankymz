using System;

namespace UglyToad.PdfPig.AcroForms.Fields;

[Flags]
public enum AcroButtonFieldFlags : uint
{
	ReadOnly = 1u,
	Required = 2u,
	NoExport = 4u,
	NoToggleToOff = 0x4000u,
	Radio = 0x8000u,
	PushButton = 0x10000u,
	RadiosInUnison = 0x2000000u
}
