using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbRasterImage_ClipBoundaryType
{
	kInvalid = 0,
	kRect = 1,
	kPoly = 2
}
