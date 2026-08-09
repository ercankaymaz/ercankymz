using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiSubEntityTraits_DrawFlags
{
	kNoDrawFlags = 0,
	kDrawBackfaces = 1,
	kDrawHatchGroup = 2,
	kDrawFrontfacesOnly = 4,
	kDrawGradientFill = 8,
	kDrawSolidFill = 0x10,
	kDrawNoLineWeight = 0x20,
	kDrawNoPlotstyle = 0x80,
	kDrawContourFill = 0x8000,
	kDisableLayoutCache = 0x10000,
	kDrawBoundaryForClipping = 0x20000,
	kDrawBoundaryForClippingDrw = 0x40000,
	kClipSetIsEmpty = 0x80000,
	kDrawPolygonFill = 0x100000,
	kExcludeFromViewExt = 0x200000,
	kDrawDgLsPolyWithoutBreaks = 0x400000,
	kPolygonProcessing = 0x800000,
	kDisableAutoGenerateNormals = 0x1000000,
	kDisableFillModeCheck = 0x2000000,
	kDrawUnderlayReference = 0x4000000,
	kLineStyleScaleOverride = 0x8000000,
	kDisableDisplayClipping = 0x10000000,
	kRegenTypeDependent2dDraw = 0x20000000,
	kInternalDrawFlags = 0x20090000,
	kInheritableDrawFlags = 0x302F00A5
}
