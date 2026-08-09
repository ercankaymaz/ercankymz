using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiMaterialTextureManager_ManageType
{
	kFileTexturesOnly = 0,
	kFileAndProceduralTextures = 1,
	kDisable = 2
}
