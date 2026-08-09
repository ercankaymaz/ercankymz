using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiVisualStyle_Type
{
	kFlat = 0,
	kFlatWithEdges = 1,
	kGouraud = 2,
	kGouraudWithEdges = 3,
	k2DWireframe = 4,
	k3DWireframe = 5,
	kHidden = 6,
	kBasic = 7,
	kRealistic = 8,
	kConceptual = 9,
	kCustom = 0xA,
	kDim = 0xB,
	kBrighten = 0xC,
	kThicken = 0xD,
	kLinePattern = 0xE,
	kFacePattern = 0xF,
	kColorChange = 0x10,
	kFaceOnly = 0x11,
	kEdgeOnly = 0x12,
	kDisplayOnly = 0x13,
	kJitterOff = 0x14,
	kOverhangOff = 0x15,
	kEdgeColorOff = 0x16,
	kShadesOfGray = 0x17,
	kSketchy = 0x18,
	kXRay = 0x19,
	kShadedWithEdges = 0x1A,
	kShaded = 0x1B,
	kByViewport = 0x1C,
	kByLayer = 0x1D,
	kByBlock = 0x1E,
	kEmptyStyle = 0x1F
}
