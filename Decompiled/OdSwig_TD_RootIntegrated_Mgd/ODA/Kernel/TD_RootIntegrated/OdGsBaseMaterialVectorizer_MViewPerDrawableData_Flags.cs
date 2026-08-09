using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsBaseMaterialVectorizer_MViewPerDrawableData_Flags
{
	kMapperNeedExtents = 4,
	kBaseLevel = 8,
	kHasModelTransform = 0x10,
	kIsEntity = 0x20
}
