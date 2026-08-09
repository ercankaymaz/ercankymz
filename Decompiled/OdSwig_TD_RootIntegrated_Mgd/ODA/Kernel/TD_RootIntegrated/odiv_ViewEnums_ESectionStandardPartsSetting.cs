using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum odiv_ViewEnums_ESectionStandardPartsSetting
{
	kDefaultSectionStandardPartsSetting = 2,
	kAlwaysSectionStandardParts = 0,
	kNeverSectionStandardParts = 1,
	kObeyBrowserSettingsSectionStandardParts = 2
}
