using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsFilerObjectId_ObjectType
{
	kUnknown = 0,
	kMetafile = 1,
	kMaterial = 2,
	kLayer = 3,
	kBlock = 4,
	kReference = 5,
	kRefLinker = 6,
	kVisualStyle = 7,
	kRasterImage = 8,
	kTtfCache = 9,
	kGroup = 0xA,
	kInternalLayer = 0xB,
	kInternalMf = 0xC,
	kInternalMatItem = 0xD,
	kRenderMf = 0xE,
	kRenderMaterial = 0xF,
	kRenderTexture = 0x10,
	kRenderVs = 0x11,
	kRenderGroup = 0x12,
	kRenderLayer = 0x13
}
