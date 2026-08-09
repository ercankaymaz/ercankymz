using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiBaseVectorizerImpl_VectorizingFlags
{
	kNotVectorizing = 0,
	kVectorizing = 1,
	kDisplaying = 2,
	kSelecting = 4,
	kExtentsComp = 8
}
