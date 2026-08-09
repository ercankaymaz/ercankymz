using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiOrthoClipperEx_CountsClassify
{
	kCCDontClassify = 0,
	kCCClassifiedByInclusion = 1,
	kCCClassifiedByInteger = 2,
	kCCClassifiedByOrder = 3,
	kCCClassifiedByNormal = 4,
	kCCClassifiedByXor = 5,
	kCCClassifiedBySignedXor = 6
}
