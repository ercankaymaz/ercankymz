using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiVisualStyleOperations_Operation
{
	kInvalidOperation = -1,
	kInherit = 0,
	kSet = 1,
	kDisable = 2,
	kEnable = 3
}
