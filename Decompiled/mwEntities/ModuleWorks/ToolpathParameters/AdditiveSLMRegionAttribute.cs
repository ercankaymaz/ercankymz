using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum AdditiveSLMRegionAttribute
{
	Any,
	Volume,
	DownSkin,
	UpSkin,
	UpSkinRemelting,
	UpSkinRecoating,
	Support,
	LastType
}
