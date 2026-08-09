using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum odiv_ViewEnums_ERefAndNonRefTreatment
{
	kDefaultRefAndNonRefTreatment = 0,
	kRefAndNonRefSeparate = 0,
	kRefAndNonRefCombine = 1
}
