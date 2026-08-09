using System;

namespace PdfSharp.Pdf;

[Flags]
internal enum DocumentState
{
	Created = 1,
	Imported = 2,
	Disposed = 0x8000
}
