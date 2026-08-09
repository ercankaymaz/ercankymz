using System;

namespace ODA.Kernel.TD_PdfExport;

[Flags]
public enum TD_PDF_2D_EXPORT_PDFExportDocumentParams_PDFAccessPermissionsFlags
{
	kAllowExtract = 1,
	kAllowAssemble = 2,
	kAllowAnnotateAndForm = 4,
	kAllowFormFilling = 8,
	kAllowModifyOther = 0x10,
	kAllowPrintAll = 0x20,
	kAllowPrintLow = 0x40,
	kDefaultPermissions = 0x29
}
