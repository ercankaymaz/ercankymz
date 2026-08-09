using System;

namespace ODA.Kernel.TD_PdfExport;

[Flags]
public enum TD_PDF_2D_EXPORT_PDFExport2DParams_PDFExportFlags
{
	kZeroFlag = 0,
	kEmbededTTF = 1,
	kTTFTextAsGeometry = 2,
	kSHXTextAsGeometry = 4,
	kSimpleGeomOptimization = 8,
	kEnableLayers = 0x10,
	kIncludeOffLayers = 0x20,
	kEmbededOptimizedTTF = 0x40,
	kUseHLR = 0x80,
	kFlateCompression = 0x100,
	kASCIIHexEncoding = 0x200,
	kExportHyperlinks = 0x400,
	kZoomToExtentsMode = 0x800,
	kLinearized = 0x1000,
	kMergeLines = 0x2000,
	kMeasuring = 0x4000,
	kDefault = 0xB06
}
