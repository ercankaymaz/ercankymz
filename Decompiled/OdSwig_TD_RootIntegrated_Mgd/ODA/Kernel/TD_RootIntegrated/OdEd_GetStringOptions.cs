using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdEd_GetStringOptions
{
	kGstDefault = 0,
	kGstNoSpaces = 0,
	kGstAllowSpaces = 1,
	kGstNoEmpty = 2
}
