using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdTf_ConditionOperatorsEnum
{
	kTrue = 1,
	kFalse = 2,
	kNot = 4,
	kAnd = 8,
	kLessThan = 0x10,
	kGreaterThan = 0x20
}
