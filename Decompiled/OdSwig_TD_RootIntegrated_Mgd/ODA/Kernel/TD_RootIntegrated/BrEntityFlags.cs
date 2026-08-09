using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum BrEntityFlags
{
	kNoFlags = 0,
	kDoubleSide = 1,
	kVisible = 2,
	kInvisible = 4,
	kHighlight = 8,
	kSelectionIgnore = 0x10,
	kBimRvEdgeSwapFaces = 0x1000000,
	kBimRvEdgeJoint = 0x2000000
}
