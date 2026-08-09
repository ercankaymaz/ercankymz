using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OverrulingType
{
	kDrawableOverrule = 0,
	kObjectOverrule = 1,
	kPropertiesOverrule = 2,
	kGeometryOverrule = 3,
	kHighlightOverrule = 4,
	kSubentityOverrule = 5,
	kGripOverrule = 6,
	kTransformOverrule = 7,
	kOsnapOverrule = 8,
	kVisibilityOverrule = 9,
	kTotalOverrules = 0xA
}
