using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdDb_SubentType
{
	kNullSubentType = 0,
	kFaceSubentType = 1,
	kEdgeSubentType = 2,
	kVertexSubentType = 3,
	kMlineSubentCache = 4,
	kClassSubentType = 5,
	kAxisSubentType = 6
}
