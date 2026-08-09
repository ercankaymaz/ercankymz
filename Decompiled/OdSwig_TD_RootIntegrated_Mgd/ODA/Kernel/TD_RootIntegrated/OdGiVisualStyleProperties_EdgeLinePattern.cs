using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiVisualStyleProperties_EdgeLinePattern
{
	kSolid = 1,
	kDashedLine = 2,
	kDotted = 3,
	kShortDash = 4,
	kMediumDash = 5,
	kLongDash = 6,
	kDoubleShortDash = 7,
	kDoubleMediumDash = 8,
	kDoubleLongDash = 9,
	kMediumLongDash = 0xA,
	kSparseDot = 0xB
}
