using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum PdfConversionFlags
{
	kAnnotations = 1,
	kLCDText = 2,
	kNoNativeText = 4,
	kGrayScale = 8,
	kReverseByteOrder = 0x10,
	kDebugInfo = 0x80,
	kNoCatch = 0x100,
	kLimitImageCache = 0x200,
	kForceHalfTone = 0x400,
	kPrinting = 0x800,
	kDisableAAforText = 0x1000,
	kDisableAAforImage = 0x2000,
	kDisableAAforGeom = 0x4000
}
