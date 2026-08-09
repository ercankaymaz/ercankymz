using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdDbBaseHostAppServices_FindFileHint
{
	kDefault = 0,
	kFontFile = 1,
	kCompiledShapeFile = 2,
	kTrueTypeFontFile = 3,
	kEmbeddedImageFile = 4,
	kXRefDrawing = 5,
	kPatternFile = 6,
	kTXApplication = 7,
	kFontMapFile = 8,
	kUnderlayFile = 9,
	kTextureMapFile = 0xA,
	kPhotometricWebFile = 0xB,
	kAssetLibXMLFile = 0xC,
	kTemplateFile = 0xD,
	kSchemaFile = 0xE
}
