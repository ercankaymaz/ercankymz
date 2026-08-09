using System;

namespace Zen.Barcode;

[Flags]
public enum PdfRenderFlags
{
	UseAspectRatio = 0,
	FixedRectangle = 1,
	FixedColumns = 2,
	FixedRows = 4,
	AutoErrorLevel = 0,
	UseErrorLevel = 0x10,
	UseRawCodeWords = 0x40,
	InvertBitmap = 0x80
}
