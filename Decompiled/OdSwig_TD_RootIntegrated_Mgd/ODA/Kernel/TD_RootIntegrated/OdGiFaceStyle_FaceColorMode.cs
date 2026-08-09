using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiFaceStyle_FaceColorMode
{
	kNoColorMode = 0,
	kObjectColor = 1,
	kBackgroundColor = 2,
	kMono = 3,
	kTint = 4,
	kDesaturate = 5
}
