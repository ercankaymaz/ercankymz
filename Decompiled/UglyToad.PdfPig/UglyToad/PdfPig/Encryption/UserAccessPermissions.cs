using System;

namespace UglyToad.PdfPig.Encryption;

[Flags]
internal enum UserAccessPermissions : long
{
	Print = 4L,
	Modify = 8L,
	CopyTextAndGraphics = 0x10L,
	AddOrModifyTextAnnotationsAndFillFormFields = 0x20L,
	FillExistingFormFields = 0x100L,
	ExtractTextAndGraphics = 0x200L,
	AssembleDocument = 0x400L,
	PrintHighQuality = 0x1000L
}
