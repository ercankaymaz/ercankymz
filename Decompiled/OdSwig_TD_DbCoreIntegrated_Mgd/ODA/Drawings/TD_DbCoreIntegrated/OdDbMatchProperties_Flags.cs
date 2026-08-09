using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbMatchProperties_Flags
{
	kColorFlag = 1,
	kLayerFlag = 2,
	kLtypeFlag = 4,
	kThicknessFlag = 8,
	kLtscaleFlag = 0x10,
	kTextFlag = 0x20,
	kDimensionFlag = 0x40,
	kHatchFlag = 0x80,
	kLweightFlag = 0x100,
	kPlotstylenameFlag = 0x200,
	kPolylineFlag = 0x400,
	kViewportFlag = 0x800,
	kTableFlag = 0x1000,
	kMaterialFlag = 0x2000,
	kShadowDisplayFlag = 0x4000,
	kMultileaderFlag = 0x8000,
	kTransparencyFlag = 0x10000,
	kSetAllFlagsOn = 0x1FFFF
}
