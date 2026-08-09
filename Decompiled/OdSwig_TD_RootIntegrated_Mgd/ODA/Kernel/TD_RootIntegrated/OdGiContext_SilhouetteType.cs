using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiContext_SilhouetteType
{
	kNoSilhouettes = 0,
	kMeshSilhouettes = 1,
	kModelerSilhouettes = 2,
	kAllSilhouettes = 3
}
