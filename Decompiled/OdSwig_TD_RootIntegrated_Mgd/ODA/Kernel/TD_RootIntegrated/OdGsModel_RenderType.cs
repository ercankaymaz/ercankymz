using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsModel_RenderType
{
	kMinRenderType = -3,
	kUserBg1 = -3,
	kUserBg2 = -2,
	kUserBg3 = -1,
	kMain = 0,
	kSprite = 1,
	kDirect = 2,
	kHighlight = 3,
	kHighlightSelection = 4,
	kDirectTopmost = 5,
	kContrast = 6,
	kCount = 7,
	kUserFg1 = 7,
	kUserFg2 = 8,
	kUserFg3 = 9,
	kMaxRenderType = 0xA,
	kNumRenderTypes = 0xD
}
