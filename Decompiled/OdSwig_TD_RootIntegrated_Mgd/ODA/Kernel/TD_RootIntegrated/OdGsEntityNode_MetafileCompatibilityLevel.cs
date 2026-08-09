using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsEntityNode_MetafileCompatibilityLevel
{
	kSkipCheckCompatible = 0,
	kCheckViewChanges = 1,
	kCheckCompatibleView = 2,
	kFindCompatible = 3
}
