using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiRasterImage_ImageSource
{
	kUndefinedSource = -1,
	kFromDwg = 0,
	kFromOleObject = 1,
	kFromRender = 2,
	kFromUnderlay = 0xA,
	kFromImageBGRA32 = 0xB,
	kFromPdfUnderlay = 1,
	kFromFile = 0
}
