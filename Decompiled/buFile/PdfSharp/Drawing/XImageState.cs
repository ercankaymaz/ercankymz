using System;

namespace PdfSharp.Drawing;

[Flags]
internal enum XImageState
{
	UsedInDrawingContext = 1,
	StateMask = 0xFFFF
}
