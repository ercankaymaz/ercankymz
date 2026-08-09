using System;

namespace ODA.Kernel.TD_PDFToolkit;

[Flags]
public enum TD_PDF_PDFFieldFlags_PDFFieldFlagsEnum
{
	kReadOnly = 1,
	kRequired = 2,
	kNoExport = 3,
	kMultiline = 0xD,
	kPassword = 0xE,
	kNoToggleToOff = 0xF,
	kRadio = 0x10,
	kPushbutton = 0x11,
	kCombo = 0x12,
	kEdit = 0x13,
	kSort = 0x14,
	kFileSelect = 0x15,
	kMultiSelect = 0x16,
	kDoNotSpellCheck = 0x17,
	kDoNotScroll = 0x18,
	kComb = 0x19,
	kRichText = 0x1A,
	kRadiosInUnison = 0x1A,
	kCommitOnSelChange = 0x1B
}
