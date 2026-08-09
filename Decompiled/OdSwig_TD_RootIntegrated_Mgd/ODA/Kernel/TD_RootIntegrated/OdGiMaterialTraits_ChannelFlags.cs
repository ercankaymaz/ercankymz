using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiMaterialTraits_ChannelFlags
{
	kNone = 0,
	kUseDiffuse = 1,
	kUseSpecular = 2,
	kUseReflection = 4,
	kUseOpacity = 8,
	kUseBump = 0x10,
	kUseRefraction = 0x20,
	kUseNormalMap = 0x40,
	kUseEmission = 0x80,
	kUseTint = 0x100,
	kUseRoughness = 0x200,
	kUseCutouts = 0x400,
	kUseAll = 0x7F,
	kUseAllInternal = 0x7FF
}
