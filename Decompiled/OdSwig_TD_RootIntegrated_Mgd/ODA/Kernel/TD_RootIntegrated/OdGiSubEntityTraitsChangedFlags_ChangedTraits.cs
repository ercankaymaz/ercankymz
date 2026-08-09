using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiSubEntityTraitsChangedFlags_ChangedTraits
{
	kFirstChangedFlag = 1,
	kColorChanged = 1,
	kLayerChanged = 2,
	kLineTypeChanged = 4,
	kFillTypeChanged = 8,
	kLineWeightChanged = 0x10,
	kLineTypeScaleChanged = 0x20,
	kThicknessChanged = 0x40,
	kPlotStyleChanged = 0x80,
	kMaterialChanged = 0x100,
	kMapperChanged = 0x200,
	kVisualStyleChanged = 0x400,
	kTransparencyChanged = 0x800,
	kDrawFlagsChanged = 0x1000,
	kSelectionGeomChanged = 0x2000,
	kShadowFlagsChanged = 0x4000,
	kSectionableChanged = 0x8000,
	kSelectionFlagsChanged = 0x10000,
	kSecColorChanged = 0x20000,
	kLSModifiersChanged = 0x40000,
	kFillChanged = 0x80000,
	kAwareFlagChanged = 0x100000,
	kLockFlagsChanged = 0x200000,
	kAuxDataChanged = 0x400000,
	kAllChanged = 0x7FFFFF,
	kSomeChanged = 0x7FFFFF
}
