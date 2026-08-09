using System;

namespace PdfSharp.Drawing.Pdf;

[Flags]
internal enum DirtyFlags
{
	Ctm = 1,
	ClipPath = 2,
	LineWidth = 0x10,
	LineJoin = 0x20,
	MiterLimit = 0x40,
	StrokeFill = 0x70
}
