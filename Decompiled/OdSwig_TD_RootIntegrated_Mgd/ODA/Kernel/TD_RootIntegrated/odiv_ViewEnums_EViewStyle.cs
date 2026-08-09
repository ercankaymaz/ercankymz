using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum odiv_ViewEnums_EViewStyle
{
	kDefaultViewStyle = 0,
	kShadedHiddenLineDrawingViewStyle = 0,
	kHiddenLineDrawingViewStyle = 1,
	kHiddenLineRemovedDrawingViewStyle = 2,
	kShadedDrawingViewStyle = 3,
	kFromBaseDrawingViewStyle = 4,
	kVisibleLines = 0,
	kVisibleAndHiddenLines = 1,
	kShadedVisibleLines = 2,
	kShadedVisibleAndHiddenLines = 3
}
