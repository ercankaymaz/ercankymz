using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiVariant_VariantType
{
	kUndefined = 0,
	kBoolean = 1,
	kInt = 2,
	kDouble = 3,
	kColor = 4,
	kString = 5,
	kTable = 6
}
