using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_PdfPublishResult
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
	exOdError = 0x20000,
	eLastErrorNum = 0xFFFF
}
