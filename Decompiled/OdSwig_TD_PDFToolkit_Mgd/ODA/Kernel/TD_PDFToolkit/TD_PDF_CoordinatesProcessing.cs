using System;

namespace ODA.Kernel.TD_PDFToolkit;

[Flags]
public enum TD_PDF_CoordinatesProcessing
{
	kCastToInt = 0,
	kProcessAsDouble = 1,
	kRoundTo720DPI = 2
}
