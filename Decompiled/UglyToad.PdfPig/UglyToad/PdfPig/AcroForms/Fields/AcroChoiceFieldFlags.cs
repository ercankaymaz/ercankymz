using System;

namespace UglyToad.PdfPig.AcroForms.Fields;

[Flags]
public enum AcroChoiceFieldFlags : uint
{
	ReadOnly = 1u,
	Required = 2u,
	NoExport = 4u,
	Combo = 0x20000u,
	Edit = 0x40000u,
	Sort = 0x80000u,
	MultiSelect = 0x200000u,
	DoNotSpellCheck = 0x400000u,
	CommitOnSelectionChange = 0x4000000u
}
