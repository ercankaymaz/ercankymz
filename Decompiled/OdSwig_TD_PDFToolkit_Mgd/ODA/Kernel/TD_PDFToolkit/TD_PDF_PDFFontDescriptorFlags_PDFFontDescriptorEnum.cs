using System;

namespace ODA.Kernel.TD_PDFToolkit;

[Flags]
public enum TD_PDF_PDFFontDescriptorFlags_PDFFontDescriptorEnum
{
	kFixedPitch = 1,
	kSerif = 2,
	kSymbolic = 3,
	kScript = 4,
	kNonsymbolic = 6,
	kItalic = 7,
	kAllCap = 0x11,
	kSmallCap = 0x12,
	kForceBold = 0x13
}
