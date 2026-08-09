using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsFilerExtension_Type
{
	kSubstitutor = 0,
	kArbitraryData = 1,
	kPointersRegistrator = 2,
	kStreamAccessor = 3,
	kIdSaver = 4,
	kLoadingReactor = 5,
	kNumExtensions = 6
}
