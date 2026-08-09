using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdEd_GetFilePathFlags
{
	kGfpForOpen = 0,
	kGfpForSave = 1,
	kGfpOverwritePrompt = 2
}
