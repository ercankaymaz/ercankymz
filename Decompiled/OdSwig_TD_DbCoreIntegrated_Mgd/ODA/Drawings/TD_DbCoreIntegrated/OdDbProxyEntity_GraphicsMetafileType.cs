using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbProxyEntity_GraphicsMetafileType
{
	kNoMetafile = 0,
	kBoundingBox = 1,
	kFullGraphics = 2
}
