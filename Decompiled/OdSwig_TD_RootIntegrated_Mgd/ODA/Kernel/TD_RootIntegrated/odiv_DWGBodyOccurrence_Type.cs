using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum odiv_DWGBodyOccurrence_Type
{
	kUnchanged = 1,
	kAdd = 2,
	kDelete = 3,
	kUpdate = 4
}
