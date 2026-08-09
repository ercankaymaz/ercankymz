using System;

namespace ODA.Kernel.TD_PDFToolkit;

[Flags]
public enum TD_PDF_PDFResult
{
	eOk = 0,
	eInternalError = 1,
	eEmptyInputArray = 2,
	eNotSortedArray = 3,
	eDuplicatedElement = 4,
	eNullDocument = 5,
	eKeyNotFound = 6,
	eNullBaseName = 7,
	eNotImplementedYet = 8,
	eCannotFillFontDescriptor = 9,
	eLastErrorNum = 0xFFFF
}
