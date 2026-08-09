using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsBaseMaterialVectorizer_ExtentsContainer_Flags
{
	kExtentsValid = 1,
	kExtentsAwaitingCalc = 2,
	kLastFlag = 2
}
