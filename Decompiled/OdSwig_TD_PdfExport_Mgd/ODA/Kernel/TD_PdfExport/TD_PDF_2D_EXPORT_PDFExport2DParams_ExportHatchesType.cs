using System;

namespace ODA.Kernel.TD_PdfExport;

[Flags]
public enum TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType
{
	kBitmap = 0,
	kDrawing = 1,
	kPdfPaths = 2,
	kPolygons = 3
}
