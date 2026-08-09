using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsOverlayMapping_OverlayTypeDefs
{
	kMainDepth = 0,
	kNoDepth = 1,
	kOwnDepth = 2,
	kNoFrameBuf = 4,
	kHltStyle = 8,
	kContrastStyle = 0x10
}
