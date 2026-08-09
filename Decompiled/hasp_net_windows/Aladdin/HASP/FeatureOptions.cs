using System;

namespace Aladdin.HASP;

[Serializable]
[Flags]
public enum FeatureOptions
{
	Default = 0,
	NotLocal = 0x8000,
	NotRemote = 0x4000,
	Process = 0x2000,
	Classic = 0x1000,
	IgnoreTS = 0x800
}
