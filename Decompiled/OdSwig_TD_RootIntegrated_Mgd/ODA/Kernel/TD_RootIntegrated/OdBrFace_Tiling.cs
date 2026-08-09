using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdBrFace_Tiling
{
	kInheritTiling = 0,
	kTile = 1,
	kCrop = 2,
	kClamp = 3,
	kMirror = 4
}
