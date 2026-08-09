using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsStateBranch_BranchType
{
	kHighlightingBranch = 0,
	kVisibilityBranch = 1,
	kTransformationBranch = 2,
	kNumBranchTypes = 3
}
