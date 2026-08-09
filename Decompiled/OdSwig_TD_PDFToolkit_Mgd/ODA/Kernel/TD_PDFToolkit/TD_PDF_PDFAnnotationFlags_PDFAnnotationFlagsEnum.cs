using System;

namespace ODA.Kernel.TD_PDFToolkit;

[Flags]
public enum TD_PDF_PDFAnnotationFlags_PDFAnnotationFlagsEnum
{
	kInvisible = 1,
	kHidden = 2,
	kPrint = 3,
	kNoZoom = 4,
	kNoRotate = 5,
	kNoView = 6,
	kReadOnly = 7,
	kLocked = 8,
	kToggleNoView = 9,
	kLockedContents = 0xA
}
