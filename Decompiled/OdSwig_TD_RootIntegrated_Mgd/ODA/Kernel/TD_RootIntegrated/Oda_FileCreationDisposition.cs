using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum Oda_FileCreationDisposition
{
	kCreateNew = 1,
	kCreateAlways = 2,
	kOpenExisting = 3,
	kOpenAlways = 4,
	kTruncateExisting = 5
}
