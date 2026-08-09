using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsBaseVectorizer_MetafileTransformFlags
{
	kSharedRefTransform = 1,
	kSharedRefUpdate = 2,
	kSharedRefSelect = 4
}
