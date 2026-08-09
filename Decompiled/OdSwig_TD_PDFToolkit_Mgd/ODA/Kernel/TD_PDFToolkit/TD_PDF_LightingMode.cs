using System;

namespace ODA.Kernel.TD_PDFToolkit;

[Flags]
public enum TD_PDF_LightingMode
{
	kArtwork = 1,
	kNone = 2,
	kWhite = 3,
	kDay = 4,
	kBright = 5,
	kPrimaryColor = 6,
	kNight = 7,
	kBlue = 8,
	kRed = 9,
	kCube = 0xA,
	kCADOptimized = 0xB,
	kHeadlamp = 0xC
}
