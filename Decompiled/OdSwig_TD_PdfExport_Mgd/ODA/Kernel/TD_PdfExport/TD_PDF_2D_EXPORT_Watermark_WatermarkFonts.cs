using System;

namespace ODA.Kernel.TD_PdfExport;

[Flags]
public enum TD_PDF_2D_EXPORT_Watermark_WatermarkFonts
{
	kTimesRoman = 0,
	kHelvetica = 1,
	kCourier = 2,
	kSymbol = 3,
	kTimesBold = 4,
	kHelveticaBold = 5,
	kCourierBold = 6,
	kZapfDingbats = 7,
	kTimesItalic = 8,
	kHelveticaOblique = 9,
	kCourierOblique = 0xA,
	kTimesBoldItalic = 0xB,
	kHelveticaBoldOblique = 0xC,
	kCourierBoldOblique = 0xD,
	kSystemTTFFont = -1
}
