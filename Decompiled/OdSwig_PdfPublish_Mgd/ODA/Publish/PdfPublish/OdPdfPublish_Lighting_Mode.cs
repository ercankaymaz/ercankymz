using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_Lighting_Mode
{
	kDefault = 0,
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
