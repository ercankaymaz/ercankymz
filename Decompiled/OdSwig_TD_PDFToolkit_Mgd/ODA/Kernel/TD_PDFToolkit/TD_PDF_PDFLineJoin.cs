using System;

namespace ODA.Kernel.TD_PDFToolkit;

[Flags]
public enum TD_PDF_PDFLineJoin
{
	kLineJoinNotSet = -1,
	kMiterJoin = 0,
	kRoundJoin = 1,
	kBevelJoin = 2
}
