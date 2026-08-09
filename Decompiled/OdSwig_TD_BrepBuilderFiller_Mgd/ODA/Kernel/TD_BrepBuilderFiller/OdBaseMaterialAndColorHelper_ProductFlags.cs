using System;

namespace ODA.Kernel.TD_BrepBuilderFiller;

[Flags]
public enum OdBaseMaterialAndColorHelper_ProductFlags
{
	fFaceHasColor = 1,
	fFaceHasMaterialMapping = 2,
	fEdgeHasColor = 4,
	fNoVisual = 0,
	fFaceColorAndMappingEdgeColor = 7
}
