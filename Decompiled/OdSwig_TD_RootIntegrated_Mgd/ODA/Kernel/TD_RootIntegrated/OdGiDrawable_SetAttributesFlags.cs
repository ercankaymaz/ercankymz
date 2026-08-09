using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiDrawable_SetAttributesFlags
{
	kDrawableNone = 0,
	kDrawableIsAnEntity = 1,
	kDrawableUsesNesting = 2,
	kDrawableIsCompoundObject = 4,
	kDrawableViewIndependentViewportDraw = 8,
	kDrawableIsInvisible = 0x10,
	kDrawableHasAttributes = 0x20,
	kDrawableRegenTypeDependantGeometry = 0x40,
	kDrawableIsDimension = 0x85,
	kDrawableRegenDraw = 0x100,
	kDrawableStandardDisplaySingleLOD = 0x200,
	kDrawableShadedDisplaySingleLOD = 0x400,
	kDrawableViewDependentViewportDraw = 0x800,
	kDrawableBlockDependentViewportDraw = 0x1000,
	kDrawableIsExternalReference = 0x2000,
	kDrawableNotPlottable = 0x4000,
	kDrawableNotAllowLCS = 0x8000,
	kDrawableMergeControlOff = 0x10000,
	kLastFlag = 0x10000
}
