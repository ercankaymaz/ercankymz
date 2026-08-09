using System;

namespace PdfSharp.Drawing;

[Flags]
internal enum InternalGraphicsMode
{
	DrawingGdiGraphics = 0,
	DrawingPdfContent = 1,
	DrawingBitmap = 2
}
