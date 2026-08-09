using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsBaseMaterialVectorizer_MaterialViewFlags
{
	kProcessMappers = 1,
	kProcessMaterials = 2,
	kProcessMappersAndMaterials = 3,
	kMappersForRender = 4,
	kMaterialsForRender = 8,
	kMappersAndMaterialsForRender = 0xC,
	kProcessForRender = 0xF,
	kEnableDelayCache = 0x10
}
