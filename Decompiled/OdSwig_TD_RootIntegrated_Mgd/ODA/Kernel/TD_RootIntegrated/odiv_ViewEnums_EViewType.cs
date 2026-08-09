using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum odiv_ViewEnums_EViewType
{
	kDefaultViewType = 0,
	kBaseViewType = 0,
	kUnkViewType = 1,
	kDetailViewType = 2,
	kSectionViewType = 3,
	kProjectedViewType = 4
}
