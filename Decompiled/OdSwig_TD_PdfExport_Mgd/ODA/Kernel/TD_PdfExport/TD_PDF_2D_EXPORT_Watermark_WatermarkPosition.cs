using System;

namespace ODA.Kernel.TD_PdfExport;

[Flags]
public enum TD_PDF_2D_EXPORT_Watermark_WatermarkPosition
{
	kLeftToRight = 0,
	kUpperLeftToLowerRight = 1,
	kLowerLeftToUpperRight = 2,
	kUpperLeft = 3,
	kUpperRight = 4,
	kLowerRight = 5,
	kLowerLeft = 6,
	kUpperMiddle = 7,
	kLowerMiddle = 8,
	kLeftMiddle = 9,
	kRightMiddle = 0xA
}
