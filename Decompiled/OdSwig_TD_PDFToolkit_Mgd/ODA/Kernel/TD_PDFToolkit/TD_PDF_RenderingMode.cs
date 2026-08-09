using System;

namespace ODA.Kernel.TD_PDFToolkit;

[Flags]
public enum TD_PDF_RenderingMode
{
	kSolid = 1,
	kSolidWireframe = 2,
	kSolidOutline = 3,
	kBoundingBox = 4,
	kTransparent = 5,
	kTransparentWireframe = 6,
	kTransparentBoundingBox = 7,
	kTransparentBoundingBoxOutline = 8,
	kIllustration = 9,
	kShadedIllustration = 0xA,
	kWireframe = 0xB,
	kShadedWireframe = 0xC,
	kHiddenWireframe = 0xD,
	kVertices = 0xE,
	kShadedVertices = 0xF
}
