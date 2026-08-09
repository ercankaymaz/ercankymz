using System;

namespace PdfSharp.Pdf.Security;

[Flags]
internal enum PdfUserAccessPermission
{
	PermitAll = -3,
	PermitPrint = 4,
	PermitModifyDocument = 8,
	PermitExtractContent = 0x10,
	PermitAnnotations = 0x20,
	PermitFormsFill = 0x100,
	PermitAccessibilityExtractContent = 0x200,
	PermitAssembleDocument = 0x400,
	PermitFullQualityPrint = 0x800
}
